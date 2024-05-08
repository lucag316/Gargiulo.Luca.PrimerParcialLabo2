using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Barco
    {
        #region Atributos
        public int numeroDeCubiertas;
        public string tipoDeCasco;
        #endregion

        #region Propiedades
        #endregion

        #region Constructor
        public Barco()
        {

        }
        public Barco(int numeroDeCubiertas)
        {
            this.numeroDeCubiertas = numeroDeCubiertas;
        }
        public Barco(int numeroDeCubiertas, string tipoDeCasco) : this(numeroDeCubiertas)
        {
            this.tipoDeCasco = tipoDeCasco;
        }
        #endregion

        #region Metodos
        public string MostrarBarco()
        {
            return $" {this.numeroDeCubiertas} cubiertas - Tipo de casco: {this.tipoDeCasco}";
        }
        #endregion

        #region Sobrecargas
        #endregion



    }
}
