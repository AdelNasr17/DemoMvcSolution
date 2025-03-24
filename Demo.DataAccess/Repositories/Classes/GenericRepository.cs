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
        void IGenericRepository<T>.Add(T Entity) => dbContext.Set<T>().Add(Entity);

        public IEnumerable<T> GetAll()=> dbContext.Set<T>().ToList();
       

        T? IGenericRepository<T>.GetById(int id) => dbContext.Set<T>().Find(id);


        void IGenericRepository<T>.Remove(T Entity) => dbContext.Set<T>().Remove(Entity);
      

        void IGenericRepository<T>.Update(T Entity) => dbContext.Set<T>().Update(Entity);
      
    }
}
