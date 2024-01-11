using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace KonyvekFeladat.Models;

public partial class KonyvekContext : DbContext
{
    public KonyvekContext()
    {
    }

    public KonyvekContext(DbContextOptions<KonyvekContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Konyv> Konyvs { get; set; }

    public virtual DbSet<Nemzetiseg> Nemzetisegs { get; set; }

    public virtual DbSet<Szerzo> Szerzos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=192.168.56.1;database=Konyvek;user=root;password=password;sslmode=none", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.2.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_hungarian_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Konyv>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Konyv");

            entity.Property(e => e.Cim).HasMaxLength(64);
            entity.Property(e => e.Kiadev).HasColumnType("datetime");
            entity.Property(e => e.Szerzo).HasMaxLength(16);
        });

        modelBuilder.Entity<Nemzetiseg>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Nemzetiseg");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.SzerzoNemzetiseg).HasMaxLength(16);
        });

        modelBuilder.Entity<Szerzo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Szerzo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nev).HasMaxLength(16);

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
