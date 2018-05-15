using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhongKhamThuY2018.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var cusDAO = new CustomerDAO();

            var totalCus = cusDAO.ListAll().Count;
            ViewBag.totalKhach = totalCus;


            var petDAO = new PetDAO();

            var totalThu = petDAO.ListAll().Count;
            ViewBag.totalThu = totalThu;


            var medicalDAO = new MedicalDAO();

            var totalThuoc = medicalDAO.ListAll().Count;
            ViewBag.totalThuoc = totalThuoc;
            //------LINE CHART ---

            var DAO = new MedicalRecordDAO();

            var totalBenhAn = DAO.ListAll().Count;
            ViewBag.totalBenhAn = totalBenhAn;

            var listThu = DAO.ListAll();


            List<int> repartations = new List<int>();

            var Datetimes = listThu.Select(x => x.NGAYKHAM).Distinct().OrderBy(x=>x.Day);

            List<String> Date = new List<String>();

            foreach (var item in Datetimes)
            {
                Date.Add("Ngày "+item.Day.ToString());
            }

            foreach (var item in Datetimes)
            {
                repartations.Add(listThu.Count(x => x.NGAYKHAM == item));
            }

            var rep = repartations;

            ViewBag.Date = Date;
            ViewBag.Rep = repartations.ToList(); //ko co toList dc k o


            return View();
        }

    }
}