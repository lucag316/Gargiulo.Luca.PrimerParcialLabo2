using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        public string apellido;
        public string nombre;

        public Cliente()
        {
            this.apellido = "Sin apellido";
            this.nombre = "Sin nombre";
        }
        public Cliente(string apellido) : this()
        {
            this.apellido = apellido;
        }
        public Cliente(string apellido, string nombre) : this(apellido)
        {
            this.nombre = nombre;
        }

        public static bool operator ==(Cliente cliente1, Cliente cliente2)
        {
            return cliente1.nombre == cliente2.nombre && cliente1.apellido == cliente2.apellido;
        }
        public static bool operator !=(Cliente cliente1, Cliente cliente2)
        {
            return !(cliente1 == cliente2);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Apellido: {this.apellido}");
            sb.Append($"Nombre: {this.nombre}");

            return sb.ToString();
        }
        public override bool Equals(object? obj)
        {
            bool mismoCliente = false;

            if (obj is Cliente)
            {
                if(((Cliente)obj) == this)
                {
                    mismoCliente = true;
                }
            }
            return mismoCliente;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


    }
}
