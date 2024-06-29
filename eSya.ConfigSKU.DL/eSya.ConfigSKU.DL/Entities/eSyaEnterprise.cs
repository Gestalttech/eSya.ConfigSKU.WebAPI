using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eSya.ConfigSKU.DL.Entities
{
    public partial class eSyaEnterprise : DbContext
    {
        public static string _connString = "";

        public eSyaEnterprise()
        {
        }

        public eSyaEnterprise(DbContextOptions<eSyaEnterprise> options)
            : base(options)
        {
        }

        public virtual DbSet<GtEiitct> GtEiitcts { get; set; } = null!;
        public virtual DbSet<GtEiitgc> GtEiitgcs { get; set; } = null!;
        public virtual DbSet<GtEiitgr> GtEiitgrs { get; set; } = null!;
        public virtual DbSet<GtEiitsc> GtEiitscs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(_connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GtEiitct>(entity =>
            {
                entity.HasKey(e => e.ItemCategory);

                entity.ToTable("GT_EIITCT");

                entity.Property(e => e.ItemCategory).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal).HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FormID");

                entity.Property(e => e.ItemCategoryDesc).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEiitgc>(entity =>
            {
                entity.HasKey(e => new { e.ItemGroup, e.ItemCategory, e.ItemSubCategory });

                entity.ToTable("GT_EIITGC");

                entity.Property(e => e.ComittmentAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal).HasMaxLength(50);

                entity.Property(e => e.Fastatus).HasColumnName("FAStatus");

                entity.Property(e => e.FormId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FormID");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.OriginalBudgetAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.RevisedBudgetAmount).HasColumnType("numeric(18, 6)");

                entity.HasOne(d => d.ItemCategoryNavigation)
                    .WithMany(p => p.GtEiitgcs)
                    .HasForeignKey(d => d.ItemCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_EIITGC_GT_EIITCT");

                entity.HasOne(d => d.ItemGroupNavigation)
                    .WithMany(p => p.GtEiitgcs)
                    .HasForeignKey(d => d.ItemGroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_EIITGC_GT_EIITGR");
            });

            modelBuilder.Entity<GtEiitgr>(entity =>
            {
                entity.HasKey(e => e.ItemGroup);

                entity.ToTable("GT_EIITGR");

                entity.Property(e => e.ItemGroup).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal).HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FormID");

                entity.Property(e => e.ItemGroupDesc).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEiitsc>(entity =>
            {
                entity.HasKey(e => new { e.ItemCategory, e.ItemSubCategory });

                entity.ToTable("GT_EIITSC");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal).HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FormID");

                entity.Property(e => e.ItemSubCategoryDesc).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.HasOne(d => d.ItemCategoryNavigation)
                    .WithMany(p => p.GtEiitscs)
                    .HasForeignKey(d => d.ItemCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_EIITSC_GT_EIITCT");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
