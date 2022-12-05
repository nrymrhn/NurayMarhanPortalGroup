using NurayMarhanPortalGroup.Entities.Entities;
using NurayMarhanPortalGroup.Repository.Abstract;
using NurayMarhanPortalGroup.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace NurayMarhanPortalGroup.Repository.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ProjectDbContext _context;

        public GenericRepository(ProjectDbContext context)
        {
            _context = context;
        }
        public bool Add(T item)
        {
            try
            {
                _context.Set<T>().Add(item);
                return Save() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Add(List<T> item)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope()) 
                {
                    _context.Set<T>().AddRange(item);
                    ts.Complete();  
                    return Save() > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public bool Remove(T item)
        {
            _context.Set<T>().Remove(item);
            return Save() > 0;
        }

        //public bool Remove(int id)
        //{
        //    try
        //    {
        //        using (TransactionScope ts = new TransactionScope())
        //        {
        //            T item = GetById(id);
        //            item.Status = false;
        //            ts.Complete(); 
        //            var update= Update(item);
        //            if (update)
        //            {
        //               ts.Complete();
                      
        //            }
                    
        //            return update;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        public bool Update(T item)
        {
            try
            {
                _context.Set<T>().Update(item);
                return Save() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
    }
}
