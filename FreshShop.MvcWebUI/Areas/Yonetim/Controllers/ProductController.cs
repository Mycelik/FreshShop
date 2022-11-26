using FreshShop.Business.AbstractStructure;
using FreshShop.Model.ComplexTypes.Yonetim.Product;
using FreshShop.Model.Domain;
using InfraStructure.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI.WebControls;

namespace FreshShop.MvcWebUI.Areas.Yonetim.Controllers
{
    public class ProductController : Controller
    {
        IProductBs _bs;
        ICategoryBs _categoryBs;
        IProductPhotoBs _photoBs;

        public ProductController(IProductBs bs, ICategoryBs categoryBs, IProductPhotoBs photoBs)
        {
            _bs = bs;
            _categoryBs = categoryBs;
            _photoBs = photoBs;
        }

        public ActionResult New()
        {
            NewProductVm vm = new NewProductVm();

            vm.MainCategories = _categoryBs.GetAllActiveMainCategories()
                           .Select(x => new SelectListItem()
                           {
                               Text = x.CategoryName,
                               Value = x.Id.ToString()
                           }).ToList();


            return View(vm);

        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult New(NewProductVm vm)
        {
            Product p = new Product();

            p.CategoryId = vm.CategoryId;
            p.Created = DateTime.Now;
            p.Description = vm.Description;
            p.Discount = vm.Discount;
            p.IsActive = true;
            p.Modified = DateTime.Now;
            p.ProductName = vm.ProductName;
            p.UnitPrice = vm.UnitPrice;

            _bs.Insert(p);


            return Json(new { Result = true, ProductId = p.Id });
        }

        [HttpPost]
        public JsonResult UploadPhoto(int id)
        {
            HttpFileCollectionBase files = Request.Files;
            
            if (files.Count > 0)
            {
                foreach (string s in files)
                {

                    HttpPostedFileBase file = files[s];

                    string fileName = RandomValueGenerator.FileName(Path.GetExtension(file.FileName));
                    string path = "~/Areas/Yonetim/Content/img/ProductImages/" + fileName;
                    file.SaveAs(Server.MapPath(path));

                    ProductPhoto photo = new ProductPhoto();
                    photo.Created = DateTime.Now;
                    photo.IsActive = true;
                    photo.Modified = DateTime.Now;
                    photo.Photo = fileName;
                    photo.ProductId = id;

                    _photoBs.Insert(photo);
                }

                return Json(new { Result = true });

            }

            return Json(new { Result = false, Message = "Lütfen fotoğraf seçiniz" });


        }

        public ViewResult ProductList()
        {
            List<Product> products = _bs.GetAllActive();

            return View(products);
        }

        public JsonResult Delete(int id)
        {
            ProductPhoto photo = _photoBs.Get(x => x.ProductId == id);
            _photoBs.Delete(photo);
            Product product = _bs.Get(x => x.Id == id);
            int result = _bs.Delete(product);
            if (result > 0)
                return Json(new { Operation = true, Message = "Silme İşlemi Başarıyla Gerçekleşti."  });
            return Json(new { Operation = false, Message = "Silme İşleminiz Başarısız." });




        }
       
        public ActionResult ProductUpdate(int id)
        {
            var product =_bs.GetById(id);
            return View(product);
        }

        [HttpPost]
        [ValidateInput(false)] // html gelsin diye yaptık xss atack kontrolünü sağla
        public JsonResult ProductUpdateJson(ProductUpdateVm vm )
        {
            Product product = _bs.Get(x => x.Id == vm.Id);
            product.ProductName = vm.ProductName;
            product.UnitPrice = vm.UnitPrice;
            product.Description = vm.Description;
            product.Discount = vm.Discount;
            product.IsActive = true;
            product.Modified = DateTime.Now;


            _bs.Update(product);
            return Json(new { Operation=true,});
        }
    }
      
}