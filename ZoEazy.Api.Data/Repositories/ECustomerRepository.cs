using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ZoEazy.Api.Model;
using ZoEazy.Api.Model.Entities;

namespace ZoEazy.Api.Data
{
    public class ECustomerRepository : Repository<ECustomer>, IECustomerRepository
    {
        public ECustomerRepository(ZoeazyDbContext context) : base(context)
        { }

        public IEnumerable<ECustomer> GetTopActiveCustomers(int count)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ECustomer> GetAllCustomersData()
        {
            return _appContext.ECustomers
                .Include(c => c.EOrders)
                    .ThenInclude(o => o.EOrderDetails)
                    .ThenInclude(d => d.Product)
                .Include(c => c.EOrders)
                .OrderBy(c => c.Name)
                .ToList();
        }



        private ZoeazyDbContext _appContext => (ZoeazyDbContext)_context;
    }
}
