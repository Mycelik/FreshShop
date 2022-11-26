using FreshShop.Model.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FreshShop.Model.ComplexTypes.Yonetim.User
{
    public class UserUpdateVm
    {
        //[Required(ErrorMessage = "Email Boş Bırakılamaz")]
        //[EmailAddress(ErrorMessage = "Geçerli formatta email girmelisiniz")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Şifre Boş Bırakılamaz")]
        //[MinLength(5, ErrorMessage = "Şifre en az 5 karakter olmalıdır")]
        //[MyPasswordValidator(ErrorMessage = "Şifre içinde en az 1 küçük harf en az 1 rakam olmalıdır")]
        public string Password { get; set; }


        //[Required(ErrorMessage = "Şifre Tekrarı Boş Bırakılamaz")]
        //[MinLength(5, ErrorMessage = "Şifre tekrarı en az 5 karakter olmalıdır")]
        //[Compare("Password", ErrorMessage = "Şifre ile tekrarı aynı değil")]
        public string RePassword { get; set; }

        //[Required(ErrorMessage = "Ad Soyad Boş Bırakılamaz")]
        //[MinLength(2, ErrorMessage = "Ad Soyad en az 2 karakter olmalıdır")]
        public string FullName { get; set; }

        public int Id { get; set; }
        public int RoleId { get; set; }
        public List<SelectListItem> Roles { get; set; }
    }
}
