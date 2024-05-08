using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Auto
    {
        #region Atributos
        public int numeroDePuertas;
        public string transmision; //automatico/manual
        #endregion

        #region Propiedades
        #endregion

        #region Constructor
        public Auto()
        {

        }
        public Auto(int numeroDePuertas)
        {
            this.numeroDePuertas = numeroDePuertas;
            
        }
        public Auto(int numeroDePuertas, string transmision):this(numeroDePuertas)
        {
            this.transmision = transmision;

        }
        #endregion

        #region Metodos
        public string MostrarAuto()
        {
            return $" {this.numeroDePuertas} puertas - Transmision: {this.transmision}";
        }
        #endregion

        #region Sobrecargas
        #endregion


    }
}
