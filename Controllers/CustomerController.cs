using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EvangelionERP.Data;
using EvangelionERP.Models;

namespace EvangelionERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly Context _context;
        public CustomerController([FromServices] Context userContext)
        {
            _context = userContext;
        }

        /// <summary>
        /// Traz todos os clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet("get_customers")]
        public IActionResult GetCustomers()
        {
            var customer = _context.CustomerModel.AsQueryable();
            return Ok(new
            {
                StatusCode = 200,
                customerDetails = customer
            });
        }

        /// <summary>
        /// Traz um cliente em específico
        /// </summary>
        /// <param name="cod">Código do cliente.</param>
        /// <returns></returns>
        [HttpGet("get_customer/{cod}")]
        public IActionResult GetCustomer(int cod)
        {
            var customer = _context.CustomerModel.Find(cod);
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

        /// <summary>
        /// Adiciona um cliente
        /// </summary>
        /// <param name="customer">cliente a ser adicionado.</param>
        /// <returns></returns>
        [HttpPost("add_customer")]
        public IActionResult AddCustomer([FromBody] CustomerModel customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            else
            {
                _context.CustomerModel.Add(customer);
                _context.SaveChanges();
                return Ok(
                    new
                    {
                        Message = "cliente adicionado com sucesso. ",
                        StatusCode = 200
                    });
            }
        }

        /// <summary>
        /// Atualiza um cliente
        /// </summary>
        /// <param name="customer">cliente a ser atualizado.</param>
        /// <returns></returns>
        [HttpPut("update_customer")]
        public IActionResult UpdateCustomer([FromBody] CustomerModel customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            var user = _context.CustomerModel.AsNoTracking().FirstOrDefaultAsync(x => x.Cod == customer.Cod);

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
                _context.Entry(customer).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "cliente atualizado com sucesso."
                });
            }
        }

        /// <summary>
        /// Excluí um cliente
        /// </summary>
        /// <param name="cod">Código do cliente.</param>
        /// <returns></returns>
        [HttpDelete("delete_customer/{cod}")]
        public IActionResult DeleteCustomer(int cod)
        {
            var customer = _context.CustomerModel.Find(cod);

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
                _context.Remove(customer);
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "cliente excluído com sucesso."
                });
            }
        }

    }
}
