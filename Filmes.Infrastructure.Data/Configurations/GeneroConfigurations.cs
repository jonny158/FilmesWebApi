using Filmes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filmes.Infrastructure.Data.Configurations
{
    public class GeneroConfiguration : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            
            builder.ToTable("Genero");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).HasMaxLength(100).IsRequired();
            builder.Property(u => u.Active).IsRequired();

            // Configuração do relacionamento entre Filme e Genero
            builder.HasMany(u => u.Filmes)
                .WithOne(p => p.Genero)
                .HasForeignKey(p => p.IdGenero);
        }
    }
}
