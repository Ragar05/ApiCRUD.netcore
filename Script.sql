CREATE TABLE Articulos (
	id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	descripcion VARCHAR(200) NOT NULL,
	precio DECIMAL NOT NULL,
	estado BIT,
)