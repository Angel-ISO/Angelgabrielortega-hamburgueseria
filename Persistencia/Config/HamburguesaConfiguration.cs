using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Config
{
    public class HamburguesaConfiguration : IEntityTypeConfiguration<Hamburguesa>
    {
        public void Configure(EntityTypeBuilder<Hamburguesa> builder)
        {
            builder.ToTable("Hamburguesas");


            builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("Id_Hamburguesa")
            .HasColumnType("int")
            .IsRequired();


             builder.Property(p => p.Nombre)
            .HasColumnName("NameHamburguesa")
            .HasColumnType("varchar")
            .HasMaxLength(150)
            .IsRequired();

             builder.Property(p => p.Precio)
            .HasColumnName("precio")
            .HasColumnType("int")
            .IsRequired();

              builder.Property(p => p.Id_Categoria)
            .HasColumnName("categoriaid")
            .HasColumnType("int")
            .HasMaxLength(150);


              builder.Property(p => p.Id_Chef)
            .HasColumnName("chefid")
            .HasColumnType("int")
            .HasMaxLength(150);

      builder.HasOne(u => u.Categoria)
            .WithMany(a => a.Hamburguesas)
            .HasForeignKey(u => u.Id_Categoria)
            .IsRequired();

             builder.HasOne(u => u.Chef)
            .WithMany(a => a.Hamburguesas)
            .HasForeignKey(u => u.Id_Chef)
            .IsRequired();
            


            builder
            .HasMany(p => p.Ingredientes)
            .WithMany(p => p.Hamburguesas)
            .UsingEntity<Hamburguesa_ingrediente>(
                j => j
                    .HasOne(pt => pt.Ingredientes)
                    .WithMany(t => t.Hamburguesa_Ingredientes)
                    .HasForeignKey(pt => pt.Ingrediente_Id),
                j => j
                    .HasOne(pt => pt.Hamburguesa)
                    .WithMany(p => p.Hamburguesa_Ingredientes)
                    .HasForeignKey(pt => pt.Hamburguesa_Id),
                j =>
                {
                    j.HasKey(t => new { t.Hamburguesa_Id, t.Ingrediente_Id });
                });

        }
    }
}