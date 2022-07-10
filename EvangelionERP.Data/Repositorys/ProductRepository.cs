using EvangelionERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvangelionERP.Data.Repositorys
{
    public class ProductRepository : BaseRepository<ProductModel>
    {
        private readonly Context Context;
        public ProductRepository([FromServices] Context context) : base(context) => Context = context;

        #region Add
        public ProductModel AddProduct(ProductModel product)
        {
            try
            {
                return Add(product);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Edit
        public ProductModel EditProduct(ProductModel product)
        {
            try
            {
                return Edit(product);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Delete
        public ProductModel DeleteProduct(int cod)
        {
            try
            {
                return Delete(cod);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Searchs
        public List<ProductModel> GetProducts()
        {
            try
            {
                return GetAll();
            }
            catch (Exception ex) { throw ex.InnerException; };
        }

        public ProductModel GetProduct(int cod)
        {
            try
            {
                return GetById(cod);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion
    }
}
