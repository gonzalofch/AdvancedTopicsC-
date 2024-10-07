using Microsoft.AspNetCore.Mvc;
using StockAnalyzer.Web.Models;
using System.Diagnostics;
using Newtonsoft.Json;
using StockAnalyzer.Core.Domain;

namespace StockAnalyzer.Web.Controllers;

public class HomeController : Controller
{
    private static string API_URL = "https://ps-async.fekberg.com/api/stocks";

    public async Task<IActionResult> Index()
    {
        var client = new HttpClient();
        HttpResponseMessage httpResponseMessage = await client.GetAsync($"{API_URL}/MSFT");
        var contentData = await httpResponseMessage.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<IEnumerable<StockPrice>>(contentData);
        return View(data);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}