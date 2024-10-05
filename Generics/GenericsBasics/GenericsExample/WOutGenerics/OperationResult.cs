namespace GenericsBasics.GenericsExample.WOutGenerics;

public class OperationResult
{
    public bool Success => !MessageList.Any();
    public List<string> MessageList { get; private set; }
    public Person Person { get; set; }

    public OperationResult()
    {
        MessageList = new List<string>();
    }

    public void AddMessage(string message)
    {
        MessageList.Add(message);
    }

    public void SetSuccessResponse(Person person)
    {
        Person = person;
    }
}

public class OperationResultCar
{
    public bool Success => !MessageList.Any();
    public List<string> MessageList { get; private set; }
    public Car Car { get; set; }

    public OperationResultCar()
    {
        MessageList = new List<string>();
    }

    public void AddMessage(string message)
    {
        MessageList.Add(message);
    }

    public void SetSuccessResponse(Car car)
    {
        Car = car;
    }
}

public class Example
{
    
}