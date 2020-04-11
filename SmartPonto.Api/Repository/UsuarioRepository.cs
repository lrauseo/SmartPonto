using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartPonto.Api.Models;

namespace SmartPonto.Api.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PontoDB context;
        public UsuarioRepository(PontoDB context) 
        {
            this.context = context;
        }

        public async Task<Usuario[]> GetAllUsuarioAsync(bool includeEmpresa = false, bool includeLogin = false)
        {            
            IQueryable<Usuario> query = this.context.Usuarios;
            if(includeEmpresa)
                query = query.Include(i => i.Empresa);
            if(includeLogin)
                query = query.Include(i => i.Login);
            
            return await query.ToArrayAsync();
        }

        public async Task<Usuario> GetUsuarioByEmailAsync(string email, bool includeEmpresa = false, bool includeLogin = false)
        {
            IQueryable<Usuario> query = this.context.Usuarios.Where(a => a.Login.Email.ToLower() == email.ToLower());
            if(includeEmpresa)
                query = query.Include(i => i.Empresa);
            if(includeLogin)
                query = query.Include(i => i.Login);
            
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id, bool includeEmpresa = false, bool includeLogin = false)
        {
            IQueryable<Usuario> query = this.context.Usuarios.Where(a => a.Id == id);
            if(includeEmpresa)
                query = query.Include(i => i.Empresa);
            if(includeLogin)
                query = query.Include(i => i.Login);
            
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Usuario> GetUsuarioByLoginAsync(int loginId, bool includeEmpresa = false, bool includeLogin = false)
        {
            IQueryable<Usuario> query = this.context.Usuarios.Where(a => a.Login.Id == loginId);
            if(includeEmpresa)
                query = query.Include(i => i.Empresa);
            if(includeLogin)
                query = query.Include(i => i.Login);  
            return await query.FirstOrDefaultAsync();
        }

        
    }
}