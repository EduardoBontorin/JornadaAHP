using JornadaAHP.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace JornadaAHP.Data
{
    public class FonteMapping : IEntityTypeConfiguration<Fonte>
    {
        public void Configure(EntityTypeBuilder<Fonte> builder)
        {
            builder.ToTable("Fontes");

            builder.HasKey(x => x.Id);

            builder.Property(x=> x.PartNumber).IsRequired(false);
            builder.Property(x => x.Preco).IsRequired();
            
        }
    }
}

