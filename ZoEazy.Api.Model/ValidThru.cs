//using System.Data.Entity.Spatial;

using System;
using System.ComponentModel.DataAnnotations;

namespace ZoEazy.Api.Model
{
    public class ValidThru
    {
        public Month Month { get; set; }

        [Range(typeof(short), "2000", "2050")]
        public short Year { get; set; }

        public ValidThru(Month month, short year)
        {
            Month = month;
            Year = year;
        }
        public bool Valid()
        {
            var c = new DateTime(Year, (int)Month, DateTime.DaysInMonth(Year, (int)Month));
            return c.Year < 2051;
        }
        public bool Expired()
        {
            var n = DateTime.Now;
            return Year < n.Year || Year == n.Year && (int)Month < n.Month || RecentlyExpired(n);
        }

        private bool RecentlyExpired(DateTime n)
        {
            var firstMoment = new DateTime(Year, (int)Month, DateTime.DaysInMonth(Year, (int)Month)).AddDays(1);
            return (n - firstMoment).TotalMilliseconds > 0;
        }
    }
}