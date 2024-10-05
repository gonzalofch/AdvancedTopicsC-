namespace GenericsBasics.GenericsExample.WithGenerics;

public class OperationResult<T>
{
    public bool Success => !MessageList.Any();
    public List<string> MessageList { get; private set; }
    public T Content { get; set; }

    public OperationResult()
    {
        MessageList = new List<string>();
    }

    public void AddMessage(string message)
    {
        MessageList.Add(message);
    }

    public void SetSuccessResponse(T content)
    {
        Content = content;
    }
}