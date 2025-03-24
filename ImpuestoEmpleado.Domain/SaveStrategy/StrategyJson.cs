using ImpuestoEmpleado.Domain.Interfeces;
using System.Text.Json;

namespace ImpuestoEmpleado.Domain.SaveStrategy
{
    class StrategyJson : IExportable
    {
        private readonly string _path = "C:\\Users\\Lenovo\\source\\repos\\P2\\Ejercicio Strategy2\\ImpuestoEmpleado\\ImpuestoEmpleado.Domain\\ArchivoGuardado\\Empleado.json";
        public void Exportar()
        {
            List<IEmpleado> empleados = new List<IEmpleado>();
            var json = JsonSerializer.Serialize(empleados, new JsonSerializerOptions{ WriteIndented = true});
            File.WriteAllText(_path, json);
            Console.WriteLine("Se guardadó los datos en extensión json correctamente");

        }
    }
}
