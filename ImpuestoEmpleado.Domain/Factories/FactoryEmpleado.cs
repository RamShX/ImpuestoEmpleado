

using ImpuestoEmpleado.Domain.Interfeces;
using ImpuestoEmpleado.Domain.Models;

namespace ImpuestoEmpleado.Domain.Factories
{
    public class FactoryEmpleado
    {
        public static IEmpleado Create(string nombre, decimal salario, int tipo)
        {
            switch (tipo)
            {
                case 1:
                    return new EmpleadoTiempoCompleto(nombre, salario);
                case 2:
                    return new EmpleadoMedioTiempo(nombre, salario);
                case 3:
                    return new EmpleadoPorContracto(nombre, salario);
                default:
                    throw new ArgumentException("Tipo de empleado no válido");
            }
        }
    }
}
