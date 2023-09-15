
using Dominio.Entities;

namespace Dominio.Interfaces
{
    public interface IHamburguesa : IGenericRepository<Hamburguesa>
    {
        Task<IEnumerable<Hamburguesa>> GetHamburguesaVegetariana(string tipo);
        Task<IEnumerable<Hamburguesa>> GetHamburguesaIntegral(string tipopan);
    }
}