namespace MisExcepciones
{
    public class MiExcepcion : Exception
    {
        
        public MiExcepcion(string mensaje) : base(mensaje)
        {

        }

        public MiExcepcion(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }


       
    }
}
