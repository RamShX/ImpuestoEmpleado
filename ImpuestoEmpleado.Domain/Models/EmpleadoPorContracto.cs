

using ImpuestoEmpleado.Domain.Interfeces;

namespace ImpuestoEmpleado.Domain.Models
{
    class EmpleadoPorContracto : IEmpleado
    {
        public string Nombre { get; set; }
        public decimal Salario { get;  set; }
        public decimal Impuesto { get; set; } = 0.15m;
        public string TipoEmpleado { get; } = "Por Contrato";

        //Methods
        public EmpleadoPorContracto(string nombre, decimal salario)
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
