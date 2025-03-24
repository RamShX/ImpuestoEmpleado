using ImpuestoEmpleado.Domain.Interfeces;

namespace ImpuestoEmpleado.Domain.SaveStrategy
{
    class StrategyTxt : IExportable
    {
        private readonly string _path = "C:\\Users\\Lenovo\\source\\repos\\P2\\Ejercicio Strategy2\\ImpuestoEmpleado\\ImpuestoEmpleado.Domain\\ArchivoGuardado\\Empleado.txt";
        public void Exportar()
        {
            List<IEmpleado> empleados = new List<IEmpleado>();

            string txt = "Nombre | Tipo de empleado | Salario | Impuesto";
            foreach (var e in empleados)
            {
                txt += $"\n{e.Nombre} | {e.TipoEmpleado} | {e.Salario} | {e.CalcularImpuesto(e.Salario)}";
            }

            File.WriteAllText(_path, txt);
            Console.WriteLine("Se guardadó los datos en extensión TXT correctamente");
        }
    }
}
