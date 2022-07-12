using Microsoft.AspNetCore.Http;
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
    public class CustomerController : ControllerBase
    {
        private readonly Context _context;
        private readonly CustomerService CustomerService;

        public CustomerController([FromServices] Context userContext)
        {
            _context = userContext;
            CustomerService = new CustomerService(userContext);
        }

        /// <summary>
        /// Traz todos os clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet("get_customers")]
        public IActionResult GetCustomers()
        {
            try
            {
                var customer = CustomerService.GetCustomers();
                return Ok(new
                {
                    StatusCode = 200,
                    customerDetails = customer
                });
            }
            catch (Exception ex) { return Problem(ex.Message); }
        }

        /// <summary>
        /// Traz um cliente em específico
        /// </summary>
        /// <param name="cod">Código do cliente.</param>
        /// <returns></returns>
        [HttpGet("get_customer/{cod}")]
        public IActionResult GetCustomer(int cod)
        {
            try
            {
                var customer = CustomerService.GetCustomer(cod);
                if (customer == null)
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "cliente não encontrado."
                    });
                }
                else
                {
                    return Ok(customer);
                }
            }
            catch (Exception ex) { return Problem(ex.Message); }
        }

        /// <summary>
        /// Adiciona um cliente
        /// </summary>
        /// <param name="customer">cliente a ser adicionado.</param>
        /// <returns></returns>
        [HttpPost("add_customer")]
        public IActionResult AddCustomer([FromBody] CustomerModel customer)
        {
            try
            {
                if (customer == null)
                {
                    return BadRequest();
                }
                else
                {
                    CustomerService.AddCustomer(customer);
                    return Ok(
                        new
                        {
                            Message = "cliente adicionado com sucesso. ",
                            StatusCode = 200
                        });
                }
            }
            catch (Exception ex) { return Problem(ex.Message); }
        }

        /// <summary>
        /// Atualiza um cliente
        /// </summary>
        /// <param name="customer">cliente a ser atualizado.</param>
        /// <returns></returns>
        [HttpPut("update_customer")]
        public IActionResult UpdateCustomer([FromBody] CustomerModel customer)
        {
            try
            {
                if (customer == null)
                {
                    return BadRequest();
                }

                var user = CustomerService.GetCustomer(customer.Cod);

                //Se não achar o cliente.
                if (user == null)
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "cliente não encontrado."
                    });
                }
                else
                {
                    CustomerService.EditCustomer(customer);
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "cliente atualizado com sucesso."
                    });
                }
            }
            catch (Exception ex) { return Problem(ex.Message); }
        }

        /// <summary>
        /// Excluí um cliente
        /// </summary>
        /// <param name="cod">Código do cliente.</param>
        /// <returns></returns>
        [HttpDelete("delete_customer/{cod}")]
        public IActionResult DeleteCustomer(int cod)
        {
            try
            {
                var customer = CustomerService.GetCustomer(cod);

                //Se não achar o cliente.
                if (customer == null)
                {
                    //Retorna com o código de não encontrado (404)
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "cliente não encontrado."
                    });
                }
                else
                {
                    //Remove do banco esse cliente e salva as alterações.
                    CustomerService.DeleteCustomer(cod);
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "cliente excluído com sucesso."
                    });
                }
            }
            catch (Exception ex) { return Problem(ex.Message); }
        }
    }
}

