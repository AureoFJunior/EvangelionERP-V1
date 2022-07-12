using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EvangelionERP.Data;
using EvangelionERP.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using EvangelionERP.Data.Services;

namespace EvangelionERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly Context _context;
        private readonly OrderService OrderService;
        private readonly FinancialService FinancialService;
        private readonly OrderProductService OrderProductService;
        private readonly ProductService ProductService;

        public OrderController([FromServices] Context context)
        {
            _context = context;
            OrderService = new OrderService(context);
            FinancialService = new FinancialService(context);
            OrderProductService = new OrderProductService(context);
            ProductService = new ProductService(context);
        }

        /// <summary>
        /// Traz todos os pedidos.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get_orders")]
        [Authorize]
        public IActionResult GetOrders()
        {
            try
            {
                List<OrderModel> order = OrderService.GetOrders();
                return Ok(new
                {
                    StatusCode = 200,
                    OrdersDetails = order
                });
            }catch (Exception ex) { return Problem(ex.Message); };
        }

        /// <summary>
        /// Traz todos os produtos do pedido
        /// </summary>
        /// <param name="cod">Número do pedido.</param>
        /// <returns></returns>
        [HttpGet("get_order_products/{cod}")]
        public IActionResult GetOrderProducts(int cod)
        {
            try
            {
                List<OrderProductViewModel> orderProducts = OrderProductService.GetOrderProducts(cod);
                return Ok(orderProducts);
            }
            catch (Exception ex) { return Problem(ex.Message); };
        }

        /// <summary>
        /// Traz um pedido em específico
        /// </summary>
        /// <param name="cod">Código do pedido.</param>
        /// <returns></returns>
        [HttpGet("get_order/{cod}")]
        public IActionResult GetOrder(int cod)
        {
            try
            {
                OrderModel order = OrderService.GetOrder(cod);
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
            }catch (Exception ex) { return Problem(ex.Message); };
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
                    //Adiciona os produtos do pedido.
                    OrderProductService.AddOrderProduct(orderProducts);

                    //Atualiza a quantidade do produto.
                    List<ProductModel> products = ProductService.EditProduct(orderProducts);

                    return Ok(
                        new
                        {
                            Message = "Item do pedido gravado com sucesso. ",
                            StatusCode = 200
                        });
                }
            }
            catch (Exception ex) { return Problem(ex.Message); };
        }

        /// <summary>
        /// Adiciona um pedido
        /// </summary>
        /// <param name="order">Pedido a ser adicionado.</param>
        /// <returns></returns>
        [HttpPost("add_order")]
        public IActionResult AddOrder([FromBody] OrderModel order)
        {
            try
            {
                if (order == null)
                {
                    return BadRequest();
                }
                else
                {
                    //Adiciona o pedido.
                    OrderService.AddOrder(order);

                    //Atualiza o financeiro atual.
                    FinancialService.AddFinancial(order);

                    return Ok(
                        new
                        {
                            Message = "Pedido gravado com sucesso. ",
                            StatusCode = 200
                        });
                }
            }
            catch (Exception ex) { return Problem(ex.Message); };
        }

        /// <summary>
        /// Atualiza um pedido
        /// </summary>
        /// <param name="order">Código do pedido a ser atualizado.</param>
        /// <returns></returns>
        [HttpPut("update_order")]
        public IActionResult UpdateOrder([FromBody] OrderModel order)
        {
            try
            {
                if (order == null)
                {
                    return BadRequest();
                }

                OrderModel verificacao = OrderService.EditOrder(order);

                //Se não achar o pedido.
                if (verificacao == null)
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "Pedido não encontrado."
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Pedido atualizado com sucesso."
                    });
                }
            }catch (Exception ex) { return Problem(ex.Message); };
        }

        /// <summary>
        /// Excluí um pedido
        /// </summary>
        /// <param name="orderCod">Código do pedido a ser excluído.</param>
        /// <returns></returns>
        [HttpDelete("delete_order_product/{orderCod}")]
        public IActionResult DeleteOrderProduct(int orderCod)
        {
            try
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
                    //Excluí os produtos do pedido.
                    OrderProductService.DeleteOrderProduct(orderCod);

                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Produto excluído com sucesso deste pedido."
                    });
                }
            }catch (Exception ex) { return Problem(ex.Message); };
        }
    }
}

