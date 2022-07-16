using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text;

namespace ZoEazy.Api.Model
{
    [ComplexType]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "Never got to find a better name.... usually prefix the Date as Mode.Date...")]
    public class Date
    {
        readonly DateTime _max = DateTime.MaxValue;
        readonly DateTime _min = DateTime.MinValue;
        DateTime _test;
        public Date()
        {
            var d = DateTime.Now;
            Year = d.Year;
            Month = d.Month;
            Day = d.Day;
        }

        public Date(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public Date(DateTime d) {
            Day = d.Day;
            Month = d.Month;
            Year = d.Year;
        }

        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public bool Valid()
        {
            var toTest = $"{Year.ToString("nnnn", new CultureInfo("en-US"))}/{Month.ToString("nn", new CultureInfo("en-US"))}/{Day.ToString("nn", new CultureInfo("en-US"))}";
            return (DateTime.TryParse(toTest, out _test) && _test >= _max && _test <= _min);
        }
    }
}
