
using ImpuestoEmpleado.Domain.Contexts;
using ImpuestoEmpleado.Domain.Factories;
using ImpuestoEmpleado.Domain.Interfeces;
namespace ImpuestoEmpleado.App
{
    public class InstaciaApp
    {
        List<IEmpleado> _empleados = new List<IEmpleado>();
        public void Funcionalidad()
        {
            bool exit = true;

            while (exit)
            {
                Console.Clear();
                Console.WriteLine("Menú");
                Console.WriteLine("1. Agregar empleado");
                Console.WriteLine("2. Exportar Empleado");
                Console.WriteLine("3. Salir");
                Console.WriteLine("Seleccione una opción: ");
                int opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        AgregarEmpleado();
                        break;
                    case 2:
                        ExportarEmpleado();
                        break;
                    case 3:
                        exit = false;
                        Console.WriteLine("Saliste");
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }

                Console.WriteLine("Presiona cualquier tecla para avanzar...");
                Console.ReadKey();

            }
        }

        private void AgregarEmpleado()
        {
            Console.WriteLine("Ingrese el nombre del empleado: ");
            string nombre = Console.ReadLine()!;
            Console.WriteLine("Ingrese el salario del empleado: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal salario) || salario < 0)
            {
                Console.WriteLine("Salario no válido");
                return;
            }

            Console.WriteLine("Ingrese el tipo de empleado: ");
            Console.WriteLine("1. Empleado de tiempo completo");
            Console.WriteLine("2. Empleado de medio tiempo");
            Console.WriteLine("3. Empleado por contrato");
            if(!int.TryParse(Console.ReadLine(), out int tipo) || tipo < 1 || tipo > 3)
            {
                Console.WriteLine("Tipo de empleado no válido");
                return;
            }

            try
            {
                IEmpleado empleado = FactoryEmpleado.Create(nombre, salario, tipo);
                _empleados.Add(empleado);
            }
            catch (Exception e)
            {

                Console.WriteLine($"Error: {e.Message}");
            }
        }


        private void ExportarEmpleado()
        {
            Console.WriteLine("Seleccione el Formato que quiere exportar");
            Console.WriteLine("[1] Excel");
            Console.WriteLine("[2] Txt");
            Console.WriteLine("[3] Json");
            if (!int.TryParse(Console.ReadLine(), out int opcion) || opcion < 1  || opcion > 3) 
            {
                Console.WriteLine("Opción de de elegir no válida");
                return;
            }

            try
            {
                IExportable exportable = FactoryArchivo.CrearExportable(opcion, _empleados);

                if (exportable != null)
                {
                    ContextArchivo context = new ContextArchivo(exportable);
                    context.ExportarArchivo();
                }
            }
            catch (Exception e)
            {

                Console.WriteLine($"Error: {e.Message}");
            }

        }
    }
}
