using FreshShop.DataAccess.EntityFramework.Mapping;
using FreshShop.Model.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshShop.DataAccess.EntityFramework.Context
{
    public class FreshShopDbContext:DbContext
    {

        public FreshShopDbContext():base("FreshShopDbConnStr")
        {
            Database.SetInitializer<FreshShopDbContext>(null);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductPhoto> ProductPhotoes { get; set; }
        public virtual DbSet<ProductComment> ProductComments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ProductPhotoMap());
            modelBuilder.Configurations.Add(new ProductCommentMap());
        }
    }
}
