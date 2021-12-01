using System;
using System.Collections.Generic;

namespace WebApplication1AngularMachineTest.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Visit = new HashSet<Visit>();
        }

        public decimal? Empid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public decimal? PhoneNumber { get; set; }
        public decimal? Lid { get; set; }

        public virtual Login L { get; set; }
        public virtual ICollection<Visit> Visit { get; set; }
    }
}
