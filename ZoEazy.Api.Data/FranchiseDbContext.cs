using Microsoft.EntityFrameworkCore;

namespace ZoEazy.Api.Data
{
    public class FranchiseDbContext : DbContext
    {
        public DbSet<Model.Franchise.Franchise> Franchises { get; set; }
        public DbSet<Model.Franchise.Address> Addresses { get; set; }
        public DbSet<Model.Franchise.Phone> Phones { get; set; }
        public DbSet<Model.Franchise.Fax> Faxes { get; set; }




        public FranchiseDbContext(DbContextOptions<ZoeazyDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
