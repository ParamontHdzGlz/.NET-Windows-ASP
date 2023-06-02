using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Doge.Model;
using Newtonsoft.Json;

public class OrderApiClient
{
    private readonly HttpClient httpClient;

    public OrderApiClient()
    {
        httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("http://localhost:5001/");
    }

    public async Task<List<Order>> GetOrdersAsync()
    {
        List<Order> orders = null;

        HttpResponseMessage response = await httpClient.GetAsync("orders");

        if (response.IsSuccessStatusCode)
        {
            string jsonOrders = await response.Content.ReadAsStringAsync();
            orders = JsonConvert.DeserializeObject<List<Order>>(jsonOrders);
        }

        return orders;
    }
}
