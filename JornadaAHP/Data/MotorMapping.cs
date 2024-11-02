using JornadaAHP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaAHP.Data
{
    public class MotorMapping : IEntityTypeConfiguration<Motor>
    {
        public void Configure(EntityTypeBuilder<Motor> builder)
        {
            builder.ToTable("Motores");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Empresa)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(128)
                .IsRequired(false);

            builder.Property(x => x.PartNumber)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(128)
                .IsRequired(true);


            builder.Property(x => x.Categoria)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(128)
                .IsRequired(true);

            builder.Property(x=> x.Valor)
                .HasColumnType("DECIMAL")
                .IsRequired(true);

            builder.Property(x => x.Prazo)
                .HasColumnType("INT")
                .IsRequired(true);

            builder.Property(x => x.RpmMaximo)
                .IsRequired(true);

            builder.Property(x=> x.Peso)
                .HasColumnType("DECIMAL")
                .IsRequired(true);

            builder.Property(x=> x.ForcaMaxima)
                .HasColumnType("DECIMAL")
                .IsRequired(true);

            builder.HasOne(x => x.Fonte)
                .WithMany(o => o.Motores)
                .HasForeignKey(x => x.FonteId)
                .IsRequired(true);

            builder.HasOne(x => x.Drive)
                .WithMany(o=> o.Motores)
                .HasForeignKey(x=> x.DriveId)
                .IsRequired(true);

        }
    }
}