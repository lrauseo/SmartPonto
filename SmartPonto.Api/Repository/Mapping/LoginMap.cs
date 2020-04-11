using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartPonto.Api.Models;

namespace SmartPonto.Api.Repository.Mapping
{
    public class LoginMap : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.HasIndex(i => i.Email).IsUnique();
            builder.HasIndex(i =>i.TokenLogin).IsUnique();
        }
    }
}