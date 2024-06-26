using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Entidades.Interfaces
{
    public interface IOrdenable<T>
    {
        void Ordenar<TPropiedad1, TPropiedad2>(Func<T, TPropiedad1> selector1, Func<T, TPropiedad2> selector2, bool ascendente);
    }
}
