using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using EvangelionERP.Data;
using EvangelionERP.Models;
using System;
using EvangelionERP.Data.Services;

namespace EvangelionERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly Context _context;
        private readonly EmployerService EmployerService;

        public EmployerController([FromServices] Context userContext)
        {
            _context = userContext;
            EmployerService = new EmployerService(userContext);
        }

        /// <summary>
        /// Traz todos os funcionários
        /// </summary>
        /// <returns></returns>
        [HttpGet("get_employers")]
        public IActionResult GetEmployers()
        {
            try
            {  
                var employer = EmployerService.GetEmployers();
                return Ok(new
                {
                    StatusCode = 200,
                    EmployerDetails = employer
                });
            } catch (Exception ex) { return Problem(ex.Message); }
        }

        /// <summary>
        /// Traz um funcionário em específico
        /// </summary>
        /// <param name="cod">Código do funcionário.</param>
        /// <returns></returns>
        [HttpGet("get_employer/{cod}")]
        public IActionResult GetEmployer(int cod)
        {
            try 
            { 
                var employer = EmployerService.GetEmployer(cod);
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
            } catch (Exception ex) { return Problem(ex.Message); }
        }

        /// <summary>
        /// Adiciona um funcionário
        /// </summary>
        /// <param name="employer">Funcionário a ser adicionado.</param>
        /// <returns></returns>
        [HttpPost("add_employer")]
        public IActionResult AddEmployer([FromBody] EmployerModel employer)
        {
            try
            {
                if (employer == null)
                {
                    return BadRequest();
                }
                else
                {
                    EmployerService.AddEmployer(employer);
                    return Ok(
                        new
                        {
                            Message = "Funcionário adicionado com sucesso. ",
                            StatusCode = 200
                        });
                }
            }catch (Exception ex) { return Problem(ex.Message); }
        }

        /// <summary>
        /// Atualiza um funcionário
        /// </summary>
        /// <param name="employer">Funcionário a ser atualizado.</param>
        /// <returns></returns>
        [HttpPut("update_employer")]
        public  IActionResult UpdateEmployer([FromBody] EmployerModel employer)
        {
            try
            {
                if (employer == null)
                {
                    return BadRequest();
                }

                var user = EmployerService.GetEmployer(employer.Cod);

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
                    EmployerService.EditEmployer(employer);
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Funcionário atualizado com sucesso."
                    });
                }
            }catch (Exception ex) { return Problem(ex.Message);}
         }   

        /// <summary>
        /// Excluí um funcionário
        /// </summary>
        /// <param name="cod">Código do funcionário.</param>
        /// <returns></returns>
        [HttpDelete("delete_employer/{cod}")]
        public IActionResult DeleteEmployer(int cod)
        {
            try
            {
                var employer = EmployerService.GetEmployer(cod);

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
                    EmployerService.DeleteEmployer(cod);
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Funcionário excluído com sucesso."
                    });
                }
            }catch (Exception ex) { return Problem(ex.Message); }
        }
    }
}
