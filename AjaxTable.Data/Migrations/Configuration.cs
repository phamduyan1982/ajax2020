namespace AjaxTable.Data.Migrations
{
    using AjaxTable.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AjaxTable.Data.EmployeeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AjaxTable.Data.EmployeeDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Employees.AddOrUpdate(
                new Employee {Name= "An",Salary= 35000,CreatedDate= DateTime.Now,Status= true},
                new Employee { Name = "Anh", Salary = 355500, CreatedDate = DateTime.Now, Status = true },
                new Employee { Name = "hAnh", Salary = 44000, CreatedDate = DateTime.Now, Status = true },

                new Employee { Name = "hung", Salary = 54500, CreatedDate = DateTime.Now, Status = true },
                new Employee { Name = "Huy", Salary = 66600, CreatedDate = DateTime.Now, Status = true },
                new Employee { Name = "Hoang", Salary = 999900, CreatedDate = DateTime.Now, Status = true },

                new Employee { Name = "Thuy", Salary = 454, CreatedDate = DateTime.Now, Status = true },
                new Employee { Name = "Hoa", Salary = 6765, CreatedDate = DateTime.Now, Status = true },
                new Employee { Name = "Dung", Salary = 6576700, CreatedDate = DateTime.Now, Status = true },

                new Employee { Name = "Vu", Salary = 54500, CreatedDate = DateTime.Now, Status = true },
                new Employee { Name = "Hoan", Salary = 663300, CreatedDate = DateTime.Now, Status = true },
                new Employee { Name = "Hang", Salary = 776, CreatedDate = DateTime.Now, Status = true }
                );
            context.SaveChanges();
        }
    }
}
