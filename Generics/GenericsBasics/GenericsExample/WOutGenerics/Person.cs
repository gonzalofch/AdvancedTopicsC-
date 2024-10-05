namespace GenericsBasics.GenericsExample.WOutGenerics;

public class Person
{
    private string Name { get; set; }
    public string LastName { get; set; }

    public Person()
    {
    }

    public Person(string name, string lastName)
    {
        Name = name;
        LastName = lastName;
    }
}