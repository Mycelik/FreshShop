using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FreshShop.Model.ComplexTypes.Yonetim.Product
{
    public class ProductUpdateVm
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        
        [AllowHtml]
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Discount { get; set; }
    }
}
