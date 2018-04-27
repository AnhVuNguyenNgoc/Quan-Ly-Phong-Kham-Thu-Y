using Models.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
   public class CustomerDAO
    {
          private PhongKhamDbContext dbContext = null;

          public CustomerDAO()
        {
            dbContext = new PhongKhamDbContext();
        }

          public int Insert(KHACHHANG entity)
         {
             dbContext.KHACHHANG.Add(entity);
             dbContext.SaveChanges();

             return entity.MAKH;
         }

        //  public bool Update(THUOC entity)
        //{
        //    try
        //    {
        //        var cat = dbContext.THUOC.Find(entity.MATHUOC);
        //        cat.TENTHUOC = entity.TENTHUOC;
        //        cat.SOLUONG = entity.SOLUONG;
        //        cat.TINHTRANG = entity.TINHTRANG;

        //        dbContext.SaveChanges();

        //        return true;
        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }
           
           
        //}
        //  public IEnumerable<THUOC> ListAllPaging(string searchString, int page, int pageSize)
        //{
        //    IQueryable<THUOC> model = dbContext.THUOC;

        //    if(!string.IsNullOrEmpty(searchString))
        //    {
        //        model = model.Where(x => x.TENTHUOC.Contains(searchString));
        //    }
        //   // else if thêm điều kiện

        //    return model.OrderByDescending(X=>X.NGAYNHAP).ToPagedList(page, pageSize);
        //}

        //  public THUOC ViewDetail(int id)
        //{
        //    return dbContext.THUOC.Find(id);
        //}


        //  public List<THUOC> ListAll()
        //{
        //    var res = dbContext.Database.SqlQuery<THUOC>("select * from THUOC").ToList();

        //    return res;
        //}
    }
}
