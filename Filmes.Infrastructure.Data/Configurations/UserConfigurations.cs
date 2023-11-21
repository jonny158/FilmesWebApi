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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            
            builder.ToTable("User");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Username).HasMaxLength(50).IsRequired();
            builder.Property(u => u.Password).HasMaxLength(20).IsRequired();
        }
    }
}
