using System.Collections.Generic;
using ZoEazy.Api.Model;
using ZoEazy.Api.Model.Entities;

namespace ZoEazy.Api.Data
{
    public interface IECustomerRepository : IRepository<ECustomer>
    {
        IEnumerable<ECustomer> GetTopActiveCustomers(int count);
        IEnumerable<ECustomer> GetAllCustomersData();
    }
}
