using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZoEazy.Api.Model
{
   public class ZipCode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Zip { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int PopulationAt2001 { get; set; }
        public int StateId { get; set; }
        [JsonIgnore]
        [ForeignKey("StateId")]
        public virtual State State { get; set; }
        public double Area { get; set; }
        public int Sumblkpop { get; set; }
        public string Geometry { get; set; }
    }
}
