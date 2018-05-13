using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PagedList;



namespace Models.DAO
{
    public class CategoryMedicalDAO
    {
        
          private PhongKhamDbContext dbContext = null;

          public CategoryMedicalDAO()
        {
            dbContext = new PhongKhamDbContext();
        }

          public int Insert(KHACHHANG entity)
         {
             dbContext.KHACHHANG.Add(entity);
             dbContext.SaveChanges();

             return entity.MAKH;
         }


          public List<LOAITHUOC> ListAll()
          {
              var res = dbContext.Database.SqlQuery<LOAITHUOC>("select * from LOAITHUOC").ToList();

              return res;
          }


        public int Insert(LOAITHUOC entity)
        {
            dbContext.LOAITHUOC.Add(entity);
            dbContext.SaveChanges();

            return entity.MALOAITHUOC;
        }

        public bool Update(LOAITHUOC entity)
        {
            try
            {
                var cat = dbContext.LOAITHUOC.Find(entity.MALOAITHUOC);

                cat.TENLOAITHUOC = entity.TENLOAITHUOC;
              
                cat.TINHTRANG = entity.TINHTRANG;
             
                dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public IEnumerable<LOAITHUOC> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<LOAITHUOC> model = dbContext.LOAITHUOC;

            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TENLOAITHUOC.Contains(searchString));
            }
            // else if thêm điều kiện

            return model.OrderByDescending(X => X.TENLOAITHUOC).ToPagedList(page, pageSize);
        }

        public LOAITHUOC ViewDetail(int id)
        {
            dbContext.Configuration.ProxyCreationEnabled = false;
            return dbContext.LOAITHUOC.Find(id);
        }

     


        //public List<THUOC> ListAllByCategory(int idCategory)
        //{
        //    dbContext.Configuration.ProxyCreationEnabled = false;
        //    var query = (from thuoc in dbContext.THUOC
        //                 where thuoc.MALOAITHUOC == idCategory
        //                 select thuoc).ToList();
        //    return query;
        //}

        //public List<DONVITHUOC> ListAllThuoc()
        //{
        //    var res = dbContext.Database.SqlQuery<DONVITHUOC>("select * from DONVITHUOC").ToList();

        //    return res;
        //}

        //public List<LOAITHUOC> ListAllLoaiThuoc()
        //{
        //    var res = dbContext.Database.SqlQuery<LOAITHUOC>("select * from LOAITHUOC").ToList();

        //    return res;
        //}

    }
}
