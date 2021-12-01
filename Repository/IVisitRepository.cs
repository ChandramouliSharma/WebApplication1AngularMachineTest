using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1AngularMachineTest.Models;

namespace WebApplication1AngularMachineTest.Repository
{
    public interface IVisitRepository
    {
        //Get Employee
        Task<List<Employee>> Getemployees();

        //Add Employee
        Task<int> AddEmployee(Employee employees);

        //Add Visit
        Task<int> AddVisit(Visit visits);

        //Get Visit
        Task<List<Visit>> Getvisits();

        //Update Visit
        Task UpdateVisit(Visit visits);

        //Delete Visit
        Task<Visit> DeleteVisit(int VisitId);
        
    }
}
