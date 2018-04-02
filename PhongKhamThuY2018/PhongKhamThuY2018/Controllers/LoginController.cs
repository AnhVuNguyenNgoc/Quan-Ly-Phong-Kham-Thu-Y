using Models;
using PhongKhamThuY2018.Code;
using PhongKhamThuY2018.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhongKhamThuY2018.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(LoginViewModel model)
        {
            bool result = new AccountModel().Login(model.UserName,model.Pass);

            if(result && ModelState.IsValid)
            {
                SessionHelper.SetSession(new UserSession() { UserName=model.UserName });

                return RedirectToAction("Home", "Index");
            }
            else
            {
                ModelState.AddModelError("","Tên đăng nhập hoặc mật khẩu không đúng !!");
            }


            return View(model);

        }
	}
}