using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1AngularMachineTest.Models;

namespace WebApplication1AngularMachineTest.Repository
{
    public class LoginRepository: ILoginRepository
    {
        //database
        STMSContext _db;

        //Constructor dependency injection
        public LoginRepository(STMSContext db)
        {
            _db = db;
        }

        #region Validate User
        public Login validateUser(string uname, string pwd)
        {
            Console.WriteLine(uname, pwd);
            if (_db != null)
            {
                Login dbuser = _db.Login.FirstOrDefault(em => em.Username == uname && em.Password == pwd);
                if (dbuser != null)
                {
                    return dbuser;
                }
            }
            return null;
        }
        #endregion
    }
}
