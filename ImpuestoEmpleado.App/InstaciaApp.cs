
using ImpuestoEmpleado.Domain.Factories;
using ImpuestoEmpleado.Domain.Interfeces;
using ImpuestoEmpleado.Domain.Manager;

namespace ImpuestoEmpleado.App
{
    public class InstaciaApp
    {
        EmpleadoManager _empleadoManager = new EmpleadoManager();
        public void Funcionalidad() 
        {
            bool exit = true;

            while (exit)
            {
                Console.Clear();
                Console.WriteLine("Menú");
                Console.WriteLine("1. Agregar empleado");
                Console.WriteLine("2. Mostrar empleado");
                Console.WriteLine("3. Salir");
                Console.WriteLine("Seleccione una opción: ");
                int opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        AgregarEmpleado();
                        break;
                    case 2:
                        MostrarEmpleado();
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
             if(!decimal.TryParse(Console.ReadLine(), out decimal salario) && salario < 0) 
             {
                Console.WriteLine("Salario no válido");
                return;
             }
            
            Console.WriteLine("Ingrese el tipo de empleado: ");
            Console.WriteLine("1. Empleado de tiempo completo");
            Console.WriteLine("2. Empleado de medio tiempo");
            Console.WriteLine("3. Empleado por contrato");
            int tipo = Convert.ToInt32(Console.ReadLine());

            try
            {
                IEmpleado empleado = FactoryEmpleado.Create(nombre, salario, tipo);
                _empleadoManager.AddEmpleado(empleado);
            }
            catch (Exception e)
            {

                Console.WriteLine($"Error: {e.Message}");
            }
        }

        private void MostrarEmpleado()
        {
            _empleadoManager.MostrarEmpleado();

        }
    }
}
