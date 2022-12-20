﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Span.Culturio.Users.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public class UserConfigurationBuilder : IEntityTypeConfiguration<User>
        {
            public void Configure(EntityTypeBuilder<User> builder)
            {
                builder.ToTable("Users");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
                builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
                builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
                builder.Property(x => x.UserName).IsRequired().HasMaxLength(100);
                builder.Property(x => x.PasswordHash).IsRequired();
                builder.Property(x => x.PasswordSalt).IsRequired();
            }
        }
    }
}
