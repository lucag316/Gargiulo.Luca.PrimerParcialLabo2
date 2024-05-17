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
        public string formaChupetin;
        public string dureza;
        //tipo de palo
        #endregion

        #region Propiedades
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
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Forma de Chupetin: {this.formaChupetin}");
            sb.AppendLine($"Dureza: {this.dureza}");
            sb.AppendLine("========================================\n");

            return sb.ToString();
        }

        public override string MostrarEnVisor()
        {
            string mensaje = $"Forma de chupetin: {this.formaChupetin} - Dureza: {this.dureza}";
            //fijarme si poner todo o no, para no repetir codigo
            return mensaje;
        }

        #endregion

        #region Sobrecargas
        #endregion


    }
}
