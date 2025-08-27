# INSTRUCCIONES DE IMPLEMENTACIÓN - EXAMEN FINAL POOII
## Mantenimiento de Herramientas - Arquitectura de Capas

### 📋 RESUMEN DEL PROYECTO
Se ha implementado una aplicación ASP.NET MVC con arquitectura de capas para el mantenimiento de la tabla `tb_herramienta` según los requerimientos del examen final.

### 🗂️ ESTRUCTURA IMPLEMENTADA

#### **Capa de Entidades (Entity)**
- `Entity/Categoria.cs` - Clase para la entidad Categoría
- `Entity/Herramienta.cs` - Clase para la entidad Herramienta

#### **Capa de Acceso a Datos (DAO)**
- `DAO/conexionDAO.cs` - Manejo de conexión a la base de datos
- `DAO/categoriaDAO.cs` - Operaciones CRUD para categorías
- `DAO/herramientaDAO.cs` - Operaciones CRUD para herramientas

#### **Capa de Presentación (MVC)**
- `Controllers/HerramientaController.cs` - Controlador principal
- `Views/Herramienta/Index.cshtml` - Vista para listar herramientas
- `Views/Herramienta/Agregar.cshtml` - Vista para agregar herramientas
- `Views/Herramienta/Editar.cshtml` - Vista para editar herramientas

### 🛠️ PASOS PARA IMPLEMENTAR

#### **1. Configurar la Base de Datos**
1. Abrir SQL Server Management Studio
2. Ejecutar el script `Database_Script.sql` que contiene:
   - Creación de la base de datos `Negocios2023`
   - Creación de las tablas `tb_categorias` y `tb_herramienta`
   - Inserción de datos iniciales
   - Creación de todos los procedimientos almacenados

#### **2. Configurar la Cadena de Conexión**
La cadena de conexión ya está configurada en `web.config`:
```xml
<connectionStrings>
  <add name="conexionBD" connectionString="Data Source=.;Initial Catalog=Negocios2023;Integrated Security=True" providerName="System.Data.SqlClient" />
</connectionStrings>
```

**Nota:** Ajustar `Data Source` según tu servidor SQL Server.

#### **3. Compilar y Ejecutar**
1. Hacer `git pull` en tu PC con Visual Studio
2. Abrir la solución `POOII_EF_ROMANI_FLORES.sln`
3. Compilar el proyecto (Build → Build Solution)
4. Ejecutar la aplicación (F5 o Ctrl+F5)

#### **4. Probar la Aplicación**
Navegar a: `http://localhost:[puerto]/Herramienta`

### 🎯 FUNCIONALIDADES IMPLEMENTADAS

#### **✅ Procedimientos Almacenados (4 puntos)**
- `sp_ListarCategorias` - Listar categorías
- `sp_ListarHerramientas` - Listar herramientas con JOIN
- `sp_BuscarHerramientaPorId` - Buscar herramienta por ID
- `sp_AgregarHerramienta` - Insertar nueva herramienta
- `sp_ActualizarHerramienta` - Actualizar herramienta existente

#### **✅ Capa de Entidades (2 puntos)**
- Clase `Herramienta` con todas las propiedades requeridas
- Clase `Categoria` con propiedades básicas

#### **✅ Capa DAO (8 puntos)**
- `conexionDAO` - Conexión centralizada desde web.config
- `categoriaDAO` - Método `Listado()` para obtener categorías
- `herramientaDAO` - Métodos completos:
  - `Listado()` - Listar todas las herramientas
  - `BuscarPorId(string id)` - Buscar por ID
  - `Agregar(Herramienta)` - Insertar nueva herramienta
  - `Actualizar(Herramienta)` - Actualizar herramienta

#### **✅ Capa de Presentación (6 puntos)**
- Referencias a capas DAO y Entity configuradas
- `HerramientaController` con ActionResults:
  - `Index()` - Listar herramientas
  - `Agregar()` GET/POST - Crear nueva herramienta
  - `Editar(id)` GET/POST - Editar herramienta existente
- Vistas completas con Bootstrap y validaciones
- DropDownList para categorías en formularios
- Mensajes de confirmación implementados
- Campo ID como solo lectura en edición

### 🔧 CARACTERÍSTICAS ADICIONALES

- **Interfaz moderna** con Bootstrap 5
- **Validaciones** del lado cliente y servidor
- **Manejo de errores** con try-catch
- **Mensajes informativos** para el usuario
- **Indicadores visuales** de stock (colores según cantidad)
- **Responsive design** para diferentes dispositivos

### 📊 DATOS DE PRUEBA
La base de datos incluye:
- 5 categorías predefinidas
- 5 herramientas de ejemplo con diferentes categorías

### 🚨 POSIBLES PROBLEMAS Y SOLUCIONES

1. **Error de conexión a BD:**
   - Verificar que SQL Server esté ejecutándose
   - Ajustar la cadena de conexión en web.config

2. **Error de compilación:**
   - Verificar que todas las referencias estén correctas
   - Limpiar y recompilar la solución

3. **Error 404 en vistas:**
   - Verificar que las carpetas de vistas estén creadas correctamente
   - Compilar nuevamente el proyecto

### 📝 RUTAS DE ACCESO
- **Listado:** `/Herramienta` o `/Herramienta/Index`
- **Agregar:** `/Herramienta/Agregar`
- **Editar:** `/Herramienta/Editar/[ID]`

### ✅ CRITERIOS DE EVALUACIÓN CUMPLIDOS
Todos los puntos del examen han sido implementados según las especificaciones:
- ✅ Procedimientos almacenados (4 pts)
- ✅ Capa de Entidades (2 pts)
- ✅ Capa DAO - Conexión (2 pts)
- ✅ Capa DAO - CategoriaDAO (2 pts)
- ✅ Capa DAO - HerramientaDAO (4 pts)
- ✅ Referencias en MVC (1 pt)
- ✅ ActionResult Index (1 pt)
- ✅ ActionResult Editar (2 pts)
- ✅ ActionResult Create (2 pts)

**TOTAL: 20 puntos**