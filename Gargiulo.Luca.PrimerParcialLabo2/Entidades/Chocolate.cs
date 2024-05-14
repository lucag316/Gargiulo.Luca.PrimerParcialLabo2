using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Chocolate : Golosina
    {
        #region Atributos
        public string relleno; //nuez,mani,almendras, etc
        public string tipoDeCacao; //blanco,negro,con leche,etc
        #endregion

        #region Propiedades
        #endregion

        #region Constructor
        public Chocolate()
        {

        }
        public Chocolate(string relleno)
        {
            this.relleno = relleno;

        }
        public Chocolate(string relleno, string tipoDeCacao) : this(relleno)
        {
            this.tipoDeCacao = tipoDeCacao;

        }
        #endregion

        #region Metodos
        public string MostrarAuto()
        {
            return $" Relleno: {this.relleno} - Tipo de Cacao:: {this.tipoDeCacao}";
        }
        #endregion

        #region Sobrecargas
        #endregion
    }
}
