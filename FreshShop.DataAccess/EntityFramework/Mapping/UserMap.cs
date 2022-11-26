using FreshShop.Model.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreshShop.DataAccess.EntityFramework.Mapping
{
    public class UserMap:EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //HasRequired(x => x.Role)
            //    .WithMany(x => x.Users)
            //    .HasForeignKey(x => x.RoleId);

        }
    }
}
