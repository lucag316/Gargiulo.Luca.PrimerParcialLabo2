﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interfaces
{
    public interface ISerializable<T>
    {
        bool Serializar(List<T> datos);

        List<T> Deserializar();
    }
}
