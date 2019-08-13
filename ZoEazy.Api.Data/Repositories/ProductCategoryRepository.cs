using Microsoft.EntityFrameworkCore;
using ZoEazy.Api.Model;

namespace ZoEazy.Api.Data
{
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(DbContext context) : base(context)
        { }

        private ZoeazyDbContext _appContext => (ZoeazyDbContext)_context;
    }
}
