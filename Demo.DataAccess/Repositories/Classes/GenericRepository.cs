using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Models.Shared;
using Demo.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories.Classes
{
    public class GenericRepository<T>(ApplicationDbContext dbContext) : IGenericRepository<T> where T : BaseEntity
    {
        int IGenericRepository<T>.Add(T Entity)
        {
            dbContext.Set<T>().Add(Entity);
            return dbContext.SaveChanges();

        }

        public IEnumerable<T> GetAll()
        {
            
                return dbContext.Set<T>().ToList();
       
        }

        T? IGenericRepository<T>.GetById(int id) => dbContext.Set<T>().Find(id);


        int IGenericRepository<T>.Remove(T Entity)
        {
            dbContext.Set<T>().Remove(Entity);
            return dbContext.SaveChanges();
        }

        int IGenericRepository<T>.Update(T Entity)
        {
            dbContext.Set<T>().Update(Entity);
            return dbContext.SaveChanges();
        }
    }
}
