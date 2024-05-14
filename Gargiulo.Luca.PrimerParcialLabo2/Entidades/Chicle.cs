using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Chicle
    {
        #region Atributos
        //public int numeroDeCubiertas;
        //public string tipoDeCasco;
        public string elasticidad; //mucha, poca, normal, etc
        public string duracionSabor; 
        #endregion

        #region Propiedades
        #endregion

        #region Constructor
        public Chicle()
        {

        }
        public Chicle(string elasticidad)
        {
            this.elasticidad = elasticidad;
        }
        public Chicle(string elasticidad, string duracionSabor) : this(elasticidad)
        {
            this.duracionSabor = duracionSabor;
        }
        #endregion

        #region Metodos
        public string MostrarBarco()
        {
            return $" Elasticidad: {this.elasticidad}  - Duracion del sabor: {this.duracionSabor}";
        }
        #endregion

        #region Sobrecargas
        #endregion


    }
}
