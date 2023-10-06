# Task List API

Aplicación que administra en Bases de datos las tareas creadas

## Tecnologias

Se usan las diferentes tecnologias y paquetes:

* .NET CORE
* Entity.Framework (Codefirst)
* Swagger

## Ejecucion

Modificar conexión a base de datos en el archivo [appsettings.json]

```bash
    "ToDoListConnection": "Server=XXXX;Database=ToDoList;Trusted_Connection=True;TrustServerCertificate=True;"
```

Posteriormente Crear en base de datos SQL Server la Base de datos con nombre [ToDoList]


Realizar compilación y ejecucion de la solución desde Visual studio agregando como proyecto de inicio, el proyecto [TaskListAPI"] y tener este proyecto ejecutando antes de la aplicacion de react "To Do List" para que migre la tabla necesaria de tareas

--------------------

Usar en dirección y puerto https://localhost:7149