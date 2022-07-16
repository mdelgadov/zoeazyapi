using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZoEazy.Api.Model
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }//iso 3166 two letter

        [Required]
        public string Name { get; set; }
        [Required]
        public string Abbreviation { get; set; }

        public IEnumerable<State> States { get; set; }
    }
}