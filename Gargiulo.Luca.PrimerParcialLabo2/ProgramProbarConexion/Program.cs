using SQL;
using Entidades.JerarquiaYContenedora;
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

        List<Golosina> lista = ado.ObtenerListaDato();

        foreach (Golosina item in lista)
        {
            Console.WriteLine(item.ToString()); // muestro cada uno de los registros
        }

        Golosina obj = new Chocolate(); 
        obj.Codigo = 1;
        obj.Precio = 100;
        obj.Peso = 500;
        obj.Cantidad = 3;

        bool agrego = ado.AgregarGolosina(obj); //para el insert

        if (agrego)
        {
            Console.WriteLine("Se agrego");
        }
        else
        {
            Console.WriteLine("No se agrego");
        }

        lista = ado.ObtenerListaDato();

        foreach (Golosina item in lista)
        {
            Console.WriteLine(item.ToString());
        }

        // esta instancia para modificar un obj, puede ser un metodo estatico ponele
        obj.Codigo = 1;
        obj.Precio = 200;
        obj.Peso = 250;
        obj.Cantidad = 2;

        bool modifico = ado.ModificarGolosina(obj);

        if (modifico)
        {
            Console.WriteLine("Se modifico");
        }
        else
        {
            Console.WriteLine("No se modifico");
        }

        lista = ado.ObtenerListaDato();

        foreach (Golosina item in lista)
        {
            Console.WriteLine(item.ToString());

        }

        bool elimino = ado.EliminarGolosina(1);

        if (elimino)
        {
            Console.WriteLine("Se elimino");
        }
        else
        {
            Console.WriteLine("No se elimino");
        }

        lista = ado.ObtenerListaDato();

        foreach (Golosina item in lista)
        {
            Console.WriteLine(item.ToString());
        }

        Console.ReadLine();
    }
}