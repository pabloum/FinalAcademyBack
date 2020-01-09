namespace LandingAgency.Api.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using LandingAgency.Api.Logic;

    public partial class LandingAgencyModel : DbContext
    {
        public LandingAgencyModel()
            : base("name=LandingAgencyModel")
        {
            this.Configuration.LazyLoadingEnabled = false; this.Configuration.ProxyCreationEnabled = false;           
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClientType> ClientType { get; set; }
        public virtual DbSet<Package> Package { get; set; }
        public virtual DbSet<PackageProduct> PackageProduct { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientType>()
                .Property(e => e.ClientTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<Package>()
                .Property(e => e.PackageName)
                .IsUnicode(false);

            modelBuilder.Entity<Package>()
                .HasMany(e => e.PackageProduct)
                .WithRequired(e => e.Package)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.PackageProduct)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductType>()
                .Property(e => e.ProductName)
                .IsUnicode(false);
        }
    }
}
