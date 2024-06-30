using Entidades.Interfaces;
using Entidades.JerarquiaYContenedora;
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
    /// <summary>
    /// Clase para la serializacion y deserializacion de objetos en formato XML.
    /// </summary>
    //// <typeparam name="T">El tipo de objetos a serializar/deserializar.</typeparam>
    public class SerializadorXML<T> : Serializador//, ISerializable<T> where T : Golosina, new()
    {                                               // con la interfaz no puedo hacerlos staticos a los metodos, ver como hacer que funcione con interfaz

        #region Constructores
        /// <summary>
        /// Constructor que inicializa la ruta del archivo de serializacion.
        /// </summary>
        //// <param name="path">Ruta del archivo. Puede ser una ruta absoluta o relativa.</param>
        public SerializadorXML(string path) : base(path)
        {

        }

        #endregion

        #region Metodos
        /// <summary>
        /// Serializa una lista de objetos en formato XML.
        /// </summary>
        //// <param name="datos">La lista de objetos a serializar.</param>
        //// <param name="path">La ruta del archivo donde se guardara la serializacion.</param>
        /// <returns>True si la serializacion se realizo con exito.</returns>

        public static bool Serializar(List<T> datos, string path)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error al serializar: {ex.Message}"); //intentar hacer algo para usar messsageBox
                return false;
            }
        }

        /// <summary>
        /// Deserializa una lista de objetos desde un archivo XML.
        /// </summary>
        //// <param name="path">La ruta del archivo XML.</param>
        /// <returns>Una lista de objetos deserializados.</returns>
        public static List<T> Deserializar(string path) 
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error al deserializar: {ex.Message}"); // fijarme lo mismo
                return new List<T>();
            }
        }
        #endregion
    }
}
