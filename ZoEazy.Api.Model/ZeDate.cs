using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZoEazy.Api.Model
{
    [ComplexType]
    public class ZeDate
    {
        public ZeDate()
        {
            var d = DateTime.Now;
            Year = d.Year;
            Month = d.Month;
            Day = d.Day;
        }

        public ZeDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public bool Valid() {
            var toTest = Year.ToString() + "/" + Month.ToString() + '/' + Day.ToString();
            bool valid = false;
            DateTime testDate;
            DateTime minDateTime = DateTime.MaxValue;
            DateTime maxDateTime = DateTime.MinValue;

            if (DateTime.TryParse(toTest, out testDate))
            {
                if (testDate >= minDateTime && testDate <= maxDateTime)
                {
                    valid = true;
                }
            }

            return valid;
        }
    }
}
