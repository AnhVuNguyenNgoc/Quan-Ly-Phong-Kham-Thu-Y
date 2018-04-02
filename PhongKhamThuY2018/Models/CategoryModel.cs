using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CategoryModel
    {
        private PhongKhamDbContext dbContext = null;

        public CategoryModel()
        {
            dbContext = new PhongKhamDbContext();
        }

        public List<Category> ListAll()
        {
            var res = dbContext.Database.SqlQuery<Category>("select * from Category").ToList();

            return res;
        }
    }
}
