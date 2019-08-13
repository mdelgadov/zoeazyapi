
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
