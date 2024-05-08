using Entidades;
internal class Program
{
    private static void Main(string[] args)
    {
        Transporte transporte1 = new Transporte(100, 5, 500);
        Auto auto1 = new Auto(4, "manual");
        Avion avion1 = new Avion(3000, "flecha");
        Barco barco1 = new Barco(2, "simple");

        Console.WriteLine("TRANSPORTE: " + transporte1.Mostrar());
        Console.WriteLine("AUTO: " + auto1.MostrarAuto());
        Console.WriteLine("AVION: " + avion1.MostrarAvion());
        Console.WriteLine("BARCO: " + barco1.MostrarBarco());
    }
}