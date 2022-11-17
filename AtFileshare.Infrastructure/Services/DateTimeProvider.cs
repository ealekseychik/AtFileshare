namespace AtFileshare.Infrastructure.Services
{
    using AtFileshare.Application.Common.Interfaces.Services;
    using System;

    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
