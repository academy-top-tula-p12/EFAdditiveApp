using EFAdditiveApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System.Linq;

DatabaseCreate.Create();

using(HrsDbContext context = new())
{
    Employee? employee = context.Employees.FirstOrDefault();
    if (employee is not null)
    {
        //employee.Name = "Ivan";
        //context.SaveChanges();

        //employee.Name = "Vanya";
        //context.SaveChanges();

        //context.Employees.Remove(employee);
        //context.SaveChanges();
    }
}


