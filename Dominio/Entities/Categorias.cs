

namespace Dominio.Entities;

    public class Categoria : BaseEntity
    {
        public string Nombre { get; set; }
        public string Description { get; set; }
       public ICollection<Hamburguesa> Hamburguesas  { get; set; }
    }
