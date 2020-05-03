# QaR.Finder
Aplicación que permite contactar a los dueños de un vehículo de forma segura y escaneando un QR.

# Base de datos

Por defecto la base de datos esta configurada "inmemory" es decir que los datos se almacenan de forma temporal, para modificar y que vaya a un SQL hay que cambiar la configuración desde el archivo QaR.Finder.Api\appsettings.json cambiando el flag a false

```javascript
"UseInMemoryDatabase": false,
```

Revisen en el mismo archivo si "DefaultConnection" tiene un connection string válido, para eso pueden usar el MS SQL Server Managment Studio.

Una vez que chequearon eso, la idea ahora es hacer la migración.
Para eso necesitan ejecutar el siguiente código en la raiz del proyecto.

`dotnet ef migrations add "QaR.Finder.Migration" --project Backend\Infrastructure\QaR.Finder.Infrastructure.csproj --startup-project Backend\WebApi\QaR.Finder.Api.csproj --output-dir Persistence\Migrations`

Como funciona esto de las migraciones? Bueno cuando actualicen el Modelo (Capa de Domain) van a tener que hacer un cambio en el contexto, entonces ejecutan ese comando, y va a actualizarles la base de datos automaticamente cuando corran el proyecto WebApi.
