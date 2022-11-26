using InfraStructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshShop.Model.Domain
{
    public class Product : BaseDomain
    {
        public Product()
        {
            ProductComments = new HashSet<ProductComment>();
            ProductPhotoes = new HashSet<ProductPhoto>();
        }
        public int? CategoryId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Discount { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<ProductComment> ProductComments { get; set; }
        public virtual ICollection<ProductPhoto> ProductPhotoes { get; set; }
    }
}
