using GenericsBasics.GenericsExample.WOutGenerics.Interface;

namespace GenericsBasics.GenericsExample.WOutGenerics;

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