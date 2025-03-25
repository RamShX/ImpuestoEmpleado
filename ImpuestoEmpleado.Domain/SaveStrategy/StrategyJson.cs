using ImpuestoEmpleado.Domain.Interfeces;
using System.Text.Json;

namespace ImpuestoEmpleado.Domain.SaveStrategy
{
    class StrategyJson : IExportable
    {
        private readonly string _path = "C:\\Users\\Lenovo\\source\\repos\\P2\\Ejercicio Strategy2\\ImpuestoEmpleado\\ImpuestoEmpleado.Domain\\ArchivoGuardado\\Empleado.json";

        private readonly List<IEmpleado> _empleados;
        public StrategyJson(List<IEmpleado> empleados)
        {
            _empleados = empleados;
        }
        public void Exportar()
        {
            var EmpleadoConImpuestoAplicado = _empleados.Select(e => new 
            {
                Nombre = e.Nombre,
                TipoEmpleado = e.TipoEmpleado,
                Salario = e.Salario,
                Impuesto = e.CalcularImpuesto(e.Salario)
            }).ToList();

            var json = JsonSerializer.Serialize(EmpleadoConImpuestoAplicado, new JsonSerializerOptions{ WriteIndented = true});
            File.WriteAllText(_path, json);
            Console.WriteLine("Se guardadó los datos en extensión json correctamente");

        }
    }
}
