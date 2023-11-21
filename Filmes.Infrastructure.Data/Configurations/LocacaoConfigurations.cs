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
    public class LocacaoConfiguration : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            
            builder.ToTable("Locacao");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Cpf).HasMaxLength(14).IsRequired();
            builder.Property(u => u.DataLocacao).IsRequired();

           
        }
    }
}
