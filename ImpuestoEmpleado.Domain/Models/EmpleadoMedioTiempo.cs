using ImpuestoEmpleado.Domain.Interfeces;

namespace ImpuestoEmpleado.Domain.Models
{

    public class EmpleadoMedioTiempo : IEmpleado
    {
        public string Nombre { get; set; }
        public decimal Salario { get; set; }
        public decimal Impuesto { get; set; } = 0.10m;
        public string TipoEmpleado { get;} = "Medio Tiempo";

        //Methods
        public EmpleadoMedioTiempo(string nombre, decimal salario)
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
