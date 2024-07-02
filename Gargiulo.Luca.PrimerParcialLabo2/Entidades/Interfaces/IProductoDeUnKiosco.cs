using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interfaces
{
    public interface IProductoDeUnKiosco
    {
        //bool Equals(object? obj);
        double CalcularPrecioFinal();
        string MostrarEnVisor();

        int Codigo { get; set; }
        float Precio { get; set; }
        float Peso { get; set; }
        int Cantidad {  get; set; }

       // bool esIgualA(T otroProducto);

    }
}
