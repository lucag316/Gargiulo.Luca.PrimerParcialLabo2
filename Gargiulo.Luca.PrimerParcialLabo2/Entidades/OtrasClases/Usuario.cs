using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.OtrasClases
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
            get { return _apellido; }
            set { _apellido = value; }
        }
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public int legajo
        {
            get { return _legajo; }
            set { _legajo = value; }
        }
        public string correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        public string clave
        {
            get { return _clave; }
            set { _clave = value; }
        }
        public string perfil
        {
            get { return _perfil; }
            set { _perfil = value; }
        }

    }
}
