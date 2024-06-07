# Gargiulo.Luca.PrimerParcialLabo2

# Laboratorio 2  Segundo Parcial

# KioscoApp - Gestion de Golosinas

## Alumno: Gargiulo Luca
Me llamo Luca Franco Gargiulo Nicola, tengo 20 años, vivo en Lanus, Buenos Aires. Estoy cursando la carrera tecnico en Programacion en la Universidad Tecnologica Nacional de Avellaneda. Este proyecto fue creado por mi persona, es mi entrega del primer parcial de Laboratorio II. Implememte lo mejor que pude todos los conocimientos que adquiri hasta el momento por esta materia y por Programacion II.

## Resumen
La aplicacion KioscoApp esta diseñada para administrar un kiosco de golosinas. Permite al usuario que inicio sesion, agregar, modificar, eliminar, ordenar golosinas de distintos tipos (chocolates, chicles, chupetines). Ademas, tiene funcionalidades para cargar y guardar datos de golosinas en archivos XML y JSON.

### Log In
Ingreso de usuarios, pide el correo y su clave, los verifica con el uso de un archivo JSON que contiene los usuarios autorizados

### Menu Principal
- Al iniciar sesion corectamente, se muestra el formulario principal donde se puede ver el nombre del operador y la fecha actual.
- se pueden agregar golosinas de diferentes tipos: chocolate, chicle o chupetin. Se abrira un formulario correspondiente a cada tipo de golosina para ingresar los detalles.
- Una vez agregadas las golosinas, se mostraran en una lista en el formulario principal.
- Se pueden modificar y eliminar golosinas seleccionandolas de la lista y utilizando las opciones correspondientes en el menu.
- Tambien se puede ordenar la lista de golosinas por codigo o peso, de forma ascendente o descendente, desde las opciones del menu.
- La aplicacion permite cargar y guardar datos de golosinas en archivos XML o JSON desde el menu correspondiente.

### FrmVisualizadorUsuariosLog
En el menu se puede clickear una opcion del menuStrip para visualizar el registro de usuarios en un Listbox.  Carga el contenido del archivo de registros de usuarios y lo muestra en una lista.

## Entidades:

### Clase Kiosco
Es la clase responsable de almacenar y gestionar la Lista de Golosinas(esa lista puede tener 3 tipos de Golosina, chocolates, chicles o chupetines). Sus atributos incluyen la lista de golosinas disponibles y la capacidad maxima de distintos tipos de golosinas. Proporciona metodos para mostrar y calcular detalles de las golosinas, asi como para ordenarlas de distintas maneras. Ademas ofrece operadores para agregar y elimar golosinas, verificar su presencia en el kiosco y conversiones implicitas y explicitas.

### clase Golosina
Es una clase abstracta que representa una golosina generica. Contiene atributos como codigo, precio, peso y cantidad, tambien tiene propiedades para acceder y modifiar sus valores.
Tiene distintos constructores para inicializar sus atributos y metodos para sobreacrgar operadores, calcular el precio final y mostrar los detalles de la golosina.
Esta clase es serializable en formatos XML y JSON.

### clase Chocolate
Esta clase representa un tipo especifico de golosina. Hereda de la clase base Golosina y agrega atributos y comportamientos especificos para los chocolates

### clase Chicle
Esta clase representa un tipo especifico de golosina. Hereda de la clase base Golosina y agrega atributos y comportamientos especificos para los chicles

### clase Chupetin
Esta clase representa un tipo especifico de golosina. Hereda de la clase base Golosina y agrega atributos y comportamientos especificos para los chupetines

## Formularios:

### FrmGolosina
Es un formulario que proporciona una base solida para formularios de golosinas mas especificas, para el ingreso de datos, facilitando la validacion y permitiendo la personalizacion mediante herencia. Esta clase, es Padre de FrmChocolate, FrmChicle y FrmChupetin.

### FrmChocolate

### FrmChicle

### FrmChupetin

### Diagrama de Clases
![Diagrama de Clases](Gargiulo.Luca.PrimerParcialLabo2/ClassDiagram1.png)
