using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interfaces
{
    public interface IOrdenable
    {
        void OrdenarPorCodigo(bool ascendente);
        void OrdenarPorPrecio(bool ascendente);
        void OrdenarPorPeso(bool ascendente);
        void OrdenarPorCantidad(bool ascendente);
    }
}
