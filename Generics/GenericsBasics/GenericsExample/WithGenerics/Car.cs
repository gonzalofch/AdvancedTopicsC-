using GenericsBasics.GenericsExample.WithGenerics.Interface;

namespace GenericsBasics.GenericsExample.WithGenerics;

public class Car : IVehicle
{
    public string Brand { get; set; }
    public string Model { get; set; }

    public Car(string brand, string model)
    {
        Brand = brand;
        Model = model;
    }
}