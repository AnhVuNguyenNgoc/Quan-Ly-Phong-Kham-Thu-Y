using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
   public class PrescriptionDetailDAO
    {
        private PhongKhamDbContext dbContext = null;

        public PrescriptionDetailDAO()
        {
            dbContext = new PhongKhamDbContext();
        }

        public int Insert(CTTOATHUOC entity)
        {
            dbContext.CTTOATHUOC.Add(entity);
            dbContext.SaveChanges();

            return entity.MATOA;
        }
       
    }
}
