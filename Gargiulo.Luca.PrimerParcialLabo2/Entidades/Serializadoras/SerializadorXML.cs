using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades.Serializadoras
{
    public class SerializadorXML<T> : Serializador//,ISerializable<T> where T : Golosina, new()
    {                                               // con la interfaz no puedo hacerlos staticos a los metodos, ver como hacer que funcione con interfaz
        #region Atributos

        #endregion


        #region Propiedades

        #endregion


        #region Constructores

        public SerializadorXML(string path) : base(path)
        {

        }

        #endregion

        #region Metodos

        public static List<T> Deserializar(string path) 
        {
            var lista = new List<T>();

            using (var streamReader = new StreamReader(path))
            {
                if (streamReader != null)
                {
                    var xml = new XmlSerializer(typeof(List<T>), new[] { typeof(Chocolate), typeof(Chicle), typeof(Chupetin) });

                    var listaDeserializada = xml.Deserialize(streamReader);

                    if (listaDeserializada != null)
                    {
                        lista = (List<T>)listaDeserializada;
                    }
                }
            }
            return lista;
        }

        public static bool Serializar(List<T> datos, string path)
        {
            using (var streamWriter = new StreamWriter(path))
            {
                if (streamWriter != null)
                {                                                       //indicando de manera específica qué tipos están permitidos en la lista genérica que estás serializando. Esto asegura que solo los tipos indicados serán considerados durante la serialización y deserialización.
                    var xmlSer = new XmlSerializer(typeof(List<T>), new[] { typeof(Chocolate), typeof(Chicle), typeof(Chupetin) }); // esto me va a servir para serializar cualquier cosa
                                                                     //en este caso cualquier lista
                    xmlSer.Serialize(streamWriter, datos);
                }
            }
            return true;
        }



        #endregion


    }
}
