using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Avion
    {

        #region Atributos
        public int altitudMaxima;
        public string tipoDeAlas; //flecha, delta, etc, buscar
        #endregion

        #region Propiedades
        #endregion

        #region Constructor
        public Avion()
        {

        }
        public Avion(int altitudMaxima)
        {
            this.altitudMaxima = altitudMaxima;
        }
        public Avion(int altitudMaxima, string tipoDeAlas):this(altitudMaxima)
        {
            this.tipoDeAlas = tipoDeAlas;
        }
        #endregion

        #region Metodos
        public string MostrarAvion()
        {
            return $"{this.altitudMaxima} de altura - Tipo de alas: {this.tipoDeAlas}";
        }
        #endregion

        #region Sobrecargas
        #endregion
    }
}
