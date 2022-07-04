using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EvangelionERP.Data;
using EvangelionERP.Models;
using System;
using System.Linq;

namespace EvangelionERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialController : ControllerBase
    {
        private readonly Context _context;
        public FinancialController([FromServices] Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Traz todos os produtos
        /// </summary>
        /// <returns></returns>
        [HttpGet("get_financials")]
        public IActionResult GetFinancials()
        {
            var financial = _context.FinancialModel.AsNoTracking().OrderByDescending(x => x.InclusionDate).AsQueryable();
            return Ok(new
            {
                StatusCode = 200,
                FinancialssDetails = financial
            });
        }

        /// <summary>
        /// Traz o valor total monetário da empresa.
        /// </summary>
        /// <param name="date">Data do financeiro. (Ex: 02-05-2022 (mês-dia-ano em padrão estadunidense))</param>
        /// <param name="cod">Código do financeiro.</param>
        /// <returns></returns>
        [HttpGet("get_financial/{date}/{cod?}")]
        public IActionResult GeFinancials(DateTime date, int? cod)
        {
            FinancialModel financial = _context.FinancialModel.AsNoTracking().OrderByDescending(x => x.InclusionDate).FirstOrDefault();
            if (cod == null || cod <= 0)
            {
                financial = _context.FinancialModel.Find(cod);
            }

            if (financial == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Financeiro não encontrado."
                });
            }
            else
            {
                return Ok(financial);
            }
        }

        /// <summary>
        /// Adiciona um financeiro
        /// </summary>
        /// <param name="financial">Financeiro a ser adicionado.</param>
        /// <returns></returns>
        [HttpPost("add_financial")]
        public IActionResult AddFinancial([FromBody] FinancialModel financial)
        {
            if (financial == null)
            {
                return BadRequest();
            }
            else
            {
                _context.FinancialModel.Add(financial);
                _context.SaveChanges();
                return Ok(
                    new
                    {
                        Message = "Financeiro adicionado com sucesso. ",
                        StatusCode = 200
                    });
            }
        }

        /// <summary>
        /// Atualiza um financeiro
        /// </summary>
        /// <param name="financial">Financeiro a ser atualizado.</param>
        /// <returns></returns>
        [HttpPut("update_financial")]
        public IActionResult UpdateFinancial([FromBody] FinancialModel financial)
        {
            if (financial == null)
            {
                return BadRequest();
            }

            var finan = _context.FinancialModel.AsNoTracking().FirstOrDefaultAsync(x => x.Cod == financial.Cod);

            //Se não achar o financeiro.
            if (finan == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Financeiro não encontrado."
                });
            }
            else
            {
                _context.Entry(financial).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Financeiro atualizado com sucesso."
                });
            }
        }

        /// <summary>
        /// Excluí um financeiro
        /// </summary>
        /// <param name="cod">Código do financeiro.</param>
        /// <returns></returns>
        [HttpDelete("delete_financial/{cod}")]
        public IActionResult DeleteFinancials(int cod)
        {
            var financial = _context.FinancialModel.Find(cod);

            //Se não achar o financeiro.
            if (financial == null)
            {
                //Retorna com o código de não encontrado (404)
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Financeiro não encontrado."
                });
            }
            else
            {
                //Remove do banco esse financeiro e salva as alterações.
                _context.Remove(financial);
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Financeiro excluído com sucesso."
                });
            }
        }

    }
}
