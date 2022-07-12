using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EvangelionERP.Data;
using EvangelionERP.Models;
using EvangelionERP.Data.Services;
using System;

namespace EvangelionERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Context _context;
        private readonly ProductService ProductService;

        public ProductController([FromServices] Context context)
        {
            _context = context;
            ProductService = new ProductService(context);
        }

        /// <summary>
        /// Traz todos os produtos
        /// </summary>
        /// <returns></returns>
        [HttpGet("get_products")]
        public IActionResult GetProducts()
        {
            try
            {
                var product = ProductService.GetProducts();
                return Ok(new
                {
                    StatusCode = 200,
                    ProductsDetails = product
                });

            }catch(Exception ex) { return Problem(ex.Message);}
        }

        [HttpGet("get_products_only")]
        public IActionResult GetProductsOnly()
        {
            var product = ProductService.GetProducts();
            return Ok(product);
        }

        /// <summary>
        /// Traz um produto em específico
        /// </summary>
        /// <param name="cod">Código do produto.</param>
        /// <returns></returns>
        [HttpGet("get_product/{cod}")]
        public IActionResult GeProduct(int cod)
        {
            try
            {
                var product = ProductService.GetProduct(cod);
                if (product == null)
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "Produto não encontrado."
                    });
                }
                else
                {
                    return Ok(product);
                }
            }catch (Exception ex) { return Problem(ex.Message); }
        }

        /// <summary>
        /// Adiciona um produto
        /// </summary>
        /// <param name="product">Produto a ser adicionado.</param>
        /// <returns></returns>
        [HttpPost("add_product")]
        public IActionResult AddProduct([FromBody] ProductModel product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest();
                }
                else
                {
                    ProductService.AddProduct(product);
                    return Ok(
                        new
                        {
                            Message = "Produto adicionado com sucesso. ",
                            StatusCode = 200
                        });
                }
            }catch (Exception ex) { return Problem(ex.Message); }
        }

        /// <summary>
        /// Atualiza um produto
        /// </summary>
        /// <param name="product">Produto a ser atualizado.</param>
        /// <returns></returns>
        [HttpPut("update_product")]
        public IActionResult UpdateProduct([FromBody] ProductModel product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest();
                }

                var prod = ProductService.GetProduct(product.Cod);

                //Se não achar o produto.
                if (prod == null)
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "Produto não encontrado."
                    });
                }
                else
                {
                    ProductService.EditProduct(product);
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Produto atualizado com sucesso."
                    });
                }
            }catch (Exception ex) { return Problem(ex.Message);}
        }

        /// <summary>
        /// Excluí um produto
        /// </summary>
        /// <param name="cod">Código do produto.</param>
        /// <returns></returns>
        [HttpDelete("delete_product/{cod}")]
        public IActionResult DeleteProduct(int cod)
        {
            try
            {
                var product = ProductService.GetProduct(cod);

                //Se não achar o produto.
                if (product == null)
                {
                    //Retorna com o código de não encontrado (404)
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "Produto não encontrado."
                    });
                }
                else
                {
                    //Remove do banco esse produto e salva as alterações.
                    ProductService.DeleteProduct(cod);
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Produto excluído com sucesso."
                    });
                }
            }catch (Exception ex) { return Problem(ex.Message);}
        }
    }
}
