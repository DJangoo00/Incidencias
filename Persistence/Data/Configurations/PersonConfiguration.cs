using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain.Entities;

namespace Persistencia.Data.Configuration;
public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        // Aquí puedes configurar las propiedades de la entidad Marca
        // utilizando el objeto 'builder'.
        builder.ToTable("Person");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
        .HasMaxLength(10);

        builder.Property(e => e.FirstName)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(e => e.LastName)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(e => e.Adress)
        .IsRequired()
        .HasMaxLength(100);

        builder.HasOne(e => e.Gender)
        .WithMany(p => p.Persons)
        .HasForeignKey(p => p.IdGenderFk);
        
        builder.HasOne(e => e.City)
        .WithMany(p => p.Persons)
        .HasForeignKey(p => p.IdCityFk);

        builder.HasOne(e => e.PersonType)
        .WithMany(p => p.Persons)
        .HasForeignKey(p => p.IdPersonTypeFk);
    }
}