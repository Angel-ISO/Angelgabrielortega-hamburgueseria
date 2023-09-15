using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplication.Repository;

    public class CategoriaRepository:GenericRepository<Categoria>,ICategoria
    {
     private readonly PAppContext _context;
    public CategoriaRepository(PAppContext context) : base(context)
    {
         _context = context;
    }
    public override async Task<IEnumerable<Categoria>> GetAllAsync()
    {
        return await _context.Categorias.Include(p => p.Hamburguesas)
        .ToListAsync();
    }
}
