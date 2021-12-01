using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1AngularMachineTest.Models;

namespace WebApplication1AngularMachineTest.Repository
{
    public interface ILoginRepository
    {
        public Login validateUser(string uname, string pwd);
    }
}
