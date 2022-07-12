using EvangelionERP.Data.Repositorys;
using EvangelionERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvangelionERP.Data.Services
{
    public class ProductService
    {
        private readonly Context Context;
        private readonly ProductRepository ProductRepository;

        public ProductService([FromServices] Context context)
        {
            Context = context;
            ProductRepository = new ProductRepository(context);
        }

        #region Add
        public ProductModel AddProduct(ProductModel product)
        {
            try
            {
                return ProductRepository.AddProduct(product);
            }   
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Edit
        public List<ProductModel> EditProduct(OrderProductModel[] orderProducts)
        {
            try
            {
                List<ProductModel> products = new List<ProductModel>();
                ProductModel verify = new ProductModel();

                foreach (var orderProduct in orderProducts)
                {
                    ProductModel product = ProductRepository.GetProduct(orderProduct.Cod);

                    if (orderProduct.FlOutput == true)
                    {
                        product.Quantity -= orderProduct.Quantity;
                    }
                    else
                    {
                        product.Quantity += orderProduct.Quantity;
                    }
                    verify = ProductRepository.EditProduct(product);

                    if(verify != null)
                        products.Add(product);
                }

                return products;
            }
            catch (Exception ex) { throw ex.InnerException; };
        }

        public ProductModel EditProduct(ProductModel product)
        {
            try
            {
                return ProductRepository.EditProduct(product);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Delete
        public ProductModel DeleteProduct(int cod)
        {
            try
            {
                return ProductRepository.DeleteProduct(cod);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion

        #region Searchs
        public List<ProductModel> GetProducts()
        {
            try
            {
                return ProductRepository.GetProducts();
            }
            catch (Exception ex) { throw ex.InnerException; };
        }

        public ProductModel GetProduct(int cod)
        {
            try
            {
                return ProductRepository.GetProduct(cod);
            }
            catch (Exception ex) { throw ex.InnerException; };
        }
        #endregion
    }
}
