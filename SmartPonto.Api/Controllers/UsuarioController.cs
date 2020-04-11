using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartPonto.Api.Dto;
using SmartPonto.Api.Models;
using SmartPonto.Api.Models.TokenAuth;
using SmartPonto.Api.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartPonto.Api.Controllers
{
    [Route("api/[controller]")]    
    public class UsuarioController : Controller
    {
        private readonly ITokenAuthentication authentication;
        private readonly IMapper mapper;
        private readonly IUsuarioRepository repo;
        private readonly IPontoRepository pontoDB;

        public UsuarioController(ITokenAuthentication authentication, IMapper mapper, IUsuarioRepository repo, IPontoRepository pontoDB)
        {
            this.authentication = authentication;
            this.mapper = mapper;
            this.repo = repo;
            this.pontoDB = pontoDB;
        }
        // GET: api/values
        [HttpGet]        
        [Authorize]
        public async Task<IActionResult> Get()
        {
            try
            {                
                var usuarios = await this.repo.GetAllUsuarioAsync();
                var usuariosDto = this.mapper.Map<UsuarioDto[]>(usuarios);
                return Ok(usuariosDto);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }  
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            try
            {                
                var usuario = await this.repo.GetUsuarioByIdAsync(id);
                var usuarioDto = this.mapper.Map<UsuarioDto>(usuario);
                return Ok(usuarioDto);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }  
        }
        [HttpGet("UsuarioByEmail")]        
        [Authorize]
        public async Task<IActionResult> GetUsuarioByEmail(string email)
        {
            try
            {                
                var usuario = await this.repo.GetUsuarioByEmailAsync(email);
                var usuarioDto = this.mapper.Map<UsuarioDto>(usuario);
                return Ok(usuarioDto);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }  
        }

        [HttpGet("UsuarioByLogin")]
        [Authorize]
        public async Task<IActionResult> GetUsuarioByLogin(int loginId)
        {
            try
            {                
                var usuario = await this.repo.GetUsuarioByLoginAsync(loginId);
                var usuarioDto = this.mapper.Map<UsuarioDto>(usuario);
                return Ok(usuarioDto);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }  
        }
        [HttpPost("Create")]
        [Authorize]
        public async Task<IActionResult> CadastroUsuario([FromBody] UsuarioDto usuario)
        {
            try
            {
                var usuarioDb = this.mapper.Map<Usuario>(usuario);
                await this.pontoDB.AddAsync<Usuario>(usuarioDb);
                usuario = this.mapper.Map<UsuarioDto>(usuarioDb);
                return Ok(usuario);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }  
        }

        // POST api/values
        [HttpPost("Autenticacao")]
        [AllowAnonymous]
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> Put(int id, [FromBody]UsuarioDto usuario)
        {
            try
            {                
                var usuarioDb = this.mapper.Map<Usuario>(usuario);
                usuarioDb.Id = id;
                this.pontoDB.Update<Usuario>(usuarioDb);
                usuarioDb = await this.repo.GetUsuarioByIdAsync(id);
                usuario = this.mapper.Map<UsuarioDto>(usuarioDb);
                return Ok(usuario);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }  
        }

        // DELETE api/values/5
        // [HttpDelete("{id}")]
        // [Authorize]
        // public void Delete(int id)
        // {
        // }
    }
}
