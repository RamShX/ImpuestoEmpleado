using ImpuestoEmpleado.Domain.Interfeces;

namespace ImpuestoEmpleado.Domain.SaveStrategy
{
    class StrategyTxt : IExportable
    {
        private readonly string _path = "C:\\Users\\Lenovo\\source\\repos\\P2\\Ejercicio Strategy2\\ImpuestoEmpleado\\ImpuestoEmpleado.Domain\\ArchivoGuardado\\Empleado.txt";
        private readonly List<IEmpleado> _empleados;
        public StrategyTxt(List<IEmpleado> empleados)
        {
            _empleados = empleados;
        }

        public void Exportar()
        {
            string txt = "Nombre | Tipo de empleado | Salario | Impuesto";
            foreach (var e in _empleados)
            {
                txt += $"\n{e.Nombre} | {e.TipoEmpleado} | {e.Salario} | {e.CalcularImpuesto(e.Salario)}";
            }

            File.WriteAllText(_path, txt);
            Console.WriteLine("Se guardadó los datos en extensión TXT correctamente");
        }
    }
}
