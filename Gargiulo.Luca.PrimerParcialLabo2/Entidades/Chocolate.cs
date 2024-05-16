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
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"Relleno: {this.relleno}");
            sb.AppendLine($"Tipo de cacao: {this.tipoDeCacao}");

            return sb.ToString();
        }
        #endregion

        #region Sobrecargas
        #endregion
    }
}
