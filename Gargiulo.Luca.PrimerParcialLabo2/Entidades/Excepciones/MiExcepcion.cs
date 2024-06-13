﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Excepciones
{
    public class MiExcepcion : Exception
    {

        public MiExcepcion() : base()
        {

        }
        public MiExcepcion(string mensaje) : base(mensaje)
        {

        }
        public MiExcepcion(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }
    }
}
