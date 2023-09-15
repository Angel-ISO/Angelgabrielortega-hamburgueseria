
namespace Dominio.Entities;

    public class Hamburguesa : BaseEntity
    {
        public string Nombre { get; set; }
        public int Precio { get; set;}
        public int Id_Chef { get; set; }
        public Chef Chef{ get; set; }
        public int Id_Categoria { get; set; }
         public Categoria Categoria{ get; set; }
        public ICollection<Ingrediente> Ingredientes { get; set; } = new HashSet<Ingrediente>();
        public ICollection<Hamburguesa_ingrediente> Hamburguesa_Ingredientes { get; set; }
    }
