using api_db_first.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace api_db_first.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuditoriaPrestamo> AuditoriaPrestamos { get; set; }

    public virtual DbSet<Calificacione> Calificaciones { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Cuenta> Cuentas { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<DetalleVenta> DetalleVentas { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<LogGeneral> LogGenerals { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ProductosAuditorium> ProductosAuditoria { get; set; }

    public virtual DbSet<Transaccione> Transacciones { get; set; }

    public virtual DbSet<UsuariosBiblioteca> UsuariosBibliotecas { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuditoriaPrestamo>(entity =>
        {
            entity.HasKey(e => e.AuditoriaId).HasName("PK__Auditori__095694E35A7EB0F2");

            entity.Property(e => e.AuditoriaId).HasColumnName("AuditoriaID");
            entity.Property(e => e.Accion).HasMaxLength(50);
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LibroId).HasColumnName("LibroID");
            entity.Property(e => e.PrestamoId).HasColumnName("PrestamoID");
            entity.Property(e => e.Usuario).HasMaxLength(100);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
        });

        modelBuilder.Entity<Calificacione>(entity =>
        {
            entity.HasKey(e => e.CalificacionId).HasName("PK__Califica__4CF54ABE38DF91F5");

            entity.Property(e => e.CalificacionId).HasColumnName("CalificacionID");
            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.EstudianteId).HasColumnName("EstudianteID");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Materia).HasMaxLength(100);
            entity.Property(e => e.Nota).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Periodo).HasMaxLength(20);

            entity.HasOne(d => d.Estudiante).WithMany(p => p.Calificaciones)
                .HasForeignKey(d => d.EstudianteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calificac__Estud__7B5B524B");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Clientes__71ABD0A74419B793");

            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Categoria)
                .HasMaxLength(20)
                .HasDefaultValue("Nuevo");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.TotalCompras)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Cuenta>(entity =>
        {
            entity.HasKey(e => e.CuentaId).HasName("PK__Cuentas__40072EA1CBF60C21");

            entity.HasIndex(e => e.NumeroCuenta, "UQ__Cuentas__E039507B27D47CA9").IsUnique();

            entity.Property(e => e.CuentaId).HasColumnName("CuentaID");
            entity.Property(e => e.Activa).HasDefaultValue(true);
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.FechaApertura)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NumeroCuenta).HasMaxLength(20);
            entity.Property(e => e.Saldo).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.TipoCuenta)
                .HasMaxLength(20)
                .HasDefaultValue("Ahorros");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cuentas__Cliente__52593CB8");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.DepartamentoId).HasName("PK__Departam__66BB0E1EBEA1FD54");

            entity.Property(e => e.DepartamentoId).HasColumnName("DepartamentoID");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.HasKey(e => e.DetalleId).HasName("PK__DetalleV__6E19D6FA92B15526");

            entity.Property(e => e.DetalleId).HasColumnName("DetalleID");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.VentaId).HasColumnName("VentaID");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleVe__Produ__47DBAE45");

            entity.HasOne(d => d.Venta).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.VentaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleVe__Venta__46E78A0C");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.EmpleadoId).HasName("PK__Empleado__958BE6F0C00909C1");

            entity.HasIndex(e => e.Departamento, "IX_Empleados_Departamento");

            entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Departamento).HasMaxLength(50);
            entity.Property(e => e.DepartamentoId).HasColumnName("DepartamentoID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FechaContratacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaUltimoAumento).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Salario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Telefono).HasMaxLength(20);

            entity.HasOne(d => d.DepartamentoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.DepartamentoId)
                .HasConstraintName("FK__Empleados__Depar__5FB337D6");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.EstudianteId).HasName("PK__Estudian__6F768338CFF747B3");

            entity.HasIndex(e => e.Carnet, "UQ__Estudian__5E387B4D51F39363").IsUnique();

            entity.Property(e => e.EstudianteId).HasColumnName("EstudianteID");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Carnet).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FechaIngreso)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.LibroId).HasName("PK__Libros__35A1EC8DCAC696B8");

            entity.Property(e => e.LibroId).HasColumnName("LibroID");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Autor).HasMaxLength(100);
            entity.Property(e => e.CopiasDisponibles).HasDefaultValue(1);
            entity.Property(e => e.CopiasTotal).HasDefaultValue(1);
            entity.Property(e => e.Editorial).HasMaxLength(100);
            entity.Property(e => e.Isbn)
                .HasMaxLength(20)
                .HasColumnName("ISBN");
            entity.Property(e => e.Titulo).HasMaxLength(200);
        });

        modelBuilder.Entity<LogGeneral>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__LogGener__5E5499A812683E65");

            entity.ToTable("LogGeneral");

            entity.Property(e => e.LogId).HasColumnName("LogID");
            entity.Property(e => e.Accion).HasMaxLength(50);
            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RegistroId).HasColumnName("RegistroID");
            entity.Property(e => e.Tabla).HasMaxLength(100);
            entity.Property(e => e.Usuario).HasMaxLength(100);
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.PrestamoId).HasName("PK__Prestamo__AA58A08087C568D3");

            entity.HasIndex(e => e.Estado, "IX_Prestamos_Estado");

            entity.Property(e => e.PrestamoId).HasColumnName("PrestamoID");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValue("Activo");
            entity.Property(e => e.FechaDevolucionEsperada).HasColumnType("datetime");
            entity.Property(e => e.FechaDevolucionReal).HasColumnType("datetime");
            entity.Property(e => e.FechaPrestamo)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LibroId).HasColumnName("LibroID");
            entity.Property(e => e.Multa)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Libro).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.LibroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prestamos__Libro__6EF57B66");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prestamos__Usuar__6FE99F9F");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK__Producto__A430AE83B835DC5D");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("trg_Productos_Auditoria");
                    tb.HasTrigger("trg_update_productos");
                });

            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<ProductosAuditorium>(entity =>
        {
            entity.HasKey(e => e.AuditoriaId).HasName("PK__Producto__095694E38953E6F1");

            entity.Property(e => e.AuditoriaId).HasColumnName("AuditoriaID");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PrecioAnterior).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PrecioNuevo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.Usuario).HasMaxLength(100);
        });

        modelBuilder.Entity<Transaccione>(entity =>
        {
            entity.HasKey(e => e.TransaccionId).HasName("PK__Transacc__86A849DEDB967C07");

            entity.HasIndex(e => e.Fecha, "IX_Transacciones_Fecha");

            entity.Property(e => e.TransaccionId).HasColumnName("TransaccionID");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Monto).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.TipoTransaccion)
                .HasMaxLength(20)
                .HasDefaultValue("Transferencia");

            entity.HasOne(d => d.CuentaDestinoNavigation).WithMany(p => p.TransaccioneCuentaDestinoNavigations)
                .HasForeignKey(d => d.CuentaDestino)
                .HasConstraintName("FK__Transacci__Cuent__5812160E");

            entity.HasOne(d => d.CuentaOrigenNavigation).WithMany(p => p.TransaccioneCuentaOrigenNavigations)
                .HasForeignKey(d => d.CuentaOrigen)
                .HasConstraintName("FK__Transacci__Cuent__571DF1D5");
        });

        modelBuilder.Entity<UsuariosBiblioteca>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE798B861C5F5");

            entity.ToTable("UsuariosBiblioteca");

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.TipoUsuario)
                .HasMaxLength(20)
                .HasDefaultValue("Estudiante");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.VentaId).HasName("PK__Ventas__5B41514C57913B69");

            entity.HasIndex(e => e.ClienteId, "IX_Ventas_ClienteID");

            entity.HasIndex(e => e.Fecha, "IX_Ventas_Fecha");

            entity.HasIndex(e => e.ProductoId, "IX_Ventas_ProductoID");

            entity.Property(e => e.VentaId).HasColumnName("VentaID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Venta)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ventas__ClienteI__4316F928");

            entity.HasOne(d => d.Producto).WithMany(p => p.Venta)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ventas__Producto__440B1D61");
        });

        modelBuilder.Entity<ProductoResult>().HasNoKey();
        modelBuilder.Entity<MensajeResult>().HasNoKey();

        OnModelCreatingPartial(modelBuilder);
    }

    public async Task<List<ProductoResult>> sp_Productos_Listar(
           string? nombre = null,
           bool soloActivos = true,
           decimal? precioMinimo = null,
           decimal? precioMaximo = null,
           int pageNumber = 1,
           int pageSize = 20)
    {
        return await Database.SqlQueryRaw<ProductoResult>(
            "EXEC sp_Productos_Listar @Nombre, @SoloActivos, @PrecioMinimo, @PrecioMaximo, @PageNumber, @PageSize",
            new SqlParameter("@Nombre", (object?)nombre ?? DBNull.Value),
            new SqlParameter("@SoloActivos", soloActivos),
            new SqlParameter("@PrecioMinimo", (object?)precioMinimo ?? DBNull.Value),
            new SqlParameter("@PrecioMaximo", (object?)precioMaximo ?? DBNull.Value),
            new SqlParameter("@PageNumber", pageNumber),
            new SqlParameter("@PageSize", pageSize)
        ).ToListAsync();
    }

    public async Task<ProductoResult?> sp_Productos_ObtenerPorID(int productoID)
    {
        var result = await Database.SqlQueryRaw<ProductoResult>(
            "EXEC sp_Productos_ObtenerPorID @ProductoID",
            new SqlParameter("@ProductoID", productoID)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    public async Task<ProductoResult?> sp_Productos_Insertar(
        string nombre,
        decimal precio,
        int stock,
        string? descripcion = null,
        bool activo = true)
    {
        var result = await Database.SqlQueryRaw<ProductoResult>(
       "EXEC sp_Productos_Insertar @Nombre, @Descripcion, @Precio, @Stock, @Activo",
       new SqlParameter("@Nombre", nombre),
       new SqlParameter("@Descripcion", (object?)descripcion ?? DBNull.Value),
       new SqlParameter("@Precio", precio),
       new SqlParameter("@Stock", stock),
       new SqlParameter("@Activo", activo)
   ).ToListAsync();

        return result.FirstOrDefault();
    }

    public async Task<ProductoResult?> sp_Productos_Actualizar(
        int productoID,
        string? nombre = null,
        string? descripcion = null,
        decimal? precio = null,
        int? stock = null,
        bool? activo = null)
    {
        return await Database.SqlQueryRaw<ProductoResult>(
            "EXEC sp_Productos_Actualizar @ProductoID, @Nombre, @Descripcion, @Precio, @Stock, @Activo",
            new SqlParameter("@ProductoID", productoID),
            new SqlParameter("@Nombre", (object?)nombre ?? DBNull.Value),
            new SqlParameter("@Descripcion", (object?)descripcion ?? DBNull.Value),
            new SqlParameter("@Precio", (object?)precio ?? DBNull.Value),
            new SqlParameter("@Stock", (object?)stock ?? DBNull.Value),
            new SqlParameter("@Activo", (object?)activo ?? DBNull.Value)
        ).FirstOrDefaultAsync();
    }

    public async Task<MensajeResult?> sp_Productos_Eliminar(int productoID)
    {
        return await Database.SqlQueryRaw<MensajeResult>(
            "EXEC sp_Productos_Eliminar @ProductoID",
            new SqlParameter("@ProductoID", productoID)
        ).FirstOrDefaultAsync();
    }

    public async Task<MensajeResult?> sp_Productos_EliminarFisico(int productoID)
    {
        return await Database.SqlQueryRaw<MensajeResult>(
            "EXEC sp_Productos_EliminarFisico @ProductoID",
            new SqlParameter("@ProductoID", productoID)
        ).FirstOrDefaultAsync();
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
