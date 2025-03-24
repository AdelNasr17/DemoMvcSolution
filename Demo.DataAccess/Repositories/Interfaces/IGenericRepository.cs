using Demo.DataAccess.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        void Add(T Entity);
        IEnumerable<T> GetAll();
        T? GetById(int id);
        void Remove(T Entity);
        void Update(T Entity);
    }
}
