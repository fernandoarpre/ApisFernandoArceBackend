# ApisFernandoArceBackend

### Backend Net.Core 3.1

# Instalacion

Descargar Codigo y Ejecutar en Visual Studio (Preferencia 2017 o 2019)

### Base de Datos
    Ejecutar script de la base de datos 'Apis_Ventas.sql'
    ruta de string de conexion 'ApiVentas/appsettings.json' : ApiVentasConnection
    
### Configuracion Smtp
    'ApiVentas/appsettings.json'
    
    "AppSettings": {
     "SecretKey": "Apis_ApiVentasF3rn4nd04RC3", // Key de Jwt
     "SmtpHost": "smtp.gmail.com", // Host Gmail
     "SmtpPort": 587, // Puerto
     "SmtpUser": "pruebatecnicaapisfernando@gmail.com", // Correo Creado para la Prueba
     "SmtpPass": "5Ur93P4s4r3" // Contraseña de Correo
    }

### Postman Collection
    PruebaTecnica.postman_collection.json
    Descargar la colección e importarla en postman, para hacer las pruebas de la Api
