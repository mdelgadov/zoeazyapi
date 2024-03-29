﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using ZoEazy.Api.Model;
using ZoEazy.Api.Model.Entities;
using ZoEazy.Api.Model.Subscriber;
using ZoEazy.Api.Model.Branch;

namespace ZoEazy.Api.Data
{
    public class ZoeazyDbContext : IdentityDbContext<Subscriber, ApplicationRole, Guid>
    {
        public string CurrentUserId { get; set; }
        public DbSet<ECustomer> ECustomers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<EOrder> EOrders { get; set; }
        public DbSet<EOrderDetail> EOrderDetails { get; set; }

        public DbSet<Culture> Cultures { get; set; }
        public DbSet<Resource> Resources { get; set; }
        //public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        //public DbSet<Franchise> Franchises { get; set; }
        // public DbSet<Branch> Branches { get; set; }
        //public DbSet<FranchiseAddress> FranchiseAddresses { get; set; }
        // public DbSet<Model.Branch.Address> BranchAddresses { get; set; }
        public DbSet<UnitOfLength> Lengths { get; set; }
        // public DbSet<BranchAddressGeo> AddressGeos { get; set; }
        //public DbSet<SubscriberAddress> SubscriberAddresses { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        //public DbSet<SubscriberPhone> SubscriberPhones { get; set; }
        public DbSet<CustomerPhone> CustomerPhones { get; set; }
        //public DbSet<FranchisePhone> FranchisePhones { get; set; }
        // public DbSet<Model.Branch.Phone> BranchPhones { get; set; }
        //public DbSet<FranchiseFax> FranchiseFaxes { get; set; }
        public DbSet<Locale> Locales { get; set; }

        // public DbSet<Model.Branch.Fax> BranchFaxes { get; set; }
        //public DbSet<SubscriberFax> SubscriberFaxes { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuPresentation> MenuPresentations { get; set; }
        public DbSet<OfferType> OfferTypes { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuItemPresentation> MenuItemPresentations { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<OfferItem> OfferItems { get; set; }
        public DbSet<OfferItemPresentation> OfferPresentations { get; set; }
        public DbSet<OrderItemPresentation> OrderPresentations { get; set; }
        public DbSet<FavoritePresentation> FavoritePresentations { get; set; }
        public DbSet<Model.Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DeliveryArea> DeliveryAreas { get; set; }
        public DbSet<Side> Sides { get; set; }
        public DbSet<Corner> Corners { get; set; }
        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<CreditCardBrand> CreditCardBrands { get; set; }
        //public DbSet<CreditCard> SubscriberCreditCards { get; set; }
        public DbSet<CustomerCreditCard> CustomerCreditCards { get; set; }
        public DbSet<WebsiteName> WebsiteNames { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        
        public DbSet<Setup> Setups { get; set; }
        // public DbSet<Model.Branch.Order> BranchOrders { get; set; }
        // public DbSet<Item> BranchOrderItems { get; set; }
        //public DbSet<Contract> Contracts { get; set; }
        //public DbSet<ContractItem> ContractItems { get; set; }
        //public DbSet<ContractService> ContractServices { get; set; }
        //public DbSet<ContractPeriod> ContractPeriods { get; set; }

        public DbSet<PredefinedSchedule> PredefinedSchedules { get; set; }
        public DbSet<PostalCode> PostalCodes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<ZipCode> ZipCodes { get; set; }
        public DbSet<Feature> Features { get; set; }
        // public DbSet<Plan> Plans { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
       
        //public DbSet<Franchise> Franchises { get; set; }
        public DbSet<Model.Subscriber.Address> Addresses { get; set; }
        public DbSet<Model.Subscriber.Phone> Phones { get; set; }
        public DbSet<Model.Subscriber.Fax> Faxes { get; set; }
        public DbSet<Model.Subscriber.CreditCard> CreditCards { get; set; }

        public ZoeazyDbContext(DbContextOptions<ZoeazyDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
            .Where(e => typeof(IAuditable).IsAssignableFrom(e.ClrType)))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property<DateTime>("CreatedAt");

                modelBuilder.Entity(entityType.ClrType)
                    .Property<DateTime>("UpdatedAt");
            }


            modelBuilder.Entity<Model.Subscriber.CreditCard>().HasMany(s => s.Orders);
            modelBuilder.Entity<Subscriber>().OwnsOne(e => e.Name);
            modelBuilder.Entity<Model.Subscriber.CreditCard>().OwnsOne(e => e.ValidThru);
            modelBuilder.Entity<Subscriber>().OwnsOne(e => e.DateOfBirth);
            modelBuilder.Entity<Subscriber>().OwnsOne(e => e.Suspended);

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<CreditCard>().HasMany(s => s.Orders);
            //modelBuilder.Entity<BranchOrder>().HasOne(b => b.CreditCard).WithMany(b => b.Orders).IsRequired().OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<CreditCard>().OwnsOne(e => e.ValidThru);
            modelBuilder.Entity<CustomerCreditCard>().OwnsOne(e => e.ValidThru);
            //modelBuilder.Entity<Contract>().HasOne(b => b.CreditCard).WithMany(b => b.Contracts).IsRequired().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Plan>().HasOne(b => b.Currency).WithMany(c => c.Plans).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Plan>().HasOne(b => b.Period).WithMany(c => c.Plans).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Customer>().OwnsOne(e => e.Name);

            base.OnModelCreating(modelBuilder);
          
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            
        }

        /// <summary>
        /// Override SaveChanges so we can call the new AuditEntities method.
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            this.AuditEntities();
            return base.SaveChanges();
        }
        /// <summary>
        /// Override SaveChangesAsync so we can call the new AuditEntities method.
        /// </summary>
        /// <returns></returns>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.AuditEntities();

            return await base.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Method that will set the Audit properties for every added or modified Entity marked with the 
        /// IAuditable interface.
        /// </summary>
        private void AuditEntities()
        {

            DateTime now = DateTime.Now;

            // For every changed entity marked as IAditable set the values for the audit properties
            foreach (EntityEntry<IAuditable> entry in ChangeTracker.Entries<IAuditable>())
            {
                // If the entity was added.
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedAt").CurrentValue = now;
                }
                else if (entry.State == EntityState.Modified) // If the entity was updated
                {
                    entry.Property("UpdatedAt").CurrentValue = now;
                }
            }
        }
    }

}
