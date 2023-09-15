
using Dominio.Entities;

namespace Dominio.Interfaces
{
    public interface IIngrediente : IGenericRepository<Ingrediente>
    {
           Task<IEnumerable<Ingrediente>> GetProductosAgotados(int cantidad);
    }
}