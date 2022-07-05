using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EvangelionERP.Data;
using EvangelionERP.Models;
using System;
using System.Linq;
using System.Collections.Generic;

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
        /// Traz todos os registros financeiros.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get_financials")]
        public IActionResult GetFinancials()
        {
            var financial = _context.FinancialModel.AsNoTracking().OrderByDescending(x => x.Cod).ThenBy(x => x.InclusionDate).AsQueryable();
            return Ok(new
            {
                StatusCode = 200,
                FinancialsDetails = financial
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
        /// Traz todos os registros financeiros de cada mês de cada ano (GAMBIARRA).
        /// </summary>
        /// <returns></returns>
        [HttpGet("get_financials_months")]
        public IActionResult GetFinancialsMonths()
        {
            List<FinancialModel> financials = new List<FinancialModel>();
            FinancialModel financial = new FinancialModel();
            List<int> years = new List<int>();
            int oldYear = 0;

            var query = _context.FinancialModel.AsNoTracking().OrderByDescending(x => x.Cod).ThenBy(x => x.InclusionDate).GroupBy(x => x.InclusionDate.Year).SelectMany(x => x).ToList();

            foreach (FinancialModel fin in query)
            {
                if (fin.InclusionDate.Year != oldYear)
                {
                    years.Add(fin.InclusionDate.Year);
                }
                oldYear = fin.InclusionDate.Year;
            }

            foreach (int year in years)
            {
                //TODO: Pegar o último registro de cada mês (considerar se é dia 30 ou 31)
                financials.Add(_context.FinancialModel.AsNoTracking().Where(x => x.InclusionDate.Year == year && x.InclusionDate.Month == 1  && x.InclusionDate.Day == 31 ).OrderByDescending(x => x.Cod).FirstOrDefault()); //Jan
                financials.Add(_context.FinancialModel.AsNoTracking().Where(x => x.InclusionDate.Year == year && x.InclusionDate.Month ==  2 && x.InclusionDate.Day == 28 ).OrderByDescending(x => x.Cod).FirstOrDefault()); //Fev
                financials.Add(_context.FinancialModel.AsNoTracking().Where(x => x.InclusionDate.Year == year && x.InclusionDate.Month ==  3 && x.InclusionDate.Day == 31 ).OrderByDescending(x => x.Cod).FirstOrDefault()); //Mar
                financials.Add(_context.FinancialModel.AsNoTracking().Where(x => x.InclusionDate.Year == year && x.InclusionDate.Month ==  4 && x.InclusionDate.Day == 30 ).OrderByDescending(x => x.Cod).FirstOrDefault()); //Abr
                financials.Add(_context.FinancialModel.AsNoTracking().Where(x => x.InclusionDate.Year == year && x.InclusionDate.Month ==  5 && x.InclusionDate.Day == 31 ).OrderByDescending(x => x.Cod).FirstOrDefault()); //Mai
                financials.Add(_context.FinancialModel.AsNoTracking().Where(x => x.InclusionDate.Year == year && x.InclusionDate.Month ==  6 && x.InclusionDate.Day == 30 ).OrderByDescending(x => x.Cod).FirstOrDefault()); //Jun
                financials.Add(_context.FinancialModel.AsNoTracking().Where(x => x.InclusionDate.Year == year && x.InclusionDate.Month == 7 && x.InclusionDate.Day == 31 ).OrderByDescending(x => x.Cod).FirstOrDefault()); //Jul
                financials.Add(_context.FinancialModel.AsNoTracking().Where(x => x.InclusionDate.Year == year && x.InclusionDate.Month == 8 && x.InclusionDate.Day == 31 ).OrderByDescending(x => x.Cod).FirstOrDefault()); //Ago
                financials.Add(_context.FinancialModel.AsNoTracking().Where(x => x.InclusionDate.Year == year && x.InclusionDate.Month == 9 && x.InclusionDate.Day == 30 ).OrderByDescending(x => x.Cod).FirstOrDefault()); //Set
                financials.Add(_context.FinancialModel.AsNoTracking().Where(x => x.InclusionDate.Year == year && x.InclusionDate.Month == 10 && x.InclusionDate.Day == 31 ).OrderByDescending(x => x.Cod).FirstOrDefault()); //Out
                financials.Add(_context.FinancialModel.AsNoTracking().Where(x => x.InclusionDate.Year == year && x.InclusionDate.Month == 11 && x.InclusionDate.Day == 30 ).OrderByDescending(x => x.Cod).FirstOrDefault()); //Nov
                financials.Add(_context.FinancialModel.AsNoTracking().Where(x => x.InclusionDate.Year == year && x.InclusionDate.Month == 12 && x.InclusionDate.Day == 31 ).OrderByDescending(x => x.Cod).FirstOrDefault()); //Dez
            }

            return Ok(financials);
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
