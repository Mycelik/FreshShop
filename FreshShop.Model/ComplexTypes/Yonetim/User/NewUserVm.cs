
using FreshShop.Model.Domain;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FreshShop.Model.ComplexTypes.Yonetim.User
{
    public class NewUserVm
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string FullName { get; set; }
        public string FileName { get; set; }
        public int RoleId { get; set; }

        public List<SelectListItem> Roles { get; set; }
    }
}
