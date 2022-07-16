using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    public abstract class AuditableEntity : ClientChangeTracker, IAuditableEntity
    {
        public AuditableEntity(Guid user)
        {
            Created = new Status(user);
        }
        public Status Created { get; set; }
        public Status Updated { get; set; }
        public Status Deleted { get; set; }
    }
}
