using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyral.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Convert the <c>DateTime</c> into a pretty and more readable version, such as "8 minutes ago"
        /// </summary>
        public static string GetPrettyDate(this DateTime d)
        {
            string stringy = string.Empty;
            TimeSpan diff = DateTime.Now.Subtract(d);
            double days = diff.Days;
            double hours = diff.Hours + days * 24;
            double minutes = diff.Minutes + hours * 60;
            if (minutes <= 1)
            {
                return "Just Now";
            }
            double years = Math.Floor(diff.TotalDays / 365);
            if (years >= 1)
            {
                return string.Format("{0} year{1} ago", years, years >= 2 ? "s" : null);
            }
            double months = Math.Floor(diff.TotalDays / 31);
            double weeks = Math.Floor(diff.TotalDays / 7);
            if (months >= 1)
            {
                int partOfMonth = (int)(weeks - months * 4.34812);
                if (partOfMonth > 0)
                {
                    stringy = string.Format(", {0} week{1}", partOfMonth, partOfMonth > 1 ? "s" : null);
                }
                return string.Format("{0} month{1}{2} ago", months, months >= 2 ? "s" : null, stringy);
            }
            if (weeks >= 1)
            {
                double partOfWeek = days - weeks * 7;
                if (partOfWeek > 0)
                {
                    stringy = string.Format(", {0} day{1}", partOfWeek, partOfWeek > 1 ? "s" : null);
                }
                return string.Format("{0} week{1}{2} ago", weeks, weeks >= 2 ? "s" : null, stringy);
            }
            if (days >= 1)
            {
                double partOfDay = hours - days * 24;
                if (partOfDay > 0)
                {
                    stringy = string.Format(", {0} hour{1}", partOfDay, partOfDay > 1 ? "s" : null);
                }
                return string.Format("{0} day{1}{2} ago", days, days >= 2 ? "s" : null, stringy);
            }
            if (hours >= 1)
            {
                double partOfHour = minutes - hours * 60;
                if (partOfHour > 0)
                {
                    stringy = string.Format(", {0} minute{1}", partOfHour, partOfHour > 1 ? "s" : null);
                }
                return string.Format("{0} hour{1}{2} ago", hours, hours >= 2 ? "s" : null, stringy);
            }

            // Only condition left is minutes > 1
            return string.Format("{0} minutes ago", minutes);
        }

        /// <summary>
        /// Indicates whether the specified date is on a weekend (Ex: Saturday or Sunday).
        /// </summary>
        public static bool IsWeekend(this DateTime date)
        {
            return date.DayOfWeek.EqualsAny(DayOfWeek.Saturday, DayOfWeek.Sunday);
        }

        /// <summary>
        /// Adds the specified amount of weeks (7 days) to the <c>DateTime</c> value.
        /// </summary>
        public static DateTime AddWeeks(this DateTime date, int value)
        {
            return date.AddDays(value * 7);
        }
    }
}
