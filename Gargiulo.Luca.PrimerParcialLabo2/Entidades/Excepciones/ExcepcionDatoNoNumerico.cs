using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Excepciones
{
    public class ExcepcionDatoNoNumerico : MiExcepcion
    {
        public ExcepcionDatoNoNumerico() : base()
        {

        }
        public ExcepcionDatoNoNumerico(string mensaje) : base(mensaje)
        {

        }
        public ExcepcionDatoNoNumerico(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }
    }
}
