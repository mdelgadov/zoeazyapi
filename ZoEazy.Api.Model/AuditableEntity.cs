using System;
using System.ComponentModel.DataAnnotations;

namespace ZoEazy.Api.Model
{
    public class AuditableEntity : IAuditableEntity
    {
        [Required]
        public Guid UserId { get; set; }
        [MaxLength(256)]
        public string CreatedBy { get; set; }
        [MaxLength(256)]
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
