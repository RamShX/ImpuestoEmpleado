
using ImpuestoEmpleado.Domain.Interfeces;

namespace ImpuestoEmpleado.Domain.Manager
{
    public class EmpleadoManager
    {
        public List<IEmpleado> Empleados { get; set; } = new List<IEmpleado>();

        public void AddEmpleado(IEmpleado empleado)
        {
            Empleados.Add(empleado);
            Console.WriteLine("Se agregó completamente el empleado");
        }

        public void MostrarEmpleado() 
        {
            foreach (var e in Empleados)
            {
                decimal impuesto = e.CalcularImpuesto(e.Salario);
                Console.WriteLine($"Nombre: {e.Nombre} | Tipo de empleado: {e.TipoEmpleado} | Salario: {e.Salario} | Impuesto: {impuesto.ToString("F2")}");
                Console.WriteLine("==========================================================================================================================");
            }
        }
    }
}
