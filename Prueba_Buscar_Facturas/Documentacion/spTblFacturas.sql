Create procedure spTblFacturas
	@Id int,
	@FechaEmisionFactura datetime,
	@IdCliente int,
	@NumeroFactura int,
	@NumeroTotalArticulos int,
	@SubTotalFacturas decimal(18, 2),
	@TotalImpuestos decimal (18, 2),
	@TotalFactura decimal (18, 2),
	@NroTransaccion int
AS
BEGIN
	IF @NroTransaccion = 1 -- Agregar nueva Factura
	BEGIN
		INSERT INTO TblFacturas(FechaEmisionFactura, IdCliente,NumeroFactura,NumeroTotalArticulos,SubTotalFacturas,TotalImpuestos,TotalFactura)
		values(@FechaEmisionFactura,@IdCliente,@NumeroFactura,@NumeroTotalArticulos,@SubTotalFacturas,@TotalImpuestos,@TotalFactura);

		Select @@IDENTITY AS 'Id'
	END
	ELSE IF @NroTransaccion = 2 -- Obtine listado de Factura
	BEGIN
		SELECT * FROM TblFacturas;
	END
	ELSE IF @NroTransaccion = 3 -- Obtine listado de Factura
	BEGIN
		SELECT MAX(NumeroFactura) AS MaxNumeroFactura
		FROM TblFacturas;
	END
END
