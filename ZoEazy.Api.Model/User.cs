using System;
using System.ComponentModel.DataAnnotations;

namespace ZoEazy.Api.Model
{
    public class User
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm ampm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime EntryTime { get; set; }

        //Setting Default value
        public User()
        {
            EntryTime = DateTime.Now;
        }
    }
}
