using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Models.DepartmentModel;
using Demo.DataAccess.Models.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories.Shared
{
    public class GenericRepository<T>(ApplicationDbContext dbContext) : IGenericRepository<T> where T : BaseEntity
    {
        void IGenericRepository<T>.Add(T Entity) => dbContext.Set<T>().Add(Entity);

        public IEnumerable<T> GetAll() 
           {

            return dbContext.Set<T>().Where(e=> !e.IsDeleted).ToList();
           }


        T? IGenericRepository<T>.GetById(int? id) => dbContext.Set<T>().Find(id);


        void IGenericRepository<T>.Remove(T Entity)
        {
            Entity.IsDeleted = true;
            dbContext.Set<T>().Update(Entity);
            dbContext.SaveChanges();
        }


        void IGenericRepository<T>.Update(T Entity) => dbContext.Set<T>().Update(Entity);


        public IQueryable<T> GetAllQueryable()
        {
            return dbContext.Set<T>();
        }
    }
}
