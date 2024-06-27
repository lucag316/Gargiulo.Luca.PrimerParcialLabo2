using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.JerarquiaYContenedora;

namespace Entidades.Interfaces
{
    public interface IAccesibleDatos<T> where T : Golosina
    {
        bool Agregar(T entidad);
        bool Modificar(T entidad);
        bool Eliminar(int codigo);
        List<T> ObtenerLista();
    }
}
