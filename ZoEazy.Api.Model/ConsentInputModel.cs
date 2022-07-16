using System;
using System.Collections.Generic;

namespace ZoEazy.Api.Model
{
    public class ConsentInputModel
    {
        public string Button { get; set; }
        public IEnumerable<string> ScopesConsented { get; set; }
        public bool RememberConsent { get; set; }
        public Uri ReturnUrl { get; set; }
    }
}