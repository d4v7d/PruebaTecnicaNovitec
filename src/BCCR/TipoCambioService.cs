using System;
using System.Threading.Tasks;

using Microsoft.Data.SqlClient;

public class TipoCambioService
{
    private readonly ApplicationDbContext _context;
    private readonly BccrApiClient _apiClient;

    public TipoCambioService()
    {
        _context = new ApplicationDbContext();
        _apiClient = new BccrApiClient();
    }

    public async Task GuardarTipoCambioAsync()
    {
        TipoCambio tipoCambio = await _apiClient.ObtenerTipoCambioAsync("317", DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("dd/MM/yyyy"), "David Gonzalez Villanueva", "davidgonzav2003@gmail.com", "25ND2C3MO0");

        var query = "INSERT INTO dbo.TipoCambio (COD_INDICADORINTERNO, DES_FECHA, NUM_VALOR) VALUES (@IndicadorInterno, @Fecha, @Valor)";

        using (var connection = new SqlConnection("Server=DAVIS\\SQLEXPRESS;Database=BCCR_API;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"))
        using (var command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Valor", tipoCambio.Valor);
            command.Parameters.AddWithValue("@Fecha", tipoCambio.Fecha);
            command.Parameters.AddWithValue("@IndicadorInterno", 317);

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        Console.WriteLine($"Guardado: {tipoCambio.Valor} el {tipoCambio.Fecha}");
    }
}