using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Chupetin : Golosina
    {
        #region Atributos
        private string formaChupetin;
        private string dureza;
        //tipo de palo
        #endregion

        #region Propiedades
        public string FormaChupetin { get { return this.formaChupetin; } }
        public string Dureza {  get { return this.dureza; } }
        #endregion
        
        #region Constructor
        public Chupetin(int codigo, float peso, double precio) : base (codigo, peso, precio)
        {
            this.formaChupetin = "redondo";
            this.dureza = "mucha";
        }
        public Chupetin(int codigo, float peso, double precio, string formaChupetin) : this(codigo, peso, precio)
        {
            this.formaChupetin = formaChupetin;
        }
        public Chupetin(int codigo, float peso, double precio, string formaChupetin, string dureza) : this(codigo, peso, precio, formaChupetin)
        {
            this.dureza = dureza;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            //fijarse bien porque ademas segurolo tengo que hacer en una linea
            sb.AppendLine("=============== CHUPETIN ===============");
            sb.Append(base.ToString());
            sb.AppendLine($"Forma de Chupetin: {this.formaChupetin}");
            sb.AppendLine($"Dureza: {this.dureza}");
            sb.AppendLine("========================================\n");

            return sb.ToString();
        }
        /*public override bool Equals(object? obj)
        {
            bool mismoChupetin = false;

            if (base.Equals(obj) && obj is Chupetin chupetin)
            {
                if (this == chupetin) //aca no se si poner this.codigo == chocolate.codigo
                {
                    mismoChupetin = true;
                }
            }
            return mismoChupetin;
        }*/
        public override bool Equals(object? obj)
        {
            bool mismoChupetin = false;

            if (base.Equals(obj) && obj is Chupetin chupetin)
            {
                if (this.FormaChupetin == chupetin.FormaChupetin && this.Dureza == chupetin.Dureza) //aca no se si poner this.codigo == chocolate.codigo
                {
                    mismoChupetin = true;
                }
            }
            return mismoChupetin;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), this); //ver bien que hace esto, no entendi bien
        }

        public override string MostrarEnVisor()
        {
            string mensaje = $"Forma de chupetin: {this.formaChupetin} - Dureza: {this.dureza}";
            //fijarme si poner todo o no, para no repetir codigo
            return mensaje;
        }

        #endregion

        #region Sobrecargas

        public static bool operator ==(Chupetin chupetin1, Chupetin chupetin2)
        {
            bool mismoChupetin = false;

            if (chupetin1.Equals(chupetin2))// en Equals comparo codigo y peso, decia que tenia que usarlo en ==
            {
                mismoChupetin = true;
            }
            return mismoChupetin;
        }
        public static bool operator !=(Chupetin chupetin1, Chupetin chupetin2)
        {
            return !(chupetin1 == chupetin2); // aca llamo al == de g1 y g2
        }
        #endregion


    }
}
