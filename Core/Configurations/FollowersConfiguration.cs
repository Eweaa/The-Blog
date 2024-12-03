using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Configurations;

public class FollowersConfiguration : IEntityTypeConfiguration<Followers>
{
    public void Configure(EntityTypeBuilder<Followers> builder)
    {
        builder.HasKey(b => new { b.UserName, b.FollowedUserName });
        builder.HasIndex(b => b.UserName);
    }
}