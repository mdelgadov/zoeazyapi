using System.Collections.Generic;

namespace ZoEazy.Api.Model
{
    public class ProductCategory : Delete
    {
        public string Description { get; set; }
        public string Icon { get; set; }

        public ICollection<Product> Products { get;  }
    }
}
