using System.Text;
using System.Text.Json;

namespace GenericsExample;

public class SendRequest<T> where T : Requestable
{
    private HttpClient _clientHttp = new HttpClient();

    public async Task<T> Send(T model)
    {
        string url = "https://jsonplaceholder.typicode.com/posts/";
        var data = JsonSerializer.Serialize<T>(model);
        HttpContent content =
            new StringContent(data, Encoding.UTF8, "application/json");
        var httpResponse = await _clientHttp.PostAsync(url, content);
        if (httpResponse.IsSuccessStatusCode)
        {
            var result = await httpResponse.Content.ReadAsStringAsync();
            var postResult = JsonSerializer.Deserialize<T>(result);
            return postResult;
        }

        return default(T);
    }
}