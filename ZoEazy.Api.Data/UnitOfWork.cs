using ZoEazy.Api.Data.Repositories.Interfaces;

namespace ZoEazy.Api.Data
{

    public class UnitOfWork : IUnitOfWork
    {
        readonly ZoeazyDbContext _context;

        IECustomerRepository _customers;
        IProductCategoryRepository _productsCategories;
        IProductRepository _products;
        IOrdersRepository _orders;



        public UnitOfWork(ZoeazyDbContext context)
        {
            _context = context;
        }



        public IECustomerRepository ECustomers
        {
            get
            {
                if (_customers == null)
                    _customers = new ECustomerRepository(_context);

                return _customers;
            }
        }



        public IProductRepository Products
        {
            get
            {
                if (_products == null)
                    _products = new ProductRepository(_context);

                return _products;
            }
        }

        public IProductCategoryRepository ProductCategories
        {
            get
            {
                if (_productsCategories == null)
                    _productsCategories = new ProductCategoryRepository(_context);

                return _productsCategories;
            }
        }



        public IOrdersRepository Orders
        {
            get
            {
                if (_orders == null)
                    _orders = new OrdersRepository(_context);

                return _orders;
            }
        }




        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
