using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace Entidades
{
    public class Serializadora
    {


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

        public static void SerializarGolosinasJSON(List<Golosina> golosinas, string pathArchivo)
        {
            JsonSerializerOptions opciones = new JsonSerializerOptions();
            opciones.WriteIndented = true;  //le doy true para que se vea mejor

            using (StreamWriter streamWriter = new StreamWriter(pathArchivo + ".json")) //instancio un SW que me va a escribir el archivo
            {
                string objJon = JsonSerializer.Serialize(golosinas, opciones); //lo que voy a serializar y el identado opcional

                streamWriter.WriteLine(objJon); //aca lo escribo
            }
        }
        public static void SerializarGolosinasXML(List<Golosina> golosinas, string pathArchivo)
        {
            using (XmlTextWriter xmlWriter = new XmlTextWriter(pathArchivo + ".xml", Encoding.UTF8)) //primero lo instancio
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
