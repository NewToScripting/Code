using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inspire
{
    /// <summary>
    /// Helper class for dates
    /// </summary>
    public class DateHelper
    {
        //the list of months in a year
        public static readonly string[] Months = new string[]
        {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "Novemeber",
            "December"
        };

        /// <summary>
        /// Gets the day of week for a specific date
        /// </summary>
        /// <param name="year">The year of the date</param>
        /// <param name="month">The month of the date</param>
        /// <param name="day">The day of the date</param>
        /// <returns>Returns the day of week</returns>
        public static DayOfWeek GetDayOfWeek(int year, int month, int day)
        {
            return new DateTime(year, month, day).DayOfWeek;
        }

        /// <summary>
        /// Gets a string that represents the string for the current month
        /// </summary>
        /// <param name="month">a number from 1 to 12</param>
        /// <returns>Returns the string that represents the month</returns>
        /// <exception cref="ArgumentException">Thrown if the month number is less than 1 or greater than 12</exception>
        public static string GetMonthDisplayName(int month)
        {
            if (month < 1 || month > 12)
                throw new ArgumentException("INVALID_MONTH_NUMBER", "month");

            return Months[month - 1];
        }

        /// <summary>
        /// Moves one month forward
        /// </summary>
        /// <param name="currentMonth">The current month</param>
        /// <param name="currentYear">The current year</param>
        /// <param name="monthToGetNext">The next month</param>
        /// <param name="yearTogetNext">The relative year for the new month</param>
        public static void MoveMonthForward(int currentMonth, int currentYear,
            out int monthToGetNext, out int yearTogetNext)
        {
            monthToGetNext = currentMonth;
            yearTogetNext = currentYear;
            if (monthToGetNext < 12)
                monthToGetNext++;
            else//move a year forward
            {
                yearTogetNext++;
                monthToGetNext = 1;
            }
        }
        /// <summary>
        /// Move one month back
        /// </summary>
        /// <param name="currentMonth">The current month</param>
        /// <param name="currentYear">The current year</param>
        /// <param name="monthToGetPrevious">The previous month</param>
        /// <param name="yearToGetPrevious">The relative year for the new month</param>
        public static void MoveMonthBack(int currentMonth, int currentYear,
            out int monthToGetPrevious, out int yearToGetPrevious)
        {
            monthToGetPrevious = currentMonth;
            yearToGetPrevious = currentYear;
            if (monthToGetPrevious > 1)
                monthToGetPrevious--;
            else // move one year down
            {
                yearToGetPrevious--;
                monthToGetPrevious = 12;
            }
        }

    }

    /// <summary>
    /// Enum that specifies the list of months
    /// </summary>
    public enum Months
    {
        /// <summary>
        /// January 
        /// </summary>
        January = 1,
        /// <summary>
        /// February
        /// </summary>
        February = 2,
        /// <summary>
        /// March
        /// </summary>
        March = 3,
        /// <summary>
        /// April
        /// </summary>
        April = 4,
        /// <summary>
        /// May
        /// </summary>
        May = 5,
        /// <summary>
        /// June
        /// </summary>
        June = 6,
        /// <summary>
        /// July
        /// </summary>
        July = 7,
        /// <summary>
        /// August
        /// </summary>
        August = 8,
        /// <summary>
        /// September
        /// </summary>
        September = 9,
        /// <summary>
        /// October
        /// </summary>
        October = 10,
        /// <summary>
        /// November
        /// </summary>
        November = 11,
        /// <summary>
        /// December
        /// </summary>
        December = 12
    }
}
