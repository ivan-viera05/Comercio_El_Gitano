COMERCIO EL GITANO.
Comercio El Gitano es una aplicación de escritorio desarrollada en C# utilizando Windows Forms. Está diseñada para la gestión de una librería ficticia, proporcionando funcionalidades completas y complejas de alta, baja, modificación y consulta (CRUD) de libros y ventas. El proyecto está estructurado en tres capas (datos, negocio y presentación) y utiliza SQL Server para la gestión de la base de datos.

CARACTERISTICAS Gestión de Libros: Permite realizar operaciones CRUD sobre los libros de la librería. Gestión de Ventas: Incluye funcionalidades para registrar ventas, así como para consultar y modificar registros existentes. Gestion de Clientes: Podras tener el control de clientes como datos personales tambien datos de compra y mas... Validaciones: Implementación de validaciones de datos en la capa de negocio. Estructura en Capas: Separación de la lógica de negocio, acceso a datos y presentación. Base de Datos: Uso de SQL Server para el almacenamiento y gestión de datos. Interfaz de Usuario: Desarrollado con Windows Forms para una interfaz de usuario amigable.

INSTALACION Para ejecutar este proyecto en tu máquina local, sigue estos pasos: 1-Clona el repositorio: bash Copiar código git clone https://github.com/ivan-viera05/Comercio_El_Gitano.git cd ComercioElGitano 
2-Configura la base de datos:

Asegúrate de tener SQL Server instalado y en funcionamiento. Restaura la base de datos desde el archivo de respaldo proporcionado en la carpeta Database. Actualiza la cadena de conexión en el archivo App.config en el proyecto de capa de datos (Datos). Compila y ejecuta el proyecto:

3-Abre el archivo de solución (.sln) en Visual Studio. Compila la solución para asegurarte de que todos los paquetes y dependencias se instalen correctamente. Ejecuta la aplicación desde Visual Studio. Uso Una vez que la aplicación esté en funcionamiento, podrás:

Añadir nuevos libros: Ingresa la información requerida en los campos de texto y guarda el registro. Modificar libros existentes: Selecciona un libro de la lista, edita la información y guarda los cambios. Eliminar libros: Selecciona un libro y elimina el registro. Registrar ventas: Ingresa los detalles de la venta y guarda la información. Consultar y modificar ventas: Busca ventas por diferentes criterios, edita los registros según sea necesario. Podras hacer un Alta Baja y Modificacion de datos y llevar un registro exitoso

CONTRIBUCIONES Las contribuciones son bienvenidas. Puedes hacer un fork del repositorio, crear una nueva rama para tus cambios y abrir un Pull Request cuando estés listo. 1-Haz un fork del proyecto. 2-Crea tu rama de característica (git checkout -b feature/nueva-caracteristica). 3-Haz commit de tus cambios (git commit -am 'Agrega una nueva característica'). 4-Empuja tu rama (git push origin feature/nueva-caracteristica). 5-Abre un Pull Request.

LICENCIA Este proyecto está bajo la Licencia MIT. Consulta el archivo LICENSE para más detalles.
