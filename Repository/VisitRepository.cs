using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1AngularMachineTest.Models;

namespace WebApplication1AngularMachineTest.Repository
{
    public class VisitRepository : IVisitRepository
    {
        //database
        STMSContext db;

        //Constructor dependency injection
        public VisitRepository(STMSContext _db)
        {
            db = _db;
        }

        //crud operation

        #region GetEmployee
        public async Task<List<Employee>> Getemployees()
        {

            if (db != null)
            {
                return await db.Employee.ToListAsync();
            }
            return null;
        }
        #endregion

        #region Add Employee
        public async Task<int> AddEmployee(Employee employees)
        {
            if (db != null)
            {
                await
                db.Employee.AddAsync(employees);
                await db.SaveChangesAsync();
                return (int)employees.Empid;
            }
            return 0;
        }

        #endregion

        #region GetVisit
        public async Task<List<Visit>> Getvisits()
        {
            if (db != null)
            {
                return await db.Visit.ToListAsync();
            }
            return null;
        }
        #endregion

        #region Add Visit
        public async Task<int> AddVisit(Visit visits)
        {
            if (db != null)
            {
                await
                db.Visit.AddAsync(visits);
                await db.SaveChangesAsync();
                return (int)visits.VisitId;
            }
            return 0;
        }



        #region Update Visit
        public async Task UpdateVisit(Visit visits)
        {
            if (db != null)
            {
                db.Visit.Update(visits);
                await db.SaveChangesAsync();
            }
        }
        #endregion

        #region Delete Visit
        public async Task<Visit> DeleteVisit(int VisitId)
        {
            if (db != null)
            {
                Visit dbVisit = db.Visit.Find(VisitId);
                db.Visit.Remove(dbVisit);
                db.SaveChanges();
                return (dbVisit);
            }
            return null;
        }
        #endregion
    }
}

  
