using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PagedList;

namespace Models.DAO
{
    public class CategoryDAO
    {
          private PhongKhamDbContext dbContext = null;

          public CategoryDAO()
        {
            dbContext = new PhongKhamDbContext();
        }

        public int Insert(Category entity)
         {
             dbContext.Category.Add(entity);
             dbContext.SaveChanges();

             return entity.Id;
         }

        public bool Update(Category entity)
        {
            try
            {
                var cat = dbContext.Category.Find(entity.Id);
                cat.Name = entity.Name;
                cat.SoLuong = entity.SoLuong;
                cat.Status = entity.Status;

                dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
           
        }
        public IEnumerable<Category> ListAllPaging(string searchString,int page,int pageSize)
        {
             IQueryable<Category> model=dbContext.Category;

            if(!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
           // else if thêm điều kiện

            return model.OrderByDescending(X=>X.NgayNhap).ToPagedList(page, pageSize);
        }

        public Category ViewDetail(int id)
        {
            return dbContext.Category.Find(id);
        }


        public List<Category> ListAll()
        {
            var res = dbContext.Database.SqlQuery<Category>("select * from Category").ToList();

            return res;
        }
    }
}
