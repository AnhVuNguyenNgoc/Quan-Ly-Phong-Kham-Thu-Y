using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PagedList;
using Models.ViewModel;

namespace Models.DAO
{
    public class MedicalDAO
    {
        private PhongKhamDbContext dbContext = null;

        public MedicalDAO()
        {
            dbContext = new PhongKhamDbContext();
        }

        //có duy nhật hay không ? 
        public bool isUnique(THUOC entity)
        {
            THUOC  model = dbContext.THUOC.Where(x => x.TENTHUOC.Contains(entity.TENTHUOC)).FirstOrDefault();

            if (model.TENTHUOC != null)
            {
                return false;
            }
            return true;
             
        }

        public int Insert(THUOC entity)
        {
            dbContext.THUOC.Add(entity);
            dbContext.SaveChanges();

            return entity.MATHUOC;
        }

        public bool Update(THUOC entity)
        {
            try
            {
                var cat = dbContext.THUOC.Find(entity.MATHUOC);

                cat.TENTHUOC = entity.TENTHUOC;
                cat.SOLUONG = entity.SOLUONG;
                cat.TINHTRANG = entity.TINHTRANG;
                cat.HUONGDANSUDUNG = entity.HUONGDANSUDUNG;
                cat.MADONVI = entity.MADONVI;
                cat.MALOAITHUOC = entity.MALOAITHUOC;

                dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }
        public IEnumerable<THUOC> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<THUOC> model = dbContext.THUOC;

            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TENTHUOC.Contains(searchString));
            }
            // else if thêm điều kiện

            return model.OrderByDescending(X => X.NGAYNHAP).ToPagedList(page, pageSize);
        }

        public THUOC ViewDetail(int id)
        {
            dbContext.Configuration.ProxyCreationEnabled = false;
            return dbContext.THUOC.Find(id);
        }



        public AddingMedicalModel GetMedicalById(int id)
          {
              dbContext.Configuration.ProxyCreationEnabled = false;

              var query = (from thuoc in dbContext.THUOC
                           join donvi in dbContext.DONVITHUOC
                           on thuoc.MADONVI equals donvi.MADONVI
                           where thuoc.MATHUOC == id
                           select new AddingMedicalModel
                           {
                               MATHUOC=thuoc.MATHUOC, TENTHUOC=thuoc.TENTHUOC,SOLUONG=thuoc.SOLUONG, HANSUDUNG=thuoc.HANSUDUNG,
                               DONGIA=thuoc.DONGIA,HUONGDANSUDUNG=thuoc.HUONGDANSUDUNG,TENDONVI=thuoc.DONVITHUOC.TENDONVI
                           }).SingleOrDefault();
              return query;
          }



        public List<THUOC> ListAll()
        {
            var res = dbContext.Database.SqlQuery<THUOC>("select * from THUOC").ToList();

            return res;
        }
        public List<THUOC> ListAllByCategory(int idCategory)
        {
            dbContext.Configuration.ProxyCreationEnabled = false;
            var query = (from thuoc in dbContext.THUOC
                         where thuoc.MALOAITHUOC == idCategory
                         select thuoc).ToList();
            return query;
        }

        public List<DONVITHUOC> ListAllThuoc()
        {
            var res = dbContext.Database.SqlQuery<DONVITHUOC>("select * from DONVITHUOC").ToList();

            return res;
        }

        public List<LOAITHUOC> ListAllLoaiThuoc()
        {
            var res = dbContext.Database.SqlQuery<LOAITHUOC>("select * from LOAITHUOC").ToList();

            return res;
        }
    }
}
