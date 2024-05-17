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
        public Chocolate(int codigo, float peso, double precio) : base(codigo, peso, precio)
        {
            this.relleno = Rellenos.SinRelleno; 
            this.tipoDeCacao = TiposDeCacao.Negro;
            //como no los completa, lo pongo por defecto, creo que esta bien
        }
        public Chocolate(int codigo, float peso, double precio, Rellenos relleno): this(codigo, peso, precio)
        {
            this.relleno = relleno;
            this.tipoDeCacao = TiposDeCacao.Negro; // no se bien si hay que agregarla
        }
        public Chocolate(int codigo, float peso, double precio, Rellenos relleno, TiposDeCacao tipoDeCacao) : this(codigo, peso, precio, relleno)
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
                if (this == chocolate) //aca no se si poner this.codigo == chocolate.codigo
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

        #endregion

       


        #region Sobrecargas
        #endregion
    }
}
