using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APInet5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly ApiContext _context;

        public ClienteController(ILogger<ClienteController> logger, ApiContext context)
        {
             _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            var retorno = _context.Clientes.ToList();

            return retorno;
        }
        
        [HttpGet("{id}")]
        public string GetById(string id)
        {
            var cliente = _context.Clientes.Where(w => w.Id == Guid.Parse(id)).SingleOrDefault();

            if (cliente == null)
            {
                return "Usuario não encontrado!";
            }
            else 
            {
                return $"Dados criados:\nId: {cliente.Id}\nNome: {cliente.Nome}\nNascimento: {cliente.Nascimento}\nE-mail: {cliente.Email}";
            }
        }

        [HttpPost]
        public string Post(Cliente cliente)
        {
            var clienteNovo = new Cliente(cliente.Nome, cliente.Nascimento, cliente.Email);

            _context.Clientes.Add(clienteNovo);
            _context.SaveChanges();

            clienteNovo.Nome = cliente.Nome;
            clienteNovo.Nascimento = cliente.Nascimento;
            clienteNovo.Email = cliente.Email;

            return $"Dados criados:\nId: {cliente.Id}\nNome: {cliente.Nome}\nNascimento: {cliente.Nascimento}\nE-mail: {cliente.Email}";
        }

        [HttpPut]
        public string UpdatePutById(Cliente cliente)
        {
            var resultado = _context.Clientes.Where(w => w.Id == cliente.Id).SingleOrDefault();

            resultado.Nome = cliente.Nome == "" ? resultado.Nome : cliente.Nome;
            resultado.Email = cliente.Email == "" ? resultado.Email : cliente.Email;
            resultado.Nascimento = cliente.Nascimento == "" ? resultado.Nascimento : cliente.Nascimento;

            _context.SaveChanges();

            return $"Dados criados:\nId: {cliente.Id}\nNome: {cliente.Nome}\nNascimento: {cliente.Nascimento}\nE-mail: {cliente.Email}";
        }

        [HttpPatch]
        public string UpdatePatchById(Cliente cliente)
        {
            var resultado = _context.Clientes.Where(w => w.Id == cliente.Id).SingleOrDefault();

            resultado.Nome = cliente.Nome == "" ? resultado.Nome : cliente.Nome;

            _context.SaveChanges();

            if (cliente.Nome == "")
            {
                return "Nome não alterado";
            }  
            else 
            {
                return $"Dado alterado:\nId: {cliente.Id}\nAntigo nome: {resultado.Nome}\nNovo nome: {cliente.Nome}";
            }
        }

        [HttpDelete("{id}")]
        public string Delete(string id)
        {
             var cliente = _context.Clientes.Where(w => w.Id == Guid.Parse(id)).SingleOrDefault();

             _context.Clientes.Remove(cliente);

             _context.SaveChanges();

            return $"Dados criados:\nId: {cliente.Id}\nNome: {cliente.Nome}\nNascimento: {cliente.Nascimento}\nE-mail: {cliente.Email}";
        }

    }
}
