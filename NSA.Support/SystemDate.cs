using System;

namespace NSA.Support
{
    public static class SystemDate
    {
        private static readonly DefaultDateTimeProvider defaultProvider = new DefaultDateTimeProvider();
        private static IDateTimeProvider dateTimeProvider = defaultProvider;

        public static void SetDateTimeProvider(IDateTimeProvider provider)
        {
            dateTimeProvider = provider;
        }

        public static void UseDefault()
        {
            dateTimeProvider = defaultProvider;
        }

        public static DateTime Now { get { return dateTimeProvider.Now; } }

        public static DateTime Today { get { return dateTimeProvider.Today; } }
    }
}