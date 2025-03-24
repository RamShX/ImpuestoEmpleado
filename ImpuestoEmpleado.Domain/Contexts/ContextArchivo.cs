

using ImpuestoEmpleado.Domain.Interfeces;

namespace ImpuestoEmpleado.Domain.Contexts
{
    public class ContextArchivo
    {
        private readonly IExportable _exportable;
        public ContextArchivo(IExportable exportable)
        {
            _exportable = exportable;
        }

        public void ExportarArchivo()
        {
            _exportable.Exportar();
        }
    }
}
