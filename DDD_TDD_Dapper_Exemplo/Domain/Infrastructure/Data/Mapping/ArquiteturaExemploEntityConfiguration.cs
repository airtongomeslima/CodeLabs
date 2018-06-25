using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API.Data.SqlServer.Entities;

namespace API.Domain.Infrastructure.Data.Mapping
{
    public class ArquiteturaExemploEntityConfiguration : IEntityTypeConfiguration<ArquiteturaExemplo>
    {
        public void Configure(EntityTypeBuilder<ArquiteturaExemplo> builder)
        {
            builder.ToTable("ArquiteturaExemplo");

            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Nome)
                    .IsRequired()
                    .HasMaxLength(150);

            builder.Property(_ => _.Descricao)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
