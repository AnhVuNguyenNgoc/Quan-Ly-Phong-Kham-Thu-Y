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

        public int Insert(User entity)
         {
             dbContext.User.Add(entity);
             dbContext.SaveChanges();

             return entity.Id;
         }

        public User GetById(string UserName)
        {
            return dbContext.User.SingleOrDefault(x=>x.UserName==UserName) ;
        }

        public bool Login(string username, string pass)
        {
            var result = dbContext.User.Count(x => x.UserName == username && x.PassWord == pass);

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
