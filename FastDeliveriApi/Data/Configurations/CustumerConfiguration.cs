using FastDeliveriApi.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastDeliveriApi.Data.Configurations;

public class CustumerConfiguration : IEntityTypeConfiguration<Custumer>
{
    public void Configure(EntityTypeBuilder<Custumer> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Name)
            .HasMaxLength(100)
            .HasColumnType("text")
            .IsRequired();

            builder.Property(b => b.PhoneNumber)
            .HasMaxLength(9)
            .HasColumnType("text")
            .HasColumnName("PhomeNumberCustumer");

            builder.Property(b => b.Email)
            .HasMaxLength(120)
            .HasColumnType("text")
            .IsRequired();

            builder.Property(b => b.Address)
            .HasMaxLength(120)
            .HasColumnType("text")
            .IsRequired();

            builder.HasData(
                new Custumer
                {
                    Id = 1,
                    Name = "Jorge Argueta",
                    Email = "JorgeArgueta@univo.edu.sv",
                    Address = "Morazan",
                    PhoneNumber = "7889-9639",
                    Status = true
                },
                new Custumer
                {
                    Id = 2,
                    Name = "Javier Ramirez",
                    Email = "JavieraRamirez@univo.edu.sv",
                    Address = "Morazan",
                    PhoneNumber = "7999-9639",
                    Status = true
                }
            );
    }
}