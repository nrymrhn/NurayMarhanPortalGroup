using NurayMarhanPortalGroup.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurayMarhanPortalGroup.Repository.Abstract
{
    public interface IGenericRepository<T> where T:BaseEntity
    {
        bool Add(T item);
        bool Add(List<T> item);
        bool Update(T item);
        bool Remove(T item);
        //bool Remove(int id);
        List<T> GetAll();
        T GetById(int id);
        int Save();
    }
}
