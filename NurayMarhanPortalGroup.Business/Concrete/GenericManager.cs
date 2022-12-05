using NurayMarhanPortalGroup.Business.Abstract;
using NurayMarhanPortalGroup.Entities.Entities;
using NurayMarhanPortalGroup.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurayMarhanPortalGroup.Business.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : BaseEntity
    {
    
        private readonly IGenericRepository<T> _repository;

        public GenericManager(IGenericRepository<T> repository)
        {
            _repository = repository;
        }
        public bool Add(T item)
        {
            return _repository.Add(item);
        }

        public bool Add(List<T> item)
        {
            return _repository.Add(item);
        }

        public List<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool Remove(T item)
        {
            if (item == null) return false;
            else
                return _repository.Remove(item);
        }

        //public bool Remove(int id)
        //{
        //    if (id <= 0) return false;
        //    else
        //        return _repository.Remove(id);
        //}

        public bool Update(T item)
        {
            if (item == null) return false;
            else
                return _repository.Update(item);
        }
    }
}
