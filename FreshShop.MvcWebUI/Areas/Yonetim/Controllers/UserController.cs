using FluentValidation.Results;
using FreshShop.Business.AbstractStructure;
using FreshShop.Business.ValidationRules.FluentValidation;
using FreshShop.Model.ComplexTypes.Yonetim.User;
using FreshShop.Model.Domain;
using FreshShop.Model.Enums;
using FreshShop.MvcWebUI.Models;
using InfraStructure;
using InfraStructure.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FreshShop.MvcWebUI.Models.Filters;

namespace FreshShop.MvcWebUI.Areas.Yonetim.Controllers
{
    public class UserController : Controller
    {
        IUserBs _bs;
        IRoleBs _roleBs;
        public UserController(IUserBs bs, IRoleBs roleBs)
        {
            _bs = bs;
            _roleBs = roleBs;
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            if (Request.Cookies["ckKullaniciAdi"] != null && Request.Cookies["ckSifre"] != null)
            {
                //LogInVm vm = new LogInVm();
                //vm.Email = Request.Cookies["ckKullaniciAdi"].Value;
                //vm.Password = Request.Cookies["ckSifre"].Value;

                //return View(vm);

                string cryptoSalt = MagicStrings.AES_CRYPTO_SALT;
                string userNameHash = HashHelper.AESDecrypt(Request.Cookies["ckKullaniciAdi"].Value, cryptoSalt);

                string passwordHash = HashHelper.AESDecrypt(Request.Cookies["ckSifre"].Value, MagicStrings.AES_CRYPTO_SALT);

                User user = _bs.LogIn(userNameHash, passwordHash);

                if (user != null)
                {
                    SessionManager.ActiveUser = user;

                    return RedirectToAction("Index", "Home");
                }
            }


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult LogIn(LogInVm vm)
        {
            User user = _bs.LogIn(vm.Email, HashHelper.AESEncrypt(vm.Password,MagicStrings.AES_CRYPTO_SALT));

            if (user != null)
            {
                SessionManager.ActiveUser = user;
                if (vm.RememberMe)
                {
                    HttpCookie ckUserName = new HttpCookie("ckKullaniciAdi", HashHelper.AESEncrypt(user.Email, MagicStrings.AES_CRYPTO_SALT));

                    ckUserName.Expires = DateTime.Now.AddHours(2);

                    HttpCookie ckPassword = new HttpCookie("ckSifre", HashHelper.AESEncrypt(user.Password, MagicStrings.AES_CRYPTO_SALT));
                    ckPassword.Expires = DateTime.Now.AddHours(2);

                    Response.Cookies.Add(ckUserName);
                    Response.Cookies.Add(ckPassword);
                }

                return Json(new { Operation = true });
            }

            return Json(new { Operation = false, Message = "Kullanıcı Bulunamadı" });
        }

        public ActionResult LogOut()
        {
            SessionManager.ActiveUser = null;

            Response.Cookies["ckKullaniciAdi"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["ckSifre"].Expires = DateTime.Now.AddDays(-1);

            //Session.Clear();

            return RedirectToAction("LogIn");
        }

        [RoleFilter((int)RoleNames.Admin)]
        public ViewResult UserList()
        {
            List<User> users = _bs.GetAllActive();

            return View(users);
        }

        [RoleFilter((int)RoleNames.Admin,(int)RoleNames.ProductAdmin)]
        public ViewResult New()
        {
            NewUserVm vm = new NewUserVm();
            vm.Roles = _roleBs.GetAllActive().Select(x=>
                                        new SelectListItem()
                                        {
                                            Text =x.RoleName,
                                            Value =x.Id.ToString(),
                                            Selected = x.RoleName == "CategoryAdmin" ? true:false
                                        }).ToList();

           
            return View(vm);
        }

        [HttpPost]
        public JsonResult New(NewUserVm vm)
        {
            NewUserVmValidator val = new NewUserVmValidator();
            ValidationResult valResult = val.Validate(vm);

            if (valResult.IsValid)
            {
                User user = new User();
                user.Created = DateTime.Now;
                user.Email = vm.Email;
                user.FullName = vm.FullName;
                user.IsActive = true;
                user.Modified = DateTime.Now;
                user.Password = HashHelper.AESEncrypt(vm.Password,MagicStrings.AES_CRYPTO_SALT);
                user.Photo = vm.FileName;
                user.RoleId = vm.RoleId;

                _bs.Insert(user);


                return Json(new { Result = true, Message = "Kayıt Başarılı" });
            }
            else
            {
                string errorMessagesForClient = "";

                foreach (ValidationFailure failure in valResult.Errors)
                {
                    errorMessagesForClient += failure.ErrorMessage + "<br />";
                }

                return Json(new { Result = false, ErrorMessages = errorMessagesForClient });


            }
        }

        [HttpPost]
        public JsonResult UploadPhoto()
        {
            HttpFileCollectionBase files = Request.Files;

            if (files.Count > 0)
            {
                HttpPostedFileBase file = files[0];

                if (!file.ContentType.Contains("image/"))
                    return Json(new { Result = false, Message = "Sadece resim dosyası yükleyebilirsiniz" });

                

                string fileName = RandomValueGenerator.FileName(Path.GetExtension(file.FileName));

                string path = "~/Areas/Yonetim/Content/img/UserImages/" + fileName;


                file.SaveAs(Server.MapPath(path));

                return Json(new { Result = true, FileName = fileName });

            }

            return Json(new { Result = false, Message = "Lütfen fotoğraf seçiniz" });
        }

        public ActionResult UserUpdate(int id)
        {
            var user = _bs.GetById(id);
            return View(user);
        }

        [HttpPost]
        public JsonResult UserUpdateJson(UserUpdateVm vm)
        {
            User user = _bs.Get(x => x.Id == vm.Id);
            
            
            user.Email = vm.Email;
            user.FullName = vm.FullName;
            user.IsActive = true;
            user.Modified = DateTime.Now;
            user.Password = HashHelper.AESEncrypt(vm.Password, MagicStrings.AES_CRYPTO_SALT);

            _bs.Update(user);
            return Json(new { Operation = true });
        }

       
        public JsonResult UserRoleUpdateJson(int userId, int yetkiId)
        {
            var user = _bs.GetById(userId);
            user.RoleId = yetkiId;
            _bs.Update(user);
            return Json(new { Operation = true });
        }
    }
}