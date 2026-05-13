namespace INOA.Services
{
    public class MonitorService
    {
        public async Task Start(  
            string symbol,
            decimal sellPrice,
            decimal buyPrice)
        {
            StockService stock =
                new StockService();
            EmailService email =
                new EmailService();

            while (true)
            {
                decimal price =
                    await stock.GetPrice(symbol);

                Console.WriteLine($"Preço Atual: {price}");

                if (price > sellPrice)
                {
                    await email.SendEmail(
                        "ALERTA DE VENDA",
                        $"O ativo {symbol} está em {price}"
                    );
                }
                else if (price < buyPrice)
                {
                    await email.SendEmail(
                        "ALERTA DE COMPRA",
                        $"O ativo {symbol} está em {price}"
                    );
                }


                await Task.Delay(5000);
            }
        }
    }
}