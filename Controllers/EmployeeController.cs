using ASPNetCoreWebAPiDemo.Interface;
using ASPNetCoreWebAPiDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreWebAPiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        //n the Constructor of our controller, we implement dependency injection for our service.

        IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService service)
        {
            _employeeService = service;
        }

        //For this controller, we are using routing with action methods.
        //For example, if the user called Employee with Get method then it will call Get List Of All Employee Method
        //and if the user called Employee/{id} with Get then it will call Get Employee Details By Id Method
        //and If user called Employee with POST method then it will call Save Employee Method
        //and same as if the user called Employee with Delete method then it will call Delete Employee Method

        //*************************************Get List Of All Employee Method*********************
        /// <summary>
        /// get all employess
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var employees = _employeeService.GetEmployeesList();
                if (employees == null) return NotFound();
                return Ok(employees);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //in the above method, we call a method from our service and assign it to the variable.
        //If the variable is not null then we return ok status with this variable, else we return not found.

        //*********************Get Employee Details By Id Method*************************
        /// <summary>
        /// get employee details by  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetEmployeesById(int id)
        {
            try
            {
                var employees = _employeeService.GetEmployeeDetailsById(id);
                if (employees == null) return NotFound();
                return Ok(employees);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //*************************Save Employee Method****************
        /// <summary>
        /// save employee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveEmployees(Employees employeeModel)
        {
            try
            {
                var model = _employeeService.SaveEmployee(employeeModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //*************Delete Employee Method*****************
        /// <summary>
        /// delete employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var model = _employeeService.DeleteEmployee(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }




    }
}
