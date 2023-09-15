using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplication.Repository;

    public class HamburguesaRepository:GenericRepository<Hamburguesa>,IHamburguesa
    {

    private readonly PAppContext _context;

    public HamburguesaRepository(PAppContext context) : base(context)
    {
        _context = context;     
    }
    

      public async Task<IEnumerable<Hamburguesa>> GetHamburguesaVegetariana(string tipo) =>
                    await _context.Hamburguesas
                    .Where(h => h.Categoria.Equals("vegetariana")).ToListAsync();


                     public async Task<IEnumerable<Hamburguesa>> GetHamburguesaIntegral(string tipo) =>
                    await _context.Hamburguesas
                    .Where(h => h.Ingredientes.Equals("panintegral")).ToListAsync();
}


