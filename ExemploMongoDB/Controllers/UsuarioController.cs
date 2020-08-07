using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExemploMongoDB.BLL;
using ExemploMongoDB.DAL;
using ExemploMongoDB.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExemploMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioDados bll;
        public UsuarioController()
        {
            var dal = new UsuarioDAL();
            bll = new UsuarioBLL(dal);
        }
        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return bll.ObterTodos();
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public Usuario Get(string id)
        {            
            return bll.ObterUsuario(id);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public void Post([FromBody] Usuario usuario)
        {
            bll.Incluir(usuario);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Usuario usuario)
        {            
            bll.Alterar(usuario);
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {         
            bll.Excluir(id);
        }
    }
}
