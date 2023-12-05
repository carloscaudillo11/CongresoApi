using System;
using System.Collections.Generic;
using CongresoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CongresoApi.Context;

public partial class CongresoContext : DbContext
{
    public CongresoContext()
    {
    }

    public CongresoContext(DbContextOptions<CongresoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asiste> Asistes { get; set; }

    public virtual DbSet<Conferencia> Conferencias { get; set; }

    public virtual DbSet<Participante> Participantes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-GPL4MCG\\MSSQLSERVER2;Database=Congreso;Trust Server Certificate=true;User Id=sa;Password=12345678;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asiste>(entity =>
        {
            entity.HasKey(e => e.IdParticipanteConf).HasName("PK__Asiste__CA425C14717DAAD0");

            entity.ToTable("Asiste");

            entity.Property(e => e.IdParticipanteConf).HasColumnName("ID_participante_conf");
            entity.Property(e => e.FkConferencias).HasColumnName("fk_conferencias");
            entity.Property(e => e.FkParticipantes).HasColumnName("fk_participantes");

            entity.HasOne(d => d.FkConferenciasNavigation).WithMany(p => p.Asistes)
                .HasForeignKey(d => d.FkConferencias)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Asiste__fk_confe__29572725");

            entity.HasOne(d => d.FkParticipantesNavigation).WithMany(p => p.Asistes)
                .HasForeignKey(d => d.FkParticipantes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Asiste__fk_parti__286302EC");
        });

        modelBuilder.Entity<Conferencia>(entity =>
        {
            entity.HasKey(e => e.IdConf).HasName("PK__Conferen__744A9E9C5F6A91B9");

            entity.Property(e => e.IdConf).HasColumnName("ID_conf");
            entity.Property(e => e.Conferencista)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.Horario).HasColumnType("date");
            entity.Property(e => e.NombreConf)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Participante>(entity =>
        {
            entity.HasKey(e => e.IdParticipantes).HasName("PK__Particip__3DF813EA1340E45D");

            entity.Property(e => e.IdParticipantes).HasColumnName("ID_participantes");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Avatar)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Ocupacion)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.Twitter)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
