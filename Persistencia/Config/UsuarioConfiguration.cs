using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("User");


            builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("Id_User")
            .HasColumnType("int")
            .IsRequired();


             builder.Property(p => p.Username)
            .HasColumnName("NameUser")
            .HasColumnType("varchar")
            .HasMaxLength(150)
            .IsRequired();



            builder
            .HasMany(p => p.Roles)
            .WithMany(p => p.Usuarios)
            .UsingEntity<UsuarioRoles>(
                j => j
                    .HasOne(pt => pt.Rol)
                    .WithMany(t => t.UsuariosRoles)
                    .HasForeignKey(pt => pt.RolId),
                j => j
                    .HasOne(pt => pt.Usuario)
                    .WithMany(p => p.UsuariosRoles)
                    .HasForeignKey(pt => pt.UsuarioId),
                j =>
                {
                    j.HasKey(t => new { t.UsuarioId, t.RolId });
                });

        }
    }
}