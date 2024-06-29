using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Excepciones
{
    public class ExcepcionNumeroNegativo : MiExcepcion
    {
        public ExcepcionNumeroNegativo() : base()
        {

        }
        public ExcepcionNumeroNegativo(string mensaje) : base(mensaje)
        {

        }
        public ExcepcionNumeroNegativo(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }
    }
}
