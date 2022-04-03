using EnsekEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnsekTechincalTest.Services
{
    public class MeterReadingValidate : IMeterReadingValidate
    {
        EnsekDBContext _context;
        public MeterReadingValidate(EnsekDBContext context)
        {
            _context = context;
        }

        public bool Validate(int AccountId, string MeterReading, DateTime MeterReadingDate)
        {
            var result = false;
            try
            {
                var account = _context.Accounts.Where(x => x.AccountId == AccountId)
                    .FirstOrDefault();
                if (account != null)
                {
                    var reading = _context.MeterReadings.Where(x => x.AccountId == AccountId && x.MeterReadingDateTime >= MeterReadingDate).FirstOrDefault();

                    if (reading == null)
                    {
                        var newReading = new MeterReadings()
                        {
                            AccountId = AccountId,
                            MeterReadValue = MeterReading.ToString().PadLeft(5, '0'),
                            MeterReadingDateTime = MeterReadingDate
                        };
                        _context.MeterReadings.Add(newReading);
                        _context.SaveChanges();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }
    }
}
