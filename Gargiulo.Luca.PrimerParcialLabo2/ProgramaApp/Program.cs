﻿using Entidades;
internal class Program
{
    private static void Main(string[] args)
    {
        Kiosco kiosco = new Kiosco(1);

        Chocolate chocolate1 = new Chocolate(0, 0, 0);
        Chicle chicle1 = new Chicle(1, 2, 5, "mucha", "larga");
        Chupetin chupetin1 = new Chupetin(2, 10, 1);
        Chupetin chupetin2 = new Chupetin(2, 10, 1, "corazon", "irrompible");

        kiosco += chocolate1;
        kiosco += chicle1;
        kiosco += chupetin1;
        kiosco += chupetin2;

        Console.WriteLine(kiosco.ToString());
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