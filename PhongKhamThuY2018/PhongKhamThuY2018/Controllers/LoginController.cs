
using Models.DAO;
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
            if(Session[CommonConstants.USER_SESSION]!=null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userDao = new UserDAO();

                bool result = userDao.Login(model.UserName, model.Pass);

                if (result)
                {
                    //Session giữ userid, userDaoname
                    var user=userDao.GetById(model.UserName);

                    var usersession = new UserSession();

                    usersession.UserID = user.ID;
                    usersession.UserName = user.UserName;

                    Session.Add(CommonConstants.USER_SESSION, usersession);

                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng !!");
                }
            }
            return View(model);
        }
    }
}