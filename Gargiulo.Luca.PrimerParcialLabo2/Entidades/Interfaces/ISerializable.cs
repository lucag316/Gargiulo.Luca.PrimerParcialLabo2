using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interfaces
{
    public interface ISerializable<T>
    {
        // convencion que empiece  con I y termine con able
        //puedo poner ISerializable<List<T>> a donde lo llamo, en vez de aca. seria mas generico
        bool SerializarI(List<T> datos);

         List<T> DeserializarI();
    }
}
