using ImpuestoEmpleado.Domain.Interfeces;
using ImpuestoEmpleado.Domain.SaveStrategy;

namespace ImpuestoEmpleado.Domain.Factories
{
    public class FactoryArchivo 
    {
        public IExportable CrearExportable(string tipo)
        {
            switch (tipo)
            {
                case "Excel":
                    return new StrategyExcel();
                case "Txt":
                    return new StrategyTxt();
                case "Json":
                    return new StrategyJson();
                default:
                    return null;
            }
        }
    }
}
