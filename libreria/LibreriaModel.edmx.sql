
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/23/2017 10:15:36
-- Generated from EDMX file: C:\Users\SOPORTE\Source\Repos\GestorLibreria\GestorLibreria\LibreriaModel.edmx
-- --------------------------------------------------

--SET QUOTED_IDENTIFIER OFF;
--Drop DATABASE [LibreriaHC.mdf]
--go
--Create DATABASE [LibreriaHC.mdf]
--go

--USE [LibreriaHC.mdf];
--GO
--IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHE	MA [dbo]');
--GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'LibrosSet'
CREATE TABLE [dbo].[LibrosSet] (
	[ISBN] nvarchar(20)  NOT NULL,
	[Titulo] nvarchar(250)  NOT NULL,
	[Pais] nvarchar(250)  NOT NULL,
	[Stock] int  NOT NULL,
	[Editorial] nvarchar(250)  NOT NULL,
	[CategoriaId] int  NOT NULL
);
GO

-- Creating table 'CategoriasSet'
CREATE TABLE [dbo].[CategoriasSet] (
	[Id] int IDENTITY(1,1) NOT NULL,
	[Genero] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'AutoresSet'
CREATE TABLE [dbo].[AutoresSet] (
	[Id] int IDENTITY(1,1) NOT NULL,
	[Nombre] nvarchar(50)  NOT NULL,
	[Apellido] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'LibroAutorSet'
CREATE TABLE [dbo].[LibroAutorSet] (
	[Id] int IDENTITY(1,1) NOT NULL,
	[LibroISBN] nvarchar(20)  NOT NULL,
	[AutorId] int  NOT NULL
);
GO

-- Creating table 'LibroEjemplarSet'
CREATE TABLE [dbo].[LibroEjemplarSet] (
	[Codigo] nvarchar(30)  NOT NULL,
	[LibroISBN] nvarchar(20)  NOT NULL,
	[Numero] int  NOT NULL
);
GO

-- Creating table 'ClientesSet'
CREATE TABLE [dbo].[ClientesSet] (
	[Identificacion] nvarchar(25)  NOT NULL,
	[Nombre] nvarchar(50)  NOT NULL,
	[Apellido] nvarchar(100)  NOT NULL,
	[Telefono] nvarchar(20)  NOT NULL,
	[Correo] nvarchar(30)  NOT NULL
);
GO

-- Creating table 'DireccionSet'
CREATE TABLE [dbo].[DireccionSet] (
	[Id] int IDENTITY(1,1) NOT NULL,
	[ClienteID] nvarchar(25)  NOT NULL,
	[Sector] nvarchar(50)  NOT NULL,
	[Pais] nvarchar(50)  NOT NULL,
	[Calle] nvarchar(50)  NOT NULL,
	[Provincia] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'HistorialPrestamoSet'
CREATE TABLE [dbo].[HistorialPrestamoSet] (
	[Id] int IDENTITY(1,1) NOT NULL,
	[LibroEjemplarCodigo] nvarchar(30)  NOT NULL,
	[ClientesIdentificacion] nvarchar(25)  NOT NULL,
	[Fecha_Ini] datetime NOT NULL default GETDATE(),
	[Fecha_Fin] datetime  NOT NULL,
	[Estado] int NOT NULL default 1
);
GO

-- Creating table 'VariablesSet'
CREATE TABLE [dbo].[VariablesSet] (
	[Id] int IDENTITY(1,1) NOT NULL,
	[Nombre] nvarchar(50)  NOT NULL,
	[Valor] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'CredencialesSet'
CREATE TABLE [dbo].[CredencialesSet](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](10) NOT NULL,
	[Password] [varchar](100) NOT NULL,
 CONSTRAINT [PK_CredencialSet] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ISBN] in table 'LibrosSet'
ALTER TABLE [dbo].[LibrosSet]
ADD CONSTRAINT [PK_LibrosSet]
	PRIMARY KEY CLUSTERED ([ISBN] ASC);
GO

-- Creating primary key on [Id] in table 'CategoriasSet'
ALTER TABLE [dbo].[CategoriasSet]
ADD CONSTRAINT [PK_CategoriasSet]
	PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AutoresSet'
ALTER TABLE [dbo].[AutoresSet]
ADD CONSTRAINT [PK_AutoresSet]
	PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LibroISBN], [AutorId] in table 'LibroAutorSet'
ALTER TABLE [dbo].[LibroAutorSet]
ADD CONSTRAINT [PK_LibroAutorSet]
	PRIMARY KEY CLUSTERED ([LibroISBN], [AutorId]);
GO

-- Creating primary key on [Codigo] in table 'LibroEjemplarSet'
ALTER TABLE [dbo].[LibroEjemplarSet]
ADD CONSTRAINT [PK_LibroEjemplarSet]
	PRIMARY KEY CLUSTERED ([Codigo] ASC);
GO

-- Creating primary key on [Identificacion] in table 'ClientesSet'
ALTER TABLE [dbo].[ClientesSet]
ADD CONSTRAINT [PK_ClientesSet]
	PRIMARY KEY CLUSTERED ([Identificacion] ASC);
GO

-- Creating primary key on [Id], [ClienteID] in table 'DireccionSet'
ALTER TABLE [dbo].[DireccionSet]
ADD CONSTRAINT [PK_DireccionSet]
	PRIMARY KEY CLUSTERED ([Id], [ClienteID] ASC);
GO

-- Creating primary key on [Id] in table 'HistorialPrestamoSet'
ALTER TABLE [dbo].[HistorialPrestamoSet]
ADD CONSTRAINT [PK_HistorialPrestamoSet]
	PRIMARY KEY CLUSTERED ([Id] ASC,[LibroEjemplarCodigo]);
GO

-- Creating primary key on [Id] in table 'VariablesSet'
ALTER TABLE [dbo].[VariablesSet]
ADD CONSTRAINT [PK_VariablesSet]
	PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Codigo] in table 'CredencialesSet'
ALTER TABLE [dbo].[CredencialesSet]
ADD CONSTRAINT [PK_CredencialesSet]
	PRIMARY KEY CLUSTERED ([Codigo] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CategoriaId] in table 'LibrosSet'
ALTER TABLE [dbo].[LibrosSet]
ADD CONSTRAINT [FK_CategoriaLibro]
	FOREIGN KEY ([CategoriaId])
	REFERENCES [dbo].[CategoriasSet]
		([Id])
	ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoriaLibro'
CREATE INDEX [IX_FK_CategoriaLibro]
ON [dbo].[LibrosSet]
	([CategoriaId]);
GO

-- Creating foreign key on [LibroISBN] in table 'LibroAutorSet'
ALTER TABLE [dbo].[LibroAutorSet]
ADD CONSTRAINT [FK_LibrosLibroAutor]
	FOREIGN KEY ([LibroISBN])
	REFERENCES [dbo].[LibrosSet]
		([ISBN])
	ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LibrosLibroAutor'
CREATE INDEX [IX_FK_LibrosLibroAutor]
ON [dbo].[LibroAutorSet]
	([LibroISBN]);
GO

-- Creating foreign key on [AutorId] in table 'LibroAutorSet'
ALTER TABLE [dbo].[LibroAutorSet]
ADD CONSTRAINT [FK_AutoresLibroAutor]
	FOREIGN KEY ([AutorId])
	REFERENCES [dbo].[AutoresSet]
		([Id])
	ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AutoresLibroAutor'
CREATE INDEX [IX_FK_AutoresLibroAutor]
ON [dbo].[LibroAutorSet]
	([AutorId]);
GO

-- Creating foreign key on [LibroISBN] in table 'LibroEjemplarSet'
ALTER TABLE [dbo].[LibroEjemplarSet]
ADD CONSTRAINT [FK_LibrosLibroEjemplar]
	FOREIGN KEY ([LibroISBN])
	REFERENCES [dbo].[LibrosSet]
		([ISBN])
	ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LibrosLibroEjemplar'
CREATE INDEX [IX_FK_LibrosLibroEjemplar]
ON [dbo].[LibroEjemplarSet]
	([LibroISBN]);
GO

-- Creating foreign key on [LibroEjemplarCodigo] in table 'HistorialPrestamoSet'
ALTER TABLE [dbo].[HistorialPrestamoSet]
ADD CONSTRAINT [FK_LibroEjemplarHistorialPrestamo]
	FOREIGN KEY ([LibroEjemplarCodigo])
	REFERENCES [dbo].[LibroEjemplarSet]
		([Codigo])
	ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LibroEjemplarHistorialPrestamo'
CREATE INDEX [IX_FK_LibroEjemplarHistorialPrestamo]
ON [dbo].[HistorialPrestamoSet]
	([LibroEjemplarCodigo]);
GO

-- Creating foreign key on [ClientesIdentificacion] in table 'HistorialPrestamoSet'
ALTER TABLE [dbo].[HistorialPrestamoSet]
ADD CONSTRAINT [FK_ClientesHistorialPrestamo]
	FOREIGN KEY ([ClientesIdentificacion])
	REFERENCES [dbo].[ClientesSet]
		([Identificacion])
	ON DELETE CASCADE ON UPDATE NO ACTION;
GO
----
alter table[dbo].[DireccionSet]
add Constraint [FK_DireccionCliente]
	foreign Key (ClienteID)
	references [dbo].[ClientesSet]
		([Identificacion])
	on Delete no action on update no action;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientesHistorialPrestamo'
CREATE INDEX [IX_FK_ClientesHistorialPrestamo]
ON [dbo].[HistorialPrestamoSet]
	([ClientesIdentificacion]);
GO

----------------------- PROCEDURES -----------------------------------
----Inserta un libro y crea su stock
CREATE PROCEDURE spInsertLibro
	@isbn nvarchar(20), @titulo nvarchar(250), @pais nvarchar(250),
	@Stock int = 1, @Editorial nvarchar(250), @Genero int
AS
	declare @count int = 0;
	Set nocount on;
	insert into LibrosSet 
	values (@isbn, @titulo, @pais, @Stock, @Editorial, @Genero);

	while @count < @Stock
	begin
		set @count = @count + 1;
		declare @Cod nvarchar(30) = concat(@isbn,'#', @count);
		insert into LibroEjemplarSet
		values (@Cod, @isbn, @count);
	end
	;
Go
----- Update Genre
CREATE PROCEDURE spUpdateGenre
	@id  int,
	@Name nvarchar(50)
AS
	declare @oldN nvarchar(50);
	select @oldN = Genero from CategoriasSet where  Id = @id

	if @oldN <> @Name
	begin 
		update CategoriasSet 
		set Genero = @Name where Id = @id;
	end
	;

go
----- Nuevo Genero
CREATE PROCEDURE spNewGenero
	@Name nvarchar(250)
AS
	insert into CategoriasSet(Genero) values (@Name);
	go
---- Eliminar Genero
CREATE PROCEDURE spDeleteGenero
	@ID int
AS

	Delete from CategoriasSet where Id = @ID;
go
--- Libros POr autor
CREATE PROCEDURE spGetLibrosPorAutor
	@IdAutor int
AS
	select distinct  lb.ISBN, lb.Titulo from LibrosSet as Lb  
	inner join  LibroAutorSet as la on lb.ISBN = la.LibroISBN
	inner join AutoresSet as a on la.AutorId = a.Id
	where a.Id = @IdAutor;
go
--Libros sin Autor Especificando
CREATE PROCEDURE spGetLibrosSinAutor
	@IdAutor int
AS
	select ISBN, Titulo from LibrosSet

	except

	select distinct  lb.ISBN, lb.Titulo from LibrosSet as Lb  
	inner join  LibroAutorSet as la on lb.ISBN = la.LibroISBN
	inner join AutoresSet as a on la.AutorId = a.Id
	where a.Id = @IdAutor;
go
----Manejo de Direcciones
-----I = insertar, U = update, D = Delete
CREATE PROCEDURE spDirecciones
	@Calle varchar(25) = '',
	@Prov varchar(25) = '',
	@Sect varchar(25) = '',
	@Pais varchar(25) = '',
	@ClientID varchar(25) = '',
	@Accion varchar(2) = 'I'
	
AS

	if @Accion = 'I'
		begin
			insert into  DireccionSet(Calle,Pais,Provincia, Sector, ClienteID) 
			values (@Calle, @Pais, @Prov, @Sect, @ClientID)
		end
	else 
	if @Accion = 'U'
	 begin
		 update DireccionSet 
		 set Pais = @Pais, Calle = @Calle, Provincia = @Prov, Sector= @Sect
		 where ClienteID = @ClientID
		end
	else 
	if @Accion = 'D'
	begin
		delete from DireccionSet where ClienteID = @ClientID
	end
	;
	go
-----Manejo de Clientes / Estudiantes
CREATE PROCEDURE spEstudiantes
	@IDE varchar(25) = '',
	@Name varchar(25) = '',
	@Ape varchar(25) = '',
	@Tel varchar(25) = '',
	@Cor varchar(25) = '',
	@Accion varchar(2) = 'I'
as

if @Accion = 'I'
	insert into ClientesSet values(@IDE, @Name, @Ape, @Tel,@Cor)
else
if @Accion = 'U'
	update ClientesSet set
	Nombre = @Name, Apellido = @Ape, Telefono =@Tel, Correo = @Cor
	where Identificacion = @Ide
else
if @Accion = 'D'
	delete from ClientesSet where Identificacion = @IDE
go
------Trabajo del Historial PRestamo------
CREATE PROCEDURE spH_Prestamos
(	@id int = 0,
	@Cod varchar(35) = '',
	@Cli varchar(35) = '' ,
	@Fi datetime = null,
	@FF datetime = null,
	@Est int = 1,
	@Accion varchar(2) = 'I'
	)
AS
	set @Fi =ISNULL(@Fi,GETDATE())
	set @FF = ISNULL(@FF,DATEADD(MONTH, 1, @Fi))

if @Accion = 'I'
	insert into HistorialPrestamoSet values(@Cod, @Cli, @Fi, @FF, @Est)
else
if @Accion = 'U'
	update HistorialPrestamoSet set
	LibroEjemplarCodigo = @Cod, ClientesIdentificacion = @Cli,
	Fecha_Ini = @Fi, Fecha_Fin =@FF, Estado = @Est
	where Id = @id
go

--------------
----Stock Manager
CREATE PROCEDURE spStockWork
@CodEjemplar varchar(35),
@Accion varchar(2) = '+'
AS
BEGIN
	declare @isbn varchar(30)
	select @isbn = LibroISBN from LibroEjemplarSet where Codigo = @CodEjemplar

	if @Accion = '+'
		update LibrosSet set Stock = Stock + 1 where ISBN = @isbn
	else 
	if @Accion = '-'
		update LibrosSet set Stock = Stock - 1 where ISBN = @isbn


END
GO

-----getAll from categorias
CREATE PROCEDURE [dbo].[usp_Data_CCategoria_GetAll]
	AS
BEGIN
	Select Id, Genero from [dbo].[CategoriasSet];
END
go
-----get columns names from categorias
CREATE PROCEDURE [dbo].[usp_Data_CCategoria_GetColumnNames]
@tabla varchar(100)
	AS
BEGIN
	SELECT name AS Names FROM sys.columns 
	WHERE object_id = OBJECT_ID(@tabla);
END
go
----- Actuaizar libros
CREATE PROCEDURE [dbo].[usp_Data_CLibro_Actualizar]
	@ISBN nvarchar(20), @Titulo nvarchar(250), @Pais nvarchar(250),
	@Editorial nvarchar(250), @CategoriaId int
AS
	UPDATE [dbo].[LibrosSet] SET Titulo=@Titulo, 
	Pais=@Pais, Editorial=@Editorial, 
	CategoriaId=@CategoriaId WHERE ISBN=@ISBN;

	select @@ROWCOUNT as CantidadAfectada
go
-----Eliminar libro
CREATE PROCEDURE [dbo].[usp_Data_CLibro_Eliminar]
	@ISBN nvarchar(20)
AS
BEGIN	
	delete from [dbo].[LibrosSet] where ISBN=@ISBN
	select @@ROWCOUNT as CantidadAfectada
END
go
----- get all libros
CREATE PROCEDURE [dbo].[usp_Data_CLibro_GetAll]
AS
BEGIN
	SELECT * FROM view_Libros;
END
go
-----get libros no disponibles
Create PROCEDURE [dbo].[usp_Data_CLibro_GetBorrowed]
AS
BEGIN
	SELECT * FROM view_Libros where Stock <= 0;
END
go
-----get libros disponibles
Create PROCEDURE [dbo].[usp_Data_CLibro_GetStocked]
AS
BEGIN
	SELECT * FROM view_Libros where Stock > 0;
END
go
-----insertar libros
CREATE PROCEDURE [dbo].[usp_Data_CLibro_Insertar]
	@ISBN nvarchar(20), @Titulo nvarchar(250), @Pais nvarchar(250),
	@Stock int = 1, @Editorial nvarchar(250), @CategoriaId int
AS
	declare @count int = 0;
	Set nocount on;
	insert into LibrosSet 
	values (@ISBN, @Titulo, @Pais, @Stock, @Editorial, @CategoriaId);

	while @count < @Stock
	begin
		set @count = @count + 1;
		declare @Cod nvarchar(30) = concat(@isbn,'#', @count);
		insert into LibroEjemplarSet
		values (@Cod, @isbn, @count);
	end;

	select 1 as CantidadAfectada
go
-----actualizar ejemplares
Create PROCEDURE usp_Data_Ejemplares_Actualizar
	@ISBN nvarchar(20), 
	@Cod nvarchar(30), 
	@newN int,
	@oldN int
AS	
	UPDATE LibroEjemplarSet SET Codigo=@cod, Numero=@newN where Codigo=concat(@ISBN, '#', @oldN);

	select @@ROWCOUNT as CantidadAfectada;
go
-----insertar ejemplares
CREATE PROCEDURE usp_Data_Ejemplares_Insertar
	@ISBN nvarchar(20), 
	@Cod nvarchar(30), 
	@numero int
AS
	declare @stock int
	declare @count int

	set @stock = (select Stock from LibrosSet where ISBN=@ISBN);

	insert into LibroEjemplarSet
		values (@Cod, @isbn, @numero);
	
	if( @@ROWCOUNT > 0) set @stock = @stock + 1
	
	UPDATE [dbo].[LibrosSet] SET Stock=@Stock;

	select @@ROWCOUNT as CantidadAfectada
go
-----Eliminar ejemplares
--not yet
go
-----get colunms names para cualquier tabla
create PROCEDURE [dbo].[usp_Data_GetColumnNames]
@tabla varchar(50)
	AS
BEGIN
	SELECT name AS Names FROM sys.columns 
	WHERE object_id = OBJECT_ID(@tabla);
END
go
-----

go


-------Vistas
---Vista Generos con total de libros
CREATE VIEW vwGenerosLibrosCount
	AS 
	SELECT c.Id, C.Genero , Count(lb.CategoriaId) as Total_Libros from CategoriasSet as C left join LibrosSet as lb
	on c.Id = lb.CategoriaId
	group by c.Id, c.Genero;
	go
-----------
---- crear vista libros normal
CREATE VIEW vwListadoLibrosNormal
	AS 

	Select ISBN, Titulo, Genero, Stock From LibrosSet lb inner join CategoriasSet C on lb.CategoriaId = C.Id;
	go
-----Prestamos actuales
CREATE VIEW vwVerPrestamos
	AS 
	Select l.Titulo, l.ISBN ,
'Estado' =
Case
	when h.Estado = 1 then 'Pendiente'
	when h.Estado = 0 then 'Devuelto'
end,
h.Fecha_Ini as Fecha_Inicial,
h.Fecha_Fin as Fecha_Entrega,
CONCAT(cl.Nombre, ' ', cl.Apellido) as NombreCliente,
h.Id, le.Numero as Numero_Ejemplar,
cl.Identificacion as DNI

from LibroEjemplarSet as le inner join LibrosSet as l on le.LibroISBN = l.ISBN
left join HistorialPrestamoSet as h on h.LibroEjemplarCodigo = le.Codigo
inner join ClientesSet as cl on cl.Identificacion = h.ClientesIdentificacion
go

-----------Libros sin Historial activo
CREATE VIEW vwLibrosFaltantes
	as
select  l.ISBN, l.Titulo, Count(*) as Disponibles from LibrosSet as l inner join LibroEjemplarSet as lb on lb.LibroISBN = l.ISBN
left join HistorialPrestamoSet  on LibroEjemplarCodigo = lb.Codigo

where Estado is null or Estado = 0
group by l.ISBN, l.Titulo
go
-- crear vista libros 
CREATE VIEW view_Libros
AS
SELECT        dbo.LibrosSet.ISBN, dbo.LibrosSet.Titulo, dbo.LibrosSet.Pais, dbo.LibrosSet.Stock, dbo.LibrosSet.Editorial, dbo.LibrosSet.CategoriaId, dbo.CategoriasSet.Genero
FROM            dbo.CategoriasSet INNER JOIN
						 dbo.LibrosSet ON dbo.CategoriasSet.Id = dbo.LibrosSet.CategoriaId
go

----Inserte Categorias
Insert into CategoriasSet(Genero) values ('Ficcion')
Insert into CategoriasSet(Genero) values ('Aventuras')
Insert into CategoriasSet(Genero) values ('Drama')
Insert into CategoriasSet(Genero) values ('Programacion')

go
------INSERTANDO Libros
exec spInsertLibro '9788484417552', 'La Piramide Roja, Las Cronicas de Kane Vol. 1', 'España', 5, 'Montena', 1
exec spInsertLibro N'0470277947', N'LINQ for Dummies', N'Estados Unidos', 2, N'Wiley Publishing, Inc.', 1
insert into AutoresSet values (N'John Paul', N'Mueller');
insert into AutoresSet values (N'Rick', N'Riordan');
go

-----FUNCIONES-----------
---Trae ejemplares
CREATE FUNCTION fxTraeEjemplaresDisponibles
(
	@ISBN varchar(30)
)
RETURNS TABLE AS RETURN
(
	select Numero, Codigo from LibroEjemplarSet le left join HistorialPrestamoSet
	on LibroEjemplarCodigo = le.Codigo
	where le.LibroISBN = @ISBN and (Estado is null or Estado = 0)
)
go
----Trae ISBN por Autor
CREATE FUNCTION fxTraeLibroPorAutor
(
	@idAutor int
)
RETURNS TABLE AS RETURN
(
	select LibroISBN from LibroAutorSet where AutorId = @idAutor
)
go
-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
