using System;
using System.Collections.Generic;

namespace ZoEazy.Api.Model.Entities
{
    public class ECustomer : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public Gender Gender { get; set; }
        public ICollection<EOrder> EOrders { get; set; }
    }
}
