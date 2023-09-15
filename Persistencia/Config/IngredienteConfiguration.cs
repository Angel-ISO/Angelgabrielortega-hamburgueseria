using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Config;

public class IngredienteConfiguration : IEntityTypeConfiguration<Ingrediente>
{
    public void Configure(EntityTypeBuilder<Ingrediente> builder)
    {

            builder.ToTable("Ingredientes");

       
            builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("Id_Ingrediente")
            .HasColumnType("int")
            .IsRequired();

            builder.Property(p => p.Nombre)
            .HasColumnName("NameIngrediente")
            .HasColumnType("varchar")
            .HasMaxLength(200)
            .IsRequired();


            builder.Property(p => p.Descripcion)
            .HasColumnName("Descripcion")
            .HasColumnType("varchar")
            .HasMaxLength(200)
            .IsRequired();

            builder.Property(p => p.Precio)
            .HasColumnName("precio")
            .HasColumnType("int")
            .IsRequired();

            builder.Property(p => p.Stock)
            .HasColumnName("stock")
            .HasColumnType("int")
            .IsRequired();

    }
}