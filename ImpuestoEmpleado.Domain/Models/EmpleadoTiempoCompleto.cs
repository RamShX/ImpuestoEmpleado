using ImpuestoEmpleado.Domain.Interfeces;

namespace ImpuestoEmpleado.Domain.Models
{
    public class EmpleadoTiempoCompleto : IEmpleado
    {
        public string Nombre { get; set; }
        public decimal Salario { get; set; }
        public decimal Impuesto { get; set; } = 0.25m;
        public string TipoEmpleado { get; } = "Tiempo Completo";

        //Methods
        public EmpleadoTiempoCompleto(string nombre, decimal salario)
        {
            Nombre = nombre;
            Salario = salario;
        }

        public decimal CalcularImpuesto(decimal salario)
        {
            return salario * Impuesto;
        }
    }
}
