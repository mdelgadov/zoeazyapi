using ZoEazy.Api.Model;
using ZoEazy.Api.Model.Extensions;
using ZoEazy.Api.Model.Entities;
using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.Extensions.Logging;

namespace ZoEazy.Api.Data.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IECustomerRepository ECustomers { get; }
        IProductRepository Products { get; }
        IProductCategoryRepository ProductCategories { get; }
        IOrdersRepository Orders { get; }
        int SaveChanges();
    }
}

