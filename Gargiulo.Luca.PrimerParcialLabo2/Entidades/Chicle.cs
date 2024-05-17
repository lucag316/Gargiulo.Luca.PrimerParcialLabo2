using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Chicle : Golosina
    {
        #region Atributos
        public string elasticidad; //mucha, poca, normal, etc
        public string duracionSabor; 
        #endregion

        #region Propiedades
        #endregion

        #region Constructor

        public Chicle(int codigo, double precio, double cantidad) : base(codigo, precio, cantidad)
        {
            this.elasticidad = "nada";
            this.duracionSabor = "poca";
        }
        public Chicle(int codigo, double precio, double cantidad, string elasticidad) : this(codigo, precio, cantidad)
        {
            this.elasticidad = elasticidad;
            this.duracionSabor = "poca";
        }
        public Chicle(int codigo, double precio, double cantidad, string elasticidad, string duracionSabor) : this(codigo, precio, cantidad, elasticidad)
        {
            this.duracionSabor = duracionSabor;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("=============== CHICLE ===============");
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Elasticidad: {this.elasticidad}");
            sb.AppendLine($"Duracion del sabor: {this.duracionSabor}");
            sb.AppendLine("======================================\n");

            return sb.ToString();
        }

        public override string MostrarEnVisor()
        {
            string mensaje = $"Elasticidad: {this.elasticidad} - Duracion del sabor: {this.duracionSabor}";
            //fijarme si poner todo o no, para no repetir codigo
            return mensaje;
        }

        #endregion

        #region Sobrecargas
        #endregion


    }
}
