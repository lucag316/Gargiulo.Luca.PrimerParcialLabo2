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
        protected Rellenos relleno;
        protected TiposDeCacao tipoDeCacao;
        #endregion

        #region Propiedades
        #endregion

        #region Constructor
        public Chocolate(int codigo, double precio, double cantidad) : base(codigo, precio, cantidad)
        {
            this.relleno = Rellenos.SinRelleno; 
            this.tipoDeCacao = TiposDeCacao.Negro;
            //como no los completa, lo pongo por defecto, creo que esta bien
        }
        public Chocolate(int codigo, double precio, double cantidad, Rellenos relleno): this(codigo, precio, cantidad)
        {
            this.relleno = relleno;
            this.tipoDeCacao = TiposDeCacao.Negro; // no se bien si hay que agregarla
        }
        public Chocolate(int codigo, double precio, double cantidad, Rellenos relleno, TiposDeCacao tipoDeCacao) : this(codigo, precio, cantidad, relleno)
        {
            this.tipoDeCacao = tipoDeCacao;

        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("=============== CHOCOLATE ===============");
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Relleno: {this.relleno}");
            sb.AppendLine($"Tipo de cacao: {this.tipoDeCacao}");
            sb.AppendLine("=========================================\n");

            return sb.ToString();
        }
        public override string MostrarEnVisor()
        {
            string mensaje = $"Relleno: {this.relleno} - Tipo de cacao: {this.tipoDeCacao}";
            //fijarme si poner todo o no, para no repetir codigo
            return mensaje;
        }

        #endregion

        #region Sobrecargas
        #endregion
    }
}
