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
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public IQueryable<Employee> GetEmployeeByAddress(string Address)
        {
            return appDbContext.Employees.Where(e => e.Address.ToLower().Contains(Address.ToLower()));
        }
    }
}
