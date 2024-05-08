using System.Security.Cryptography.X509Certificates;

namespace Entidades
{
    public class Transporte
    {
        #region Atributos
        public int velocidad;
        public int capacidadPasajeros;
        public int cargaMaxima;
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
            return $" {this.velocidad} KM - {this.capacidadPasajeros} pasajeros - {this.cargaMaxima} KILOS";
        }
        #endregion

        #region Sobrecargas
        #endregion
    }
}