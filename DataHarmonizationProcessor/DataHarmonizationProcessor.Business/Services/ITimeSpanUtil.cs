namespace DataHarmonizationProcessor.Business.Services
{
    public interface ITimeSpanUtil
    {
        double ConvertMillisecondsToDays(double milliseconds);
        double ConvertSecondsToDays(double seconds);
        double ConvertMinutesToDays(double minutes);
        double ConvertHoursToDays(double hours);
        double ConvertMillisecondsToHours(double milliseconds);
        double ConvertSecondsToHours(double seconds);
        double ConvertMinutesToHours(double minutes);
        double ConvertDaysToHours(double days);
        double ConvertMillisecondsToMinutes(double milliseconds);
        double ConvertSecondsToMinutes(double seconds);
        double ConvertHoursToMinutes(double hours);
        double ConvertDaysToMinutes(double days);
        double ConvertMillisecondsToSeconds(double milliseconds);
        double ConvertMinutesToSeconds(double minutes);
        double ConvertHoursToSeconds(double hours);
        double ConvertDaysToSeconds(double days);
        double ConvertSecondsToMilliseconds(double seconds);
        double ConvertMinutesToMilliseconds(double minutes);
        double ConvertHoursToMilliseconds(double hours);
        double ConvertDaysToMilliseconds(double days);
    }
}