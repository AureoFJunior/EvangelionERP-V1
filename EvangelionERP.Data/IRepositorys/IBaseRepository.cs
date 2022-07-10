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
        T Add(T entity);
        T Edit(T entity);
        T Delete(int id);
    }
}
