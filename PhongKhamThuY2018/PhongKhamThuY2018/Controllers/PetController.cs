using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhongKhamThuY2018.Controllers
{
    public class PetController : Controller
    {
        //
        // GET: /Pet/
        public ActionResult Index(string searchString, int page = 1, int pageSize = 3)
        {
            var Cate = new PetDAO();

            var model = Cate.ListAllPaging(searchString, page, pageSize);

            ViewBag.searchString = searchString;

            return View(model);
        }
        //
        // GET: /Pet/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Pet/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Pet/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Pet/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Pet/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Pet/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Pet/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
