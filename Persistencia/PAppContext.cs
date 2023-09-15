using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public class PAppContext : DbContext
    {
        public PAppContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioRoles> UsuariosRoles { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Chef> Chefs { get; set; }
         public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Hamburguesa_ingrediente> Hamburguesa_Ingredientes { get; set; }
        public DbSet<Hamburguesa> Hamburguesas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    
    }
}