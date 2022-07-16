using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    [ComplexType]
    public class Status
    {
        public Status(Guid user, bool state = true)
        {
            if (state)
                _StateDate = DateTimeOffset.Now.ToUniversalTime();
            else
                _StateDate = null;

            ByUser = user;
        }
        public Guid ByUser { get; set; }
        private DateTimeOffset? _StateDate { get; set; }
        [JsonIgnore]
        [NotMapped]
        public DateTimeOffset? StateUtc
        {
            get { return _StateDate; }
            set
            {
                if (value != null)
                    ((DateTimeOffset)value).ToUniversalTime();
            }
        }
        [JsonIgnore]
        [NotMapped]
        public bool State
        {
            get { return _StateDate == null; }
        }
    }
}


