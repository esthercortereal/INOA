using System.Net.Http;
using System.Text.Json;

namespace INOA.Services
{
    public class StockService
    {
        public async Task<decimal> GetPrice(string symbol)
        {
            HttpClient client = new HttpClient();

              client.DefaultRequestHeaders.Add(
                "User-Agent",
                "Mozilla/5.0"
            );

            string url =
                $"https://query1.finance.yahoo.com/v8/finance/chart/{symbol}.SA";

            string response =
                await client.GetStringAsync(url);

            JsonDocument doc =
                JsonDocument.Parse(response);

            decimal price = doc
                .RootElement
                .GetProperty("chart")
                .GetProperty("result")[0]
                .GetProperty("meta")
                .GetProperty("regularMarketPrice")
                .GetDecimal();

                return price;
             

        }
    }
}