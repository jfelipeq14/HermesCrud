using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HermesCrud.Models;

public partial class HermesContext : DbContext
{
    public HermesContext()
    {
    }

    public HermesContext(DbContextOptions<HermesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actividad> Actividad { get; set; }

    public virtual DbSet<CategoriaServicio> CategoriaServicio { get; set; }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<Departamento> Departamento { get; set; }

    public virtual DbSet<DetallePaqueteServicio> DetallePaqueteServicio { get; set; }

    public virtual DbSet<DetalleReservaViajero> DetalleReservaViajero { get; set; }

    public virtual DbSet<Municipio> Municipio { get; set; }

    public virtual DbSet<Pago> Pago { get; set; }

    public virtual DbSet<Pais> Pais { get; set; }

    public virtual DbSet<Paquete> Paquete { get; set; }

    public virtual DbSet<Permiso> Permiso { get; set; }

    public virtual DbSet<Privilegio> Privilegio { get; set; }

    public virtual DbSet<Programacion> Programacion { get; set; }

    public virtual DbSet<Reserva> Reserva { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<RolPrivilegio> RolPrivilegio { get; set; }

    public virtual DbSet<Servicio> Servicio { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Actividad>(entity =>
        {
            entity.HasKey(e => e.IdActividad).HasName("PK_idActividad");

            entity.ToTable("actividad");

            entity.HasIndex(e => e.NombreActividad, "UC_nombreActividad").IsUnique();

            entity.Property(e => e.IdActividad).HasColumnName("idActividad");
            entity.Property(e => e.NombreActividad)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nombreActividad");
        });

        modelBuilder.Entity<CategoriaServicio>(entity =>
        {
            entity.HasKey(e => e.IdCategoriaServicio);

            entity.ToTable("categoriaServicio");

            entity.HasIndex(e => e.NombreCategoriaServicio, "UC_nombreCategoriaServicio").IsUnique();

            entity.Property(e => e.IdCategoriaServicio).HasColumnName("idCategoriaServicio");
            entity.Property(e => e.NombreCategoriaServicio)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nombreCategoriaServicio");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK_idCliente");

            entity.ToTable("cliente");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.Direccion)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Eps)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("eps");
            entity.Property(e => e.EstadoCliente)
                .HasDefaultValue(true)
                .HasColumnName("estadoCliente");
            entity.Property(e => e.IdMunicipio).HasColumnName("idMunicipio");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.NumeroContacto)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("numeroContacto");
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sexo");
            entity.Property(e => e.TipoDeSangre)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("tipoDeSangre");

            entity.HasOne(d => d.oMunicipio).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdMunicipio)
                .HasConstraintName("FK_idMunicipio");

            entity.HasOne(d => d.oUsuario).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_idUsuario");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK_idDepartamento");

            entity.ToTable("departamento");

            entity.HasIndex(e => e.CodigoDepartamento, "UC_codigoDepartamento").IsUnique();

            entity.HasIndex(e => e.NombreDepartamento, "UC_nombreDepartamento").IsUnique();

            entity.Property(e => e.IdDepartamento).HasColumnName("idDepartamento");
            entity.Property(e => e.CodigoDepartamento).HasColumnName("codigoDepartamento");
            entity.Property(e => e.IdPais).HasColumnName("idPais");
            entity.Property(e => e.NombreDepartamento)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nombreDepartamento");

            entity.HasOne(d => d.oPais).WithMany(p => p.Departamentos)
                .HasForeignKey(d => d.IdPais)
                .HasConstraintName("FK_idPais");
        });

        modelBuilder.Entity<DetallePaqueteServicio>(entity =>
        {
            entity.HasKey(e => e.IdDetallePaqueteServicio).HasName("PK_idDetallePaqueteServicio");

            entity.ToTable("DetallePaqueteServicio");

            entity.Property(e => e.IdDetallePaqueteServicio).HasColumnName("idDetallePaqueteServicio");
            entity.Property(e => e.CantidadServicioPaquete).HasColumnName("cantidadServicioPaquete");
            entity.Property(e => e.IdPaquete).HasColumnName("idPaquete");
            entity.Property(e => e.IdServicio).HasColumnName("idServicio");
            entity.Property(e => e.ValorServicioPaquete)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("valorServicioPaquete");

            entity.HasOne(d => d.oPaquete).WithMany(p => p.DetallePaqueteServicios)
                .HasForeignKey(d => d.IdPaquete)
                .HasConstraintName("FK_idPackage");

            entity.HasOne(d => d.oServicio).WithMany(p => p.DetallePaqueteServicios)
                .HasForeignKey(d => d.IdServicio)
                .HasConstraintName("FK_idService");
        });

        modelBuilder.Entity<DetalleReservaViajero>(entity =>
        {
            entity.HasKey(e => e.IdDetalleReservaViajero).HasName("PK_idDetalleReservaViajero");

            entity.ToTable("detalleReservaViajero");

            entity.Property(e => e.IdDetalleReservaViajero).HasColumnName("idDetalleReservaViajero");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdReserva).HasColumnName("idReserva");

            entity.HasOne(d => d.oCliente).WithMany(p => p.DetalleReservaViajeros)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_idClienteReservaViajero");

            entity.HasOne(d => d.oReserva).WithMany(p => p.DetalleReservaViajeros)
                .HasForeignKey(d => d.IdReserva)
                .HasConstraintName("FK_idReserva");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.IdMunicipio).HasName("PK_idMunicipio");

            entity.ToTable("municipio");

            entity.HasIndex(e => e.CodigoMunicipio, "UC_codigoMunicipio").IsUnique();

            entity.HasIndex(e => e.NombreMunicipio, "UC_nombreMunicipio").IsUnique();

            entity.Property(e => e.IdMunicipio).HasColumnName("idMunicipio");
            entity.Property(e => e.CodigoMunicipio).HasColumnName("codigoMunicipio");
            entity.Property(e => e.IdDepartamento).HasColumnName("idDepartamento");
            entity.Property(e => e.NombreMunicipio)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nombreMunicipio");

            entity.HasOne(d => d.oDepartamento).WithMany(p => p.Municipios)
                .HasForeignKey(d => d.IdDepartamento)
                .HasConstraintName("FK_idDepartamento");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago);

            entity.ToTable("pago");

            entity.Property(e => e.IdPago).HasColumnName("idPago");
            entity.Property(e => e.Comprobante)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("comprobante");
            entity.Property(e => e.EstadoPago)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estadoPago");
            entity.Property(e => e.FechaPago).HasColumnName("fechaPago");
            entity.Property(e => e.IdReserva).HasColumnName("idReserva");
            entity.Property(e => e.ValorPago)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("valorPago");

            entity.HasOne(d => d.oReserva).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdReserva)
                .HasConstraintName("FK_reservation");
        });

        modelBuilder.Entity<Pais>(entity =>
        {
            entity.HasKey(e => e.IdPais).HasName("PK_idPais");

            entity.ToTable("pais");

            entity.HasIndex(e => e.CodigoPais, "UC_codigoPais").IsUnique();

            entity.HasIndex(e => e.NombrePais, "UC_nombrePais").IsUnique();

            entity.Property(e => e.IdPais).HasColumnName("idPais");
            entity.Property(e => e.CodigoPais).HasColumnName("codigoPais");
            entity.Property(e => e.NombrePais)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nombrePais");
        });

        modelBuilder.Entity<Paquete>(entity =>
        {
            entity.HasKey(e => e.IdPaquete);

            entity.ToTable("paquete");

            entity.Property(e => e.IdPaquete).HasColumnName("idPaquete");
            entity.Property(e => e.IdActividad).HasColumnName("idActividad");
            entity.Property(e => e.IdMunicipio).HasColumnName("idMunicipio");
            entity.Property(e => e.InversionPaquete)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("inversionPaquete");
            entity.Property(e => e.NivelActividad)
                .HasColumnType("decimal(2, 1)")
                .HasColumnName("nivelActividad");
            entity.Property(e => e.NombrePaquete)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nombrePaquete");
            entity.Property(e => e.ReservaPaquete)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("reservaPaquete");

            entity.HasOne(d => d.oActividad).WithMany(p => p.Paquetes)
                .HasForeignKey(d => d.IdActividad)
                .HasConstraintName("FK_idActividadPaquete");

            entity.HasOne(d => d.oMunicipio).WithMany(p => p.Paquetes)
                .HasForeignKey(d => d.IdMunicipio)
                .HasConstraintName("FK_idMunicipioPaquete");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.IdPermiso).HasName("PK_idPermiso");

            entity.ToTable("permiso");

            entity.HasIndex(e => e.NombrePermiso, "uc_nombrePermiso").IsUnique();

            entity.Property(e => e.IdPermiso).HasColumnName("idPermiso");
            entity.Property(e => e.EstadoPermiso)
                .HasDefaultValue(true)
                .HasColumnName("estadoPermiso");
            entity.Property(e => e.NombrePermiso)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nombrePermiso");
        });

        modelBuilder.Entity<Privilegio>(entity =>
        {
            entity.HasKey(e => e.IdPrivilegio).HasName("PK_idPrivilegio");

            entity.ToTable("privilegio");

            entity.HasIndex(e => e.NombrePrivilegio, "uc_nombrePrivilegio").IsUnique();

            entity.Property(e => e.IdPrivilegio).HasColumnName("idPrivilegio");
            entity.Property(e => e.IdPermiso).HasColumnName("idPermiso");
            entity.Property(e => e.NombrePrivilegio)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nombrePrivilegio");

            entity.HasOne(d => d.oPermiso).WithMany(p => p.Privilegios)
                .HasForeignKey(d => d.IdPermiso)
                .HasConstraintName("FK_idPermiso");
        });

        modelBuilder.Entity<Programacion>(entity =>
        {
            entity.HasKey(e => e.IdProgramacion).HasName("PK_idProgramation");

            entity.ToTable("programacion");

            entity.Property(e => e.IdProgramacion).HasColumnName("idProgramacion");
            entity.Property(e => e.FechaEjecucion).HasColumnName("fechaEjecucion");
            entity.Property(e => e.FechaFinInscripcion).HasColumnName("fechaFinInscripcion");
            entity.Property(e => e.FechaFinalizacion).HasColumnName("fechaFinalizacion");
            entity.Property(e => e.FechaInicioInscripcion).HasColumnName("fechaInicioInscripcion");
            entity.Property(e => e.HoraFinRecogida).HasColumnName("horaFinRecogida");
            entity.Property(e => e.HoraInicioRecogida).HasColumnName("horaInicioRecogida");
            entity.Property(e => e.IdPaquete).HasColumnName("idPaquete");

            entity.HasOne(d => d.oPaquete).WithMany(p => p.Programaciones)
                .HasForeignKey(d => d.IdPaquete)
                .HasConstraintName("FK_idPaquete");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PK_idReserva");

            entity.ToTable("reserva");

            entity.Property(e => e.IdReserva).HasColumnName("idReserva");
            entity.Property(e => e.EstadoReserva)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estadoReserva");
            entity.Property(e => e.FechaReserva).HasColumnName("fechaReserva");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdProgramacion).HasColumnName("idProgramacion");
            entity.Property(e => e.ValorReserva)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("valorReserva");

            entity.HasOne(d => d.oCliente).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_idCliente");

            entity.HasOne(d => d.oProgramacion).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdProgramacion)
                .HasConstraintName("FK_idProgramacion");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK_idRol");

            entity.ToTable("rol");

            entity.HasIndex(e => e.NombreRol, "UC_nombreRol").IsUnique();

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.EstadoRol)
                .HasDefaultValue(true)
                .HasColumnName("estadoRol");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nombreRol");
        });

        modelBuilder.Entity<RolPrivilegio>(entity =>
        {
            entity.HasKey(e => e.IdRolPrivilegio).HasName("PK_idRolPrivilegio");

            entity.ToTable("rolPrivilegio");

            entity.Property(e => e.IdRolPrivilegio).HasColumnName("idRolPrivilegio");
            entity.Property(e => e.IdPrivilegio).HasColumnName("idPrivilegio");
            entity.Property(e => e.IdRol).HasColumnName("idRol");

            entity.HasOne(d => d.oPrivilegio).WithMany(p => p.RolPrivilegios)
                .HasForeignKey(d => d.IdPrivilegio)
                .HasConstraintName("FK_idPrivilegio");

            entity.HasOne(d => d.oRol).WithMany(p => p.RolPrivilegios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_idRol");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK_Service");

            entity.ToTable("servicio");

            entity.HasIndex(e => e.NombreServicio, "UC_nombreServicio").IsUnique();

            entity.Property(e => e.IdServicio).HasColumnName("idServicio");
            entity.Property(e => e.EstadoServicio)
                .HasDefaultValue(true)
                .HasColumnName("estadoServicio");
            entity.Property(e => e.IdCategoriaServicio).HasColumnName("idCategoriaServicio");
            entity.Property(e => e.NombreServicio)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nombreServicio");
            entity.Property(e => e.ValorServicio)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("valorServicio");

            entity.HasOne(d => d.oCategoriaServicio).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.IdCategoriaServicio)
                .HasConstraintName("FK_categoryService");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK_idUsuario");

            entity.ToTable("usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Contrasenha)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contrasenha");
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.EstadoUsuario)
                .HasDefaultValue(true)
                .HasColumnName("estadoUsuario");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("identificacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("tipoDocumento");

            entity.HasOne(d => d.oRol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_idRolUsuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
