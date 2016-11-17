using System;

namespace DataHarmonizationProcessor.Business.Services
{
    public class TimeSpanUtil : ITimeSpanUtil
    {
        #region To days

        public double ConvertMillisecondsToDays(double milliseconds)
        {
            return TimeSpan.FromMilliseconds(milliseconds).TotalDays;
        }

        public double ConvertSecondsToDays(double seconds)
        {
            return TimeSpan.FromSeconds(seconds).TotalDays;
        }

        public double ConvertMinutesToDays(double minutes)
        {
            return TimeSpan.FromMinutes(minutes).TotalDays;
        }

        public double ConvertHoursToDays(double hours)
        {
            return TimeSpan.FromHours(hours).TotalDays;
        }

        #endregion To days

        #region To hours

        public double ConvertMillisecondsToHours(double milliseconds)
        {
            return TimeSpan.FromMilliseconds(milliseconds).TotalHours;
        }

        public double ConvertSecondsToHours(double seconds)
        {
            return TimeSpan.FromSeconds(seconds).TotalHours;
        }

        public double ConvertMinutesToHours(double minutes)
        {
            return TimeSpan.FromMinutes(minutes).TotalHours;
        }

        public double ConvertDaysToHours(double days)
        {
            return TimeSpan.FromHours(days).TotalHours;
        }

        #endregion To hours

        #region To minutes

        public double ConvertMillisecondsToMinutes(double milliseconds)
        {
            return TimeSpan.FromMilliseconds(milliseconds).TotalMinutes;
        }

        public double ConvertSecondsToMinutes(double seconds)
        {
            return TimeSpan.FromSeconds(seconds).TotalMinutes;
        }

        public double ConvertHoursToMinutes(double hours)
        {
            return TimeSpan.FromHours(hours).TotalMinutes;
        }

        public double ConvertDaysToMinutes(double days)
        {
            return TimeSpan.FromDays(days).TotalMinutes;
        }

        #endregion To minutes

        #region To seconds

        public double ConvertMillisecondsToSeconds(double milliseconds)
        {
            return TimeSpan.FromMilliseconds(milliseconds).TotalSeconds;
        }

        public double ConvertMinutesToSeconds(double minutes)
        {
            return TimeSpan.FromMinutes(minutes).TotalSeconds;
        }

        public double ConvertHoursToSeconds(double hours)
        {
            return TimeSpan.FromHours(hours).TotalSeconds;
        }

        public double ConvertDaysToSeconds(double days)
        {
            return TimeSpan.FromDays(days).TotalSeconds;
        }

        #endregion To seconds

        #region To milliseconds

        public double ConvertSecondsToMilliseconds(double seconds)
        {
            return TimeSpan.FromSeconds(seconds).TotalMilliseconds;
        }

        public double ConvertMinutesToMilliseconds(double minutes)
        {
            return TimeSpan.FromMinutes(minutes).TotalMilliseconds;
        }

        public double ConvertHoursToMilliseconds(double hours)
        {
            return TimeSpan.FromHours(hours).TotalMilliseconds;
        }

        public double ConvertDaysToMilliseconds(double days)
        {
            return TimeSpan.FromDays(days).TotalMilliseconds;
        }

        #endregion To milliseconds
    }
}