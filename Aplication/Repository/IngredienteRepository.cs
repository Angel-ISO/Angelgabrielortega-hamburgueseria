using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplication.Repository;

    public class IngredienteRepository:GenericRepository<Ingrediente>,IIngrediente
    {

    private readonly PAppContext _context;

    public IngredienteRepository(PAppContext context) : base(context)
    {
      _context = context;
    }




public async Task<IEnumerable<Ingrediente>> GetProductosAgotados(int cantidad) =>
                        await _context.Ingredientes
                        .Where(x => x.Stock >= 400)
                        .OrderByDescending(p => p.Stock)
                        .Take(400)
                        .ToListAsync();
}
