﻿using Entidades.Interfaces;
using Entidades.JerarquiaYContenedora;
using System.Runtime.CompilerServices;
internal class Program
{
    private static void Main(string[] args)
    {
        Kiosco<Golosina>.CapacidadMaximaAlcanzada += MostrarMensajeCapacidadMaxima;
        Kiosco<Golosina>.GolosinaYaEstaEnLista += MostrarMensajeGolosinaRepetida;
        Kiosco<Golosina> kiosco = new Kiosco<Golosina>(3);

        Chocolate chocolate1 = new Chocolate(1646416, 15, 10, 5);
        Chicle chicle1 = new Chicle(1, 20, 10, 5);
        Chupetin chupetin1 = new Chupetin(4, 10, 10, 5);
        Chupetin chupetin2 = new Chupetin(3, 5, 10, 2);
        //Chupetin chupetin3 = new Chupetin(4, 10, 1,3, "picodulce", "irrompible");
        //Chupetin chupetin4 = new Chupetin(5, 10, 1, 4,"corazon", "derretido");

        kiosco += chocolate1;
        kiosco += chicle1;
        kiosco += chupetin1;
        kiosco += chupetin2;
        //kiosco += chupetin3;
        //kiosco += chupetin4;

        //kiosco -= chupetin1; 

        kiosco.Ordenar(g => g.Codigo, g => g.Codigo, true);
        //kiosco.OrdenarGolosinasPorPeso(true);
        //Console.WriteLine(kiosco.OrdenarGolosinasPorCodigo());
        //Console.WriteLine(kiosco.Detalle);

        //Console.WriteLine($"Esta la siguiente golosina en el kiosco: \n{chupetin2} Respuesta:" + (kiosco == chupetin2));

        Console.WriteLine(chocolate1.Equals(chocolate1));
        //Console.WriteLine(chocolate1 == chocolate1);
        /*
        Console.WriteLine(chocolate1.ToString());
        Console.WriteLine(chicle1.ToString());
        Console.WriteLine(chupetin1.ToString());
        Console.WriteLine(chupetin2.ToString());
        */

        
        //Console.WriteLine();


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