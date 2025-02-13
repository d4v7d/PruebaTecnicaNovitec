using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;


public class TipoCambioJob : BackgroundService
{
    private readonly TipoCambioService _tipoCambioService;
    private readonly TimeSpan _intervalo;

    public TipoCambioJob(IConfiguration configuration)
    {
        _tipoCambioService = new TipoCambioService();
        int intervaloSegundos = configuration.GetValue<int>("TipoCambioJob:IntervaloSegundos");
        _intervalo = TimeSpan.FromSeconds(intervaloSegundos);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _tipoCambioService.GuardarTipoCambioAsync();
            await Task.Delay(_intervalo, stoppingToken);
        }
    }
}