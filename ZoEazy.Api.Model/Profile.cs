using System.ComponentModel.DataAnnotations;

namespace ZoEazy.Api.Model
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        //Will be the foreing key to attach to the User Id ( Id of the AspNetUsers table... )
        [StringLength(128)]
        public string UserId { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        //public virtual ApplicationUser ApplicationUser { get; set; }

        public byte[] Image { get; set; }
        public string ImageSource { get; set; }


    }
}