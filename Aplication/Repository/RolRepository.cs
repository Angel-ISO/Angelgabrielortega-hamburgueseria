using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;

    public class RolRepository:GenericRepository<Rol>,IRol
    {
        private readonly PAppContext _context;

    public RolRepository(PAppContext context) : base(context)
    {
        _context = context;
    }
    
    }
