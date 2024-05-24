using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Chocolate : Golosina
    {
        #region Atributos
        protected ERellenos relleno;
        protected ETiposDeCacao tipoDeCacao;
        #endregion

        #region Propiedades
        public ERellenos Relleno { get { return this.relleno; } }
        public ETiposDeCacao TipoDeCacao { get { return this.tipoDeCacao; } }
        #endregion

        #region Constructor
        public Chocolate()  : base()//constructor sin parametros para poder usar JSON
        {

        }
        public Chocolate(int codigo, float peso, double precio, int cantidad) : base(codigo, peso, precio, cantidad)
        {
            this.relleno = ERellenos.SinRelleno; 
            this.tipoDeCacao = ETiposDeCacao.Negro;
            //como no los completa, lo pongo por defecto, creo que esta bien
        }
        public Chocolate(int codigo, float peso, double precio, int cantidad, ERellenos relleno): this(codigo, peso, precio, cantidad)
        {
            this.relleno = relleno;
        }
        public Chocolate(int codigo, float peso, double precio, int cantidad, ERellenos relleno, ETiposDeCacao tipoDeCacao) : this(codigo, peso, precio, cantidad, relleno)
        {
            this.tipoDeCacao = tipoDeCacao;

        }
        #endregion

        #region Metodos ToString, Equals, GetHashCode Sobrescritos
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
            //por ej, verifico si el obj es del mismo tipo osea si es Golosina
            if (obj is Chocolate)
            {
                if (((Chocolate)obj) == this) // voy al == de Golosina y Golosina
                {
                    mismoChocolate = true;
                }
            }
            return mismoChocolate;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        #region Metodos sobrescritos
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

        #region Sobrecarga de operadores de igualdad
        public static bool operator ==(Chocolate chocolate1, Chocolate chocolate2)
        {
            bool mismoChocolate = false;
            //invocar al == de la clase base
            if (chocolate1.Codigo == chocolate2.Codigo && chocolate1.Peso == chocolate2.Peso)
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
