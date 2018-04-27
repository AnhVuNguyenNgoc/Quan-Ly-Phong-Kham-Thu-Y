using Models.DAO;
using Models.FrameWork;
using Models.ViewModel;
using PhongKhamThuY2018.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhongKhamThuY2018.Controllers
{
    public class PrescriptionController : Controller
    {
        //
        // GET: /Prescription/
        public ActionResult Index()
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
        
    }
}