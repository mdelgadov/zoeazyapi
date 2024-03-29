﻿using System;
using System.Collections.Generic;

namespace ZoEazy.Api.Model.Entities
{
    public class EOrder : AuditableEntity
    {
        public EOrder(Guid user) : base(user)
        {
        }

        public decimal Discount { get; set; }
        public string Comments { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<EOrderDetail> EOrderDetails { get;  }
    }
    public class EOrderDetail : Delete
    {
      
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }


        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
