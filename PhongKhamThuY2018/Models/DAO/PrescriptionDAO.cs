using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class PrescriptionDAO
    {
          private PhongKhamDbContext dbContext = null;

          public PrescriptionDAO()
        {
            dbContext = new PhongKhamDbContext();
        }

        public int Insert(TOATHUOC entity)
        {
            dbContext.TOATHUOC.Add(entity);
            dbContext.SaveChanges();

            return entity.MATOATHUOC;
        }
    }
}
