using System;

namespace NSA.Support
{
    public class DefaultDateTimeProvider : IDateTimeProvider
    {
        public DateTime Now
        {
            get { return DateTime.UtcNow; }
        }

        public DateTime Today
        {
            get { return DateTime.UtcNow.Date; }
        }
    }
}