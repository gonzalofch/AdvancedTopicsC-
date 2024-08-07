namespace GenericsBasics;

public class Printer
{
    public static void PrintListWithTypes<T>(List<T> list)
    {
        Console.WriteLine(list.GetType());

        foreach (var item in list)
        {
            Console.WriteLine($"Value: {item}, Type: {item.GetType()}");
        }
    }
}