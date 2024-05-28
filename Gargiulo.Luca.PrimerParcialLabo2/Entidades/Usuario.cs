using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        private string _apellido;
        private string _nombre;
        private int _legajo;
        private string _correo;
        private string _clave;
        private string _perfil;

        public string apellido
        {
            get { return this._apellido; }
            set { this._apellido = value; }
        }
        public string nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; }
        }
        public int legajo
        {
            get { return this._legajo; }
            set { this._legajo = value; }
        }
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
        public string perfil
        {
            get { return this._perfil; }
            set { this._perfil = value; }
        }

    }
}
