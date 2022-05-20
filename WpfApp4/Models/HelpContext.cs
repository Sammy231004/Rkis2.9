using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WpfApp4
{
    public partial class HelpContext : DbContext
    {
        public HelpContext()
        {
        }

        public HelpContext(DbContextOptions<HelpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StatusTask> StatusTasks { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb ; Initial Catalog=2.9_opbd\\;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatusTask>(entity =>
            {
                entity.HasKey(e => e.IdstatusTask);

                entity.ToTable("StatusTask");

                entity.Property(e => e.IdstatusTask)
                    .ValueGeneratedNever()
                    .HasColumnName("IDStatusTask");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasKey(e => e.Idtask);

                entity.ToTable("Task");

                entity.Property(e => e.Idtask)
                    .ValueGeneratedNever()
                    .HasColumnName("IDTask");

                entity.Property(e => e.DatePuplic).HasColumnType("date");

                entity.Property(e => e.IdstatusTask).HasColumnName("IDStatusTask");

                entity.Property(e => e.IduserAccept).HasColumnName("IDUserAccept");

                entity.Property(e => e.IduserCreated).HasColumnName("IDUserCreated");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.IdstatusTaskNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.IdstatusTask)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_StatusTask");

                entity.HasOne(d => d.IduserAcceptNavigation)
                    .WithMany(p => p.TaskIduserAcceptNavigations)
                    .HasForeignKey(d => d.IduserAccept)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_User1");

                entity.HasOne(d => d.IduserCreatedNavigation)
                    .WithMany(p => p.TaskIduserCreatedNavigations)
                    .HasForeignKey(d => d.IduserCreated)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Iduser);

                entity.ToTable("User");

                entity.Property(e => e.Iduser)
                    .ValueGeneratedNever()
                    .HasColumnName("IDUser");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.NumberTel).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
