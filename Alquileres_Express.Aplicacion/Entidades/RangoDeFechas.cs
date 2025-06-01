namespace Alquileres_Express.Aplicacion.Entidades;

public class RangoDeFechas(DateTime startDate, DateTime endDate)
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; } = startDate;
    public DateTime EndDate { get; set; } = endDate;

    public bool Contains(DateTime? date)
    {

        return date >= StartDate && date <= EndDate;
    }

    public bool SeSuperponeCon(RangoDeFechas otroRango)
    {
        return StartDate <= otroRango.EndDate && EndDate >= otroRango.StartDate;

    }
}