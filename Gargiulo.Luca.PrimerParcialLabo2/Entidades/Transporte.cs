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
        public Transporte(int velocidad, int capacidadPasajeros, int cargaMaxima)
        {
            this.velocidad = velocidad;
            this.capacidadPasajeros = capacidadPasajeros;
            this.cargaMaxima = cargaMaxima;
        }
        #endregion

        #region Metodos
        #endregion

        #region Sobrecargas
        #endregion
    }
}