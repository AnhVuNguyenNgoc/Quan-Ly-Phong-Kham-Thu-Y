using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class UserDAO
    {
         private PhongKhamDbContext dbContext = null;

         public UserDAO()
        {
            dbContext = new PhongKhamDbContext();
        }

        public int Insert(NGUOIDUNG entity)
         {
             dbContext.NGUOIDUNG.Add(entity);
             dbContext.SaveChanges();

             return entity.ID;
         }

        public NGUOIDUNG GetById(string username)
        {
            return dbContext.NGUOIDUNG.SingleOrDefault(x => x.UserName == username);
        }

        public bool Login(string username, string pass)
        {
            var result = dbContext.NGUOIDUNG.Count(x => x.UserName == username && x.PassWord == pass);

            if(result >0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
