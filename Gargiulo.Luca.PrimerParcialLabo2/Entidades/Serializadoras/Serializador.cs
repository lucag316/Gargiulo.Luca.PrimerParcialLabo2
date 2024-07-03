using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Serializadoras
{
    /// <summary>
    /// Clase abstracta base para serializacion, proporciona una funcionalidad comun para manejar rutas de archivos.
    /// </summary>
    public abstract class Serializador
    {
        #region Atributos
        /// <summary>
        /// Ruta del archivo donde se realizaran las operaciones de serializacion/deserializacion.
        /// </summary>
        private string path;
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene o establece la ruta del archivo de serializacion.
        /// </summary>
        public string Path
        {
            get { return this.path; }
            set { this.path = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor que inicializa la ruta del archivo de serializacion.
        /// </summary>
        //// <param name="path">Ruta del archivo. Puede ser una ruta absoluta o relativa.</param>
        public Serializador(string path)
        {
            if (System.IO.Path.IsPathRooted(path))
            {
                this.path = path; // Si la ruta es absoluta, la uso directamente
            }
            else
            {
                // Si la ruta es relativa, la concateno con el directorio predeterminado
                this.path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "GolosinasSerializadas", path);
            }

            string directory = System.IO.Path.GetDirectoryName(this.path) ?? String.Empty; // le doy un valor predeterminado si es null


            if (!Directory.Exists(directory) && directory != null) //si el directorio no existe, lo creo
            {
                Directory.CreateDirectory(directory);
            }
        }

        #endregion

    }
}
