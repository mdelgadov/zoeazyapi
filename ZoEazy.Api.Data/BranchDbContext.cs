using Microsoft.EntityFrameworkCore;

namespace ZoEazy.Api.Data
{
    public class BranchDbContext : DbContext
    {
        public DbSet<Model.Branch.Branch> Branches { get; set; }
        public DbSet<Model.Branch.Address> Addresses { get; set; }
        public DbSet<Model.Branch.Phone> Phones { get; set; }
        public DbSet<Model.Branch.Fax> Faxes { get; set; }

        public DbSet<Model.Branch.Plan> Plans { get; set; }

        public DbSet<Model.Branch.Order.Order> Orders { get; set; }
        public DbSet<Model.Branch.Order.Item> Items { get; set; }
        public DbSet<Model.Branch.Order.Service> Services { get; set; }
        public DbSet<Model.Branch.Contract.Contract> Contracts { get; set; }
        public DbSet<Model.Branch.Contract.Period> Periods { get; set; }

        // public DbSet<Model.Branch.Order.Order> 
        //public DbSet<Contract> Contracts { get; set; }
        public DbSet<Model.Branch.Contract.Item> ContractItems { get; set; }
        public DbSet<Model.Branch.Contract.Service> ContractServices { get; set; }

        public BranchDbContext(DbContextOptions<ZoeazyDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
