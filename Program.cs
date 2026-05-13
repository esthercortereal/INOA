using INOA.Services;

namespace INOA
{
    class Program
    {
        static async Task Main(string[] args)
        {
            MonitorService monitor =
                new MonitorService();

            await monitor.Start();

        }
    }
}