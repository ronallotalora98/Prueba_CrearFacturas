CREATE PROCEDURE spCatProductos
	@Id int,
	@NombreProducto varchar(50),
	@ImagenProducto image,
	@PrecioUnitario decimal(18, 2),
	@ext varchar(5),
	@NroTransaccion int
AS
BEGIN
	IF @NroTransaccion = 1 -- Agregar nuevo Producto
	BEGIN
		INSERT INTO CatProductos(NombreProducto, ImagenProducto,PrecioUnitario,ext)
		values(@NombreProducto,@ImagenProducto,@PrecioUnitario,@ext);
	END
	ELSE IF @NroTransaccion = 2 -- Obtine listado de Productos
	BEGIN
		SELECT * FROM CatProductos;
	END
	
end
