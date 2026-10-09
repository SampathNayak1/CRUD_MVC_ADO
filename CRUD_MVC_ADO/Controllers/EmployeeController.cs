using CRUD_MVC_ADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_MVC_ADO.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(EmpInfo obj)
        {
            try
            {
                EmpRepositary er=new EmpRepositary();
                er.AddEmployee(obj);
                //return View();
                return RedirectToAction("GetAllEmployeeDetails");
            }
            catch(Exception e)
            {
                ViewBag.Message = e.Message;
                return View();
            }
        }

        public ActionResult GetAllEmployeeDetails()
        {
            EmpRepositary obj=new EmpRepositary();
            ModelState.Clear();
            return View(obj.GetAllEmployeeDetails());
        }

        public ActionResult EditEmpDetails(int id)
        {
            EmpRepositary emp=new EmpRepositary();
            return View (emp.GetAllEmployeeDetails().Find(e => e.EmpId == id)); 
        }

        [HttpPost]
        public ActionResult EditEmpDetails( EmpInfo obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmpRepositary emp = new EmpRepositary();
                    emp.EditEmployee(obj);
                    return RedirectToAction("GetAllEmployeeDetails"); 
                }
                return View();
            }
            catch(Exception e)
            {
                ViewBag.Message = e.Message;
                return View();
            }
           
        }


        public ActionResult DeleteEmpDetails(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmpRepositary emp = new EmpRepositary();
                    emp.DeleteEmployee(id);
                    return RedirectToAction("GetAllEmployeeDetails");
                }
                return View();
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View();
            }
        }


        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
    }
}