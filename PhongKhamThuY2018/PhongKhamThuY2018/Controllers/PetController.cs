using Microsoft.Reporting.WebForms;
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
    public class PetController : Controller
    {
        //
        // GET: /Pet/
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
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

        public ActionResult ReportListAnimal(string id)
        {
            LocalReport lr = new LocalReport();


            string path = Path.Combine(Server.MapPath("~/Report"), "testReport.rdlc");

            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("Index", "Home");
            }

            var petDAO = new PetDAO();

            List<THU> thu = petDAO.ListAll();

            ReportDataSource rd = new ReportDataSource("MyDataset", thu);

          
            lr.DataSources.Add(rd);

           

            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;


            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + id + "</OutputFormat>" +
            "  <PageWidth>12in</PageWidth>" +
            "  <PageHeight>12in</PageHeight>" +
            "  <MarginTop>0.5in</MarginTop>" +
            "  <MarginLeft>1in</MarginLeft>" +
            "  <MarginRight>1in</MarginRight>" +
            "  <MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;


            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);

            return File(renderedBytes, mimeType);

        }

        public void ExportToExcel()
        {
            var petDAO = new PetDAO();

            var listThu = petDAO.ListAll();

            string Filename = "ThuCungExcel" + DateTime.Now.ToString("mm_dd_yyy_hh_ss_tt") + ".xls";

            string FolderPath = HttpContext.Server.MapPath("/ExcelFiles/");
            string FilePath = System.IO.Path.Combine(FolderPath, Filename);


            //Step-1: Checking: If file name exists in server then remove from server.
            if (System.IO.File.Exists(FilePath))
            {
                System.IO.File.Delete(FilePath);
            }

            //Step-2: Get Html Data & Converted to String
            string HtmlResult = RenderRazorViewToString("~/Views/Pet/GenerateExcel.cshtml", listThu);

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
