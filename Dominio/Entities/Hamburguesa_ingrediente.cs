namespace Dominio.Entities;

    public class Hamburguesa_ingrediente
    {
        public int Hamburguesa_Id { get; set; }
        public Hamburguesa Hamburguesa { get; set; }
        public int Ingrediente_Id { get; set; }
        public Ingrediente Ingredientes { get; set; }
    }
