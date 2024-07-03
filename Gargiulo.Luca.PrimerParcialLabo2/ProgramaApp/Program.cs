using Entidades.Interfaces;
using Entidades.JerarquiaYContenedora;
using System.Runtime.CompilerServices;
internal class Program
{
    private static void Main(string[] args)
    {
        Kiosco<Golosina>.CapacidadMaximaAlcanzada += MostrarMensajeCapacidadMaxima;
        Kiosco<Golosina>.ProductoYaEstaEnLista += MostrarMensajeGolosinaRepetida;
        Kiosco<Golosina> miKiosco = new Kiosco<Golosina>(10);

        Chicle chicle1 = new Chicle(1, 0.05f, 1.5f, 10, ENivelesDeElasticidad.Poca, ENivelesDuracionDeSabor.MuyPoca);
        Chicle chicle2 = new Chicle(2, 0.07f, 2.0f, 8, ENivelesDeElasticidad.Media, ENivelesDuracionDeSabor.Media, true);
        
        Chocolate chocolate1 = new Chocolate(3, 0.1f, 3.5f, 5, ERellenos.Nuez, ETiposDeCacao.Amargo, true);
        Chocolate chocolate2 = new Chocolate(4, 0.08f, 2.8f, 7,ERellenos.Nutela, ETiposDeCacao.Blanco, false);
        Chocolate chocolate3 = new Chocolate(3, 0.1f, 3.5f, 5, ERellenos.Nuez, ETiposDeCacao.Amargo, true);

        Chupetin chupetin1 = new Chupetin(5, 0.02f, 1.0f, 15, EFormasDeChupetin.Redondo, ENivelesDeDureza.Irrompible, true);
        Chupetin chupetin2 = new Chupetin(6, 0.03f, 1.2f, 12, EFormasDeChupetin.Pirulin);


        miKiosco += chicle1;
        miKiosco += chicle2;
        miKiosco += chocolate1;
        miKiosco += chocolate2;
        miKiosco += chupetin1;
        miKiosco += chupetin2;

        Console.WriteLine("Golosinas en el kiosco:");
        Console.WriteLine(miKiosco.MostrarListaEnVisorDetalle());

        miKiosco -= chocolate1;

        Console.WriteLine("\nGolosinas ordenadas por precio descendente:");
        miKiosco.Ordenar(g => g.Precio, g => g.Precio, false);
        Console.WriteLine(miKiosco.MostrarListaEnVisorDetalle());

        Console.WriteLine($"chicle1 y chocolate1 son distintos?: {chicle1 != chocolate1}");
        Console.WriteLine($"¿chocolate1 y chocolate3 son iguales?: {chocolate1 == chocolate3}");

        Console.ReadKey();
    }
    private static void MostrarMensajeGolosinaRepetida(string mensaje)
    {
        Console.WriteLine($"Advertencia: {mensaje}");
    }
    private static void MostrarMensajeCapacidadMaxima(string mensaje)
    {
        Console.WriteLine($"Error: {mensaje}");
    }
}