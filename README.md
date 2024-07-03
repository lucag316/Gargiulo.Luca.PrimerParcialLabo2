# Gargiulo.Luca.PrimerParcialLabo2

# Laboratorio 2  Segundo Parcial

# KioscoApp - Gestion de Golosinas

## Alumno: Gargiulo Luca
Me llamo Luca Franco Gargiulo Nicola, tengo 20 años, vivo en Lanus, Buenos Aires. Estoy cursando la carrera tecnico en Programacion en la Universidad Tecnologica Nacional de Avellaneda. Este proyecto fue creado por mi persona, es mi entrega del primer parcial de Laboratorio II. Implememte lo mejor que pude todos los conocimientos que adquiri hasta el momento por esta materia y por Programacion II.

## Resumen
La aplicacion KioscoApp esta diseñada para administrar un kiosco de golosinas. Permite al usuario que inicio sesion, agregar, modificar, eliminar, ordenar golosinas de distintos tipos (chocolates, chicles, chupetines). Ademas, tiene funcionalidades para cargar y guardar datos de golosinas en archivos XML y JSON.

### Log In
Es un formulario diseñado para la autenticacion de usuarios mediante un sistema de login. Permite cargar una lista de usuarios desde un archivo JSON al inicializarse, validar las credenciales ingresadas por el usuario (correo electronico y clave), registrar accesos exitosos utilizando un archivo de registro, y abrir un formulario principal (FrmMenuPrincipal) si las credenciales son validas. Ademas, incluye manejo de eventos para confirmar la salida del programa, garantizando una terminacion adecuada de la aplicacian.

### Menu Principal
- Al iniciar sesion corectamente, se muestra el formulario principal donde se puede ver el nombre del operador y la fecha actual.
### 1. Administracion de Golosinas
- **Agregar Golosinas:**
  - Permite agregar chocolates, chicles y chupetines al kiosco mediante formularios especificos.
  
- **Modificar Golosinas:**
  - Permite modificar las golosinas existentes seleccionando y editando desde un ListBox.

- **Eliminar Golosinas:**
  - Permite eliminar golosinas seleccionadas del kiosco despues de una confirmacion del usuario.

### 2. Ordenamiento de Golosinas
- **Ordenar por Criterios:**
  - Permite ordenar las golosinas en el kiosco segun diferentes criterios seleccionados desde un ComboBox, tanto de forma ascendente como descendente.

### 3. Gestion de Archivos
- **Guardar y Cargar Datos:**
  - Proporciona funcionalidades para guardar y cargar datos de golosinas en archivos XML, utilizando la clase SerializadorXML.

### 4. Administracion del Formulario
- **Configuracion de Formulario:**
  - Configura el formulario principal como contenedor MDI para una gestion mas eficiente de multiples formularios.

- **Cierre del Formulario:**
  - Muestra un mensaje de confirmacion al usuario antes de cerrar el formulario principal para evitar perdida de datos.

### 5. Informacion y Detalles del Kiosco
- **Mostrar Detalles del Kiosco:**
  - Muestra en un formulario los detalles del kiosco, incluyendo informacion sobre los descuentos aplicables a las golosinas.

### 6. Gestion de Usuarios Logueados
- **Visualizacion de Usuarios Logueados:**
  - Abre un formulario que muestra un registro de los usuarios que estan actualmente logueados en la aplicacion.

### 7. Retroceso
- **Volver al Formulario de Login:**
  - Permite al usuario regresar al formulario de login, con confirmación previa.

### 8. Utilizacion de Eventos
- **Eventos:**
  -  En la aplicacion se utilizan varios eventos para notificar y manejar diferentes situaciones, por ej:CapacidadMaximaAlcanzada, ProductoYaEstaEnLista, ProductoAgregadoExitosamente, etc.

### 8. Gestion Base de Datos
- **Guardar y Cargar Datos:**
   - La aplicación interactua con una base de datos SQL Server para persistir los datos de las golosinas. Las operaciones principales incluyen:
        - GuardarGolosinasEnBaseDeDatos: Metodo que guarda las golosinas en la base de datos de manera asincrona, utilizando un hilo separado para no bloquear la interfaz de usuario.
        - CargarGolosinasDesdeBaseDeDatos: Metodo que carga las golosinas desde la base de datos de manera asincrona, utilizando un hilo separado para no bloquear la interfaz de usuario.
        - GuardarGolosinas: Funcion que realiza el proceso de guardar golosinas en la base de datos, maneja posibles excepciones y notifica el resultado mediante eventos.
        - CargarGolosinas: Funcion que carga golosinas desde la base de datos, actualiza la interfaz y maneja errores usando eventos.

### 8. Utilizacion de Delegados e Hilos
- **Delegados:**
   - Se utilizan para manejar los eventos y asegurar que las operaciones se ejecuten en el hilo correcto para interactuar con la interfaz de usuario de manera segura.
- **Hilos:**
   - Se implementan para tareas como la actualizacion continua del reloj en la interfaz (AsignarHora) y para ejecutar operaciones de guardado y carga en segundo plano, manteniendo la responsividad de la aplicacion.


# SQl:
### clase AccesoDatos:
La clase AccesoDatos facilita la interaccion con una base de datos SQL Server para operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre objetos Golosina. Utiliza la biblioteca Microsoft.Data.SqlClient para la conexion y ejecucion de comandos SQL.

- ProbarConexion: Verifica si es posible establecer una conexion con la base de datos.
- ObtenerListaGolosinas: Recupera una lista de golosinas almacenadas en la base de datos y las convierte en objetos Golosina.
- AgregarGolosina: Inserta una nueva golosina en la base de datos, adaptándose dinsmicamente al tipo de golosina especifica (Chocolate, Chicle, Chupetin).
- ModificarGolosina: Actualiza los datos de una golosina existente en la base de datos.
- EliminarGolosina: Elimina una golosina de la base de datos segun su codigo.
- CrearGolosinaDesdeDataReader: Construye un objeto Golosina a partir de los datos obtenidos de un lector de datos.
- BorrarTodasLasGolosinas: Elimina todas las golosinas de la base de datos.
La clase esta diseñada para manejar varios tipos de golosinas y garantizar la conexion segura y la ejecucion de consultas SQL, manejando excepciones y asegurando la correcta apertura y cierre de la conexion.

# Entidades:

## Jerarquia y Contenedora:

### clase Golosina
Representa una golosina generica con propiedades para codigo, precio, peso y cantidad. Permite la serialización XML y estáA diseñada para ser la base de clases concretas como Chocolate, Chicle y Chupetin. Incluye validaciones con excepciones para el codigo (numerico, no negativo y no mayor a 1000) y metodos para mostrar detalles, calcular precios finales y comparar golosinas.

### clase Chocolate
Representa un tipo especifico de golosina, que incluye atributos como relleno, tipo de cacao y si es vegano. Tiene varios constructores para inicializar estas propiedades de diferentes maneras. Sobrescribe metodos de la clase base Golosina y define sus propios metodos, como ToString para mostrar informacion detallada, Equals para comparar si dos chocolates son iguales, y CalcularPrecioFinal para calcular el precio final con descuento si se compran mas de tres. También implementa la interfaz IDescuentoCalculable para aplicar descuentos. Ademas, sobrecarga los operadores de igualdad == y != para comparar dos instancias de Chocolate.

### clase Chicle
representa una golosina del tipo especifico chicle, heredando de la clase base Golosina y implementando la interfaz IDescuentoCalculable. Define atributos especificos del chicle como elasticidad, duracion del sabor, y si contiene blanqueador dental. Proporciona propiedades para acceder y modificar estos atributos, así como multiples constructores para inicializarlos. La clase sobrescribe metodos de Object como ToString, Equals, y GetHashCode, y tambien define metodos especificos para calcular descuentos y mostrar informacion en un visor. Adicionalmente, la clase implementa sobrecargas de operadores de igualdad para comparar instancias de chicles.

### clase Chupetin
Representa un tipo especifico de golosina, un chupetin. Tiene atributos que definen su forma, dureza y si tiene envoltura transparente. Además de los metodos y propiedades basicos heredados de la clase base Golosina, la clase Chupetin incluye constructores para inicializar estos atributos y metodos para mostrar su información, calcular su precio final, y comparar si dos chupetines son iguales.

![Diagrama de Clases Jerarquia](Gargiulo.Luca.PrimerParcialLabo2/DiagramaJerarquia.png)

### Clase Kiosco
Es una implementacion generica que representa un kiosco capaz de almacenar una variedad de productos. Utiliza una lista interna para mantener los productos y ofrece metodos y operadores para agregar, eliminar y visualizar estos productos. Con eventos estaticos, notifica sobre eventos como alcanzar la capacidad maxima del kiosco, agregar o eliminar exitosamente productos, y permite la personalizacion del ordenamiento de productos basado en criterios especificos. Ademas, la clase sobrecarga operadores para facilitar la gestion de productos, y proporciona metodos para calcular el precio total de los productos almacenados y para convertir el kiosco en una lista o una cadena de texto segun sea necesario. Esta estructura ofrece flexibilidad y funcionalidad robusta para la gestion eficiente de inventarios en un entorno de kiosco. Tiene una restriccion que es que los productos que se manejan deben tener implementada la interfaz IProductoDeUnKiosco.

## Serializadoras:

### clase Serializador
Es una clase abstracta que proporciona una base comun para la serializacion y deserializacion de archivos, manejando la ruta del archivo donde se realizaran estas operaciones. Permite establecer y obtener la ruta del archivo, asegurando que la ruta sea absoluta y creando automaticamente el directorio necesario si no existe.

### clase SerializadorXML
 Maneja la serializacion y deserializacion de objetos genericos en formato XML, con soporte especifico para los tipos Chocolate, Chicle y Chupetin. Hereda de la clase Serializador para gestionar las rutas de los archivos de manera flexible, permitiendo usar rutas absolutas o relativas. Implementa metodos estaticos para serializar y deserializar listas de objetos, manejando excepciones para asegurar la robustez del proceso.

### clase SerializadorJSON
Maneja la deserializacion de un Json de usuarios. El metodo DeserializarUsuariosJSON especificamente deserializa un archivo JSON que contiene datos de usuarios y los convierte en una lista de objetos Usuario. Utiliza las clases de System.Text.Json para leer el contenido del archivo y convertirlo de JSON a objetos Usuario.

### clase Usuario
La clase Usuario representa un usuario con sus datos basicos. Incluye propiedades para el apellido, nombre, numero de legajo, correo electronico, clave y perfil.

### clase UsuarioLog
Esta clase gestiona un registro de accesos de usuarios en un archivo de registro especifico. Permite la verificacion y creacion del archivo si no existe, registra detalles de acceso de usuarios y facilita la lectura completa del contenido del registro.

# Formularios:

## Jerarquia:

### FrmGolosina
Es un formulario diseñado para capturar y validar información de golosinas, incluyendo codigo, precio, peso y cantidad. Utiliza eventos como btnAceptar_Click para validar los datos ingresados por el usuario y mostrar mensajes de error especificos mediante excepciones personalizadas (ExcepcionDatoNoNumerico, ExcepcionNumeroNegativo, ExcepcionNumeroMuyAlto). Ademas, ofrece la opcion de cancelar la operacion con el boton btnCancelar_Click, proporcionando una experiencia interactiva y segura al usuario al manejar adecuadamente las entradas numericas y el flujo de cancelacion.

### FrmChocolate
Es un formulario diseñado para ingresar y editar informacion especifica de chocolates. Hereda funcionalidades del formulario base FrmGolosina, permitiendo configurar y mostrar detalles como el codigo, peso, precio, cantidad, relleno, tipo de cacao y opcion vegana de un objeto Chocolate. Ademas, ofrece metodos para inicializar y configurar controles como ComboBoxes con valores especificos de enumeraciones relacionadas con caracteristicas del chocolate, asegurando una interfaz de usuario coherente y funcional para la gestion de datos de chocolates.

### FrmChicle
Es un formulario diseñado para ingresar y editar informacion especifica de chicles. Hereda funcionalidades del formulario base FrmGolosina, permitiendo configurar y mostrar detalles como el codigo, peso, precio, cantidad, elasticidad, duracion del sabor y opcion blanqueador dental de un objeto Chicle. Ademas, ofrece metodos para inicializar y configurar controles como ComboBoxes con valores especificos de enumeraciones relacionadas con caracteristicas del chicle, asegurando una interfaz de usuario coherente y funcional para la gestion de datos de chicles.

### FrmChupetin
Es un formulario diseñado para ingresar y editar informacion especifica de chupetines. Hereda funcionalidades del formulario base FrmGolosina, permitiendo configurar y mostrar detalles como el codigo, peso, precio, cantidad, forma, dureza y opcion de envoltura transparente de un objeto Chupetin. Ademas, ofrece metodos para inicializar y configurar controles como ComboBoxes con valores especificos de enumeraciones relacionadas con caracteristicas del chupetin, asegurando una interfaz de usuario coherente y funcional para la gestion de datos de chupetines.

## Otros Formularios:

### FrmVisualizadorUsuariosLog
Esta clase tiene como objetivo mostrar el contenido de un archivo de registro de usuarios en un ListBox. Al recibir la ruta del archivo de registro en su constructor, inicializa una instancia de UsuarioLog para manejar las operaciones de lectura del archivo. El metodo MostrarLog() lee el contenido del archivo, lo divide por lineas utilizando Environment.NewLine como separador, y luego agrega cada linea al ListBox lstVisualizadorUsuariosLog para visualizacion en la interfaz grafica. Esta clase proporciona una manera eficiente y clara de visualizar registros de acceso de usuarios almacenados en archivos.

### FrmDetalleKiosco
Es un formulario diseñado para mostrar el detalle del kiosco de golosinas. Incluye un metodo publico MostrarDetalleEnVisor que toma una cadena de detalle y la muestra en un ListBox (lstVisorDetalleKiosco), separando cada linea para una presentacion clara y ordenada del contenido del kiosco.

# Diagrama de Clases con todo:
![Diagrama de Clases](Gargiulo.Luca.PrimerParcialLabo2/ClassDiagram1.png)

# Script: