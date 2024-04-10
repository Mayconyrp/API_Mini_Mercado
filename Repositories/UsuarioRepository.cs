using Microsoft.EntityFrameworkCore;
using MiniMercado.Context;
using MiniMercado.Model;

namespace MiniMercado.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Usuario> GetUsuarios()
        {
           var usuarios = _context.Usuarios.ToList();
           return usuarios;
        }

        public Usuario GetUsuario(int id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Id == id);

        }


        public Usuario Create(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public Usuario Update(Usuario usuario)
        {
            if(usuario is null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
            return usuario;
        }

        public Usuario Delete(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario is null)
            {
                return null;            
            }
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges(); 
            return usuario;e
        }
    }
}
