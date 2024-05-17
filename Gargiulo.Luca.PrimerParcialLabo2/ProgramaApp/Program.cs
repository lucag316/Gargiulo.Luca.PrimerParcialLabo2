using Entidades;
internal class Program
{
    private static void Main(string[] args)
    {


        Chocolate chocolate1 = new Chocolate(0, 0, 0);
        Chicle chicle1 = new Chicle(1, 2, 5, "mucha", "larga");
        Chupetin chupetin1 = new Chupetin(2, 10, 1);
        Chupetin chupetin2 = new Chupetin(2, 10, 1, "corazon", "irrompible");


        Console.WriteLine(chocolate1.ToString());
        Console.WriteLine(chicle1.ToString());
        Console.WriteLine(chupetin1.ToString());
        Console.WriteLine(chupetin2.ToString());



        Console.WriteLine();


        Console.ReadKey();
    }
}