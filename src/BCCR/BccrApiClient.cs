
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

public class BccrApiClient
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://gee.bccr.fi.cr/Indicadores/Suscripciones/WS/wsindicadoreseconomicos.asmx";

    public BccrApiClient()
    {
        _httpClient = new HttpClient();
    }

    public async Task<TipoCambio> ObtenerTipoCambioAsync(string indicador, string fechaInicio, string fechaFinal, string nombre, string email, string token)
    {
        string url = $"{BaseUrl}/ObtenerIndicadoresEconomicos?" +
                     $"Indicador={indicador}&FechaInicio={fechaInicio}&FechaFinal={fechaFinal}" +
                     $"&Nombre={nombre}&SubNiveles=N&CorreoElectronico={email}&Token={token}";

        HttpResponseMessage response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        string xmlContent = await response.Content.ReadAsStringAsync();
        XDocument xmlDoc = XDocument.Parse(xmlContent);

        var INGC011_CAT_INDICADORECONOMIC = xmlDoc.Descendants("INGC011_CAT_INDICADORECONOMIC");

        var tipoCambio = new TipoCambio
        {
            Id = Guid.NewGuid(),
            Valor = double.TryParse(INGC011_CAT_INDICADORECONOMIC.Elements("NUM_VALOR").FirstOrDefault()?.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out double valor) ? valor : 0,
            Fecha = DateTime.TryParse(INGC011_CAT_INDICADORECONOMIC.Elements("DES_FECHA").FirstOrDefault()?.Value, out DateTime fecha) ? fecha : DateTime.MinValue,
            IndicadorInterno = int.TryParse(INGC011_CAT_INDICADORECONOMIC.Elements("COD_INDICADORINTERNO").FirstOrDefault()?.Value, out int indicadorInterno) ? indicadorInterno : 0
        };

        return tipoCambio;
    }
}