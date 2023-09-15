
using Dominio.Entities;

namespace Dominio.Interfaces
{
    public interface IChef : IGenericRepository<Chef>
    {
        Task<IEnumerable<Chef>> GetChefCarnico(string especialidad);
       // Task<IEnumerable<Chef>> GetHamburguesasChef(string platillos);
    }
}