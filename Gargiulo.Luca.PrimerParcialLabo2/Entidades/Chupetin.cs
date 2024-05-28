using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Chupetin: Golosina
    {
        #region Atributos
        protected EFormasDeChupetin formaChupetin;
        protected ENivelesDeDureza dureza;
        #endregion

        #region Propiedades
        [JsonPropertyName("formaChupetin")]
        public EFormasDeChupetin FormaChupetin
        {
            get { return this.formaChupetin;}
            set { this.formaChupetin = value;}
        }

        [JsonPropertyName("dureza")]
        public ENivelesDeDureza Dureza
        {
            get { return this.dureza; }
            set { this.dureza = value; }
        }
        #endregion

        #region Constructor
        public Chupetin() : base() //constructor sin parametros para poder usar JSON
        {

        }
        public Chupetin(int codigo, float peso, double precio, int cantidad) : base(codigo, peso, precio, cantidad)
        {
            this.formaChupetin = EFormasDeChupetin.Redondo;
            this.dureza = ENivelesDeDureza.Media;
        }
        public Chupetin(int codigo, float peso, double precio, int cantidad, EFormasDeChupetin formaChupetin) : this(codigo, peso, precio, cantidad)
        {
            this.formaChupetin = formaChupetin;
        }
        public Chupetin(int codigo, float peso, double precio, int cantidad, EFormasDeChupetin formaChupetin, ENivelesDeDureza dureza) : this(codigo, peso, precio, cantidad, formaChupetin)
        {
            this.dureza = dureza;
        }
        #endregion

        #region Metodos ToString, Equals, GetHashCode Sobrescritos
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("=============== CHUPETIN ===============");
            sb.Append(base.ToString());
            sb.AppendLine($"Forma de Chupetin: {this.formaChupetin}");
            sb.AppendLine($"Dureza: {this.dureza}");
            sb.AppendLine("========================================\n");

            return sb.ToString();
        }
        public override bool Equals(object? obj)
        {
            bool mismoChupetin = false;

            if (obj is Chupetin)
            {
                if (((Chupetin)obj) == this)
                {
                    mismoChupetin = true;
                }
            }
            return mismoChupetin;
        }
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Metodos sobrescritos
        public override string MostrarEnVisor()
        {
            string mensaje = $"CHUPETIN: Codigo de barra: {base.Codigo} - Precio: ${base.Precio} - Peso: {base.Peso}g - Cantidad: {base.Cantidad} unidades - Forma de chupetin: {this.formaChupetin} - Dureza: {this.dureza}";
            //fijarme si poner todo o no, para no repetir codigo
            return mensaje;
        }
        public override double CalcularPrecioFinal()
        {
            double precioFinal = base.CalcularPrecioFinal();
            //si compro mas de 2 chupetines aplico 20% de descuento
            if (Cantidad > 3) //aca no se si tendria que poner this.Cantidad
            {
                precioFinal *= 0.80;
            }
            return precioFinal;
        }
        #endregion

        #region Sobrecargas de operadores de igualdad
        public static bool operator ==(Chupetin chupetin1, Chupetin chupetin2)
        {
            bool mismoChupetin = false;

            if (chupetin1.Codigo == chupetin2.Codigo && chupetin1.Peso == chupetin2.Peso)
            {
                mismoChupetin = true;
            }

            return mismoChupetin;
        }
        public static bool operator !=(Chupetin chupetin1, Chupetin chupetin2)
        {
            return !(chupetin1 == chupetin2);
        }

        
        #endregion
    }
}
