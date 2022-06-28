using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UcsCrudV1.Data;
using UcsCrudV1.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace UcsCrudV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly Context _context;
        public OrderController([FromServices] Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Traz todos os pedidos.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get_orders")]
        [Authorize]
        public IActionResult GetOrders()
        {
            var order = _context.OrderModel.AsQueryable().OrderByDescending(x => x.Cod);
            return Ok(new
            {
                StatusCode = 200,
                OrdersDetails = order
            });
        }

        /// <summary>
        /// Traz todos os produtos do pedido
        /// </summary>
        /// <param name="cod">Número do pedido.</param>
        /// <returns></returns>
        [HttpGet("get_order_products/{cod}")]
        public IActionResult GetOrderProducts(int cod)
        {
            var order = _context.OrderProductModel.Where(o => o.OrderCod == cod).AsNoTracking().ToList();
            var products = _context.ProductModel.AsNoTracking().ToList();
            int orderCod = 0;
            int productCod = 0;

            List<OrderProductViewModel> orderProducts = new List<OrderProductViewModel>();
            ProductModel produto = new ProductModel();


            foreach (OrderProductModel product in order)
            {
                OrderProductViewModel orderProduct = new OrderProductViewModel()
                {
                    Cod = product.Cod,
                    Name = product.Name,
                    OrderCod = product.OrderCod,
                    Price = product.Price,
                    ProductCod = product.ProductCod,
                    Quantity = product.Quantity
                };
                orderProducts.Add(orderProduct);
                produto = products.Where(x => x.Cod == product.Cod || x.Name == product.Name).FirstOrDefault();
                products.Remove(produto);
                orderCod = product.OrderCod;
            }

            foreach (ProductModel product in products)
            {
                OrderProductViewModel orderProduct = new OrderProductViewModel()
                {
                    Cod = product.Cod,
                    Name = product.Name,
                    OrderCod = orderCod,
                    Price = product.Price,
                    ProductCod = productCod,
                    Quantity = 0
                };
                orderProducts.Add(orderProduct);
            }

            return Ok(orderProducts);
        }

        /// <summary>
        /// Traz um pedido em específico
        /// </summary>
        /// <param name="cod">Código do pedido.</param>
        /// <returns></returns>
        [HttpGet("get_order/{cod}")]
        public IActionResult GetOrder(int cod)
        {
            var order = _context.OrderModel.Find(cod);
            if (order == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Pedido não encontrado."
                });
            }
            else
            {
                return Ok(order);
            }
        }

        /// <summary>
        /// Adiciona os itens do pedido
        /// </summary>
        /// <param name="orderProducts">Array com os itens do pedido.</param>
        /// <returns></returns>
        [HttpPost("add_order_products")]
        public IActionResult AddOrderProducts([FromBody] OrderProductModel[] orderProducts)
        {
            try
            {

                if (orderProducts == null)
                {
                    return BadRequest();
                }
                else
                {
                    foreach (var orderProduct in orderProducts)
                    {
                        //Se o produto possuir quantidade ou preço zerado ele não será incluso no pedido.
                        if (orderProduct.Price <= 0 || orderProduct.Quantity <= 0)
                            orderProducts = orderProducts.Where(x => x.ProductCod != orderProduct.ProductCod).ToArray();
                        else
                        {
                            //Atribui o número do pedido aos itens.
                            var orderCod = _context.OrderModel.OrderByDescending(o => o.Cod).Select(o => o.Cod == 0 ? 1 : o.Cod).FirstOrDefault() + 1;
                            for (int i = 0; i < orderProducts.Length; i++)
                            {
                                orderProducts[i].OrderCod = orderProducts[i].OrderCod == 0 ? orderCod : orderProducts[i].OrderCod;
                            }
                        }
                    }

                    _context.OrderProductModel.AddRange(orderProducts);
                    _context.SaveChanges();

                    //Atualiza a quantidade do produto.
                    foreach(var orderProduct in orderProducts)
                    {
                        ProductModel product = _context.ProductModel.Find(orderProduct.ProductCod);

                        if (orderProduct.FlOutput == true)
                        {
                            product.Quantity -= orderProduct.Quantity;
                        }
                        else
                        {
                            product.Quantity += orderProduct.Quantity;
                        }
                        _context.ProductModel.Update(product);
                        _context.SaveChanges();
                    }

                    return Ok(
                        new
                        {
                            Message = "Item do pedido gravado com sucesso. ",
                            StatusCode = 200
                        });
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona um pedido
        /// </summary>
        /// <param name="order">Pedido a ser adicionado.</param>
        /// <returns></returns>
        [HttpPost("add_order")]
        public IActionResult AddOrder([FromBody] OrderModel order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            else
            {
                _context.OrderModel.Add(order);
                _context.SaveChanges();
                return Ok(
                    new
                    {
                        Message = "Pedido gravado com sucesso. ",
                        StatusCode = 200
                    });
            }
        }

        /// <summary>
        /// Atualiza um pedido
        /// </summary>
        /// <param name="order">Código do pedido a ser atualizado.</param>
        /// <returns></returns>
        [HttpPut("update_order")]
        public IActionResult UpdateOrder([FromBody] OrderModel order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            var orderCod = _context.OrderModel.OrderByDescending(o => o.Cod).Select(o => o.Cod == 0 ? 1 : o.Cod).FirstOrDefault();

            if (order.Cod == 0)
            {
                order.Cod = orderCod;
            }

            var ord = _context.OrderModel.AsNoTracking().FirstOrDefault(x => x.Cod == orderCod);

            //Se não achar o pedido.
            if (ord == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Pedido não encontrado."
                });
            }
            else
            {
                _context.Entry(order).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Pedido atualizado com sucesso."
                });
            }
        }

        /// <summary>
        /// Excluí um pedido
        /// </summary>
        /// <param name="orderCod">Código do pedido a ser excluído.</param>
        /// <returns></returns>
        [HttpDelete("delete_order_product/{orderCod}")]
        public IActionResult DeleteOrderProduct(int orderCod)
        {
            //Se não achar o pedido..
            if (orderCod == 0)
            {
                //Retorna com o código de não encontrado (404)
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Pedido não encontrado."
                });
            }
            else
            {
                var products = _context.OrderProductModel.Where(x => x.OrderCod == orderCod).AsNoTracking().ToList();
                //Remove do banco esse produto e salva as alterações.
                _context.OrderProductModel.FromSqlRaw("SET foreign_key_checks = 0;");
                foreach (OrderProductModel product in products)
                {
                    _context.Remove(product);
                }
                _context.OrderProductModel.FromSqlRaw("SET foreign_key_checks = 1;");
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Produto excluído com sucesso deste pedido."
                });
            }
        }

    }
}

