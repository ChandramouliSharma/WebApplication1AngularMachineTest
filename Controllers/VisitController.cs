using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1AngularMachineTest.Models;
using WebApplication1AngularMachineTest.Repository;

namespace WebApplication1AngularMachineTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        //Constructor Dependency Injection for VisitRepository

        private IConfiguration _config;
        IVisitRepository visitRepository;

        public VisitController(IConfiguration config, IVisitRepository _e)
        {
            _config = config;
            this.visitRepository = _e;
        }

        #region GetEmployees
        [HttpGet]
        [Route("GetEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = await visitRepository.Getemployees();
                if (employees == null)
                {
                    return NotFound();
                }
                return Ok(employees);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region New Employee

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] Employee model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    int employeeId = await visitRepository.AddEmployee(model);
                    if (employeeId > 0)
                    {
                        return Ok(employeeId);
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region add visit

       
        [HttpPost]
        [Route("AddVisit")]
        public async Task<IActionResult> AddVisit([FromBody] Visit model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    int visitId = await visitRepository.AddVisit(model);
                    if (visitId > 0)
                    {
                        return Ok(visitId);
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
#endregion

        #region Update Visits
        [HttpPost]
        [Route("UpdateVisit")]
        public async Task<IActionResult> UpdateVisit([FromBody] Visit model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await visitRepository.UpdateVisit(model);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Delete visit

        [HttpDelete]
        [Route("DeleteVisit")]
        public async Task<IActionResult> DeleteVisit(int VisitId)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await visitRepository.DeleteVisit(VisitId);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();

        }
        #endregion

        #region GetVisits
        [HttpGet]
        [Route("GetVisits")]
        public async Task<IActionResult> GetVisits()
        {
            try
            {
                var views = await visitRepository.Getvisits();
                if (views == null)
                {
                    return NotFound();
                }
                return Ok(views);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

    }
}
