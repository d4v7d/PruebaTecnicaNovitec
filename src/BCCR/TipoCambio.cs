using System;
using System.ComponentModel.DataAnnotations;

public class TipoCambio
{
    [Key]
    public Guid Id { get; set; }
    public double Valor { get; set; }
    public DateTime Fecha { get; set; }
    public int IndicadorInterno { get; set; }
}