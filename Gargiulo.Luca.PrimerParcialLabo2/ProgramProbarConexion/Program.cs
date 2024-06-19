using SQL;
internal class Program
{
    private static void Main(string[] args)
    {
        AccesoDatos ado = new AccesoDatos();

        if (ado.ProbarConexion())
        {
            Console.WriteLine("Se conecto exitosamente");
        }
        else
        {
            Console.WriteLine("No se pudo conectar");
        }

        //List<DatoGolosina> lista = ado.ObtenerListaDato();

        //foreach(DatoGolosina item in lista)
        //{
        //    Console.WriteLine(item.ToString());
        //}

        //DatoGolosina obj = new DatoGolosina();
        //obj.cadena = "nuevo";
        //obj.entero = 100;





        Console.WriteLine("");
    }
}