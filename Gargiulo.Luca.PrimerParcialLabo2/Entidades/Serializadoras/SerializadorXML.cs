using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades.Serializadoras
{
    public class SerializadorXML<T> : Serializador, ISerializable<T> where T : new() //solo clases con constructor sin parametros
    {
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

        public List<T> Deserializar()
        {
            var lista = new List<T>();

            using (var streamReader = new StreamReader(Path))
            {
                if (streamReader != null)
                {
                    var xml = new XmlSerializer(typeof(List<T>));

                    var listaDeserializada = xml.Deserialize(streamReader);

                    if (listaDeserializada != null)
                    {
                        lista = (List<T>)listaDeserializada;
                    }
                }
            }
            return lista;

        }

        public bool Serializar(List<T> datos)
        {
            using (var streamWriter = new StreamWriter(Path))
            {
                if (streamWriter != null)
                {
                    var xmlSer = new XmlSerializer(typeof(List<T>)); // esto me va a servir para serializar cualquier cosa
                                                                     //en este caso cualquier lista
                    xmlSer.Serialize(streamWriter, datos);
                }
            }
            return true;
        }

        #endregion


    }
}
