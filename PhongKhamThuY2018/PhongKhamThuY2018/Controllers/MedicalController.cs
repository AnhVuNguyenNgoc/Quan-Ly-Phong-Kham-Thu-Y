using Models;
using Models.DAO;
using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PhongKhamThuY2018.Controllers
{
    public class MedicalController : BaseController
    {


        //
        // GET: /Category/
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var Cate = new MedicalDAO();

            var model = Cate.ListAllPaging(searchString, page, pageSize);

            ViewBag.searchString = searchString;

            return View(model);
        }


        //
        // GET: /Category/Create
        public ActionResult Create()
        {
            var catDAO = new MedicalDAO();

            List<DONVITHUOC> ListThuoc = catDAO.ListAllThuoc();
            List<LOAITHUOC> ListLoaiThuoc = catDAO.ListAllLoaiThuoc();

            ViewBag.ListThuoc = new SelectList(ListThuoc, "MADONVI", "TENDONVI");
            ViewBag.ListLoaiThuoc = new SelectList(ListLoaiThuoc, "MALOAITHUOC", "TENLOAITHUOC");

            return View();
        }

        //
        // POST: /Category/Create
        [HttpPost]
        public ActionResult Create(THUOC entity)
        {

            if (ModelState.IsValid)
            {
                var catDAO = new MedicalDAO();

                if (catDAO.isUnique(entity))
                {
                    entity.NGAYNHAP = DateTime.Now;

                    int result = catDAO.Insert(entity);

                    if (result > 0)
                    {
                        //Xuất thông báo thành công notification

                        SetAlert("Thêm " + entity.TENTHUOC + " thành công !!", "success");
                        return RedirectToAction("Index", "Medical");

                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm không thành công !!");
                    }

                }
                else
                {
                    SetAlert("Thêm " + entity.TENTHUOC + " không thành công !!", "error");
                    return RedirectToAction("Create");
                }

            }
            // TODO: Add insert logic here

            return View(entity);



        }


        // GET: /Category/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new MedicalDAO().ViewDetail(id);

            var catDAO = new MedicalDAO();

            List<DONVITHUOC> ListThuoc = catDAO.ListAllThuoc();
            List<LOAITHUOC> ListLoaiThuoc = catDAO.ListAllLoaiThuoc();

            ViewBag.ListThuoc = new SelectList(ListThuoc, "MADONVI", "TENDONVI", model.MADONVI);

            ViewBag.ListLoaiThuoc = new SelectList(ListLoaiThuoc, "MALOAITHUOC", "TENLOAITHUOC", model.MALOAITHUOC);

            return View(model);

        }

        //
        // POST: /Category/Edit/5
        [HttpPost]
        public ActionResult Edit(THUOC cat)
        {
            if (ModelState.IsValid)
            {
                var dao = new MedicalDAO();

                bool result = dao.Update(cat);

                if (result)
                {
                    //Xuất thông báo thành công notification

                    SetAlert("Sửa " + cat.TENTHUOC + " thành công !!", "success");

                    return RedirectToAction("Index", "Medical");
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



        public void ExportToExcel()
        {
            var petDAO = new MedicalDAO();

            var listThu = petDAO.ListAll();

            string Filename = "ThuocExcel" + DateTime.Now.ToString("mm_dd_yyy_hh_ss_tt") + ".xls";

            string FolderPath = HttpContext.Server.MapPath("/ExcelFiles/");
            string FilePath = System.IO.Path.Combine(FolderPath, Filename);


            //Step-1: Checking: If file name exists in server then remove from server.
            if (System.IO.File.Exists(FilePath))
            {
                System.IO.File.Delete(FilePath);
            }

            //Step-2: Get Html Data & Converted to String
            string HtmlResult = RenderRazorViewToString("~/Views/Medical/GenerateExcel.cshtml", listThu);

            //Step-4: Html Result store in Byte[] array
            byte[] ExcelBytes = Encoding.UTF8.GetBytes(HtmlResult);

            //Step-5: byte[] array converted to file Stream and save in Server
            using (Stream file = System.IO.File.OpenWrite(FilePath))
            {
                file.Write(ExcelBytes, 0, ExcelBytes.Length);
            }

            //Step-6: Download Excel file 
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(Filename));


            Response.WriteFile(FilePath);

            Response.End();
            Response.Flush();


        }

        protected string RenderRazorViewToString(string viewName, object model)
        {
            if (model != null)
            {
                ViewData.Model = model;
            }

            using (StringWriter sw = new StringWriter())
            {

                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);

                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);

                return sw.GetStringBuilder().ToString();
            }
        }

    }
}
