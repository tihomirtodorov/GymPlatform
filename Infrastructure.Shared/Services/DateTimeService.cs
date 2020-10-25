using System;
using System.Collections.Generic;
using System.Text;
using Application.Interfaces;

namespace Infrastructure.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
