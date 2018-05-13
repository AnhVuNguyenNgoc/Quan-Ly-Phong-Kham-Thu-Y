using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;


namespace Models.DAO
{
   public class MedicalRecordDAO
    {  
        private PhongKhamDbContext dbContext = null;

        public MedicalRecordDAO()
        {
            dbContext = new PhongKhamDbContext();
        }

          public int Insert(BENHAN entity)
         {
             dbContext.BENHAN.Add(entity);
             dbContext.SaveChanges();

             return entity.MABENHAN;
         }

          public List<BENHAN> ListAll(BENHAN entity)
          {
              var result = dbContext.BENHAN.Include("THU").ToList();

              return result;
          }

          public IEnumerable<BENHAN> ListAllPaging(string searchString, int page, int pageSize)
          {
              IQueryable<BENHAN> model = dbContext.BENHAN;

              if (!string.IsNullOrEmpty(searchString))
              {
                  model = model.Where(x => x.THU.TENTHU.Contains(searchString));
              }
              // else if thêm điều kiện

              return model.OrderByDescending(x=>x.NGAYKHAM).ToPagedList(page, pageSize);
          }

    }
}
