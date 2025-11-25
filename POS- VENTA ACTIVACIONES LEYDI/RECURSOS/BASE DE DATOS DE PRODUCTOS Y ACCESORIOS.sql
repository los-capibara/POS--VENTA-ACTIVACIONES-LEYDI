-- ============================================
-- BASE DE DATOS POS LEYDI
-- Sistema Punto de Venta
-- ============================================

CREATE DATABASE POSLeydi;
GO

USE POSLeydi;
GO

-- Tabla Categorias
CREATE TABLE Categorias (
    CategoriaID INT PRIMARY KEY IDENTITY(1,1),
    NombreCategoria NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    Activo BIT DEFAULT 1,
    FechaCreacion DATETIME DEFAULT GETDATE()
);

-- Tabla Proveedores
CREATE TABLE Proveedores (
    ProveedorID INT PRIMARY KEY IDENTITY(1,1),
    NombreProveedor NVARCHAR(200) NOT NULL,
    Contacto NVARCHAR(100),
    Telefono NVARCHAR(20),
    Email NVARCHAR(100),
    Direccion NVARCHAR(255),
    Activo BIT DEFAULT 1,
    FechaCreacion DATETIME DEFAULT GETDATE()
);

-- Tabla Productos
CREATE TABLE Productos (
    ProductoID INT PRIMARY KEY IDENTITY(1,1),
    CodigoBarras NVARCHAR(50),
    NombreProducto NVARCHAR(200) NOT NULL,
    CategoriaID INT,
    ProveedorID INT,
    Descripcion NVARCHAR(500),
    PrecioCompra DECIMAL(18,2) NOT NULL,
    PrecioVenta DECIMAL(18,2) NOT NULL,
    Stock INT DEFAULT 0,
    StockMinimo INT DEFAULT 5,
    Ubicacion NVARCHAR(100),
    ImagenURL NVARCHAR(255),
    Activo BIT DEFAULT 1,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FechaModificacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (CategoriaID) REFERENCES Categorias(CategoriaID),
    FOREIGN KEY (ProveedorID) REFERENCES Proveedores(ProveedorID)
);

-- Tabla TelefonosUsados
CREATE TABLE TelefonosUsados (
    TelefonoID INT PRIMARY KEY IDENTITY(1,1),
    ProductoID INT,
    IMEI NVARCHAR(20) NOT NULL,
    Marca NVARCHAR(100),
    Modelo NVARCHAR(100),
    Color NVARCHAR(50),
    Almacenamiento NVARCHAR(50),
    RAM NVARCHAR(50),
    EstadoFisico NVARCHAR(50),
    Bateria NVARCHAR(50),
    Accesorios NVARCHAR(255),
    FechaCompra DATETIME,
    Garantia INT,
    Vendido BIT DEFAULT 0,
    FechaVenta DATETIME,
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID)
);

-- Tabla TiposReparacion
CREATE TABLE TiposReparacion (
    TipoReparacionID INT PRIMARY KEY IDENTITY(1,1),
    NombreReparacion NVARCHAR(100) NOT NULL,
    PrecioBase DECIMAL(18,2),
    TiempoEstimado INT,
    Descripcion NVARCHAR(255),
    Activo BIT DEFAULT 1
);

-- Tabla Clientes
CREATE TABLE Clientes (
    ClienteID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(200) NOT NULL,
    Apellido NVARCHAR(200),
    Telefono NVARCHAR(20),
    Email NVARCHAR(100),
    Direccion NVARCHAR(255),
    DUI NVARCHAR(20),
    FechaNacimiento DATE,
    FechaRegistro DATETIME DEFAULT GETDATE(),
    PuntosAcumulados INT DEFAULT 0,
    Activo BIT DEFAULT 1
);

-- Tabla Reparaciones
CREATE TABLE Reparaciones (
    ReparacionID INT PRIMARY KEY IDENTITY(1,1),
    ClienteID INT,
    TipoReparacionID INT,
    MarcaTelefono NVARCHAR(100),
    ModeloTelefono NVARCHAR(100),
    IMEI NVARCHAR(20),
    FallaReportada NVARCHAR(500),
    DiagnosticoTecnico NVARCHAR(500),
    EstadoReparacion NVARCHAR(50),
    FechaRecepcion DATETIME DEFAULT GETDATE(),
    FechaPromesaEntrega DATETIME,
    FechaEntrega DATETIME,
    CostoManoObra DECIMAL(18,2),
    CostoRepuestos DECIMAL(18,2),
    CostoTotal DECIMAL(18,2),
    Abono DECIMAL(18,2) DEFAULT 0,
    Saldo DECIMAL(18,2),
    Observaciones NVARCHAR(500),
    TecnicoAsignado NVARCHAR(100),
    FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID),
    FOREIGN KEY (TipoReparacionID) REFERENCES TiposReparacion(TipoReparacionID)
);

-- Tabla RepuestosReparacion
CREATE TABLE RepuestosReparacion (
    RepuestoReparacionID INT PRIMARY KEY IDENTITY(1,1),
    ReparacionID INT,
    ProductoID INT,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(18,2),
    Subtotal DECIMAL(18,2),
    FOREIGN KEY (ReparacionID) REFERENCES Reparaciones(ReparacionID),
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID)
);

-- Tabla TiposRecarga
CREATE TABLE TiposRecarga (
    TipoRecargaID INT PRIMARY KEY IDENTITY(1,1),
    Operadora NVARCHAR(100) NOT NULL,
    Monto DECIMAL(18,2) NOT NULL,
    Comision DECIMAL(18,2),
    Activo BIT DEFAULT 1
);

-- Tabla Usuarios
CREATE TABLE Usuarios (
    UsuarioID INT PRIMARY KEY IDENTITY(1,1),
    NombreUsuario NVARCHAR(50) NOT NULL,
    Contrasena NVARCHAR(255) NOT NULL,
    NombreCompleto NVARCHAR(200),
    Rol NVARCHAR(50),
    Activo BIT DEFAULT 1,
    FechaCreacion DATETIME DEFAULT GETDATE()
);

-- Tabla Ventas
CREATE TABLE Ventas (
    VentaID INT PRIMARY KEY IDENTITY(1,1),
    ClienteID INT,
    UsuarioID INT,
    TipoVenta NVARCHAR(50),
    FechaVenta DATETIME DEFAULT GETDATE(),
    Subtotal DECIMAL(18,2),
    Descuento DECIMAL(18,2) DEFAULT 0,
    Total DECIMAL(18,2),
    MetodoPago NVARCHAR(50),
    Estado NVARCHAR(50) DEFAULT 'Completada',
    FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID),
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
);

-- Tabla DetalleVentas
CREATE TABLE DetalleVentas (
    DetalleVentaID INT PRIMARY KEY IDENTITY(1,1),
    VentaID INT,
    ProductoID INT,
    TipoRecargaID INT,
    Cantidad INT DEFAULT 1,
    PrecioUnitario DECIMAL(18,2),
    Descuento DECIMAL(18,2) DEFAULT 0,
    Subtotal DECIMAL(18,2),
    NumeroRecarga NVARCHAR(20),
    FOREIGN KEY (VentaID) REFERENCES Ventas(VentaID),
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID),
    FOREIGN KEY (TipoRecargaID) REFERENCES TiposRecarga(TipoRecargaID)
);

-- Tabla MovimientosInventario
CREATE TABLE MovimientosInventario (
    MovimientoID INT PRIMARY KEY IDENTITY(1,1),
    ProductoID INT,
    TipoMovimiento NVARCHAR(50),
    Cantidad INT,
    Motivo NVARCHAR(255),
    UsuarioID INT,
    FechaMovimiento DATETIME DEFAULT GETDATE(),
    StockAnterior INT,
    StockNuevo INT,
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID),
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
);

-- Tabla Gastos
CREATE TABLE Gastos (
    GastoID INT PRIMARY KEY IDENTITY(1,1),
    Concepto NVARCHAR(200) NOT NULL,
    Monto DECIMAL(18,2) NOT NULL,
    Categoria NVARCHAR(100),
    FechaGasto DATETIME DEFAULT GETDATE(),
    UsuarioID INT,
    Observaciones NVARCHAR(500),
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
);

-- Tabla CierreCaja
CREATE TABLE CierreCaja (
    CierreID INT PRIMARY KEY IDENTITY(1,1),
    UsuarioID INT,
    FechaApertura DATETIME,
    FechaCierre DATETIME DEFAULT GETDATE(),
    MontoInicial DECIMAL(18,2),
    VentasEfectivo DECIMAL(18,2),
    VentasTarjeta DECIMAL(18,2),
    VentasTransferencia DECIMAL(18,2),
    TotalVentas DECIMAL(18,2),
    TotalGastos DECIMAL(18,2),
    MontoEsperado DECIMAL(18,2),
    MontoReal DECIMAL(18,2),
    Diferencia DECIMAL(18,2),
    Observaciones NVARCHAR(500),
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
);

-- Insertar Categorias
INSERT INTO Categorias (NombreCategoria, Descripcion) VALUES
('Accesorios', 'Fundas cables audifonos'),
('Recargas', 'Recargas telefonicas'),
('Telefonos Usados', 'Celulares segunda mano'),
('Repuestos', 'Pantallas baterias'),
('Servicios', 'Reparaciones');

-- Insertar Proveedores
INSERT INTO Proveedores (NombreProveedor, Contacto, Telefono, Email) VALUES
('Distribuidora Central', 'Juan Perez', '77777777', 'ventas@distribuidora.com'),
('Importadora Tech', 'Maria Lopez', '78888888', 'info@importadoratech.com'),
('Accesorios Plus', 'Carlos Ruiz', '79999999', 'carlos@accesoriosplus.com');

-- Insertar Productos Accesorios
INSERT INTO Productos (CodigoBarras, NombreProducto, CategoriaID, ProveedorID, PrecioCompra, PrecioVenta, Stock, StockMinimo) VALUES
('ACC001', 'Funda Samsung A54', 1, 1, 3.00, 5.00, 50, 10),
('ACC002', 'Funda iPhone 13', 1, 1, 4.00, 7.00, 30, 10),
('ACC003', 'Funda Xiaomi Redmi Note 12', 1, 1, 2.50, 4.50, 45, 10),
('ACC004', 'Funda Motorola G73', 1, 1, 2.80, 5.00, 38, 10),
('ACC005', 'Funda iPhone 14 Pro', 1, 1, 4.50, 8.00, 25, 8),
('ACC006', 'Funda Samsung S23', 1, 1, 3.50, 6.50, 35, 10),
('ACC007', 'Funda Huawei Y9', 1, 1, 2.00, 4.00, 60, 15),
('ACC008', 'Cable USB-C 1m', 1, 2, 2.50, 4.50, 100, 20),
('ACC009', 'Cable Lightning', 1, 2, 3.00, 5.50, 80, 20),
('ACC010', 'Cable Micro USB', 1, 2, 1.80, 3.50, 90, 25),
('ACC011', 'Cable USB-C 2m', 1, 2, 3.50, 6.00, 65, 15),
('ACC012', 'Audifonos Bluetooth TWS', 1, 3, 8.00, 15.00, 25, 5),
('ACC013', 'Audifonos con Cable', 1, 3, 2.00, 4.00, 120, 30),
('ACC014', 'Audifonos In-Ear Bluetooth', 1, 3, 12.00, 22.00, 18, 5),
('ACC015', 'Cargador Rapido 20W', 1, 2, 5.00, 10.00, 40, 10),
('ACC016', 'Cargador 33W Turbo', 1, 2, 7.50, 14.00, 28, 8),
('ACC017', 'Cargador Doble USB', 1, 2, 4.00, 8.00, 55, 12),
('ACC018', 'Cargador Inalambrico', 1, 2, 10.00, 18.00, 15, 5),
('ACC019', 'Mica Vidrio Templado', 1, 1, 1.50, 3.50, 200, 30),
('ACC020', 'Mica Hidrogel Curva', 1, 1, 2.50, 5.00, 85, 20),
('ACC021', 'Mica Privacidad', 1, 1, 3.00, 6.00, 40, 10),
('ACC022', 'PopSocket', 1, 3, 1.00, 2.50, 150, 20),
('ACC023', 'Anillo Soporte', 1, 3, 0.80, 2.00, 180, 30),
('ACC024', 'Power Bank 10000mAh', 1, 2, 12.00, 20.00, 15, 5),
('ACC025', 'Power Bank 20000mAh', 1, 2, 18.00, 30.00, 10, 3),
('ACC026', 'Soporte Auto Magnetico', 1, 3, 4.00, 8.00, 30, 5),
('ACC027', 'Soporte Auto Ventosa', 1, 3, 3.50, 7.00, 35, 8),
('ACC028', 'Memoria MicroSD 32GB', 1, 2, 6.00, 12.00, 45, 10),
('ACC029', 'Memoria MicroSD 64GB', 1, 2, 9.00, 16.00, 38, 8),
('ACC030', 'Memoria MicroSD 128GB', 1, 2, 15.00, 25.00, 22, 5),
('ACC031', 'Adaptador USB-C a USB', 1, 2, 2.00, 4.50, 70, 15),
('ACC032', 'Adaptador Lightning a Jack', 1, 2, 3.50, 7.00, 42, 10),
('ACC033', 'Selfie Stick Bluetooth', 1, 3, 5.50, 11.00, 20, 5),
('ACC034', 'Tripode para Celular', 1, 3, 8.00, 15.00, 12, 3),
('ACC035', 'Estuche Impermeable', 1, 3, 4.50, 9.00, 28, 8),
('ACC036', 'Lentes para Celular', 1, 3, 6.00, 12.00, 15, 5),
('ACC037', 'Limpiador Pantalla Kit', 1, 1, 2.50, 5.00, 50, 10),
('ACC038', 'Pano Microfibra', 1, 1, 0.50, 1.50, 200, 40),
('ACC039', 'Luz LED Selfie Ring', 1, 3, 9.00, 17.00, 10, 3),
('ACC040', 'Cable Organizador 5pcs', 1, 3, 1.50, 3.00, 65, 15),
('ACC041', 'Stylus para Tablet', 1, 3, 4.00, 8.00, 25, 8),
('ACC042', 'Protector Camara', 1, 1, 1.00, 2.50, 95, 20),
('ACC043', 'Funda Brazalete Deportivo', 1, 1, 3.50, 7.00, 30, 8),
('ACC044', 'Adaptador Tarjeta SIM', 1, 2, 0.80, 2.00, 150, 30),
('ACC045', 'Extractor Bandeja SIM', 1, 2, 0.30, 1.00, 200, 50),
('ACC046', 'Audifonos Gaming RGB', 1, 3, 15.00, 28.00, 8, 3),
('ACC047', 'Cable USB-C a HDMI', 1, 2, 8.00, 15.00, 18, 5),
('ACC048', 'Hub USB-C 4 Puertos', 1, 2, 12.00, 22.00, 10, 3),
('ACC049', 'Ventilador Celular USB', 1, 3, 2.50, 5.00, 35, 10),
('ACC050', 'Gamepad Bluetooth', 1, 3, 18.00, 32.00, 6, 2),
('ACC051', 'Mouse Inalambrico', 1, 3, 7.00, 13.00, 22, 6),
('ACC052', 'Teclado Bluetooth', 1, 3, 15.00, 27.00, 8, 3),
('ACC053', 'Cable Cargador Auto', 1, 2, 3.50, 7.00, 48, 12),
('ACC054', 'Cargador Auto Dual USB', 1, 2, 5.00, 10.00, 32, 8),
('ACC055', 'Bocina Bluetooth Portatil', 1, 3, 12.00, 22.00, 15, 4),
('ACC056', 'Funda Impermeable Universal', 1, 1, 3.00, 6.00, 40, 10),
('ACC057', 'Bateria Externa Solar', 1, 2, 22.00, 38.00, 5, 2),
('ACC058', 'Soporte Escritorio Ajustable', 1, 3, 6.00, 12.00, 25, 8),
('ACC059', 'Lampara LED USB', 1, 3, 3.00, 6.00, 35, 10),
('ACC060', 'Cable Lightning 2m', 1, 2, 4.00, 7.50, 45, 12);

-- Insertar Productos Repuestos
INSERT INTO Productos (CodigoBarras, NombreProducto, CategoriaID, ProveedorID, PrecioCompra, PrecioVenta, Stock, StockMinimo) VALUES
('REP001', 'Pantalla Samsung A54', 4, 2, 35.00, 60.00, 5, 2),
('REP002', 'Pantalla Samsung A34', 4, 2, 30.00, 55.00, 4, 2),
('REP003', 'Pantalla Samsung A14', 4, 2, 22.00, 42.00, 6, 2),
('REP004', 'Pantalla Samsung S21', 4, 2, 80.00, 135.00, 2, 1),
('REP005', 'Pantalla iPhone 12', 4, 2, 65.00, 110.00, 3, 1),
('REP006', 'Pantalla iPhone 11', 4, 2, 55.00, 95.00, 4, 2),
('REP007', 'Pantalla iPhone XR', 4, 2, 48.00, 85.00, 5, 2),
('REP008', 'Pantalla iPhone 13', 4, 2, 75.00, 125.00, 2, 1),
('REP009', 'Pantalla Redmi Note 12', 4, 2, 20.00, 40.00, 6, 2),
('REP010', 'Pantalla Redmi Note 11', 4, 2, 18.00, 38.00, 5, 2),
('REP011', 'Pantalla Motorola G73', 4, 2, 25.00, 48.00, 3, 1),
('REP012', 'Pantalla Motorola G32', 4, 2, 20.00, 40.00, 4, 2),
('REP013', 'Pantalla Huawei Y9', 4, 2, 22.00, 42.00, 3, 1),
('REP014', 'Bateria iPhone 12', 4, 2, 25.00, 45.00, 8, 3),
('REP015', 'Bateria iPhone 11', 4, 2, 22.00, 40.00, 10, 3),
('REP016', 'Bateria iPhone XR', 4, 2, 20.00, 38.00, 9, 3),
('REP017', 'Bateria iPhone 13', 4, 2, 28.00, 50.00, 6, 2),
('REP018', 'Bateria Samsung A54', 4, 2, 18.00, 35.00, 10, 3),
('REP019', 'Bateria Samsung A34', 4, 2, 16.00, 32.00, 8, 3),
('REP020', 'Bateria Samsung S21', 4, 2, 30.00, 55.00, 4, 2),
('REP021', 'Bateria Redmi Note 12', 4, 2, 12.00, 25.00, 12, 4),
('REP022', 'Bateria Motorola G73', 4, 2, 14.00, 28.00, 8, 3),
('REP023', 'Flex Carga USB-C', 4, 1, 8.00, 15.00, 20, 5),
('REP024', 'Flex Carga Lightning iPhone', 4, 1, 12.00, 22.00, 15, 5),
('REP025', 'Flex Carga Micro USB', 4, 1, 6.00, 12.00, 18, 5),
('REP026', 'Camara Trasera iPhone 12', 4, 2, 35.00, 65.00, 3, 1),
('REP027', 'Camara Trasera Samsung A54', 4, 2, 20.00, 40.00, 5, 2),
('REP028', 'Camara Frontal iPhone 12', 4, 2, 15.00, 30.00, 6, 2),
('REP029', 'Camara Frontal Samsung A54', 4, 2, 10.00, 22.00, 8, 3),
('REP030', 'Altavoz iPhone 12', 4, 1, 8.00, 16.00, 10, 3),
('REP031', 'Altavoz Samsung A54', 4, 1, 6.00, 13.00, 12, 4),
('REP032', 'Microfono iPhone 12', 4, 1, 7.00, 14.00, 8, 3),
('REP033', 'Boton Home iPhone', 4, 1, 5.00, 11.00, 10, 3),
('REP034', 'Boton Power Samsung', 4, 1, 4.00, 9.00, 15, 5),
('REP035', 'Bandeja SIM iPhone', 4, 1, 2.00, 5.00, 20, 6),
('REP036', 'Bandeja SIM Samsung', 4, 1, 1.50, 4.00, 25, 8),
('REP037', 'Tornillos iPhone Set', 4, 1, 1.00, 3.00, 30, 10),
('REP038', 'Adhesivo Pantalla Universal', 4, 1, 0.80, 2.50, 50, 15),
('REP039', 'Pasta Termica', 4, 1, 3.00, 6.00, 15, 5),
('REP040', 'Kit Destornilladores', 4, 1, 8.00, 15.00, 8, 3);

-- Insertar Tipos de Recarga
INSERT INTO TiposRecarga (Operadora, Monto, Comision) VALUES
('Tigo', 1.00, 0.10),
('Tigo', 3.00, 0.30),
('Tigo', 5.00, 0.50),
('Tigo', 10.00, 0.80),
('Claro', 1.00, 0.10),
('Claro', 3.00, 0.30),
('Claro', 5.00, 0.50),
('Claro', 10.00, 0.80),
('Movistar', 1.00, 0.10),
('Movistar', 5.00, 0.50),
('Digicel', 1.00, 0.10),
('Digicel', 5.00, 0.50);

-- Insertar Tipos de Reparacion
INSERT INTO TiposReparacion (NombreReparacion, PrecioBase, TiempoEstimado, Descripcion) VALUES
('Cambio de Pantalla', 40.00, 60, 'Reemplazo de pantalla'),
('Cambio de Bateria', 25.00, 30, 'Reemplazo de bateria'),
('Reparacion Puerto Carga', 15.00, 45, 'Limpieza o cambio flex carga'),
('Reparacion Software', 10.00, 30, 'Formateo desbloqueo actualizacion'),
('Cambio Camara', 30.00, 45, 'Reemplazo camara frontal trasera'),
('Limpieza por Liquido', 20.00, 90, 'Limpieza profunda por dano liquido');

-- Insertar Usuarios
INSERT INTO Usuarios (NombreUsuario, Contrasena, NombreCompleto, Rol) VALUES
('admin', 'admin123', 'Administrador Sistema', 'Administrador'),
('leydi', 'leydi123', 'Leydi Vendedora', 'Vendedor'),
('tecnico1', 'tecnico123', 'Jose Tecnico', 'Tecnico');

-- Insertar Clientes
INSERT INTO Clientes (Nombre, Apellido, Telefono, Email) VALUES
('Cliente', 'General', '00000000', NULL),
('Ana', 'Garcia', '71111111', 'ana@email.com'),
('Pedro', 'Martinez', '72222222', 'pedro@email.com'),
('Sofia', 'Hernandez', '73333333', 'sofia@email.com');

-- Vista Productos con Stock Bajo
GO
CREATE VIEW vw_ProductosStockBajo AS
SELECT 
    p.ProductoID,
    p.CodigoBarras,
    p.NombreProducto,
    c.NombreCategoria,
    p.Stock,
    p.StockMinimo,
    p.PrecioVenta
FROM Productos p
INNER JOIN Categorias c ON p.CategoriaID = c.CategoriaID
WHERE p.Stock <= p.StockMinimo AND p.Activo = 1;
GO

-- Vista Ventas del Dia
CREATE VIEW vw_VentasHoy AS
SELECT 
    v.VentaID,
    v.FechaVenta,
    c.Nombre + ' ' + ISNULL(c.Apellido, '') AS Cliente,
    u.NombreCompleto AS Vendedor,
    v.Total,
    v.MetodoPago
FROM Ventas v
LEFT JOIN Clientes c ON v.ClienteID = c.ClienteID
INNER JOIN Usuarios u ON v.UsuarioID = u.UsuarioID
WHERE CAST(v.FechaVenta AS DATE) = CAST(GETDATE() AS DATE);
GO

-- Vista Reparaciones Pendientes
CREATE VIEW vw_ReparacionesPendientes AS
SELECT 
    r.ReparacionID,
    c.Nombre + ' ' + ISNULL(c.Apellido, '') AS Cliente,
    c.Telefono,
    r.MarcaTelefono + ' ' + r.ModeloTelefono AS Dispositivo,
    tr.NombreReparacion,
    r.EstadoReparacion,
    r.FechaRecepcion,
    r.FechaPromesaEntrega,
    r.Saldo
FROM Reparaciones r
INNER JOIN Clientes c ON r.ClienteID = c.ClienteID
INNER JOIN TiposReparacion tr ON r.TipoReparacionID = tr.TipoReparacionID
WHERE r.EstadoReparacion != 'Entregado';
GO

-- Procedimiento Registrar Venta Producto
CREATE PROCEDURE sp_RegistrarVentaProducto
    @ClienteID INT,
    @UsuarioID INT,
    @ProductoID INT,
    @Cantidad INT,
    @MetodoPago NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @PrecioUnitario DECIMAL(18,2);
    DECLARE @Subtotal DECIMAL(18,2);
    DECLARE @VentaID INT;
    DECLARE @StockActual INT;
    DECLARE @StockNuevo INT;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Obtener precio y stock actual
        SELECT @PrecioUnitario = PrecioVenta,
               @StockActual = Stock
        FROM Productos
        WHERE ProductoID = @ProductoID AND Activo = 1;

        -- Validaciones
        IF @PrecioUnitario IS NULL OR @StockActual IS NULL
        BEGIN
            ROLLBACK TRANSACTION;
            RAISERROR('Producto no encontrado o inactivo.',16,1);
            RETURN;
        END

        IF @Cantidad <= 0
        BEGIN
            ROLLBACK TRANSACTION;
            RAISERROR('La cantidad debe ser mayor que cero.',16,1);
            RETURN;
        END

        IF @StockActual < @Cantidad
        BEGIN
            ROLLBACK TRANSACTION;
            RAISERROR('Stock insuficiente. Disponible: %d',16,1,@StockActual);
            RETURN;
        END

        -- Calcular montos
        SET @Subtotal = @PrecioUnitario * @Cantidad;

        -- Insertar venta
        INSERT INTO Ventas (ClienteID, UsuarioID, TipoVenta, Subtotal, Total, MetodoPago)
        VALUES (@ClienteID, @UsuarioID, 'Producto', @Subtotal, @Subtotal, @MetodoPago);

        SET @VentaID = CAST(SCOPE_IDENTITY() AS INT);

        -- Insertar detalle de venta
        INSERT INTO DetalleVentas (VentaID, ProductoID, Cantidad, PrecioUnitario, Subtotal)
        VALUES (@VentaID, @ProductoID, @Cantidad, @PrecioUnitario, @Subtotal);

        -- Actualizar stock del producto
        SET @StockNewo = NULL; -- placeholder to avoid undeclared use in some editors
        SET @StockNuevo = @StockActual - @Cantidad;

        UPDATE Productos
        SET Stock = @StockNuevo,
            FechaModificacion = GETDATE()
        WHERE ProductoID = @ProductoID;

        -- Registrar movimiento de inventario
        INSERT INTO MovimientosInventario (ProductoID, TipoMovimiento, Cantidad, Motivo, UsuarioID, StockAnterior, StockNuevo)
        VALUES (@ProductoID, 'Salida Venta', @Cantidad, 'VentaID ' + CAST(@VentaID AS NVARCHAR(20)), @UsuarioID, @StockActual, @StockNuevo);

        COMMIT TRANSACTION;

        -- Devolver id de la venta creada
        SELECT @VentaID AS VentaID;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0
            ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorNumber INT = ERROR_NUMBER();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        RAISERROR('Error al registrar la venta. Detalle: %s (Número %d)',16,1,@ErrorMessage,@ErrorNumber);
        RETURN;
    END CATCH
END
GO