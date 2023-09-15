using Dominio.Interfaces;
using Persistencia;
using Aplicacion.Repository;

namespace Aplicacion.UnitOfWork;

    public class UnitOfWork : IUnitOfWork, IDisposable 
    {
        private readonly PAppContext _context;

        private UsuarioRepository _Usuario;
        private RolRepository _Rol;
        public UnitOfWork(PAppContext context)
        {
            _context = context;
        }

        public IUsuario Usuarios
    {
        get
        {
            if (_Usuario is not null)
            {
                return _Usuario;
            }
            return _Usuario = new UsuarioRepository(_context);
        }
    }


    public IRol Roles
    {
        get
        {
            if (_Rol is not null)
            {
                return _Rol;
            }
            return _Rol = new RolRepository(_context);
        }
    }


    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveAsync(){
        return await _context.SaveChangesAsync();
    }

} 