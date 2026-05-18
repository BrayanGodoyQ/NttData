Tecnologias Utilizadas
Back-end
* Framework: .NET 10.0 (Web API)
* Arquitectura: Clean Architecture con separacion de responsabilidades en Controladores, Servicios, Interfaces y Modelos (DTOs).
* Inyeccion de dependencias: HttpClient tipado y configurado de forma centralizada.
* Seguridad: Politicas CORS habilitadas para permitir el acceso seguro desde el Frontend.

Front-end
* Estructura: HTML5 semantico.
* Estilos: CSS3 nativo utilizando CSS Grid y Flexbox para un diseño adaptable a dispositivos moviles.
* Logica: JavaScript Asincrono con Fetch API para la comunicacion con el Backend.

Estructura de Carpetas
* RetoTecnico: Carpeta principal del Backend en .NET 10. Contiene los controladores que exponen los endpoints, los servicios que consumen la API externa y los modelos de datos filtrados.
* Frontend: Carpeta con los archivos de la interfaz de usuario. Contiene la vista index.html, los estilos de diseño y la logica app.js que renderiza las tarjetas de los usuarios.

Como Ejecutar el Proyecto
1. Iniciar el Backend
* Abre la terminal dentro de la carpeta RetoTecnico.
* Ejecuta el comando "dotnet restore" para descargar los paquetes necesarios.
* Ejecuta el comando "dotnet run" para encender el servidor. El sistema indicara la URL local (usualmente http://localhost:5000).

2. Iniciar el Frontend
* Abre el archivo index.html en un navegador web (se recomienda usar Live Server en VS Code).
* Asegurate de que la URL de la API en app.js coincida con el puerto del Backend.
* Presiona el boton "Cargar Usuarios" para traer los datos desde .NET y ver las tarjetas en pantalla.
