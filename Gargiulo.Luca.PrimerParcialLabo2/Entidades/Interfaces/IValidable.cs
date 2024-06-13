using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interfaces
{
    public interface IValidable
    {
        //bool ValidarRangoCodigo();// para mi codigo tienen todos el mismo

        void ValidarRangoPrecio();

        void ValidarRangoPeso();

        void ValidarRangoCantidad();

    }
}
