namespace INOA.Services
{
    public class MonitorService
    {
        public async Task Start()
        {
            StockService stock =
                 new StockService();

            while (true)
            {
                decimal price =
                    await stock.GetPrice("PETR4");

                Console.WriteLine($"Preço Atual: {price}");

                await Task.Delay(5000);
            }
        }
    }
}