using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain.Entities;

namespace Persistencia.Data.Configuration;
public class TrainerClasroomConfiguration : IEntityTypeConfiguration<TrainerClassroom>
{
    public void Configure(EntityTypeBuilder<TrainerClassroom> builder)
    {
        // Aquí puedes configurar las propiedades de la entidad Marca
        // utilizando el objeto 'builder'.
        builder.ToTable("TrainerClasroom");
        
        builder.Property(e => e.IdPerson)
        .HasMaxLength(20);

        builder.Property(e => e.IdClassroom)
        .HasColumnType("int");

        builder.HasOne(e => e.Person)
        .WithMany(p => p.TrainerClassrooms)
        .HasForeignKey(p => p.IdPerson);

        builder.HasOne(e => e.Classroom)
        .WithMany(p => p.TrainerClassrooms)
        .HasForeignKey(p => p.IdClassroom);
    }
}
