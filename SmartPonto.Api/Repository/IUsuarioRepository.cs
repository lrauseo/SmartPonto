using System.Threading.Tasks;
using SmartPonto.Api.Models;

namespace SmartPonto.Api.Repository
{
    public interface IUsuarioRepository
    {
         Task<Usuario> GetUsuarioByIdAsync(int id, bool includeEmpresa = false, bool includeLogin = false);
         Task<Usuario> GetUsuarioByEmailAsync(string email, bool includeEmpresa = false, bool includeLogin = false);
         Task<Usuario> GetUsuarioByLoginAsync(int loginId, bool includeEmpresa = false, bool includeLogin = false);
         Task<Usuario[]> GetAllUsuarioAsync(bool includeEmpresa = false, bool includeLogin = false );
    }
}