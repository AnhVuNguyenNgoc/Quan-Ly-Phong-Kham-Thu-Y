using Models;
using Models.DAO;
using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhongKhamThuY2018.Controllers
{
    public class CategoryController : BaseController
    {
        //
        // GET: /Category/
        public ActionResult Index(string searchString,int page=1,int pageSize=8)
        {
            var Cate = new CategoryDAO();

            var model = Cate.ListAllPaging(searchString,page, pageSize);

            ViewBag.searchString = searchString;
            return View(model);
        }

    
        //
        // GET: /Category/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Category/Create
        [HttpPost]
        public ActionResult Create(Category entity)
        {
           
                if (ModelState.IsValid)
                {
                    var catDAO = new CategoryDAO();

                    entity.NgayNhap = DateTime.Now;
                    int result = catDAO.Insert(entity);

                    if (result > 0)
                    {
                        //Xuất thông báo thành công notification

                        SetAlert("Thêm "+entity.Name+" thành công !!","success");
                        return RedirectToAction("Index", "Category");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm không thành công !!");
                    }
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            
    
        }

        //
        // GET: /Category/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new CategoryDAO().ViewDetail(id);
            return View(model);
            
        }

        //
        // POST: /Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category cat)
        {
            if (ModelState.IsValid)
            {
               var dao=new CategoryDAO();

               bool result = dao.Update(cat);

                if (result)
                {
                    //Xuất thông báo thành công notification

                    SetAlert("Sửa " + cat.Name + " thành công !!", "success");
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa không thành công !!");
                }
            }
            // TODO: Add insert logic here

            return RedirectToAction("Index");
        }

        //
        // GET: /Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Category/Delete/5
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
