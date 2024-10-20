using System;
using Newtonsoft.Json;
using StockAnalyzer.Core.Domain;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace StockAnalyzer.Windows;

public partial class MainWindow : Window
{
    private static string API_URL = "https://ps-async.fekberg.com/api/stocks";
    private Stopwatch stopwatch = new Stopwatch();

    public MainWindow()
    {
        InitializeComponent();
    }


    private void Search_Click(object sender, RoutedEventArgs e)
    {
        //
        BeforeLoadingStockData();
        // streamReader     
        var streamReader = new StreamReader(File.OpenRead("StockPrices_Small.csv"));
        var streamFileContent = streamReader.ReadToEndAsync();

        // File readlines
        var lines = File.ReadAllLines("StockPrices_Small.csv");
        var data = new List<StockPrice>();
        foreach (var line in lines.Skip(1))
        {
            var price = StockPrice.FromCSV(line);
            data.Add(price);
        }

        Stocks.ItemsSource = data.Where(_ => _.Identifier == StockIdentifier.Text);
        
        AfterLoadingStockData();
    }

    private void ShowFinalMessage(IEnumerable<StockPrice> data)
    {
        if (data is null)
        {
            FailedOperation();
        }
        else
        {
            AfterLoadingStockData();
        }
    }

    private void BeforeLoadingStockData()
    {
        stopwatch.Restart();
        StockProgress.Visibility = Visibility.Visible;
        StockProgress.IsIndeterminate = true;
    }

    private void AfterLoadingStockData()
    {
        StocksStatus.Text = $"Loaded stocks for {StockIdentifier.Text} in {stopwatch.ElapsedMilliseconds}ms";
        StockProgress.Visibility = Visibility.Hidden;
    }

    private async Task<IEnumerable<StockPrice>> GetStocksAsync(HttpClient client)
    {
        //uses the client / calls the api url in order to get a HttpResponse 
        //StockIdentifier is the string passed by windows form input
        //This Obtains a Task<HttpResponseMessage>

        // await , waits for return value of GetAsyncMethod (the HttpResponseMessage Itself)

        //here we are entering into the attributes of HttpResponseMessage, 
        //In this case is content, has all the data in Json ready to be parsed to present in UI

        //This awaits for the process of parse JSON data to String asynchronously

        //Use the Library Method JsonConvert to Deserialize in an IEnumerable of StockPrices objects
        // returns this list of stockPrices 
        try
        {
            HttpResponseMessage? httpmessage = await client.GetAsync($"{API_URL}/{StockIdentifier.Text}");
            var contentData = await httpmessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<StockPrice>>(contentData);
        }
        catch (Exception e)
        {
            throw new Exception();
        }
    }

    private void FailedOperation()
    {
        StocksStatus.Text =
            $"The Operation has failed searching for {StockIdentifier.Text} in {stopwatch.ElapsedMilliseconds}ms";

        StockProgress.Visibility = Visibility.Hidden;
    }

    private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
    {
        Process.Start(new ProcessStartInfo { FileName = e.Uri.AbsoluteUri, UseShellExecute = true });

        e.Handled = true;
    }

    private void Close_OnClick(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }
}