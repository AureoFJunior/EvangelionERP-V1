using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvangelionERP.Data.Repositorys
{
    public interface IBaseRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Edit(T entity);
        void Delete(int id);
    }
}
