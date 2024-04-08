using System;
using System.ComponentModel.DataAnnotations;

namespace Lab101.Models
{
    public class NonWeekendDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateTime)
            {
                return dateTime.DayOfWeek != DayOfWeek.Saturday && dateTime.DayOfWeek != DayOfWeek.Sunday;
            }
            return false;
        }
    }
}
