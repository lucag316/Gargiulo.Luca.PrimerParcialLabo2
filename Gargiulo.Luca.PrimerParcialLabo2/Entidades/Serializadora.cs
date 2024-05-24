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
    public class Serializadora
    {
        private string path;

        public  string Path { get { return this.path; } }

        public Serializadora(string path)
        {
            this.path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);//me develve el path de la carpeta
            this.path += "/GolosinasSerializadas";

            if (!Directory.Exists(this.path))
            {
                Directory.CreateDirectory(this.path);
            }

            this.path += "/" + path;
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

            using (StreamWriter streamWriter = new StreamWriter( this.Path + ".json")) //instancio un SW que me va a escribir el archivo
            {

                string objJon = JsonSerializer.Serialize(golosinas, opciones); //lo que voy a serializar y el identado opcional

                streamWriter.WriteLine(objJon); //aca lo escribo
            }
        }
        public void SerializarGolosinasXML(List<Golosina> golosinas)
        {
            using (XmlTextWriter xmlWriter = new XmlTextWriter(this.Path + ".xml", Encoding.UTF8)) //primero lo instancio
            {
                XmlSerializer serXml = new XmlSerializer(typeof(List<Golosina>)); //lo serializo

                serXml.Serialize(xmlWriter, golosinas);//me pide un xmlWrite, y despues lo que yo quiero serializar
            }
        }

        public static List<Golosina> DeserializarGolosinasJSON(string pathArchivo)
        {
            List<Golosina> listaAux = new List<Golosina>();  //creo una lista vacia auxiliar donde guardo a las golosinas que se deserialicen

            using (StreamReader streamReader = new StreamReader(pathArchivo))
            {
                string jsonGolosinas = streamReader.ReadToEnd(); //leo todo completo hasta el final

                listaAux = JsonSerializer.Deserialize<List<Golosina>>(jsonGolosinas);  //recien aca deserializo
            }
            return listaAux;
        }

        public static List<Golosina> DeserialiazrGolosinasXML(string pathArchivo)
        {
            List<Golosina> auxGolosinas = new List<Golosina>();  //instancio una lista de golosinas vacia

            using (XmlTextReader xmlReader = new XmlTextReader(pathArchivo))
            {
                XmlSerializer serXml = new XmlSerializer (typeof(List<Golosina>)); //instancio el serializer

                auxGolosinas = (List<Golosina>)serXml.Deserialize(xmlReader); //deseralizo el xmltextreader y lo casteo

                return auxGolosinas;
            }
        }
    }  
}
