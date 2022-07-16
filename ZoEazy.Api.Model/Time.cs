using System;

namespace ZoEazy.Api.Model
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1815:Override equals and operator equals on value types", Justification = "Not time time, just time struct with three ints")]
    public struct Time
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
//        public int Second { get; set; }

        public Time(System.DateTime time)
        {
            Hour = time.Hour;
            Minute = time.Minute;
  //          Second = time.Second;
        }

    }
}
