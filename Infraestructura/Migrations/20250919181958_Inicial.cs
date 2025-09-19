using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "agencias_delivery",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    costo_base = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    tiempo_entrega_horas = table.Column<int>(type: "int", nullable: true),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agencias_delivery", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    apellidos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    tipo_documento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    numero_documento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ubigeo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    distrito = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    provincia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    departamento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    telefono_verificado = table.Column<bool>(type: "bit", nullable: false),
                    codigo_otp = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    otp_expiracion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    en_lista_negra = table.Column<bool>(type: "bit", nullable: false),
                    motivo_lista_negra = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    fecha_lista_negra = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_verificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "estantes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ubicacion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    capacidad_maxima = table.Column<int>(type: "int", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estantes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "metodos_pago",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    requiere_validacion = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_metodos_pago", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoria = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    precio_venta = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    stock_actual = table.Column<int>(type: "int", nullable: false),
                    stock_minimo = table.Column<int>(type: "int", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "libros",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isbn = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    titulo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    subtitulo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoria_id = table.Column<int>(type: "int", nullable: false),
                    editorial_id = table.Column<int>(type: "int", nullable: true),
                    fecha_publicacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    numero_paginas = table.Column<int>(type: "int", nullable: true),
                    idioma = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    precio_venta = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    precio_alquiler_dia = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    disponible_venta = table.Column<bool>(type: "bit", nullable: false),
                    disponible_alquiler = table.Column<bool>(type: "bit", nullable: false),
                    imagen_portada = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_libros", x => x.id);
                    table.ForeignKey(
                        name: "FK_libros_categorias_categoria_id",
                        column: x => x.categoria_id,
                        principalTable: "categorias",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "notificaciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cliente_id = table.Column<int>(type: "int", nullable: false),
                    titulo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    mensaje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    leida = table.Column<bool>(type: "bit", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_lectura = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fecha_expiracion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notificaciones", x => x.id);
                    table.ForeignKey(
                        name: "FK_notificaciones_clientes_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "clientes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    apellidos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    rol_id = table.Column<int>(type: "int", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ultimo_acceso = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuarios_roles_rol_id",
                        column: x => x.rol_id,
                        principalTable: "roles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "copias_libros",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    libro_id = table.Column<int>(type: "int", nullable: false),
                    codigo_barras = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    codigo_qr = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    estante_id = table.Column<int>(type: "int", nullable: true),
                    estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    condicion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    fecha_adquisicion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    precio_adquisicion = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    observaciones = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    fecha_baja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    motivo_baja = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_copias_libros", x => x.id);
                    table.ForeignKey(
                        name: "FK_copias_libros_estantes_estante_id",
                        column: x => x.estante_id,
                        principalTable: "estantes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_copias_libros_libros_libro_id",
                        column: x => x.libro_id,
                        principalTable: "libros",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "auditoria",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tabla_afectada = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    operacion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    registro_id = table.Column<int>(type: "int", nullable: false),
                    usuario_id = table.Column<int>(type: "int", nullable: true),
                    fecha_operacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    valores_anteriores = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    valores_nuevos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ip_address = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    user_agent = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auditoria", x => x.id);
                    table.ForeignKey(
                        name: "FK_auditoria_usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "configuracion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clave = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    valor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    tipo_dato = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    usuario_modificacion_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_configuracion", x => x.id);
                    table.ForeignKey(
                        name: "FK_configuracion_usuarios_usuario_modificacion_id",
                        column: x => x.usuario_modificacion_id,
                        principalTable: "usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "solicitudes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cliente_id = table.Column<int>(type: "int", nullable: false),
                    tipo_solicitud = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    fecha_solicitud = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_respuesta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    usuario_respuesta_id = table.Column<int>(type: "int", nullable: true),
                    observaciones = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    motivo_rechazo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    total_estimado = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    requiere_delivery = table.Column<bool>(type: "bit", nullable: false),
                    direccion_entrega = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    agencia_delivery_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_solicitudes", x => x.id);
                    table.ForeignKey(
                        name: "FK_solicitudes_agencias_delivery_agencia_delivery_id",
                        column: x => x.agencia_delivery_id,
                        principalTable: "agencias_delivery",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_solicitudes_clientes_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "clientes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_solicitudes_usuarios_usuario_respuesta_id",
                        column: x => x.usuario_respuesta_id,
                        principalTable: "usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "prestamos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    solicitud_id = table.Column<int>(type: "int", nullable: false),
                    cliente_id = table.Column<int>(type: "int", nullable: false),
                    usuario_id = table.Column<int>(type: "int", nullable: false),
                    fecha_prestamo = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_devolucion_programada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_devolucion_real = table.Column<DateTime>(type: "datetime2", nullable: true),
                    estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    total_pagado = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    metodo_pago_id = table.Column<int>(type: "int", nullable: false),
                    penalidad_aplicada = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    observaciones = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prestamos", x => x.id);
                    table.ForeignKey(
                        name: "FK_prestamos_clientes_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "clientes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_prestamos_metodos_pago_metodo_pago_id",
                        column: x => x.metodo_pago_id,
                        principalTable: "metodos_pago",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_prestamos_solicitudes_solicitud_id",
                        column: x => x.solicitud_id,
                        principalTable: "solicitudes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_prestamos_usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "solicitud_detalles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    solicitud_id = table.Column<int>(type: "int", nullable: false),
                    tipo_item = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    item_id = table.Column<int>(type: "int", nullable: false),
                    copia_libro_id = table.Column<int>(type: "int", nullable: true),
                    tipo_operacion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio_unitario = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    dias_alquiler = table.Column<int>(type: "int", nullable: true),
                    subtotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_solicitud_detalles", x => x.id);
                    table.ForeignKey(
                        name: "FK_solicitud_detalles_copias_libros_copia_libro_id",
                        column: x => x.copia_libro_id,
                        principalTable: "copias_libros",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_solicitud_detalles_solicitudes_solicitud_id",
                        column: x => x.solicitud_id,
                        principalTable: "solicitudes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ventas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    solicitud_id = table.Column<int>(type: "int", nullable: true),
                    cliente_id = table.Column<int>(type: "int", nullable: false),
                    usuario_id = table.Column<int>(type: "int", nullable: false),
                    fecha_venta = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    subtotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    impuestos = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    total = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    metodo_pago_id = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    observaciones = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ventas", x => x.id);
                    table.ForeignKey(
                        name: "FK_ventas_clientes_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "clientes",
                        principalColumn: "id");
                    //onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ventas_metodos_pago_metodo_pago_id",
                        column: x => x.metodo_pago_id,
                        principalTable: "metodos_pago",
                        principalColumn: "id");
                        //onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ventas_solicitudes_solicitud_id",
                        column: x => x.solicitud_id,
                        principalTable: "solicitudes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ventas_usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "id");
                        //onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prestamo_detalles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prestamo_id = table.Column<int>(type: "int", nullable: false),
                    copia_libro_id = table.Column<int>(type: "int", nullable: false),
                    fecha_devolucion_real = table.Column<DateTime>(type: "datetime2", nullable: true),
                    estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    penalidad = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    observaciones = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prestamo_detalles", x => x.id);
                    table.ForeignKey(
                        name: "FK_prestamo_detalles_copias_libros_copia_libro_id",
                        column: x => x.copia_libro_id,
                        principalTable: "copias_libros",
                        principalColumn: "id");
                    //onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prestamo_detalles_prestamos_prestamo_id",
                        column: x => x.prestamo_id,
                        principalTable: "prestamos",
                        principalColumn: "id");
                        //onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "venta_detalles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    venta_id = table.Column<int>(type: "int", nullable: false),
                    tipo_item = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    item_id = table.Column<int>(type: "int", nullable: false),
                    copia_libro_id = table.Column<int>(type: "int", nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio_unitario = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    subtotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_venta_detalles", x => x.id);
                    table.ForeignKey(
                        name: "FK_venta_detalles_copias_libros_copia_libro_id",
                        column: x => x.copia_libro_id,
                        principalTable: "copias_libros",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_venta_detalles_ventas_venta_id",
                        column: x => x.venta_id,
                        principalTable: "ventas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_auditoria_usuario_id",
                table: "auditoria",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_clientes_email",
                table: "clientes",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_clientes_numero_documento",
                table: "clientes",
                column: "numero_documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_configuracion_clave",
                table: "configuracion",
                column: "clave",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_configuracion_usuario_modificacion_id",
                table: "configuracion",
                column: "usuario_modificacion_id");

            migrationBuilder.CreateIndex(
                name: "IX_copias_libros_codigo_barras",
                table: "copias_libros",
                column: "codigo_barras",
                unique: true,
                filter: "[codigo_barras] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_copias_libros_codigo_qr",
                table: "copias_libros",
                column: "codigo_qr",
                unique: true,
                filter: "[codigo_qr] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_copias_libros_estante_id",
                table: "copias_libros",
                column: "estante_id");

            migrationBuilder.CreateIndex(
                name: "IX_copias_libros_libro_id",
                table: "copias_libros",
                column: "libro_id");

            migrationBuilder.CreateIndex(
                name: "IX_estantes_codigo",
                table: "estantes",
                column: "codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_libros_categoria_id",
                table: "libros",
                column: "categoria_id");

            migrationBuilder.CreateIndex(
                name: "IX_libros_isbn",
                table: "libros",
                column: "isbn",
                unique: true,
                filter: "[isbn] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_notificaciones_cliente_id",
                table: "notificaciones",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_prestamo_detalles_copia_libro_id",
                table: "prestamo_detalles",
                column: "copia_libro_id");

            migrationBuilder.CreateIndex(
                name: "IX_prestamo_detalles_prestamo_id",
                table: "prestamo_detalles",
                column: "prestamo_id");

            migrationBuilder.CreateIndex(
                name: "IX_prestamos_cliente_id",
                table: "prestamos",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_prestamos_metodo_pago_id",
                table: "prestamos",
                column: "metodo_pago_id");

            migrationBuilder.CreateIndex(
                name: "IX_prestamos_solicitud_id",
                table: "prestamos",
                column: "solicitud_id");

            migrationBuilder.CreateIndex(
                name: "IX_prestamos_usuario_id",
                table: "prestamos",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_productos_codigo",
                table: "productos",
                column: "codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_solicitud_detalles_copia_libro_id",
                table: "solicitud_detalles",
                column: "copia_libro_id");

            migrationBuilder.CreateIndex(
                name: "IX_solicitud_detalles_solicitud_id",
                table: "solicitud_detalles",
                column: "solicitud_id");

            migrationBuilder.CreateIndex(
                name: "IX_solicitudes_agencia_delivery_id",
                table: "solicitudes",
                column: "agencia_delivery_id");

            migrationBuilder.CreateIndex(
                name: "IX_solicitudes_cliente_id",
                table: "solicitudes",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_solicitudes_usuario_respuesta_id",
                table: "solicitudes",
                column: "usuario_respuesta_id");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_email",
                table: "usuarios",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_rol_id",
                table: "usuarios",
                column: "rol_id");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_username",
                table: "usuarios",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_venta_detalles_copia_libro_id",
                table: "venta_detalles",
                column: "copia_libro_id");

            migrationBuilder.CreateIndex(
                name: "IX_venta_detalles_venta_id",
                table: "venta_detalles",
                column: "venta_id");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_cliente_id",
                table: "ventas",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_metodo_pago_id",
                table: "ventas",
                column: "metodo_pago_id");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_solicitud_id",
                table: "ventas",
                column: "solicitud_id");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_usuario_id",
                table: "ventas",
                column: "usuario_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "auditoria");

            migrationBuilder.DropTable(
                name: "configuracion");

            migrationBuilder.DropTable(
                name: "notificaciones");

            migrationBuilder.DropTable(
                name: "prestamo_detalles");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "solicitud_detalles");

            migrationBuilder.DropTable(
                name: "venta_detalles");

            migrationBuilder.DropTable(
                name: "prestamos");

            migrationBuilder.DropTable(
                name: "copias_libros");

            migrationBuilder.DropTable(
                name: "ventas");

            migrationBuilder.DropTable(
                name: "estantes");

            migrationBuilder.DropTable(
                name: "libros");

            migrationBuilder.DropTable(
                name: "metodos_pago");

            migrationBuilder.DropTable(
                name: "solicitudes");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "agencias_delivery");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
