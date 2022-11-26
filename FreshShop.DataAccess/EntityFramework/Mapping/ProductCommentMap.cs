using FreshShop.Model.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshShop.DataAccess.EntityFramework.Mapping
{
    public class ProductCommentMap : EntityTypeConfiguration<ProductComment>
    {
        public ProductCommentMap()
        {
            ToTable("ProductComment");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
