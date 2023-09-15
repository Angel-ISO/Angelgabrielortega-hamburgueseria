using System.Linq.Expressions;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplication.Repository;

public class UsuarioRepository : GenericRepository<Usuario>, IUsuario
{
     private readonly PAppContext _context;

    public UsuarioRepository(PAppContext context) : base(context)
    {
        _context = context;
    }
        public async Task<Usuario> GetByUsernameAsync(string username)
    {
        return await _context.Usuarios
                            .Include(u=>u.Roles)
                            .FirstOrDefaultAsync(u=>u.Username.ToLower()==username.ToLower());
    }
   
}