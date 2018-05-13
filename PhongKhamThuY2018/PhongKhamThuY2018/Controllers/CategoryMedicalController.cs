using Models.DAO;
using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhongKhamThuY2018.Controllers
{
    public class CategoryMedicalController : BaseController
    {
        //
        // GET: /CategoryMedical/
        public ActionResult Index(string searchString, int page = 1, int pageSize = 3)
        {
            var Cate = new CategoryMedicalDAO();

            var model = Cate.ListAllPaging(searchString, page, pageSize);

            ViewBag.searchString = searchString;

            return View(model);
        }

        //
        // GET: /CategoryMedical/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /CategoryMedical/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CategoryMedical/Create
        [HttpPost]
        public ActionResult Create(LOAITHUOC entity)
        {
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    var catDAO = new CategoryMedicalDAO();

                    int result = catDAO.Insert(entity);

                    if (result > 0)
                    {
                        //Xuất thông báo thành công notification

                        SetAlert("Thêm " + entity.TENLOAITHUOC + " thành công !!", "success");

                        return RedirectToAction("Index", "CategoryMedical");

                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm không thành công !!");
                    }
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /CategoryMedical/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new CategoryMedicalDAO().ViewDetail(id);
            return View(model);
        }

        //
        // POST: /CategoryMedical/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LOAITHUOC entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new CategoryMedicalDAO();

                    bool result = dao.Update(entity);

                    if (result)
                    {
                        //Xuất thông báo thành công notification

                        SetAlert("Sửa " + entity.TENLOAITHUOC + " thành công !!", "success");

                        return RedirectToAction("Index", "CategoryMedical");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Sửa không thành công !!");
                    }
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /CategoryMedical/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /CategoryMedical/Delete/5
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
