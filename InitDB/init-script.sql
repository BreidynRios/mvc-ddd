USE PedidoDB

IF NOT EXISTS(SELECT * FROM Cliente)
BEGIN
	INSERT Cliente VALUES 
	('Juan', 'Perez', '12345678'),
	('Pedro', 'Lopez', '11223344'),
	('Lucia', 'Castillo', '11114444')
END

IF NOT EXISTS(SELECT * FROM Producto)
BEGIN
	INSERT Producto VALUES 
	('Gaseosa'),
	('Atun'),
	('Sublime'),
	('Yogurt'),
	('Cereal')
END