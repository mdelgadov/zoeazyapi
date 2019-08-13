using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    [ComplexType]
    public class Flag
    {
        public Flag()
        {
            Value = false;
        }

        public Flag(bool value)
        {
            Value = value;
            if (value) setAtUtc = DateTimeOffset.UtcNow;
            else setAtUtc = null;
        }

        public Boolean Value { get; set; }
        [JsonIgnore]
        public DateTimeOffset? setAtUtc { get; set; }

    }
}
