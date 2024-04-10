using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniMercado.Context;
using MiniMercado.Model;
using MiniMercado.Repositories;

namespace MiniMercado.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuariosController(IUsuarioRepository repository)  
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            var usuarios = _repository.GetUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id:int}", Name = "ObterUsuario")]
        public ActionResult<Usuario> Get(int id)
        {
            var usuario = _repository.GetUsuario(id);
            if (usuario == null)
            {
                return NotFound("Produto nao encontrado");
            }
            return Ok(usuario);

        }

        [HttpPost]
        public ActionResult Post(Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            var UsuarioCriado = _repository.Create(usuario);

            return new CreatedAtRouteResult("ObterUsuario",
                new { id = UsuarioCriado.Id }, UsuarioCriado);
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Usuario usuario)
        {

            if (id != usuario.Id)
            {
                return NotFound();
            }

            _repository.Update(usuario);
            return Ok(usuario);
        }


        [HttpDelete("{id:int}")]

        public ActionResult Delete(int id) { 
        
            var usuario = _repository.Delete(id);   
            if(usuario == null)
            {
                return NotFound();
            }
            var usuarioExcluido = _repository.Delete(id);
            return Ok(usuarioExcluido);
        }
    }
}
