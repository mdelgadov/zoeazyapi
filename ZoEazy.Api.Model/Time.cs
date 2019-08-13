using System;

namespace ZoEazy.Api.Model
{
    public struct Time
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }

        public Time(System.DateTime time)
        {
            Hour = time.Hour;
            Minute = time.Minute;
            Second = time.Second;
        }

    }
}
