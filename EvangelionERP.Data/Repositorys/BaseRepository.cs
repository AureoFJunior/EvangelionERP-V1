using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvangelionERP.Data.Repositorys
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly Context Context;
        public BaseRepository([FromServices] Context context)
        {
            Context = context;
        }

        public T Add(T entity)
        {
            Context.Set<T>().Add(entity); return entity;
        }

        public T Delete(int id)
        {
            var q = GetById(id);
            Context.Set<T>().Remove(q); return q;
        }

        public T Edit(T entity)
        {
            Context.Entry<T>(entity).State = EntityState.Modified; return entity;
        }

        public List<T> GetAll()
        {
            return Context.Set<T>().Select(a => a).ToList();
        }

        public T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }
    }
}
