1. ¿Dónde aplicaste SRP y por qué?
   
  Lo apliqué al separar las responsabilidades en tres capas: 
    
    - El Controller sólo gestiona HTTP y rutas, 
    - El Service contiene la lógica de validación y negocio
    - Repository se encarga exclusivamente de la persistencia de datos. 
    
  Todo esto permite que cada clase tenga una "única razón para cambiar", facilitando el mantenimiento y evitando que el controlador se convierta en una clase "Dios".

2. ¿Cómo aplicaste DIP en tu solución?
  Mediante la Inyección de Dependencias en el constructor. El Controlador no depende de una implementación concreta (PaymentRequestService), sino de su interfaz (IPaymentRequestService).
  Lo mismo ocurre entre el Servicio y el Repositorio. Esto desacopla las capas, permitiendo que las implementaciones de bajo nivel (como la base de datos) puedan ser sustituidas
  sin afectar el código de alto nivel (lógica de negocio).

3. ¿Qué devuelves en POST con 201 Created y por qué?
  Devuelvo el objeto recién creado junto con su ID autogenerado. Siguiendo el estándar REST, el código 201 Created indica que la operación fue exitosa. Al devolver el recurso completo,
  el cliente (Front) puede actualizar la UI de inmediato sin necesidad de realizar una segunda petición GET para obtener los datos generados por el servidor (como el ID o la fecha de creación).

4. ¿Qué base de datos elegiste y por qué?
  Elegí SQLite junto con Entity Framework Core. Opté por esta solución debido a su ligereza y portabilidad, lo cual es ideal para pruebas técnicas y entornos de evaluación. Al ser una
  base de datos basada en un archivo local, permite que el proyecto sea "Zero-Configuration": el evaluador puede ejecutar la solución inmediatamente sin necesidad de tener instalado o
  configurar un servidor de SQL Server completo. Utilicé EF Core Migrations para gestionar el esquema, asegurando que la base de datos sea versionable y fácil de desplegar con un solo comando.

Instrucciones de ejecución:

Esta solución está diseñada para ser funcional de inmediato sin configuraciones complejas de servidor. El Front está integrado en la carpeta "wwwroot". Fue desarrollada en .NET 8.

  1. Configuración del Entorno
       Abrir la solución PaymentRequestApp.sln en Visual Studio 2022. Asegurarse de tener instaladas las herramientas de desarrollo de ASP.NET y desarrollo web.

  2. Puesta en marcha del Backend (API)
        - Base de Datos: El proyecto ya incluye el archivo Payments.db (SQLite) con el esquema inicial. No son necesarias configuraciones adicionales
        - Si por alguna razón de permisos el archivo de base de datos no es reconocido, puede regenerarlo en segundos abriendo la Consola del Administrador de Paquetes
          y ejecutando "Update-Database". 

  3. Ejecución: Presione F5. La interfaz que se mostrará originalmente es la del Frontend. La documentación de la API con Swagger está disponible en "https://localhost:XXXX/swagger/index.html" (Sustituir
     la XXXX por el puerto asignado). Al abrir la interfaz de Swagger, se podrá visualizar los endpoints:

        - GET /api/PaymentRequest: Lista todas las solicitudes.
        - POST /api/PaymentRequest: Registra una nueva solicitud.
    
  4. Uso del Frontend
     La interfaz de usuario ha sido desarrollada en Vanilla JavaScript y se sirve directamente desde la aplicación:
         - Con el Backend en ejecución, navegue a la URL indicada (usualmente https://localhost:XXXX/index.html).
         - Desde el formulario podrá registrar nuevos pagos. La tabla inferior se actualizará automáticamente mediante peticiones fetch.

Notas Técnicas adicionales:
   - Arquitectura: Se implementó un patrón de capas (Controller -> Service -> Repository) respetando el principio de responsabilidad única (SRP).
   - Persistencia: Se utilizó Entity Framework Core con el proveedor SQLite para garantizar la portabilidad total del examen sin dependencia de un servidor SQL Server externo.
   - Validaciones: El modelo incluye validaciones mediante Data Annotations que son validadas automáticamente por el ModelState en el controlador.
