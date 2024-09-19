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
    public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
    {
        private protected readonly AppDbContext appDbContext;
        public GenericRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public int Add(T T)
        {
            appDbContext.Add(T);
            return appDbContext.SaveChanges();
        }

        public int Delete(T T)
        {
            appDbContext.Remove(T);
            return appDbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return appDbContext.Set<T>().AsNoTracking().ToList();
        }

        public T GetById(int id)
        {
            return appDbContext.Set<T>().Find(id);
        }

        public int Update(T T)
        {
            appDbContext.Set<T>().Update(T);
            return appDbContext.SaveChanges();
        }
    }
}
