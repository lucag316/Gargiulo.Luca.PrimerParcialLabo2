using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Entidades.Serializadoras
{
    public class SerializadorJSON<T> : Serializador//, ISerializable<T> where T : new()
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

        public static List<T> Deserializar(string path)
        {
            /*var lista = new List<T>();

            try
            {
                string jsonString;

                using (var streamReader = new StreamReader(path))
                {
                    jsonString = streamReader.ReadToEnd();
                }

                if (!string.IsNullOrEmpty(jsonString))
                {
                    lista = JsonSerializer.Deserialize<List<T>>(jsonString, new JsonSerializerOptions
                    {
                        Converters = { new GolosinaConverter() },
                        PropertyNameCaseInsensitive = true
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al deserializar desde JSON: {ex.Message}");
            }

            return lista;*/
            
            var lista = new List<T>();

            using (var streamReader = new StreamReader(path))
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

        public static bool Serializar(List<T> datos, string path)
        {
            using (var streamWriter = new StreamWriter(path)) // seria mejor base.Path
            {

                if (streamWriter != null)
                {
                    var opciones = new JsonSerializerOptions();
                    opciones.WriteIndented = true;

                    var jsonString = JsonSerializer.Serialize(datos, opciones);

                    streamWriter.WriteLine(jsonString); //no se si write o writeLine
                }
            }
            return true;
        }

        #endregion

    }
}
