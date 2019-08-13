using Microsoft.EntityFrameworkCore;
using ZoEazy.Api.Model;

namespace ZoEazy.Api.Data
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        { }

        private ZoeazyDbContext _appContext => (ZoeazyDbContext)_context;
    }
}
