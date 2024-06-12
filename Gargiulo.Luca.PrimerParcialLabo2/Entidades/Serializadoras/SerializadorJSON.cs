using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades.Serializadoras
{
    public class SerializadorJSON<T> : Serializador, ISerializable<T> where T : new()
    {
        #region Atributos

        #endregion


        #region Propiedades

        #endregion


        #region Constructores

        public SerializadorJSON(string path) : base(path)
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
                    var jsonString = streamReader.ReadToEnd();

                    var listaDeserializada = JsonSerializer.Deserialize<List<T>>(jsonString);

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
            using (var streamWriter = new StreamWriter(Path)) // seria mejor base.Path
            {

                if (streamWriter != null)
                {
                    var opciones = new JsonSerializerOptions();
                    opciones.WriteIndented = true;

                    var jsonString = JsonSerializer.Serialize(datos, opciones);

                    streamWriter.Write(jsonString);
                }
            }
            return true;
        }

        #endregion

    }
}
