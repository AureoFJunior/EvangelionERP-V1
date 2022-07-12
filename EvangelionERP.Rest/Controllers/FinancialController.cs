using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EvangelionERP.Data;
using EvangelionERP.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using EvangelionERP.Data.Services;

namespace EvangelionERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialController : ControllerBase
    {
        private readonly Context _context;
        private readonly FinancialService FinancialService;

        public FinancialController([FromServices] Context context)
        {
            _context = context;
            FinancialService = new FinancialService(context);
        }

        /// <summary>
        /// Traz todos os registros financeiros.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get_financials")]
        public IActionResult GetFinancials()
        {
            try
            {
                var financial = FinancialService.GetFinancials();
                return Ok(new
                {
                    StatusCode = 200,
                    FinancialsDetails = financial
                });
            } catch (Exception ex) { return Problem(ex.Message); }
        }

        /// <summary>
        /// Traz todos os registros financeiros de cada mês de cada ano (GAMBIARRA).
        /// </summary>
        /// <returns></returns>
        [HttpGet("get_financials_months")]
        public IActionResult GetFinancialsMonths()
        {
            try
            {
                var financials = FinancialService.GetFinancialsMonths();
                return Ok(financials);
            }catch (Exception ex){ return Problem(ex.Message);}
        }

        /// <summary>
        /// Adiciona um financeiro
        /// </summary>
        /// <param name="financial">Financeiro a ser adicionado.</param>
        /// <returns></returns>
        [HttpPost("add_financial")]
        public IActionResult AddFinancial([FromBody] FinancialModel financial)
        {
            try
            {
                if (financial == null)
                {
                    return BadRequest();
                }
                else
                {
                    FinancialService.AddFinancial(financial);
                    return Ok(
                        new
                        {
                            Message = "Financeiro adicionado com sucesso. ",
                            StatusCode = 200
                        });
                }
            }catch (Exception ex){ return Problem(ex.Message);}
        }

            /// <summary>
            /// Atualiza um financeiro
            /// </summary>
            /// <param name="financial">Financeiro a ser atualizado.</param>
            /// <returns></returns>
            [HttpPut("update_financial")]
            public IActionResult UpdateFinancial([FromBody] FinancialModel financial)
            {
                try
                {
                    if (financial == null)
                    {
                        return BadRequest();
                    }

                    var finan = FinancialService.GetFinancial(financial.Cod);

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
                        FinancialService.EditFinancial(financial);
                        return Ok(new
                        {
                            StatusCode = 200,
                            Message = "Financeiro atualizado com sucesso."
                        });
                    }
                } catch (Exception ex) { return Problem(ex.Message); }
            }
        }
    }
