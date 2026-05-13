using INOA.Services;

namespace INOA
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string symbol =
                args[0];

            decimal sellPrice =
                decimal.Parse(args[1]);

            decimal buyPrice =
                decimal.Parse(args[2]);

            MonitorService monitor =
                new MonitorService();

            await monitor.Start(
                symbol,
                sellPrice,
                buyPrice
            );
        }
    }
}