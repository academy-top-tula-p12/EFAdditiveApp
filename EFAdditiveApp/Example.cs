using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAdditiveApp
{
    public class Example
    {
        public static void ConcurrencyExample()
        {
            using (HrsDbContext context = new())
            {
                try
                {
                    Employee? employee = context.Employees.FirstOrDefault();
                    if (employee is not null)
                    {
                        employee.Name = "Billy-Smilly";
                        employee.Salary = 175000m;
                        context.SaveChanges();
                    }
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void LoggersExample()
        {
            //context.GetService<ILoggerFactory>()
            //       .AddProvider(new MyLoggerProvider());


            //Company? company = context.Companies.FirstOrDefault(c => c.Id == 5);
            //Position? position = context.Positions.FirstOrDefault(c => c.Id == 2);

            //Employee filly = new()
            //{
            //    Name = "Filly",
            //    Age = 32,
            //    Salary = 98000,
            //    Company = company,
            //    Position = position,
            //    Discriminator = position!.Title!
            //};

            //context.Employees.Add(filly);
            //context.SaveChanges();
        }

        public static void ViewsExample()
        {
            using (HrsDbContext context = new())
            {


                var employees = context.Employees
                                       .Include(e => e.Company)
                                            .ThenInclude(c => c.Country)
                                       .Include(e => e.Position)
                                       .ToList();

                foreach (var e in employees)
                    Console.WriteLine($"{e.Name} {e.Age} {e.Company?.Title} {e.Company?.Country?.Title} {e.Position?.Title}");

                Console.WriteLine();
                var employeesFull = context.EmployeesFull;
                foreach (var e in employeesFull)
                    Console.WriteLine($"{e.Name} {e.Age} {e.Company} {e.Country} {e.Position}");
            }
        }
    }
}
