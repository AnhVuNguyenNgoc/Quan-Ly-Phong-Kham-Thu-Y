using Models;
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

        public ActionResult Index(LoginViewModel model)
        {
            var result = new AccountModel().Login(model.UserName,model.Pass);

            if(result && ModelState.IsValid)
            {

            }
            else
            {

            }


        }
	}
}