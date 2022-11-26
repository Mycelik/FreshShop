using InfraStructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshShop.Model.Domain
{
    public class ProductComment : BaseDomain
    {
        public int? ProductId { get; set; }
        public int? CustomerId { get; set; }
        public int? Point { get; set; }
        public string Comment { get; set; }

        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
