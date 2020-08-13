using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExemploMongoDB.BLL;
using ExemploMongoDB.DAL;
using ExemploMongoDB.Models;
using Microsoft.AspNetCore.Mvc;
using RabbitMQPublisher;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExemploMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioBLL bll;
        private IRabbitMQSender rabbitMQSender;
        public UsuarioController(IUsuarioBLL bllInstance, IRabbitMQSender rabbitMQSenderInstance)
        {
            this.bll = bllInstance;
            this.rabbitMQSender = rabbitMQSenderInstance;
        }
        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            var usuarios = bll.ObterTodos();
            var message = JsonSerializer.Serialize(usuarios);
            rabbitMQSender.SendMessage(RabbitMQSettings.QueueName, message);
            return usuarios;
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
