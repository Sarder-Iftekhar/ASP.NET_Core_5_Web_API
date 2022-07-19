using ASPNetCoreWebAPiDemo.Interface;
using ASPNetCoreWebAPiDemo.Models;
using ASPNetCoreWebAPiDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreWebAPiDemo.Services
{
    public class EmployeeService : IEmployeeService
    {

        //***********************Add Dependency***************************

        //We are going to use DbContext in our service class for this we add dependency in the constructor
        //as you can see in below code.


        private EmpContext _context;
        public EmployeeService(EmpContext context)
        {
            _context = context;
        }

        //*********************************Get All Employee Method************************************


        /// <summary>
        /// get list of all employees
        /// </summary>
        /// <returns></returns>
        public List<Employees> GetEmployeesList()
        {
            List<Employees> empList;
            try
            {
                empList = _context.Set<Employees>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return empList;
        }
        //In the above code, you can see that we are returning a list of employees from this method.
        //To retrieve data from the database, we use the toList() method of DbContext.


        //*****************Get Employee Details By Id Method**************************************


        /// <summary>
        /// get employee details by employee id
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public Employees GetEmployeeDetailsById(int employeeID)
        {
            Employees emp;
            try
            {
                emp = _context.Find<Employees>(employeeID);
            }
            catch (Exception)
            {
                throw;
            }
            return emp;
        }
        //In the above code, you can see that this method takes one parameter, ID.
        //We get an employee object from the database which employee ID matches our parameter id.



        //************************************Save Employee Method***************************

        /// <summary>
        ///  add edit employee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        public ResponseModel SaveEmployee(Employees employeeModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Employees _temp = GetEmployeeDetailsById(employeeModel.EmployeeId);
                if (_temp != null)
                {
                    _temp.Designation = employeeModel.Designation;
                    _temp.EmployeeFirstName = employeeModel.EmployeeFirstName;
                    _temp.EmployeeLastName = employeeModel.EmployeeLastName;
                    _temp.Salary = employeeModel.Salary;
                    _context.Update<Employees>(_temp);
                    model.Messsage = "Employee Update Successfully";
                }
                else
                {
                    _context.Add<Employees>(employeeModel);
                    model.Messsage = "Employee Inserted Successfully"; 
                }
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }


        //As you have seen in the above code, we take the employeeModel as a parameter.
        //Then we called our get details by id method to get details of an employee by id and store In temp variable.

        //Here if employee Id is coming with a model which means we have to update the employee
        //and if the employee id is null or zero then we have added a new employee.

        //If we got data in the temp variable then we assign new data from our parameter model
        //and update employee context and with that, we also assign messages to our response model.

        //And if we got the temp variable is null, then we insert the parameter model as in context
        //and pass the message in the response model.

        //In last, we called the save changes method of context to save all changes like insert update
        //and set Is Success property of response model to true. If any error occurs,
        //then we update is success to false and pass error message in message property.





        //******************************Delete Employee Method*******************
        /// <summary>
        /// delete employees
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public ResponseModel DeleteEmployee(int employeeId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Employees _temp = GetEmployeeDetailsById(employeeId);
                if (_temp != null)
                {
                    _context.Remove<Employees>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Employee Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Employee Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        //In the delete method, we take employee id as a parameter. And call service method get detail by id
        //forget employee details.

       // If an employee is found then we remove this employee by calling remove method of context,
       // else we return the model with Employee not found


    }
}
