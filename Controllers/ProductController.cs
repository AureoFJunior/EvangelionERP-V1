using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EvangelionERP.Data;
using EvangelionERP.Models;

namespace EvangelionERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Context _context;
        public ProductController([FromServices] Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Traz todos os produtos
        /// </summary>
        /// <returns></returns>
        [HttpGet("get_products")]
        public IActionResult GetProducts()
        {
            var product = _context.ProductModel.AsQueryable();
            return Ok(new
            {
                StatusCode = 200,
                ProductsDetails = product
            });
        }

        [HttpGet("get_products_only")]
        public IActionResult GetProductsOnly()
        {
            var product = _context.ProductModel.AsQueryable();
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
            var product = _context.ProductModel.Find(cod);
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
        }

        /// <summary>
        /// Adiciona um produto
        /// </summary>
        /// <param name="product">Produto a ser adicionado.</param>
        /// <returns></returns>
        [HttpPost("add_product")]
        public IActionResult AddProduto([FromBody] ProductModel product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            else
            {
                _context.ProductModel.Add(product);
                _context.SaveChanges();
                return Ok(
                    new
                    {
                        Message = "Produto adicionado com sucesso. ",
                        StatusCode = 200
                    });
            }
        }

        /// <summary>
        /// Atualiza um produto
        /// </summary>
        /// <param name="product">Produto a ser atualizado.</param>
        /// <returns></returns>
        [HttpPut("update_product")]
        public IActionResult UpdateProduct([FromBody] ProductModel product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            var prod = _context.ProductModel.AsNoTracking().FirstOrDefaultAsync(x => x.Cod == product.Cod);

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
                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Produto atualizado com sucesso."
                });
            }
        }

        /// <summary>
        /// Excluí um produto
        /// </summary>
        /// <param name="cod">Código do produto.</param>
        /// <returns></returns>
        [HttpDelete("delete_product/{cod}")]
        public IActionResult DeleteProduct(int cod)
        {
            var product = _context.ProductModel.Find(cod);

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
                _context.Remove(product);
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Produto excluído com sucesso."
                });
            }
        }

    }
}
