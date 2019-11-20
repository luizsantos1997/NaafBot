using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NaafBot.Models
{
    public partial class dbchatruyContext : DbContext
    {
        public dbchatruyContext()
        {
        }

        public dbchatruyContext(DbContextOptions<dbchatruyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Question> Question { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("workstation id=dbchatruy.mssql.somee.com;packet size=4096;user id=sa_chatbot;pwd=Qazxsw123;data source=dbchatruy.mssql.somee.com;persist security info=False;initial catalog=dbchatruy");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DtCriacao)
                    .HasColumnName("DT_CRIACAO")
                    .HasColumnType("datetime");

                entity.Property(e => e.TxQuestion)
                    .IsRequired()
                    .HasColumnName("TX_QUESTION")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });
        }
    }
}
