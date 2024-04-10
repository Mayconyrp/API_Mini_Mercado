using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniMercado.Context;
using MiniMercado.Model;
using System.IO.Enumeration;

namespace MiniMercado.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Enviar(Produto produto)
        {
            if (produto == null)
            {
                return BadRequest("O produto não pode ser nulo.");
            }

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpGet]
        public IEnumerable<Produto> Puxar()
        {
            var produtos = _context.Produtos.ToList();
            if(produtos is null)
            {
                return null;
            }
            return produtos;
        }
    }
}
