using Entidades;
internal class Program
{
    private static void Main(string[] args)
    {
        Transporte transporte1 = new Transporte(100, 5, 500);
        Auto auto1 = new Auto(4, "manual");

        Console.WriteLine("TRANSPORTE" + transporte1.Mostrar());
        Console.WriteLine("AUTO" + auto1.MostrarAuto());
        Console.WriteLine("AVION" + auto1.MostrarAuto());
        Console.WriteLine("BARCO" + auto1.MostrarAuto());
    }
}