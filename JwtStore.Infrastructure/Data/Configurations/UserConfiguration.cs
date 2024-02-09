using JwtStore.Core.AccountContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwtStore.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Name)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(120)
            .IsRequired();

        builder.OwnsOne(u => u.Email)
            .Property(e => e.Address)
            .HasColumnType("VARCHAR")
            .HasMaxLength(255)
            .IsRequired();

        builder.OwnsOne(u => u.Email)
            .OwnsOne(e => e.Verification)
            .Property(v => v.Code)
            .HasColumnType("CHAR")
            .HasMaxLength(6)
            .IsRequired();

        builder.OwnsOne(u => u.Email)
            .OwnsOne(e => e.Verification)
            .Property(v => v.ExpiresAt);

        builder.OwnsOne(u => u.Email)
            .OwnsOne(e => e.Verification)
            .Property(v => v.VerifiedAt);

        builder.OwnsOne(u => u.Email)
            .OwnsOne(e => e.Verification)
            .Ignore(v => v.IsActive);

        builder.OwnsOne(u => u.Password)
            .Property(p => p.Hash)
            .IsRequired();

        builder.OwnsOne(u => u.Password)
            .Property(p => p.ResetCode)
            .IsRequired();

        builder.Property(u => u.Image)
            .HasColumnType("VARCHAR")
            .HasMaxLength(255)
            .IsRequired();
    }
}
