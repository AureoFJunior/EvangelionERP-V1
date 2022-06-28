using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using UcsCrudV1.Data;
using UcsCrudV1.Models;

namespace UcsCrudV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly Context _context;
        public EmployerController([FromServices] Context userContext)
        {
            _context = userContext;
        }

        /// <summary>
        /// Traz todos os funcionários
        /// </summary>
        /// <returns></returns>
        [HttpGet("get_employers")]
        public IActionResult GetEmployers()
        {
            var employer = _context.EmployerModel.AsQueryable();
            return Ok(new
            {
                StatusCode = 200,
                EmployerDetails = employer
            });
        }

        /// <summary>
        /// Traz um funcionário em específico
        /// </summary>
        /// <param name="cod">Código do funcionário.</param>
        /// <returns></returns>
        [HttpGet("get_employer/{cod}")]
        public IActionResult GetEmployer(int cod)
        {
            var employer = _context.EmployerModel.Find(cod);
            if (employer == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Funcionário não encontrado."
                });
            }
            else
            {
                return Ok(employer);
            }
        }

        /// <summary>
        /// Adiciona um funcionário
        /// </summary>
        /// <param name="employer">Funcionário a ser adicionado.</param>
        /// <returns></returns>
        [HttpPost("add_employer")]
        public IActionResult AddEmployer([FromBody] EmployerModel employer)
        {
            if (employer == null)
            {
                return BadRequest();
            }
            else
            {
                _context.EmployerModel.Add(employer);
                _context.SaveChanges();
                return Ok(
                    new
                    {
                        Message = "Funcionário adicionado com sucesso. ",
                        StatusCode = 200
                    });
            }
        }

        /// <summary>
        /// Atualiza um funcionário
        /// </summary>
        /// <param name="employer">Funcionário a ser atualizado.</param>
        /// <returns></returns>
        [HttpPut("update_employer")]
        public  IActionResult UpdateEmployer([FromBody] EmployerModel employer)
        {
            if (employer == null)
            {
                return BadRequest();
            }

            var user =  _context.EmployerModel.AsNoTracking().FirstOrDefault(x => x.Cod == employer.Cod);

            //Se não achar o funcionário.
            if (user == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Funcionário não encontrado."
                });
            }
            else
            {
                _context.Entry(employer).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Funcionário atualizado com sucesso."
                });
            }
        }

        /// <summary>
        /// Excluí um funcionário
        /// </summary>
        /// <param name="cod">Código do funcionário.</param>
        /// <returns></returns>
        [HttpDelete("delete_employer/{cod}")]
        public IActionResult DeleteEmployer(int cod)
        {
            var employer = _context.EmployerModel.Find(cod);

            //Se não achar o funcionário.
            if (employer == null)
            {
                //Retorna com o código de não encontrado (404)
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Funcionário não encontrado."
                });
            }
            else
            {
                //Remove do banco esse funcionário e salva as alterações.
                _context.Remove(employer);
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Funcionário excluído com sucesso."
                });
            }
        }

    }
}
