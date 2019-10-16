
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepositoryAndUnitOfWork.UnitOfWork;
using DataAccessLayer.EntityFrameWorkModels;

namespace GenericRepositoryAndUnitOfWorkConsole
{
    class Program
    {
        static IGenericUoW _employeeUnitOfWork = new GenericUoW(new EmployeeDBEntities());
        static void Main(string[] args)
        {
            // Get Employees
            Console.WriteLine("Getting a many employees");
            List<Employee> getEmployees = _employeeUnitOfWork.Repository<Employee>().GetAll().ToList();
            foreach (var eachEmployee in getEmployees)
            {
                Console.WriteLine(eachEmployee.FirstName+ " "+ eachEmployee.LastName+" ("+eachEmployee.Gender+")");
            }
            Console.WriteLine("");
            // Get A single employee
            Console.WriteLine("Getting a single employee");
            Employee getEmployee = _employeeUnitOfWork.Repository<Employee>().Get(u => u.ID == 7);
            Console.WriteLine(getEmployee.FirstName + " " + getEmployee.LastName + " (" + getEmployee.Gender + ")");
            Console.WriteLine("");

            // Adding a new Employee
            Employee newEmployee = new Employee()
            {
                FirstName = "Thom",
                LastName = "Banda",
                Gender = "Female",
                Salary = 40000
            };
            _employeeUnitOfWork.Repository<Employee>().Add(newEmployee);
            _employeeUnitOfWork.SaveChanges();
            Console.WriteLine("New Employee added successfully"+ newEmployee.FirstName + " " + newEmployee.LastName + " (" + newEmployee.Gender + ")");
            Console.WriteLine("");
            Console.ReadLine();
        }
    }
}
