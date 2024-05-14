using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Chupetin
    {
        #region Atributos
        public string tipoDePalo;
        public string dureza;
        #endregion

        #region Propiedades
        #endregion

        #region Constructor
        public Chupetin()
        {

        }
        public Chupetin(string tipoDePalo)
        {
            this.tipoDePalo = tipoDePalo;
        }
        public Chupetin(string tipoDePalo, string dureza) : this(tipoDePalo)
        {
            this.dureza = dureza;
        }
        #endregion

        #region Metodos
        public string MostrarBarco()
        {
            return $" Tipo de palo: {this.tipoDePalo} - Dureza: {this.dureza}";
        }
        #endregion

        #region Sobrecargas
        #endregion


    }
}
