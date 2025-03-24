

namespace ImpuestoEmpleado.Domain.Interfeces
{
    public interface IEmpleado
    {
        string Nombre { get; set; }
        decimal Salario { get; set; }
        decimal Impuesto { get; set; }
        string TipoEmpleado { get; }

        decimal CalcularImpuesto(decimal salario);
    }
}
