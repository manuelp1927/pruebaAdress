using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models;

public partial class PruebaContext : DbContext
{
    public PruebaContext()
    {
    }

    public PruebaContext(DbContextOptions<PruebaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Presupuesto> Presupuestos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
  //      => optionsBuilder.UseSqlServer("server=localhost\\SQLEXPRESS; database=prueba; integrated security=true; Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Presupuesto>(entity =>
        {
            entity.HasKey(e => e.PresupuestoId).HasName("PK__presupue__DAAAB25C24A246F5");

            entity.ToTable("presupuesto");

            entity.Property(e => e.PresupuestoId).HasColumnName("presupuesto_id");
            entity.Property(e => e.Cantidad)
                .HasMaxLength(100)
                .HasColumnName("cantidad");
            entity.Property(e => e.Documentacion)
                .HasMaxLength(100)
                .HasColumnName("documentacion");
            entity.Property(e => e.FechaAdquision)
                .HasMaxLength(100)
                .HasColumnName("fechaAdquision");
            entity.Property(e => e.Proveedor)
                .HasMaxLength(100)
                .HasColumnName("proveedor");
            entity.Property(e => e.TipoBienServicio)
                .HasMaxLength(100)
                .HasColumnName("tipoBienServicio");
            entity.Property(e => e.Unidad)
                .HasMaxLength(100)
                .HasColumnName("unidad");
            entity.Property(e => e.ValorTotal)
                .HasMaxLength(100)
                .HasColumnName("valorTotal");
            entity.Property(e => e.ValorUnitario)
                .HasMaxLength(100)
                .HasColumnName("valorUnitario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
