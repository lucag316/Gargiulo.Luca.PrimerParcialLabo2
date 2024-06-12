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
            this.path = path;
        }

        #endregion


    }
}
