using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        private string _correo;
        private string _clave;

        public string apellido { get; set; }
        public string nombre { get; set; }
        public int legajo { get; set; }
        public string correo
        {
            get { return this._correo; }
            set { this._correo = value; }
        }
        
        public string clave
        {
            get { return this._clave; }
            set { this._clave = value;}
        }
        public string perfil { get; set; }

    }
}
