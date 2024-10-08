USE [master]
GO
/****** Object:  Database [LibreriaGitano]    Script Date: 5/8/2024 22:22:05 ******/
CREATE DATABASE [LibreriaGitano] ON  PRIMARY 
( NAME = N'LibreriaGitano', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\LibreriaGitano.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'LibreriaGitano_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\LibreriaGitano_log.LDF' , SIZE = 576KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [LibreriaGitano] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibreriaGitano].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibreriaGitano] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibreriaGitano] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibreriaGitano] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibreriaGitano] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibreriaGitano] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibreriaGitano] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [LibreriaGitano] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibreriaGitano] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibreriaGitano] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibreriaGitano] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibreriaGitano] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibreriaGitano] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibreriaGitano] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibreriaGitano] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibreriaGitano] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LibreriaGitano] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibreriaGitano] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibreriaGitano] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibreriaGitano] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibreriaGitano] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibreriaGitano] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LibreriaGitano] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibreriaGitano] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LibreriaGitano] SET  MULTI_USER 
GO
ALTER DATABASE [LibreriaGitano] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibreriaGitano] SET DB_CHAINING OFF 
GO
USE [LibreriaGitano]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 5/8/2024 22:22:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[DNI] [nvarchar](20) NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
	[Apellido] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Telefono] [nvarchar](20) NOT NULL,
	[Direccion] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DNI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientesEliminados]    Script Date: 5/8/2024 22:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientesEliminados](
	[EliminadoID] [int] IDENTITY(1,1) NOT NULL,
	[DNI] [nvarchar](20) NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
	[Apellido] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Telefono] [nvarchar](20) NOT NULL,
	[Direccion] [nvarchar](255) NOT NULL,
	[FechaEliminacion] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EliminadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libros]    Script Date: 5/8/2024 22:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libros](
	[LibroID] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](255) NOT NULL,
	[Autor] [nvarchar](255) NOT NULL,
	[ISBN] [nvarchar](13) NOT NULL,
	[FechaPublicacion] [varchar](10) NULL,
	[Editorial] [nvarchar](255) NULL,
	[Precio] [decimal](10, 2) NULL,
	[Paginas] [int] NULL,
	[Genero] [nvarchar](100) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Stock] [int] NULL,
	[ProveedorID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[LibroID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 5/8/2024 22:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[ProveedorID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NULL,
	[Telefono] [nvarchar](20) NULL,
	[Direccion] [nvarchar](255) NULL,
	[Activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProveedorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProveedoresLibros]    Script Date: 5/8/2024 22:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProveedoresLibros](
	[ProveedorID] [int] NOT NULL,
	[ISBN] [nvarchar](13) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProveedorID] ASC,
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 5/8/2024 22:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas](
	[VentaID] [int] IDENTITY(1,1) NOT NULL,
	[DNI] [nvarchar](20) NULL,
	[ISBN] [nvarchar](13) NOT NULL,
	[FechaVenta] [datetime] NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioVenta] [decimal](10, 2) NOT NULL,
	[EliminadoID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[VentaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Clientes] ([DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion]) VALUES (N'000000', N'Cliente', N'Eliminado', N'noreply@example.com', N'0000000000', N'N/A')
INSERT [dbo].[Clientes] ([DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion]) VALUES (N'00000000', N'Sofia', N'Ramirez', N'sofia.ramirez0@example.com', N'7778889990', N'Paseo de la Reforma 707')
INSERT [dbo].[Clientes] ([DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion]) VALUES (N'11111111', N'Juan', N'Perez', N'juan.perez1@example.com', N'1234567890', N'Calle Falsa 123')
INSERT [dbo].[Clientes] ([DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion]) VALUES (N'123456481', N'ivanvito', N'viera', N'vierita@gmail.com', N'115994521', N'deporahi')
INSERT [dbo].[Clientes] ([DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion]) VALUES (N'12345655', N'ivan', N'viera', N'iviviera@gmail.com', N'115991516', N'mmmazini')
INSERT [dbo].[Clientes] ([DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion]) VALUES (N'17784978', N'mariano', N'ortiz', N'mariano@gmail.com', N'1175489412', N'boedo1794')
INSERT [dbo].[Clientes] ([DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion]) VALUES (N'20789421', N'hilda', N'mercedez', N'hildamercedez12@gmail.com', N'11783561780', N'colondres7895')
INSERT [dbo].[Clientes] ([DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion]) VALUES (N'21897631', N'carla', N'veron', N'carlita89@gmail.com', N'1164325480', N'numancia142')
INSERT [dbo].[Clientes] ([DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion]) VALUES (N'22222222', N'Maria', N'Gomez', N'maria.gomez2@example.com', N'0987654321', N'Avenida Siempre Viva 456')
INSERT [dbo].[Clientes] ([DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion]) VALUES (N'24789675', N'juaquin', N'fernandez', N'juaco74@gmail.com', N'1178943108', N'merlo496')
INSERT [dbo].[Clientes] ([DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion]) VALUES (N'28188899', N'Marcela', N'Cinalli', N'marcelasoledadcinalli@gmail.com', N'1156024690', N'bustos1856')
INSERT [dbo].[Clientes] ([DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion]) VALUES (N'28199816', N'octavio', N'hernandez', N'octavio@gmail.com', N'11895904', N'Buenos aires1650')
INSERT [dbo].[Clientes] ([DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion]) VALUES (N'33333333', N'Carlos', N'Rodriguez', N'carlos.rodriguez3@example.com', N'1112223334', N'Boulevard Sol 789')
INSERT [dbo].[Clientes] ([DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion]) VALUES (N'41111', N'martina', N'martinez', N'nashe@gmail.com', N'1159891620', N'mazzini')
INSERT [dbo].[Clientes] ([DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion]) VALUES (N'461228488', N'Mauro', N'Diaz', N'Maurodiaz@gmail.com', N'1178944561', N'Bolivar 4621')
INSERT [dbo].[Clientes] ([DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion]) VALUES (N'481288644', N'Marcelo', N'viera', N'marceloviera78@gmail.com', N'1102469021', N'mazzini1431')
INSERT [dbo].[Clientes] ([DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion]) VALUES (N'481888484', N'martin', N'martinez', N'martu78@gmail.com', N'1189554604', N'Caseros195')
INSERT [dbo].[Clientes] ([DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion]) VALUES (N'48789643', N'michel', N'veraz', N'micheljordan32@gmail.com', N'1176248340', N'nuston8890')
INSERT [dbo].[Clientes] ([DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion]) VALUES (N'55555555', N'Pedro', N'Lopez', N'pedro.lopez5@example.com', N'9998887776', N'Avenida Estrella 202')
INSERT [dbo].[Clientes] ([DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion]) VALUES (N'66666666', N'Laura', N'Fernandez', N'laura.fernandez6@example.com', N'3334445557', N'Camino Real 303')
INSERT [dbo].[Clientes] ([DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion]) VALUES (N'77777777', N'Luis', N'Garcia', N'luis.garcia7@example.com', N'6667778889', N'Plaza Mayor 404')
INSERT [dbo].[Clientes] ([DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion]) VALUES (N'88888888', N'Elena', N'Torres', N'elena.torres8@example.com', N'4445556661', N'Parque Central 505')
INSERT [dbo].[Clientes] ([DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion]) VALUES (N'99999999', N'Miguel', N'Sanchez', N'miguel.sanchez9@example.com', N'2223334442', N'Calle Victoria 606')
GO
SET IDENTITY_INSERT [dbo].[ClientesEliminados] ON 

INSERT [dbo].[ClientesEliminados] ([EliminadoID], [DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion], [FechaEliminacion]) VALUES (1, N'481888484', N'martin', N'martinez', N'martu78@gmail.com', N'1189554604', N'Caseros195', CAST(N'2024-08-01T19:27:59.030' AS DateTime))
INSERT [dbo].[ClientesEliminados] ([EliminadoID], [DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion], [FechaEliminacion]) VALUES (4, N'12345678', N'q', N'v', N'dwadwad@gmail.com', N'11595952', N'aca', CAST(N'2024-08-01T19:45:51.797' AS DateTime))
INSERT [dbo].[ClientesEliminados] ([EliminadoID], [DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion], [FechaEliminacion]) VALUES (5, N'44444444', N'Ana', N'Martinez', N'ana.martinez4@example.com', N'5556667778', N'Calle Luna 101', CAST(N'2024-08-01T19:49:55.653' AS DateTime))
INSERT [dbo].[ClientesEliminados] ([EliminadoID], [DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion], [FechaEliminacion]) VALUES (10, N'12345678', N'iiiiiiiiiiii', N'adwadada', N'awdwad', N'123456789', N'adawda', CAST(N'2024-08-01T19:58:40.937' AS DateTime))
INSERT [dbo].[ClientesEliminados] ([EliminadoID], [DNI], [Nombre], [Apellido], [Email], [Telefono], [Direccion], [FechaEliminacion]) VALUES (11, N'46122306', N'ivan', N'viera', N'Iviviera@gmail.com', N'1159891620', N'mazzini1431', CAST(N'2024-08-01T19:59:56.373' AS DateTime))
SET IDENTITY_INSERT [dbo].[ClientesEliminados] OFF
GO
SET IDENTITY_INSERT [dbo].[Libros] ON 

INSERT [dbo].[Libros] ([LibroID], [Titulo], [Autor], [ISBN], [FechaPublicacion], [Editorial], [Precio], [Paginas], [Genero], [Descripcion], [Stock], [ProveedorID]) VALUES (1, N'El Quijote', N'Miguel de Cervantes', N'9788437604947', N'1605-01-16', N'Editorial Anaya', CAST(1699.00 AS Decimal(10, 2)), 1023, N'Novela', N'Un clásico de la literatura española.', 7, 1)
INSERT [dbo].[Libros] ([LibroID], [Titulo], [Autor], [ISBN], [FechaPublicacion], [Editorial], [Precio], [Paginas], [Genero], [Descripcion], [Stock], [ProveedorID]) VALUES (2, N'Cien años de soledad', N'Gabriel García Márquez', N'9780307474728', N'30/05/1967', N'Editorial Sudamericana', CAST(12.99 AS Decimal(10, 2)), 417, N'Relato', N'Obra maestra del realismo mágico.', 5, 1)
INSERT [dbo].[Libros] ([LibroID], [Titulo], [Autor], [ISBN], [FechaPublicacion], [Editorial], [Precio], [Paginas], [Genero], [Descripcion], [Stock], [ProveedorID]) VALUES (4, N'1984', N'George Orwell', N'9780451524935', N'1949-06-08', N'Secker & Warburg', CAST(9.99 AS Decimal(10, 2)), 328, N'Distopía', N'Una visión aterradora del futuro.', 5, 1)
INSERT [dbo].[Libros] ([LibroID], [Titulo], [Autor], [ISBN], [FechaPublicacion], [Editorial], [Precio], [Paginas], [Genero], [Descripcion], [Stock], [ProveedorID]) VALUES (5, N'Orgullo y prejuicio', N'Jane Austen', N'9781503290563', N'1813-01-28', N'T. Egerton', CAST(8.99 AS Decimal(10, 2)), 279, N'Romance', N'Una crítica mordaz de la sociedad inglesa.', 23, 1)
INSERT [dbo].[Libros] ([LibroID], [Titulo], [Autor], [ISBN], [FechaPublicacion], [Editorial], [Precio], [Paginas], [Genero], [Descripcion], [Stock], [ProveedorID]) VALUES (6, N'Matar a un ruiseñor', N'Harper Lee', N'9780061120084', N'1960-07-11', N'J.B. Lippincott & Co.', CAST(7.99 AS Decimal(10, 2)), 324, N'Drama', N'Un análisis profundo del racismo en el sur de los Estados Unidos.', 18, 1)
INSERT [dbo].[Libros] ([LibroID], [Titulo], [Autor], [ISBN], [FechaPublicacion], [Editorial], [Precio], [Paginas], [Genero], [Descripcion], [Stock], [ProveedorID]) VALUES (7, N'El gran Gatsby', N'F. Scott Fitzgerald', N'9780743273565', N'1925-04-10', N'Charles Scribner\s Sons', CAST(10.99 AS Decimal(10, 2)), 180, N'Tragedia', N'La historia del misterioso millonario Jay Gatsby.', 20, 1)
INSERT [dbo].[Libros] ([LibroID], [Titulo], [Autor], [ISBN], [FechaPublicacion], [Editorial], [Precio], [Paginas], [Genero], [Descripcion], [Stock], [ProveedorID]) VALUES (8, N'Crimen y castigo', N'Fiódor Dostoyevski', N'9780140449136', N'1866-01-01', N'The Russian Messenger', CAST(11.99 AS Decimal(10, 2)), 671, N'Filosofía', N'Una exploración de la moralidad y la culpa.', 9, 1)
INSERT [dbo].[Libros] ([LibroID], [Titulo], [Autor], [ISBN], [FechaPublicacion], [Editorial], [Precio], [Paginas], [Genero], [Descripcion], [Stock], [ProveedorID]) VALUES (9, N'Los miserables', N'Victor Hugo', N'9780451419438', N'1862-01-01', N'A. Lacroix, Verboeckhoven & Cie', CAST(15.99 AS Decimal(10, 2)), 1463, N'Drama', N'La lucha de Jean Valjean por redimirse.', 12, 1)
INSERT [dbo].[Libros] ([LibroID], [Titulo], [Autor], [ISBN], [FechaPublicacion], [Editorial], [Precio], [Paginas], [Genero], [Descripcion], [Stock], [ProveedorID]) VALUES (10, N'La Odisea', N'Homero', N'9780140268867', N'800 a.C.', N'Desconocido', CAST(9.99 AS Decimal(10, 2)), 541, N'Épico', N'Las aventuras de Odiseo en su regreso a Ítaca.', 23, 1)
INSERT [dbo].[Libros] ([LibroID], [Titulo], [Autor], [ISBN], [FechaPublicacion], [Editorial], [Precio], [Paginas], [Genero], [Descripcion], [Stock], [ProveedorID]) VALUES (11, N'Ulises', N'James Joyce', N'9780199535675', N'1922-02-02', N'Shakespeare and Company', CAST(16.99 AS Decimal(10, 2)), 730, N'Modernismo', N'Una narración de un solo día en la vida de Leopold Bloom.', 1, 1)
INSERT [dbo].[Libros] ([LibroID], [Titulo], [Autor], [ISBN], [FechaPublicacion], [Editorial], [Precio], [Paginas], [Genero], [Descripcion], [Stock], [ProveedorID]) VALUES (12, N'El Principito', N'Antoine de Saint-Exupéry', N'9780156012195', N'1943-04-06', N'Reynal & Hitchcock', CAST(6.99 AS Decimal(10, 2)), 96, N'Fábula', N'Una historia encantadora sobre la amistad y la inocencia.', 41, 1)
INSERT [dbo].[Libros] ([LibroID], [Titulo], [Autor], [ISBN], [FechaPublicacion], [Editorial], [Precio], [Paginas], [Genero], [Descripcion], [Stock], [ProveedorID]) VALUES (13, N'El Señor de los Anillos', N'J.R.R. Tolkien', N'9780618640157', N'1954-07-29', N'George Allen & Unwin', CAST(29.99 AS Decimal(10, 2)), 1178, NULL, N'Una épica aventura en la Tierra Media.', 6, 1)
INSERT [dbo].[Libros] ([LibroID], [Titulo], [Autor], [ISBN], [FechaPublicacion], [Editorial], [Precio], [Paginas], [Genero], [Descripcion], [Stock], [ProveedorID]) VALUES (14, N'La divina comedia', N'Dante Alighieri', N'9780199535644', N'1320-01-01', N'Desconocido', CAST(12.99 AS Decimal(10, 2)), 798, N'Poesía épica', N'El viaje de Dante a través del Infierno, Purgatorio y Paraíso.', 14, 1)
INSERT [dbo].[Libros] ([LibroID], [Titulo], [Autor], [ISBN], [FechaPublicacion], [Editorial], [Precio], [Paginas], [Genero], [Descripcion], [Stock], [ProveedorID]) VALUES (15, N'En busca del tiempo perdido', N'Marcel Proust', N'9780679645689', N'1913-11-14', N'Grasset', CAST(18.99 AS Decimal(10, 2)), 4215, NULL, N'Una profunda exploración de la memoria y el tiempo.', 51, 1)
INSERT [dbo].[Libros] ([LibroID], [Titulo], [Autor], [ISBN], [FechaPublicacion], [Editorial], [Precio], [Paginas], [Genero], [Descripcion], [Stock], [ProveedorID]) VALUES (16, N'Cumbres borrascosas', N'Emily Brontë', N'9780141439556', N'1847-12-01', N'Thomas Cautley Newby', CAST(8.99 AS Decimal(10, 2)), 416, N'Gótico', N'La trágica historia de amor entre Heathcliff y Catherine.', 15, 1)
INSERT [dbo].[Libros] ([LibroID], [Titulo], [Autor], [ISBN], [FechaPublicacion], [Editorial], [Precio], [Paginas], [Genero], [Descripcion], [Stock], [ProveedorID]) VALUES (17, N'Anna Karenina', N'León Tolstói', N'9780143035008', N'1877-01-01', N'The Russian Messenger', CAST(13.99 AS Decimal(10, 2)), 864, N'Realismo', N'La vida de la aristocracia rusa en el siglo XIX.', 18, 1)
INSERT [dbo].[Libros] ([LibroID], [Titulo], [Autor], [ISBN], [FechaPublicacion], [Editorial], [Precio], [Paginas], [Genero], [Descripcion], [Stock], [ProveedorID]) VALUES (18, N'El retrato de Dorian Gray', N'Oscar Wilde', N'9780141442464', N'1890-06-20', N'Lippincott\s Monthly Magazine', CAST(7.99 AS Decimal(10, 2)), 254, N'Gótico', N'La historia de un joven que desea mantener su juventud y belleza eternamente.', 23, 1)
INSERT [dbo].[Libros] ([LibroID], [Titulo], [Autor], [ISBN], [FechaPublicacion], [Editorial], [Precio], [Paginas], [Genero], [Descripcion], [Stock], [ProveedorID]) VALUES (19, N'La metamorfosis', N'Franz Kafka', N'9780141045206', N'1915-01-01', N'Kurt Wolff Verlag', CAST(5.99 AS Decimal(10, 2)), 74, N'Existencialismo', N'La transformación de Gregor Samsa en un insecto gigante.', 35, 1)
INSERT [dbo].[Libros] ([LibroID], [Titulo], [Autor], [ISBN], [FechaPublicacion], [Editorial], [Precio], [Paginas], [Genero], [Descripcion], [Stock], [ProveedorID]) VALUES (20, N'El alquimista', N'Paulo Coelho', N'9780061122415', N'1988-01-01', N'HarperCollins', CAST(9.99 AS Decimal(10, 2)), 208, N'Ficción', N'La búsqueda de un joven pastor por su leyenda personal.', 28, 1)
INSERT [dbo].[Libros] ([LibroID], [Titulo], [Autor], [ISBN], [FechaPublicacion], [Editorial], [Precio], [Paginas], [Genero], [Descripcion], [Stock], [ProveedorID]) VALUES (21, N'Fahrenheit 451', N'Ray Bradbury', N'9781451673319', N'1953-10-19', N'Ballantine Books', CAST(10.99 AS Decimal(10, 2)), 256, N'Distopía', N'Una sociedad donde los libros están prohibidos y son quemados.', 18, 1)
INSERT [dbo].[Libros] ([LibroID], [Titulo], [Autor], [ISBN], [FechaPublicacion], [Editorial], [Precio], [Paginas], [Genero], [Descripcion], [Stock], [ProveedorID]) VALUES (22, N'Orgullo y Prejuicio', N'Jane Austen', N'9780141439518', N'1813-01-28', N'T. Egerton', CAST(699.00 AS Decimal(10, 2)), 279, N'3', N'Una comedia sobre las costumbres de la sociedad inglesa.', 60, 15)
SET IDENTITY_INSERT [dbo].[Libros] OFF
GO
SET IDENTITY_INSERT [dbo].[Proveedores] ON 

INSERT [dbo].[Proveedores] ([ProveedorID], [Nombre], [Email], [Telefono], [Direccion], [Activo]) VALUES (1, N'Proveedor1', N'proveedor1@example.com', N'1234567890', N'Calle Falsa 123', 1)
INSERT [dbo].[Proveedores] ([ProveedorID], [Nombre], [Email], [Telefono], [Direccion], [Activo]) VALUES (3, N'Proveedor3', N'proveedor3@example.com', N'1112223334', N'Boulevard Sol 789', 1)
INSERT [dbo].[Proveedores] ([ProveedorID], [Nombre], [Email], [Telefono], [Direccion], [Activo]) VALUES (4, N'Proveedor4', N'proveedor4@example.com', N'5556667778', N'Calle Luna 101', 1)
INSERT [dbo].[Proveedores] ([ProveedorID], [Nombre], [Email], [Telefono], [Direccion], [Activo]) VALUES (5, N'Proveedor5', N'proveedor5@example.com', N'9998887776', N'Avenida Estrella 202', 1)
INSERT [dbo].[Proveedores] ([ProveedorID], [Nombre], [Email], [Telefono], [Direccion], [Activo]) VALUES (6, N'Proveedor6', N'proveedor6@example.com', N'3334445557', N'Camino Real 303', 1)
INSERT [dbo].[Proveedores] ([ProveedorID], [Nombre], [Email], [Telefono], [Direccion], [Activo]) VALUES (7, N'Proveedor7', N'proveedor7@example.com', N'6667778889', N'Plaza Mayor 404', 1)
INSERT [dbo].[Proveedores] ([ProveedorID], [Nombre], [Email], [Telefono], [Direccion], [Activo]) VALUES (8, N'Proveedor8', N'proveedor8@example.com', N'4445556661', N'Parque Central 505', 1)
INSERT [dbo].[Proveedores] ([ProveedorID], [Nombre], [Email], [Telefono], [Direccion], [Activo]) VALUES (11, N'Ivan', N'Elpiterson@gmail.com', N'1159891620', N'enalgunlugardelmundo', 1)
INSERT [dbo].[Proveedores] ([ProveedorID], [Nombre], [Email], [Telefono], [Direccion], [Activo]) VALUES (12, N'Gustavo', N'gustavin@gmail.com', N'1148962042', N'Banfield 1465', 1)
INSERT [dbo].[Proveedores] ([ProveedorID], [Nombre], [Email], [Telefono], [Direccion], [Activo]) VALUES (14, N'matias', N'MatiasPedidos9009@gmail.com', N'1189345781', N'lomas de zamora bustos480', 1)
INSERT [dbo].[Proveedores] ([ProveedorID], [Nombre], [Email], [Telefono], [Direccion], [Activo]) VALUES (15, N'alfredo', N'monzoal12@gmail.com', N'115987516', N'perla79, glew', 1)
SET IDENTITY_INSERT [dbo].[Proveedores] OFF
GO
INSERT [dbo].[ProveedoresLibros] ([ProveedorID], [ISBN]) VALUES (1, N'9788437604947')
INSERT [dbo].[ProveedoresLibros] ([ProveedorID], [ISBN]) VALUES (3, N'9780307474728')
INSERT [dbo].[ProveedoresLibros] ([ProveedorID], [ISBN]) VALUES (4, N'9780451524935')
GO
SET IDENTITY_INSERT [dbo].[Ventas] ON 

INSERT [dbo].[Ventas] ([VentaID], [DNI], [ISBN], [FechaVenta], [Cantidad], [PrecioVenta], [EliminadoID]) VALUES (2, N'00000000', N'9788437604947', CAST(N'2002-05-06T00:00:00.000' AS DateTime), 2, CAST(40.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Ventas] ([VentaID], [DNI], [ISBN], [FechaVenta], [Cantidad], [PrecioVenta], [EliminadoID]) VALUES (3, N'123456481', N'9780140268867', CAST(N'2024-07-23T00:00:00.000' AS DateTime), 1, CAST(9.99 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Ventas] ([VentaID], [DNI], [ISBN], [FechaVenta], [Cantidad], [PrecioVenta], [EliminadoID]) VALUES (4, N'12345655', N'9780140268867', CAST(N'2024-07-23T00:00:00.000' AS DateTime), 1, CAST(9.99 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Ventas] ([VentaID], [DNI], [ISBN], [FechaVenta], [Cantidad], [PrecioVenta], [EliminadoID]) VALUES (5, N'12345655', N'9780743273565', CAST(N'2024-07-23T00:00:00.000' AS DateTime), 1, CAST(10.99 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Ventas] ([VentaID], [DNI], [ISBN], [FechaVenta], [Cantidad], [PrecioVenta], [EliminadoID]) VALUES (6, N'00000000', N'9781451673319', CAST(N'2024-07-23T00:00:00.000' AS DateTime), 1, CAST(10.99 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Ventas] ([VentaID], [DNI], [ISBN], [FechaVenta], [Cantidad], [PrecioVenta], [EliminadoID]) VALUES (7, N'461228488', N'9780156012195', CAST(N'2024-07-23T00:00:00.000' AS DateTime), 2, CAST(13.98 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Ventas] ([VentaID], [DNI], [ISBN], [FechaVenta], [Cantidad], [PrecioVenta], [EliminadoID]) VALUES (8, N'461228488', N'9780141439556', CAST(N'2024-07-23T00:00:00.000' AS DateTime), 1, CAST(8.99 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Ventas] ([VentaID], [DNI], [ISBN], [FechaVenta], [Cantidad], [PrecioVenta], [EliminadoID]) VALUES (9, N'28199816', N'9788437604947', CAST(N'2024-07-29T00:00:00.000' AS DateTime), 2, CAST(3398.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Ventas] ([VentaID], [DNI], [ISBN], [FechaVenta], [Cantidad], [PrecioVenta], [EliminadoID]) VALUES (10, N'000000', N'9780679645689', CAST(N'2024-07-29T00:00:00.000' AS DateTime), 2, CAST(37.98 AS Decimal(10, 2)), 11)
INSERT [dbo].[Ventas] ([VentaID], [DNI], [ISBN], [FechaVenta], [Cantidad], [PrecioVenta], [EliminadoID]) VALUES (11, N'000000', N'9780679645689', CAST(N'2024-07-29T00:00:00.000' AS DateTime), 2, CAST(37.98 AS Decimal(10, 2)), 11)
INSERT [dbo].[Ventas] ([VentaID], [DNI], [ISBN], [FechaVenta], [Cantidad], [PrecioVenta], [EliminadoID]) VALUES (12, N'481888484', N'9780156012195', CAST(N'2024-07-29T00:00:00.000' AS DateTime), 2, CAST(13.98 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Ventas] ([VentaID], [DNI], [ISBN], [FechaVenta], [Cantidad], [PrecioVenta], [EliminadoID]) VALUES (13, N'20789421', N'9780140268867', CAST(N'2024-07-29T00:00:00.000' AS DateTime), 1, CAST(9.99 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Ventas] ([VentaID], [DNI], [ISBN], [FechaVenta], [Cantidad], [PrecioVenta], [EliminadoID]) VALUES (14, N'20789421', N'9780140449136', CAST(N'2024-07-29T00:00:00.000' AS DateTime), 1, CAST(11.99 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Ventas] ([VentaID], [DNI], [ISBN], [FechaVenta], [Cantidad], [PrecioVenta], [EliminadoID]) VALUES (15, N'17784978', N'9780451524935', CAST(N'2024-07-29T00:00:00.000' AS DateTime), 3, CAST(29.97 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Ventas] ([VentaID], [DNI], [ISBN], [FechaVenta], [Cantidad], [PrecioVenta], [EliminadoID]) VALUES (16, N'21897631', N'9780618640157', CAST(N'2024-07-29T00:00:00.000' AS DateTime), 2, CAST(59.98 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Ventas] ([VentaID], [DNI], [ISBN], [FechaVenta], [Cantidad], [PrecioVenta], [EliminadoID]) VALUES (17, N'24789675', N'9781503290563', CAST(N'2024-07-29T00:00:00.000' AS DateTime), 1, CAST(8.99 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Ventas] ([VentaID], [DNI], [ISBN], [FechaVenta], [Cantidad], [PrecioVenta], [EliminadoID]) VALUES (18, N'48789643', N'9780451524935', CAST(N'2024-07-29T00:00:00.000' AS DateTime), 2, CAST(19.98 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Ventas] ([VentaID], [DNI], [ISBN], [FechaVenta], [Cantidad], [PrecioVenta], [EliminadoID]) VALUES (19, N'000000', N'9780199535675', CAST(N'2024-07-29T00:00:00.000' AS DateTime), 2, CAST(33.98 AS Decimal(10, 2)), 10)
SET IDENTITY_INSERT [dbo].[Ventas] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Libros__447D36EA25869641]    Script Date: 5/8/2024 22:22:06 ******/
ALTER TABLE [dbo].[Libros] ADD UNIQUE NONCLUSTERED 
(
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ClientesEliminados] ADD  DEFAULT (getdate()) FOR [FechaEliminacion]
GO
ALTER TABLE [dbo].[Proveedores] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Ventas] ADD  CONSTRAINT [DF_Ventas_DNI]  DEFAULT ('0000000') FOR [DNI]
GO
ALTER TABLE [dbo].[Libros]  WITH CHECK ADD  CONSTRAINT [FK_Libros_Proveedores] FOREIGN KEY([ProveedorID])
REFERENCES [dbo].[Proveedores] ([ProveedorID])
GO
ALTER TABLE [dbo].[Libros] CHECK CONSTRAINT [FK_Libros_Proveedores]
GO
ALTER TABLE [dbo].[ProveedoresLibros]  WITH CHECK ADD FOREIGN KEY([ProveedorID])
REFERENCES [dbo].[Proveedores] ([ProveedorID])
GO
ALTER TABLE [dbo].[ProveedoresLibros]  WITH CHECK ADD FOREIGN KEY([ISBN])
REFERENCES [dbo].[Libros] ([ISBN])
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Ventas_Clientes] FOREIGN KEY([DNI])
REFERENCES [dbo].[Clientes] ([DNI])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_Ventas_Clientes]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Ventas_Libros] FOREIGN KEY([ISBN])
REFERENCES [dbo].[Libros] ([ISBN])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_Ventas_Libros]
GO
USE [master]
GO
ALTER DATABASE [LibreriaGitano] SET  READ_WRITE 
GO
