using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Config;

public class ChefConfiguration : IEntityTypeConfiguration<Chef>
{
    public void Configure(EntityTypeBuilder<Chef> builder)
    {

            builder.ToTable("Chefs");

       
            builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("Id_Chef")
            .HasColumnType("int")
            .IsRequired();



            builder.Property(p => p.Nombre)
            .HasColumnName("nombrechef")
            .HasColumnType("varchar")
            .HasMaxLength(200)
            .IsRequired();

             builder.Property(p => p.Especialidad)
            .HasColumnName("especialidad")
            .HasColumnType("varchar")
            .HasMaxLength(200)
            .IsRequired();
    }
}