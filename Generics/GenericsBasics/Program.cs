using System.Diagnostics;
using Microsoft.VisualBasic.CompilerServices;

namespace GenericsBasics;

class Program
{
    static void Main(string[] args)
    {
/*
 * GENERICOS:
 * Pemiten definir clases con parametros de tipos
 * Permiten hacer el programa más eficiente.
 * Permiten Restringir que tipos se pueden pasar como argumentos para ciertas operaciones:
 *  where T : struct: El tipo debe ser un tipo de valor.
 *  where T : class: El tipo debe ser un tipo de referencia.
 *  where T : new(): El tipo debe tener un constructor sin parámetros.
 *  where T : baseClass: El tipo debe heredar de baseClass.
 *  where T : interface: El tipo debe implementar la interfaz interface.
 *
 * Permiten definir delegados con parámetros de tipo.
 * Permiten definir interfaces con parámetros de tipo.
 * Permite tener clases anidadas genéricas dentro de clases genéricas
 * Covarianza y Contravarianza:
 *  Permiten usar tipos genéricos en situaciones donde la herencia de tipos está involucrada
 * Collections genéricas (listas,diccionarios), permite pasar el tipo que debe aceptar.
 * Permite crear metodos de extensión genéricos.
 *
 * REUTILIZACIÓN DE CODIGO
 */
        List<int> listaEnteros = [2, 3, 4, 5, 6, 7];
        List<string> listaStrings = ["1", "dos", "adssdd", "mondongo", "palabras"];
        List<float> listaFloats = [3.3f, 5.5f, 3];
        List<double> listaDoubles = [3.4, 5.5, 6.6, 7.7, 2];
        
        Printer.PrintListWithTypes(listaEnteros);
        Printer.PrintListWithTypes(listaStrings);
        Printer.PrintListWithTypes(listaFloats);
        Printer.PrintListWithTypes(listaDoubles);
        
        //Tambien se le pueden pasar object
        List<object> listaObjetos = [new List<int>[2, 3, 4], "PALABRAS", 4.4, 10000, null, new HttpClient()];
        //Pero es ineficiente,
        //Comprobacion de tiempo de creacion de Lista de Objetos y lista de enteros

        Stopwatch sw = new Stopwatch();
        sw.Start();
        List<object> objects = new List<object>();
        for (int i = 0; i < 100000000; i++)
        {
            objects.Add(i);
        }

        sw.Stop();

        Console.WriteLine($"Time Elapsed List<object>: {sw.ElapsedMilliseconds}");
        sw = new();
        sw.Start();
        List<int> integers = new List<int>();
        for (int i = 0; i < 100000000; i++)
        {
            integers.Add(i);
        }

        sw.Stop();
        Console.WriteLine($"Time Elapsed List<int>: {sw.ElapsedMilliseconds}");
    }
}