using System.Security.Cryptography.X509Certificates;

namespace Entidades
{
    public class Transporte
    {
        #region Atributos
        private int velocidad;
        private int capacidadPasajeros;
        private int cargaMaxima;
        #endregion

        #region Propiedades
        #endregion

        #region Constructor
        public Transporte() //esta la pongo a eleccion, CAMBIARLA SI QUIERO
        {
            
        }
        public Transporte(int velocidad, int capacidadPasajeros)
        {
            this.velocidad = velocidad;
            this.capacidadPasajeros = capacidadPasajeros;
        }

        public Transporte(int velocidad, int capacidadPasajeros, int cargaMaxima):this(velocidad, capacidadPasajeros)
        {
            this.cargaMaxima = cargaMaxima;
        }
        #endregion

        #region Metodos
        public string Mostrar()
        {
            return $"{this.velocidad} - {this.capacidadPasajeros} - {this.cargaMaxima}";
        }
        #endregion

        #region Sobrecargas
        #endregion
    }
}