using AJAXtable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AJAXtable.Controllers
{
    public class HomeController : Controller
    {


        List<EmployeeModel> listEmployee = new List<EmployeeModel>() {

            new EmployeeModel()
            {
            ID = 1,
                Name = "Pham Duy An",
                Salary = 2000000,
                Status = true
            },
            new EmployeeModel()
            {
            ID = 2,
                Name = "Pham Duy Anh",
                Salary = 3300000,
                Status = true
            },

            new EmployeeModel()
            {
            ID = 3,
                Name = "Pham Duy Hanh",
                Salary = 5500000,
                Status = true
            },
            new EmployeeModel()
            {
            ID = 4,
                Name = "Pham Duy HA",
                Salary = 2440000,
                Status = true
            },
            new EmployeeModel()
            {
            ID = 5,
                Name = "Pham Duy Nam",
                Salary = 5550000,
                Status = true
            },

            new EmployeeModel()
            {
            ID = 6,
                Name = "Pham Duy Hung",
                Salary = 5500000,
                Status = true
            },
            new EmployeeModel()
            {
            ID = 7,
                Name = "Pham Duy Hoanh",
                Salary = 99990,
                Status = true
            },
            new EmployeeModel()
            {
            ID = 8,
                Name = "Pham Duy Huy",
                Salary = 88800,
                Status = true
            },
            new EmployeeModel()
            {
            ID = 9,
                Name = "Pham Duy han",
                Salary = 5550000,
                Status = true
            },

            new EmployeeModel()
            {
            ID = 10,
                Name = "Pham Duy vinh",
                Salary = 55222000,
                Status = true
            },

        };


        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult LoadData(int page, int pageSize=3)
        {
            var model = listEmployee.Skip((page - 1) * pageSize).Take(pageSize);
            int totalRow = listEmployee.Count();
            return Json(new
            {
                data = model,
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult Update(string model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            EmployeeModel employee = serializer.Deserialize<EmployeeModel>(model);
            // save db
            var entity = listEmployee.Single(x => x.ID == employee.ID);
            entity.Salary = employee.Salary;

            return Json(new
            {
                status = true
            });
        }
    }
}