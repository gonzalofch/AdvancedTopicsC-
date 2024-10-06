using System;
using Newtonsoft.Json;
using StockAnalyzer.Core.Domain;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading;
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


    private async void Search_Click(object sender, RoutedEventArgs e)
    {
        BeforeLoadingStockData();
        
        //creates the httpClient to make the request
        var client = new HttpClient();
        
        //uses the client / calls the api url in order to get a HttpResponse 
        //StockIdentifier is the string passed by windows form input
        //This Obtains a Task<HttpResponseMessage>
        var responseTask = client.GetAsync($"{API_URL}/{StockIdentifier.Text}");
        
        // await , waits for return value of GetAsyncMethod (the HttpResponseMessage Itself)
        var response = await responseTask;
        
        //here we are entering into the attributes of HttpResponseMessage, 
        //In this case is content, has all the data in Json ready to be parsed to present in UI
        var content = response.Content;
        
        //This awaits for the process of parse JSON data to String asynchronously
        var contentData = await content.ReadAsStringAsync();
        
        //Use the Library Method JsonConvert to Deserialize in an IEnumerable of StockPrices objects
        // returns this list of stockPrices 
        var data = JsonConvert.DeserializeObject<IEnumerable<StockPrice>>(contentData);
        
        //Updates the grid and displays the data in the form
        Stocks.ItemsSource = data;

        //esto solo añade mas informacion al final y cierra el proceso de carga de la barra verde
        AfterLoadingStockData();
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