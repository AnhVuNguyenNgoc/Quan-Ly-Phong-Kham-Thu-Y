using Models.FrameWork;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using PhongKhamThuY2018.Models;

namespace Models.DAO
{
    public class PetDAO
    {
          private PhongKhamDbContext dbContext = null;

          public PetDAO()
        {
            dbContext = new PhongKhamDbContext();
        }

          public int Insert(THU entity)
         {
             dbContext.THU.Add(entity);
             dbContext.SaveChanges();

             return entity.MATHU;
         }

          public List<SearchingPetModel> GetListSelectPet(string namePet, string nameKind)
          {
              var query = (from thu in dbContext.THU
                           join khach in dbContext.KHACHHANG
                               on thu.MAKH equals khach.MAKH
                               where thu.TENTHU.ToLower().Contains(namePet.ToLower()) && thu.LOAI.ToLower().Contains(nameKind.ToLower())
                           select new SearchingPetModel()
                           {
                               TENKH = khach.TEN,
                               MAKH = thu.MAKH,
                               LOAI = thu.LOAI,
                               MAULONG = thu.MAULONG,
                               TENTHU = thu.TENTHU,
                               MATHU = thu.MATHU,
                               GIOITINH = thu.GIOITINH
                           }).ToList();
              return query;
          }

          public SearchingPetModel GetSelectedPet(int idPet)
          {
              var query = (from thu in dbContext.THU
                           join khach in dbContext.KHACHHANG
                            on thu.MAKH equals khach.MAKH
                               where thu.MATHU.Equals(idPet)
                           select new SearchingPetModel()
                           {
                               TENKH = khach.TEN,
                               MAKH = thu.MAKH,
                               LOAI = thu.LOAI,
                               MAULONG = thu.MAULONG,
                               TENTHU = thu.TENTHU,
                               MATHU = thu.MATHU,
                               GIOITINH = thu.GIOITINH,
                               SDT=khach.SDT,
                               DIACHIKH=khach.DIACHI,
                               GIOITINHKH=khach.GIOITINH
                           }).SingleOrDefault();
              return query;
          }
    }
}
