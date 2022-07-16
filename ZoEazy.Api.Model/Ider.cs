using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZoEazy.Api.Model
{

    public abstract class Ider : IId, IThing
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string  Name {get; set;}
    }
}


