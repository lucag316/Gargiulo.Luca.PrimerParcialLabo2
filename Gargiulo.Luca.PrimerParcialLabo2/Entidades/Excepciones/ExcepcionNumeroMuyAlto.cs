using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Excepciones
{
    public class ExcepcionNumeroMuyAlto : MiExcepcion
    {
        public ExcepcionNumeroMuyAlto() : base()
        {

        }
        public ExcepcionNumeroMuyAlto(string mensaje) : base(mensaje)
        {

        }
        public ExcepcionNumeroMuyAlto(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }
    }
}
