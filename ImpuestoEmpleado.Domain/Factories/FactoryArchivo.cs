using ImpuestoEmpleado.Domain.Interfeces;
using ImpuestoEmpleado.Domain.SaveStrategy;

namespace ImpuestoEmpleado.Domain.Factories
{
    public class FactoryArchivo 
    {
        public static IExportable CrearExportable(int tipo, List<IEmpleado> empleado)
        {
            switch (tipo)
            {
                case 1:
                    return new StrategyExcel(empleado);
                case 2:
                    return new StrategyTxt(empleado);
                case 3:
                    return new StrategyJson(empleado);
                default:
                    throw new ArgumentException("Exportación no válido");
            }
        }
    }
}
