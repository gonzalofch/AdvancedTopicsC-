using System.ComponentModel.Design;
using GenericsExample.Models;
namespace GenericsExample;

class Program
{
    static async Task Main(string[] args)
    {
        var empleado = new Employee() { Name = "Gonzalo", PhoneNumber = "671312900", HomeAddress = "CasaDeGonzalo" };
        var post = new Post(){body = "bodydyydyddyy",title = "holalalala",userId = "50"};

        // SendRequest<Employee> service = new SendRequest<Employee>();
        // var empleadoResult = await service.Send(empleado);

        SendRequest<Post> servicePost = new SendRequest<Post>();
        var postResult = await servicePost.Send(post);
        
    }
}