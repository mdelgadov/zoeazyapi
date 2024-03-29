﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZoEazy.Api.Model
{
    public class Culture
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Resource> Resources { get; set; }
    }
}
