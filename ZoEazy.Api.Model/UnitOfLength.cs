using System.ComponentModel.DataAnnotations;

namespace ZoEazy.Api.Model
{
    public class UnitOfLength {
        public UnitOfLength()
        {
            Id = Length.mile;

            Name = "Mile";
            ShortName = "Mi";
        }
        
        [Key]
        public Length Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}


