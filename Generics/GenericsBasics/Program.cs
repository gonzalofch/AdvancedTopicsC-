using System.Diagnostics;
using GenericsBasics.GenericsExample.WithGenerics;
using GenericsBasics.GenericsExample.WOutGenerics;
using Microsoft.VisualBasic.CompilerServices;
using GenericsBasics.MathOperationExample;
using Car = GenericsBasics.GenericsExample.WOutGenerics.Car;
using Person = GenericsBasics.GenericsExample.WOutGenerics.Person;

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


        /**
         * GenericList Microsoft Example:
         */
        GenericList<int> list1 = new GenericList<int>();
        list1.Add(1);

        // Declare a list of type string.
        GenericList<string> list2 = new GenericList<string>();
        list2.Add("");

        // Declare a list of type ExampleClass.
        GenericList<ExampleClass> list3 = new GenericList<ExampleClass>();
        list3.Add(new ExampleClass());


        /*
         * MathOperations::::
         *
         */
        MathOperations<int> intOperations = new MathOperations<int>();
        Console.WriteLine("Integer");
        Console.WriteLine(intOperations.Add(5, 3));
        /*Operaciones que no permite debido a ser necesariamente tipo int*/
        // Console.WriteLine(intOperations.Add(5.2,4));  
        // Console.WriteLine(intOperations.Add(5.0m, 3));
        MathOperations<decimal> decimalOperations = new MathOperations<decimal>();
        Console.WriteLine("Decimal");
        Console.WriteLine(decimalOperations.Add(4.4m, 10.1m));


        /*GENERICS EXAMPLE  W/WO generics*/
        /*wout generics*/
        OperationResult operationResult = new OperationResult();
        Person person = operationResult.Person;

        OperationResultCar operationResultCar = new OperationResultCar();
        Car car = operationResultCar.Car;

        /*con generics*/
        OperationResult<Person> resultPerson = new OperationResult<Person>();
        Person p = resultPerson.Content;

        OperationResult<Car> resultCar = new OperationResult<Car>();
        Car c = resultCar.Content;
    }
}