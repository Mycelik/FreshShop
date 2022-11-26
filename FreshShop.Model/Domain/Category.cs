using InfraStructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshShop.Model.Domain
{
    public class Category : BaseDomain
    {
        public Category()
        {
            SubCategories = new HashSet<Category>();
            Products = new HashSet<Product>();
        }
        public string CategoryName { get; set; }
        public int? TopCategoryId { get; set; }

        public virtual Category TopCategory { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
