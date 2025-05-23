namespace Alquileres_Express.Aplicacion.Entidades;

public class RangoDeFechas(DateTime? startDate, DateTime? endDate)
{
    public DateTime? StartDate { get; set; } = startDate;
    public DateTime? EndDate { get; set; } = endDate;

    public bool Contains(DateTime? date)
    {
        if (date == null || StartDate == null || EndDate == null)
            return false;

        return date >= StartDate && date <= EndDate;
    }

    public bool SeSuperponeCon(RangoDeFechas otroRango)
    {
        if (otroRango == null || StartDate == null || EndDate == null)
            return false;
        return StartDate <= otroRango.EndDate && EndDate >= otroRango.StartDate;

    }
}