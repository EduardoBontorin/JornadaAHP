using JornadaAHP.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace JornadaAHP.Data
{
    public class DriveMapping : IEntityTypeConfiguration<Drive>
    {
        public void Configure(EntityTypeBuilder<Drive> builder)
        {
            builder.ToTable("Drives");

            builder.HasKey(x => x.Id);

            builder.Property(x=> x.PartNumber).IsRequired(false);
            
        }
    }
}
 