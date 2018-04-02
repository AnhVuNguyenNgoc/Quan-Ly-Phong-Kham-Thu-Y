using Models.FrameWork;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class AccountModel
    {

        private PhongKhamDbContext dbContext = null;

        public AccountModel()
        {
            dbContext = new PhongKhamDbContext();
        }

        public bool Login(string username, string pass)
        {
            object[] Sqlparams =
            {
             new SqlParameter("@UserName",username),
             new SqlParameter("@Pass",pass)
             };

            var res = dbContext.Database.SqlQuery<bool>("SP_ACCOUNT_LOGIN @UserName,@Pass", Sqlparams).SingleOrDefault();

            return res;
        }
    }
}
