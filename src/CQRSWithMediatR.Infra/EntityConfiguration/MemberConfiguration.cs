﻿using CQRSWithMediatR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRSWithMediatR.Infra.EntityConfiguration;
public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(m => m.LastName).HasMaxLength(100).IsRequired();
        builder.Property(m => m.Gender).HasMaxLength(10).IsRequired();
        builder.Property(m => m.Email).HasMaxLength(150).IsRequired();
        builder.Property(m => m.IsActive).IsRequired();

        builder.HasData(
            new Member(1, "Matheus", "Silva", "masculino", "m@m.com", true),
            new Member(2, "Ana", "Alves", "feminino", "a@a.com", true)
        );
    }
}
