using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain.Entities;


namespace Persistencia.Data.Configuration;
public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        // Aquí puedes configurar las propiedades de la entidad Marca
        // utilizando el objeto 'builder'.
        builder.ToTable("City");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
        .HasMaxLength(10);
        
        builder.Property(e => e.Name)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(e => e.Departament)
        .WithMany(e => e.Cities)
        .HasForeignKey(e => e.IdDepartamentFk);
    }
}
