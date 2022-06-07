using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace MyCMS.Controllers
{
    public class AccountController : Controller
    {
        MyCmsContext db = new MyCmsContext();

        private ILogin loginRepository;

        public AccountController()
        {
            this.loginRepository = new LoginRepository(db);
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel login,string ReturnUrl = "/")
        {
            if (ModelState.IsValid)
            {
                if (loginRepository.IsExistUser(login.UserName, login.Password))
                {
                    FormsAuthentication.SetAuthCookie(login.UserName, login.RememberMe);
                    return Redirect(ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("UserName","کاربری یافت نشد");
                }
            }

            return View(login);
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}