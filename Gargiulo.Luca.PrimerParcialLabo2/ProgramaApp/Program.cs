using Entidades;
internal class Program
{
    private static void Main(string[] args)
    {
        Kiosco kiosco = new Kiosco(10);

        Chocolate chocolate1 = new Chocolate(1, 15, 10, 5);
        Chicle chicle1 = new Chicle(2, 15, 10, 5);
        Chupetin chupetin1 = new Chupetin(2, 10, 10, 5);
        Chupetin chupetin2 = new Chupetin(3, 10, 10, 2, "corazon", "irrompible");
        //Chupetin chupetin3 = new Chupetin(4, 10, 1,3, "picodulce", "irrompible");
        //Chupetin chupetin4 = new Chupetin(5, 10, 1, 4,"corazon", "derretido");

        kiosco += chocolate1;
        kiosco += chicle1;
        kiosco += chupetin1;
        kiosco += chupetin2;
        //kiosco += chupetin3;
        //kiosco += chupetin4;

        //kiosco -= chupetin1; 

        //Console.WriteLine(kiosco.OrdenarGolosinasPorCodigo(true));
        Console.WriteLine(kiosco.Detalle);

        //Console.WriteLine($"Esta la siguiente golosina en el kiosco: \n{chupetin2} Respuesta:" + (kiosco == chupetin2));

        Console.WriteLine(chocolate1.Equals(chocolate1));
        Console.WriteLine(chocolate1 == chocolate1);
        /*
        Console.WriteLine(chocolate1.ToString());
        Console.WriteLine(chicle1.ToString());
        Console.WriteLine(chupetin1.ToString());
        Console.WriteLine(chupetin2.ToString());
        */


        Console.WriteLine();


        Console.ReadKey();
    }
}