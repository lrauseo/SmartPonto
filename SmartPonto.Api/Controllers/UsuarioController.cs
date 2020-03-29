using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartPonto.Api.Models.TokenAuth;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartPonto.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly ITokenAuthentication authentication;

        public UsuarioController(ITokenAuthentication authentication)
        {
            this.authentication = authentication;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost("Autenticacao")]
        [AllowAnonymous]
        public IActionResult Post([FromQuery] string user, string pwd)
        {
            try
            {
                var usuario = user;
                var senha = pwd;
                if (usuario == "ponto" && senha == "ponto123")
                {
                    return Ok(authentication.GenerateToken(usuario));
                }
                else
                    return Unauthorized("Usuário e senha inválidos");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
                
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
