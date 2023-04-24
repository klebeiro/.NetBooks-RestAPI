using AspNetRest.Model.Base;
using AspNetRest.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetRest.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySQLContext _context;
        private DbSet<T> dataSet;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            dataSet = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                dataSet.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(long id)
        {
            var result = dataSet.SingleOrDefault(t => t.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    dataSet.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(long Id)
        {
            return dataSet.Any(t => t.Id.Equals(Id));
        }

        public List<T> FindAll()
        {
            return dataSet.ToList<T>();
        }

        public T FindByID(long Id)
        {
            return dataSet.SingleOrDefault(t => t.Id.Equals(Id));
        }

        public T Update(T item)
        {
            var result = dataSet.SingleOrDefault(t => t.Id.Equals(item.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            } 
            else
            {
                return null;
            }
        }
    }
}
