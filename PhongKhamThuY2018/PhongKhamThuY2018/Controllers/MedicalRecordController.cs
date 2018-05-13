using Microsoft.Reporting.WebForms;
using Models.DAO;
using Models.FrameWork;
using Models.ViewModel;
using PhongKhamThuY2018.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PhongKhamThuY2018.Controllers
{
    public class MedicalRecordController : BaseController
    {
        //
        // GET: /Prescription/
        public ActionResult Index(string searchString, int page = 1, int pageSize = 3)
        {
            var Cate = new MedicalRecordDAO();

            var model = Cate.ListAllPaging(searchString, page, pageSize);

            ViewBag.searchString = searchString;

            return View(model);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult InsertCustomer(KHACHHANG model)
        {

            var CustomerDAO = new CustomerDAO();

            CustomerDAO.Insert(model);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult InsertPet(THU model)
        {

            var PetDap = new PetDAO();

            PetDap.Insert(model);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetListMedical(string text)
        {

            var CategoryDAO = new MedicalDAO();

            IEnumerable<string> list = CategoryDAO.ListAll().Where(x => x.TENTHUOC.Contains(text)).Select(x => x.TENTHUOC);

            return Json(list, JsonRequestBehavior.AllowGet);
        }


        public JsonResult SearchingListPet(string namePet, string nameKind)
        {
            var dao = new PetDAO();

            List<SearchingPetModel> list = dao.GetListSelectPet(namePet, nameKind);

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSelectedPet(string idPet)
        {
            var dao = new PetDAO();

            int idpet = Int32.Parse(idPet);

            SearchingPetModel pet = dao.GetSelectedPet(idpet);

            return Json(pet, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetListCategoryMedical()
        {
            var dao = new CategoryMedicalDAO();

            List<LOAITHUOC> list = dao.ListAll();

            return Json(list, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetListMedicalByCategory(string idLoaiThuoc)
        {
            var dao = new MedicalDAO();

            int idloaithuoc = Int32.Parse(idLoaiThuoc);

            List<THUOC> medical = dao.ListAllByCategory(idloaithuoc);

            return Json(medical, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetListMedicalForAddItem()
        {
            var dao = new MedicalDAO();

            List<THUOC> medical = dao.ListAll().Take(5).ToList();

            return Json(medical, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMedicalById(string idMedical)
        {
            var dao = new MedicalDAO();

            int idthuoc = Int32.Parse(idMedical);

            AddingMedicalModel medical = dao.GetMedicalById(idthuoc);

            return Json(medical, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult InsertPrescription(TOATHUOC prescription)//TÊN GIỐNG DATA BÊN AJAX
        {

            if (ModelState.IsValid)
            {
                var presDAO = new PrescriptionDAO();


                presDAO.Insert(prescription);

            }
            // TODO: Add insert logic here

            return Json(prescription, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult InsertDetailPrescription(List<CTTOATHUOC> medicals)//TÊN GIỐNG DATA BÊN AJAX
        {
            var presdetailDAO = new PrescriptionDetailDAO();

            foreach (var item in medicals)
            {
                presdetailDAO.Insert(item);
            }

            // TODO: Add insert logic here

            return Json(medicals, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult InsertMedicalRecord(BENHAN medicalRecord)//TÊN GIỐNG DATA BÊN AJAX
        {
            var DAO = new MedicalRecordDAO();

            medicalRecord.NGAYKHAM = DateTime.Now;


            if (DAO.Insert(medicalRecord) >0)
            {
                SetAlert("Thêm bệnh án thành công !!", "success");
            };

           
            // TODO: Add insert logic here

            return Json(medicalRecord, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Report(string id)
        {
            LocalReport lr = new LocalReport();

            string path = Path.Combine(Server.MapPath("~/Report"), "testReport.rdlc");

            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("Index","Home");
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
            "  <PageWidth>8.5in</PageWidth>" +
            "  <PageHeight>11in</PageHeight>" +
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
    }

}