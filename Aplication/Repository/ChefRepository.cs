using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplication.Repository;

public class ChefRepository : GenericRepository<Chef>, IChef
{

    private readonly PAppContext _context;

    public ChefRepository(PAppContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Chef>> GetChefCarnico(string especialidad) =>
                      await _context.Chefs
                      .Where(h => h.Especialidad.Equals("carnes")).ToListAsync();


   /*  public async Task<IEnumerable<Chef>> GetHamburguesasChef(string platillo) =>
                        await _context.Chefs.Join(hamburguesa,
                        chef => chef,                                  //incompleto
                        Hamburguesa => Hamburguesa.Owner,
                        (Hamburguesa, Chef) => new { name = Chef.name, Hamburguesa = Hamburguesa.Name }); */


}
