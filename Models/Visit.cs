using System;
using System.Collections.Generic;

namespace WebApplication1AngularMachineTest.Models
{
    public partial class Visit
    {
        public decimal VisitId { get; set; }
        public string CustName { get; set; }
        public string ContactPerson { get; set; }
        public decimal? ContactNo { get; set; }
        public string InterestProduct { get; set; }
        public string VisitSubject { get; set; }
        public string Description { get; set; }
        public DateTime? VisitDatetime { get; set; }
        public bool? IsDisabled { get; set; }
        public bool? IsDeleted { get; set; }
        public decimal? Empid { get; set; }

        public virtual Employee Emp { get; set; }
    }
}
