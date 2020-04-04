﻿using AjaxTable.Data;
using AjaxTable.Data.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AJAXtable.Controllers
{
    public class HomeController : Controller
    {
        private EmployeeDbContext _context;
        public HomeController()
        {
            _context = new EmployeeDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult LoadData(int page, int pageSize=3)
        {
            var model = _context.Employees.
                OrderByDescending(x=>x.CreatedDate).
                Skip((page - 1) * pageSize).Take(pageSize);
            int totalRow = _context.Employees.Count();
            return Json(new
            {
                data = model,
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult SaveData(string strEmployee)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Employee employee = serializer.Deserialize<Employee>(strEmployee);
            bool status = false;
            string message = string.Empty;
            // add new employee if id = 0
            if(employee.ID==0)
            {
                employee.CreatedDate = DateTime.Now; 
                _context.Employees.Add(employee);
                try
                {
                    _context.SaveChanges();
                    status = true;
                }
                catch (Exception ex)
                {
                    status = false;
                    message = ex.Message;
                }
            }
            else
            {
                // update existing DB
                // save db
                var entity = _context.Employees.Find(employee.ID);
                entity.Salary = employee.Salary;
                entity.Name = employee.Name;
                entity.Status = employee.Status;
                try
                {
                    _context.SaveChanges();
                    status = true;
                }
                catch(Exception ex)
                {
                    status = false;
                    message = ex.Message;
                }
            }            
            return Json(new
            {
                status = status,
                message= message
            });
        }
        //
        [HttpPost]
        public JsonResult Update(string model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Employee employee = serializer.Deserialize<Employee>(model);
            // save db
            var entity = _context.Employees.Find(employee.ID);
            entity.Salary = employee.Salary;

            return Json(new
            {
                status = true
            });
        }
    }
}