using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Serializadoras
{
    public abstract class Serializador
    {
        #region Atributos
        //simplemente lo hago para no volver a escribir lo del path en las derivadas
        private string path;

        #endregion

        #region Propiedades
        public string Path
        {
            get { return this.path; }
            set { this.path = value; }
        }

        #endregion

        #region Constructores
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

            string directory = System.IO.Path.GetDirectoryName(this.path);

            if (!Directory.Exists(directory) && directory != null)
            {
                Directory.CreateDirectory(directory);
            }
        }

        #endregion

        //si ya tengo interfaz creo que no va
        #region Métodos abstractos
        //public abstract bool Serializar<T>(List<T> datos);
        //public abstract List<T> Deserializar<T>();
        #endregion
    }
}
