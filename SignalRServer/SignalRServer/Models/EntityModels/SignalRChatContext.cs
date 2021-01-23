using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SignalRServer.Models.EntityModels
{
    public partial class SignalRChatContext : DbContext
    {
        public SignalRChatContext()
        {
        }

        public SignalRChatContext(DbContextOptions<SignalRChatContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserChat> UserChat { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=SignalRChat;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserChat>(entity =>
            {
                entity.HasKey(e => e.Chatid);

                entity.HasIndex(e => new { e.Senderid, e.Receiverid })
                    .HasName("NonClusteredIndex-20200419-114105");

                entity.Property(e => e.Messagedate).HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
