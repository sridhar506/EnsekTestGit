using EnsekEntities;
using EnsekTechincalTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EnsekTechincalTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Meter_Reading_UploadsController : ControllerBase
    {
        private readonly ILogger<Meter_Reading_UploadsController> _logger;

        private readonly EnsekDBContext _context;

        public Meter_Reading_UploadsController(ILogger<Meter_Reading_UploadsController> logger, EnsekDBContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet]
        public async Task Get()
        {
        }

        [HttpPost]
        public MeterReadingResponse Post(IFormFile file)
        //public MeterReadingResponse Post()
        {
            //var httpPostedFile = HttpContext.Request.Form.Files["UploadCSV"];
            MeterReadingResponse returnValue = new MeterReadingResponse();

            if (file.FileName.ToLower().EndsWith(".csv"))
            {
                var SuccessfulReadings = new List<Status>();
                var FailedReadings = new List<Status>();
                var InvalidData = new List<string>();
                var readings = new List<MeterReadings>();
                int lineNo = 1;
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    while (reader.Peek() >= 0)
                    {
                        var line = reader.ReadLine();
                        if (!line.ToLower().Contains("accountid"))
                        {
                            string[] values = line.Split(',');
                            if (values.Length >= 3)
                            {
                                var value = new MeterReadings();
                                try
                                {
                                    if (values[0].Length > 0 && values[1].Length >= 16 && values[2].Length > 0 && values[2].Length <= 5 && IsValidMeterValue(values[2]))
                                    {
                                        value.Id = lineNo++;
                                        value.AccountId = Convert.ToInt32(values[0]);
                                        value.MeterReadingDateTime = Convert.ToDateTime(values[1]);
                                        value.MeterReadValue = values[2];
                                        readings.Add(value);
                                    }
                                    else
                                    {
                                        InvalidData.Add(line);
                                        returnValue.FailedReadingsCount++;
                                    }
                                }
                                catch
                                {
                                    InvalidData.Add(line);
                                    returnValue.FailedReadingsCount++;
                                }
                            }
                            else
                            {
                                InvalidData.Add(line);
                                returnValue.FailedReadingsCount++;
                            }
                        }
                    }
                }
                MeterReadingValidate mValidate = new MeterReadingValidate(_context);
                foreach (var reading in readings)
                {
                    var processedReading = new Status()
                    {
                        AccountId = reading.AccountId,
                        MeterReading = reading.MeterReadValue,
                        MeterReadingDate = reading.MeterReadingDateTime
                    };
                    if (mValidate.Validate(reading.AccountId, reading.MeterReadValue, reading.MeterReadingDateTime))
                    {
                        SuccessfulReadings.Add(processedReading);
                        returnValue.SuccessfulReadingsCount++;
                    }
                    else
                    {
                        FailedReadings.Add(processedReading);
                        returnValue.FailedReadingsCount++;

                    }
                }
                returnValue.Result = true;
                returnValue.FailedReadings = FailedReadings;
                returnValue.SuccessfulReadings = SuccessfulReadings;
                returnValue.InvalidData = InvalidData;
            }
            else
            {
                returnValue.Message = "Invalid file, Please upload the meterreading csv file";
            }
            return returnValue;
        }

        public bool IsValidMeterValue(string val)
        {
            var result = false;
            try
            {
                if (Convert.ToInt32(val) < 100000 && Convert.ToInt32(val) > 0)
                {
                    result = true;
                }
            }
            catch { }
            return result;
        }

        public class MeterReadingResponse
        {
            public int SuccessfulReadingsCount { get; set; } = 0;
            public int FailedReadingsCount { get; set; } = 0;
            public IEnumerable<Status> SuccessfulReadings { get; set; }
            public IEnumerable<Status> FailedReadings { get; set; }
            public IEnumerable<string> InvalidData { get; set; }
            public bool Result { get; set; } = false;
            public string Message { get; set; } = "";
        }
        public class Status
        {
            public int AccountId { get; set; }
            public string MeterReading { get; set; }
            public DateTime MeterReadingDate { get; set; }
        }
    }
}
