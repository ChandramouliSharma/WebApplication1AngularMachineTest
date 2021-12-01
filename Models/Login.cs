using System;
using System.Collections.Generic;

namespace WebApplication1AngularMachineTest.Models
{
    public partial class Login
    {
        public Login()
        {
            Employee = new HashSet<Employee>();
        }

        public decimal Lid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
