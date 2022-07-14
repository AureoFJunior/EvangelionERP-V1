using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using EvangelionERP.Data;
using EvangelionERP.Models;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using EvangelionERP.Services;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System;
using EvangelionERP.Data.Services;

namespace EvangelionERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;
        private readonly LoginService LoginService;

        public LoginController([FromServices] Context userContext)
        {
            _context = userContext;
            LoginService = new LoginService(userContext);
        }

        /// <summary>
        /// Pega todos os usuários.
        /// </summary>
        /// <returns></returns>
        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            try
            {
                var userDetails = LoginService.GetLogins();
                return Ok(userDetails);
            }catch (Exception ex) { return Problem(ex.Message);}
        }

        /// <summary>
        /// Pega o usuário que está logado.
        /// </summary>
        /// <returns></returns>
        [HttpGet("isLogged")]
        public IActionResult GetLoggeds()
        {
            try
            {
                var userDetails = LoginService.GetLogins().Where(x => x.isLogged == 1).FirstOrDefault();
                return Ok(userDetails);
            }catch (Exception ex) { return Problem(ex.Message);}
        }

        /// <summary>
        /// Troca o status de login do usuário.
        /// </summary>
        /// <param name="user">Usuário a ter o status trocado.</param>
        /// <returns></returns>
        [HttpPost("changeStatus")]
        public IActionResult ChangeStatus([FromBody] UserModel user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest();
                }
                else
                {

                    LoginService.EditLogin(user);
                    return Ok(new
                    {
                        StatusCode = 200
                    });
                }
            }catch (Exception ex) { return Problem(ex.Message); }
        }

        /// <summary>
        /// Cadastra um novo usuário.
        /// </summary>
        /// <param name="user">Usuário a ser cadastrado.</param>
        /// <returns></returns>
        [HttpPost("signup")]
        public IActionResult Signup([FromBody] UserModel user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest();
                }
                else
                {
                    LoginService.AddLogin(user);
                    return Ok(
                        new
                        {
                            Message = "Usuário adicionado com sucesso. ",
                            StatusCode = 200
                        });
                }
            }catch (Exception ex) { return Problem(ex.Message);}
        }

        /// <summary>
        /// Verifica as credenciais de login.
        /// </summary>
        /// <param name="user">Usuário que está logando.</param>
        /// <returns></returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserModel user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest();
                }
                else
                {
                    var userLogin = LoginService.GetLogins().Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();

                    if (userLogin != null)
                    {
                        //Gera um token pro usuário
                        var token = TokenHelper.GenerateToken(userLogin);
                        var refreshToken = TokenHelper.GenerateRefreshToken();
                        TokenHelper.SaveRefreshToken(userLogin.UserName, refreshToken);

                        return Ok(new
                        {
                            StatusCode = 200,
                            Message = $"Bem-vindo, {userLogin.FullName}!",
                            UserData = user.FullName,
                            Token = token,
                            RefreshToken = refreshToken
                        });
                    }
                    else
                    {
                        return NotFound(new
                        {
                            StatusCode = 404,
                            Message = "Usuário não encontrado."
                        });
                    }
                }
            }
            catch (Exception ex) { return Problem(ex.Message); }
        }

    [HttpPost("refresh")]
        public IActionResult Refresh(string token, string refreshToken)
        {
            var principal = TokenHelper.GetPrincipalFromExpiredTokens(token);
            var username = principal.Identity.Name;
            var savedRefreshToken = TokenHelper.GetRefreshedToken(username);
            if (savedRefreshToken != refreshToken)
                throw new SecurityTokenException("Invalid refresh token");

            var newJwtToken = TokenHelper.GenerateToken(principal.Claims);
            var newRefreshToken = TokenHelper.GenerateRefreshToken();
            TokenHelper.DeleteRefreshedToken(username, refreshToken);
            TokenHelper.SaveRefreshToken(username, newRefreshToken);

            return new ObjectResult(new
            {
                token = newJwtToken,
                refreshToken = newRefreshToken
            });
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public List<UserModel> Users()
        {
            List<UserModel> userLogin = _context.UserModel.AsQueryable().ToList();
            return userLogin;
        }
    }
}
