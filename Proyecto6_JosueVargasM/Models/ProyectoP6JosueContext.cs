using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Proyecto6_JosueVargasM.Models;

public partial class ProyectoP6JosueContext : DbContext
{
    public ProyectoP6JosueContext()
    {
    }

    public ProyectoP6JosueContext(DbContextOptions<ProyectoP6JosueContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<HistorialMedico> HistorialMedicos { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Recepcionistum> Recepcionista { get; set; }

    public virtual DbSet<SistemaDeCita> SistemaDeCitas { get; set; }

    public virtual DbSet<UsuarioRol> UsuarioRols { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:azurejosue.database.windows.net,1433;Initial Catalog=Proyecto_P6_Josue;Persist Security Info=False;User ID=CloudSA32c1bfb5;Password=Josuevm1701;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.Idcitas).HasName("PK__Citas__45E162B6A147082A");

            entity.Property(e => e.Idcitas)
                .ValueGeneratedNever()
                .HasColumnName("idcitas");
            entity.Property(e => e.Doctor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("doctor");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Hora).HasColumnName("hora");
            entity.Property(e => e.Motivo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("motivo");
            entity.Property(e => e.Paciente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("paciente");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Iddoctor).HasName("PK__Doctor__D03B50261E20FE8C");

            entity.ToTable("Doctor");

            entity.Property(e => e.Iddoctor)
                .ValueGeneratedNever()
                .HasColumnName("iddoctor");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Horariodeatencion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("horariodeatencion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<HistorialMedico>(entity =>
        {
            entity.HasKey(e => e.Idhistorial).HasName("PK__Historia__E931D0DBC60C7395");

            entity.ToTable("HistorialMedico");

            entity.Property(e => e.Idhistorial)
                .ValueGeneratedNever()
                .HasColumnName("idhistorial");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Diagnostico)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("diagnostico");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Examenes)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("examenes");
            entity.Property(e => e.Paciente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("paciente");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.Idpaciente).HasName("PK__Paciente__58611A0ADC4BBB6D");

            entity.ToTable("Paciente");

            entity.Property(e => e.Idpaciente)
                .ValueGeneratedNever()
                .HasColumnName("idpaciente");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Fechanacimiento).HasColumnName("fechanacimiento");
            entity.Property(e => e.FkHistorialmedico).HasColumnName("fk_historialmedico");
            entity.Property(e => e.Genero)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("genero");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.FkHistorialmedicoNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.FkHistorialmedico)
                .HasConstraintName("FK__Paciente__fk_his__6A30C649");
        });

        modelBuilder.Entity<Recepcionistum>(entity =>
        {
            entity.HasKey(e => e.Idrecepcionista).HasName("PK__Recepcio__2CCBC2898488C87E");

            entity.Property(e => e.Idrecepcionista)
                .ValueGeneratedNever()
                .HasColumnName("idrecepcionista");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Cedula)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cedula");
            entity.Property(e => e.Contrasennia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contrasennia");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.UsuarioRol).WithMany(p => p.Recepcionista)
                .HasForeignKey(d => d.UsuarioRolId)
                .HasConstraintName("FK_Recepcionista_UsuarioRol");
        });

        modelBuilder.Entity<SistemaDeCita>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Agendamedicos).HasColumnName("agendamedicos");
            entity.Property(e => e.Citas).HasColumnName("citas");
            entity.Property(e => e.Medico).HasColumnName("medico");

            entity.HasOne(d => d.AgendamedicosNavigation).WithMany()
                .HasForeignKey(d => d.Agendamedicos)
                .HasConstraintName("FK__SistemaDe__agend__7D439ABD");

            entity.HasOne(d => d.CitasNavigation).WithMany()
                .HasForeignKey(d => d.Citas)
                .HasConstraintName("FK__SistemaDe__citas__7B5B524B");

            entity.HasOne(d => d.MedicoNavigation).WithMany()
                .HasForeignKey(d => d.Medico)
                .HasConstraintName("FK__SistemaDe__medic__7C4F7684");
        });

        modelBuilder.Entity<UsuarioRol>(entity =>
        {
            entity.HasKey(e => e.UsuarioRolId).HasName("PK__UsuarioR__C869CDCA1CCAEC3A");

            entity.ToTable("UsuarioRol");

            entity.Property(e => e.UsuarioRolId).ValueGeneratedNever();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
