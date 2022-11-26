using FreshShop.Business.AbstractStructure;
using FreshShop.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreshShop.MvcWebUI.Areas.Yonetim.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryBs _categoryBs;

        public CategoryController(ICategoryBs categoryBs)
        {
            _categoryBs = categoryBs;
        }

        [HttpPost]
        public JsonResult GetByMainCategoryId(int topCategoryId)
        {
            List<SelectListItem> categories = _categoryBs.GetByMainCategoryId(topCategoryId).Select(x=>new SelectListItem() { Text=x.CategoryName,Value=x.Id.ToString()}).ToList();

            return Json(new {Result=true,Categories=categories });
        }
    }
}