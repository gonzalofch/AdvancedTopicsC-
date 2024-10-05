using System.Numerics;

namespace GenericsBasics.MathOperationExample;

public class MathOperations<T> where T : INumber<T>
{
    /*Al hacer que T sea d etipo INumber nos aseguramos completamente de que pueda realizar las siguientes operaciones*/
    public T Add(T x, T y)
    {
        return x + y;
    }
}