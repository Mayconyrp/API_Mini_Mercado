using MiniMercado.Model;

namespace MiniMercado.Repositories
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> GetUsuarios();

        Usuario GetUsuario(int id);
        Usuario Create(Usuario usuario);
        Usuario Update(Usuario usuario);
        Usuario Delete(int id);
    }
}
