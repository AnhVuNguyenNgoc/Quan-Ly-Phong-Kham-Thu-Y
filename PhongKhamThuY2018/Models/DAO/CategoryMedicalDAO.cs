using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
