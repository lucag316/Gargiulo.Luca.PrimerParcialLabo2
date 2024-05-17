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
        public Rellenos Relleno { get { return this.relleno; } }
        public TiposDeCacao TipoDeCacao { get { return this.tipoDeCacao; } }
        #endregion

        #region Constructor
        public Chocolate(int codigo, float peso, double precio, int cantidad) : base(codigo, peso, precio, cantidad)
        {
            this.relleno = Rellenos.SinRelleno; 
            this.tipoDeCacao = TiposDeCacao.Negro;
            //como no los completa, lo pongo por defecto, creo que esta bien
        }
        public Chocolate(int codigo, float peso, double precio, int cantidad, Rellenos relleno): this(codigo, peso, precio, cantidad)
        {
            this.relleno = relleno;
            this.tipoDeCacao = TiposDeCacao.Negro; // no se bien si hay que agregarla
        }
        public Chocolate(int codigo, float peso, double precio, int cantidad, Rellenos relleno, TiposDeCacao tipoDeCacao) : this(codigo, peso, precio, cantidad, relleno)
        {
            this.tipoDeCacao = tipoDeCacao;

        }
        #endregion

        #region Metodos Sobrescritos
        public override string ToString()//podria tener un mostrar y poner this.Mostrar() adentro de este
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("=============== CHOCOLATE ===============");
            sb.Append(base.ToString());
            sb.AppendLine($"Relleno: {this.relleno}");
            sb.AppendLine($"Tipo de cacao: {this.tipoDeCacao}");
            sb.AppendLine("=========================================\n");

            return sb.ToString();
        }
        public override bool Equals(object? obj)
        {
            bool mismoChocolate = false;

            if (base.Equals(obj) && obj is Chocolate chocolate)
            {
                if (this.Relleno == chocolate.Relleno && this.TipoDeCacao == chocolate.TipoDeCacao) //aca no se si poner this.codigo == chocolate.codigo
                {
                    mismoChocolate = true;
                }
            }
            return mismoChocolate;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), this); //ver bien que hace esto, no entendi bien
        }

        public override string MostrarEnVisor()
        {
            string mensaje = $"Relleno: {this.relleno} - Tipo de cacao: {this.tipoDeCacao}";
            //fijarme si poner todo o no, para no repetir
            return mensaje;
        }

        public override double CalcularPrecioFinal()
        {
            double precioFinal = base.CalcularPrecioFinal();
            //si compro mas de 3 chocolates aplico 30% de descuento
            if (Cantidad > 3) //aca no se si tendria que poner this.Cantidad
            {
                precioFinal *= 0.7;
            }
            return precioFinal;
        }
        #endregion

        #region Sobrecarga de operadores
        public static bool operator ==(Chocolate chocolate1, Chocolate chocolate2)
        {
            bool mismoChocolate = false;

            if (chocolate1.Equals(chocolate2))// en Equals comparo codigo y peso, decia que tenia que usarlo en ==
            {
                mismoChocolate = true;
            }
            return mismoChocolate;
        }
        public static bool operator !=(Chocolate chocolate1, Chocolate chocolate2)
        {
            return !(chocolate1 == chocolate2); // aca llamo al == de g1 y g2
        }

        #endregion
    }
}
