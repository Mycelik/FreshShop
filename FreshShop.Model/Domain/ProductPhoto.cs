using InfraStructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshShop.Model.Domain
{
    public class ProductPhoto : BaseDomain
    {
        public int? ProductId { get; set; }
        public string Photo { get; set; }

        public virtual Product Product { get; set; }
    }
}
