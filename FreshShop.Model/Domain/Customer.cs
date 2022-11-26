using InfraStructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshShop.Model.Domain
{
    public class Customer : BaseDomain
    {
        public Customer()
        {
            ProductComments = new HashSet<ProductComment>();
        }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<ProductComment> ProductComments { get; set; }
    }
}
