using ImpuestoEmpleado.Domain.Interfeces;
using OfficeOpenXml;

namespace ImpuestoEmpleado.Domain.SaveStrategy
{
    class StrategyExcel : IExportable
    {
        private readonly string _path = "C:\\Users\\Lenovo\\source\\repos\\P2\\Ejercicio Strategy2\\ImpuestoEmpleado\\ImpuestoEmpleado.Domain\\ArchivoGuardado\\Empleado.xlsx";
        private readonly List<IEmpleado> _empleados;
        public StrategyExcel(List<IEmpleado> empleados)
        {
            _empleados = empleados;
        }
        public void Exportar()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var excel = new ExcelPackage())
            {

                var headerRow = new List<string[]>()
                {
                    new string[] { "Nombre", "Tipo de empleado", "Salario", "Impuesto" }
                };

                var hoja = excel.Workbook.Worksheets.Add("Empleados");
                hoja.Cells["A1"].LoadFromArrays(headerRow);

                int fila = 2;
                foreach (var e in _empleados)
                {
                    
                    hoja.Cells[fila, 1].Value = e.Nombre;
                    hoja.Cells[fila, 2].Value = e.TipoEmpleado;
                    hoja.Cells[fila, 3].Value = e.Salario;
                    hoja.Cells[fila, 4].Value = e.CalcularImpuesto(e.Salario);
                    fila++;
                }

                File.WriteAllBytes(_path, excel.GetAsByteArray());
                Console.WriteLine("Se guardadó los datos en extensión excel correctamente");
            }
        }
    }
}
