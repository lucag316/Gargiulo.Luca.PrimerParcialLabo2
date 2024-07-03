using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Entidades.OtrasClases;

namespace Entidades.Serializadoras
{
    /// <summary>
    /// Clase para la serializacion y deserializacion de objetos en formato JSON.
    /// </summary>
    //// <typeparam name="T">El tipo de objetos a serializar/deserializar.</typeparam>
    public class SerializadorJSON<T> : Serializador
    {

        #region Constructores
        /// <summary>
        /// Constructor que inicializa la ruta del archivo de serializacion.
        /// </summary>
        //// <param name="path">Ruta del archivo. Puede ser una ruta absoluta o relativa.</param>
        public SerializadorJSON(string path) : base(path)
        {

        }

        #endregion

        #region Metodos

        public static List<Usuario> DeserializarUsuariosJSON(string pathArchivo)
        {
            List<Usuario> listaAux = new List<Usuario>();

            using (StreamReader streamReader = new StreamReader(pathArchivo))
            {
                if (streamReader != null)
                {
                    string jsonUsuarios = streamReader.ReadToEnd();

                    listaAux = JsonSerializer.Deserialize<List<Usuario>>(jsonUsuarios);
                }
            }
            return listaAux;
        }

        #endregion
    }
}














/*
/// <summary>
/// Serializa una lista de objetos en formato JSON.
/// </summary>
//// <param name="datos">La lista de objetos a serializar.</param>
//// <param name="path">La ruta del archivo donde se guardara la serializacion.</param>
/// <returns>True si la serializacion se realizo con exito.</returns>
public static bool Serializar(List<T> datos, string path)
{
    try
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
    catch (Exception ex)
    {
        Console.WriteLine($"Error al serializar: {ex.Message}"); //intentar hacer algo para usar messsageBox
        return false;
    }
}

public static List<T> Deserializar(string path)
{
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
*/




