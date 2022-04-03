using System;

namespace EnsekTechincalTest.Services
{
    public interface IMeterReadingValidate
    {
        bool Validate(int AccountId, string MeterReading, DateTime MeterReadingDate);
    }
}