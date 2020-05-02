using QaR.Finder.Application.Common.Interfaces;
using System;

namespace QaR.Finder.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
