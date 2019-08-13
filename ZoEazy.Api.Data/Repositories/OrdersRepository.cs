using Microsoft.EntityFrameworkCore;
using ZoEazy.Api.Model;

namespace ZoEazy.Api.Data
{
    public class OrdersRepository : Repository<Order>, IOrdersRepository
    {
        public OrdersRepository(DbContext context) : base(context)
        { }

        private ZoeazyDbContext _appContext => (ZoeazyDbContext)_context;
    }
}
