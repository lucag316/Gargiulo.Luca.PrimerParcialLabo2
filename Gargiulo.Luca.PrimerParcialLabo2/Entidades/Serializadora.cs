using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Entidades
{
    /// <summary>
    /// Clase para serializar y deserializar objetos.
    /// </summary>
    public class Serializadora
    {
        private string path;
        public List<Golosina> listaGolosinas;

        public string Path { get { return this.path; } }

        public Serializadora(string pathArchivo)
        {
            if (System.IO.Path.IsPathRooted(pathArchivo))
            {
                
                this.path = pathArchivo; // Si la ruta es absoluta, la uso directamente
            }
            else
            {
                // Si la ruta es relativa, la concateno con el directorio predeterminado
                this.path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "GolosinasSerializadas", pathArchivo);
            }

            string directory = System.IO.Path.GetDirectoryName(this.path);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
        public Serializadora(string path, List<Golosina> listaGolosinas) : this(path)
        {
            this.listaGolosinas = listaGolosinas;
        }

        public static List<Usuario> DeserializarUsuariosJSON(string pathArchivo)
        {
            List<Usuario> listaAux = new List<Usuario>();

            using (StreamReader streamReader = new StreamReader(pathArchivo))
            {
                string jsonUsuarios = streamReader.ReadToEnd();

                listaAux = JsonSerializer.Deserialize<List<Usuario>>(jsonUsuarios);
            }
            return listaAux;
        }

        public void SerializarGolosinasJSON(List<Golosina> golosinas)
        {
            JsonSerializerOptions opciones = new JsonSerializerOptions();
            opciones.WriteIndented = true;  //le doy true para que se vea mejor

            using (StreamWriter streamWriter = new StreamWriter( this.Path)) //instancio un SW que me va a escribir el archivo
            {
                string objJon = JsonSerializer.Serialize((object[])golosinas.ToArray(), opciones); //lo que voy a serializar y el identado opcional

                streamWriter.WriteLine(objJon); //aca lo escribo
            }
        }
        public void SerializarGolosinasXML(List<Golosina> golosinas)
        {
            using (XmlTextWriter xmlWriter = new XmlTextWriter(this.Path, Encoding.UTF8)) //no hacia falta agregar + .xml//primero lo instancio
            {
                XmlSerializer serXml = new XmlSerializer(typeof(List<Golosina>)); //lo serializo

                serXml.Serialize(xmlWriter, golosinas);//me pide un xmlWrite, y despues lo que yo quiero serializar
            }
        }

        public List<Golosina> DeserializarGolosinasJSON()
        {
            //this.listaGolosinas = new List<Golosina>();  //creo una lista vacia auxiliar donde guardo a las golosinas que se deserialicen

            //using (StreamReader streamReader = new StreamReader(this.path))
            //{
            //    string jsonGolosinas = streamReader.ReadToEnd(); //leo todo completo hasta el final

            //    this.listaGolosinas = JsonSerializer.Deserialize<List<Golosina>>(jsonGolosinas);  //recien aca deserializo
            //}
            //return this.listaGolosinas;
            this.listaGolosinas = new List<Golosina>();

            using (StreamReader streamReader = new StreamReader(this.path))
            {
                string jsonGolosinas = streamReader.ReadToEnd();

                // Aquí es donde se realiza la deserialización a un array de objetos Golosina
                Golosina[] golosinasArray = JsonSerializer.Deserialize<Golosina[]>(jsonGolosinas);

                // Convierte el array a una lista de Golosina
                this.listaGolosinas = golosinasArray.ToList();
            }

            return this.listaGolosinas;
        }

        public List<Golosina> DeserialiazarGolosinasXML()
        {
            this.listaGolosinas = new List<Golosina>();

            using (XmlTextReader xmlReader = new XmlTextReader(this.path))
            {
                XmlSerializer serXml = new XmlSerializer (typeof(List<Golosina>)); //instancio el serializer

                this.listaGolosinas = (List<Golosina>)serXml.Deserialize(xmlReader); //deseralizo el xmltextreader y lo casteo

                return this.listaGolosinas;
            }
        }
    }  
}
