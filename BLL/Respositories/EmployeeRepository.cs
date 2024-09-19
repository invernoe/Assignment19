using BLL.Interfaces;
using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Respositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;
        public EmployeeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public int Add(Employee Employee)
        {
            appDbContext.Employees.Add(Employee);
            return appDbContext.SaveChanges();
        }

        public int Delete(Employee Employee)
        {
            appDbContext.Employees.Remove(Employee);
            return appDbContext.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            return appDbContext.Employees.AsNoTracking().ToList();
        }

        public Employee GetById(int id)
        {
            return appDbContext.Employees.Find(id);
        }

        public int Update(Employee Employee)
        {
            appDbContext.Employees.Update(Employee);
            return appDbContext.SaveChanges();
        }
    }
}
