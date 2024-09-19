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
    public class DepartmentRepository : GenericRepository<Department>, IEmployeeRepository
    {
        public DepartmentRepository(AppDbContext appDbContext) : base(appDbContext)
        { 
        }
    }
}
