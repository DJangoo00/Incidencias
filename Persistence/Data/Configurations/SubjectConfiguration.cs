using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain.Entities;

namespace Persistencia.Data.Configuration;
public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        // Aquí puedes configurar las propiedades de la entidad Marca
        // utilizando el objeto 'builder'.
        builder.ToTable("Subject");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
        .HasMaxLength(10);

        builder.HasOne(e => e.Person)
        .WithMany(p => p.Subjects)
        .HasForeignKey(p => p.IdPersonFk);
        
        builder.HasOne(e => e.Classroom)
        .WithMany(p => p.Subjects)
        .HasForeignKey(p => p.IdClassroomFk);

        //aclarar duda en el desarrollo de este modulo
    }
}
