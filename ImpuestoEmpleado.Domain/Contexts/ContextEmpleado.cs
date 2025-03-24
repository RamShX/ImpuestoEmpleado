

using ImpuestoEmpleado.Domain.Interfeces;

namespace ImpuestoEmpleado.Domain.Contexts
{
    public class ContextEmpleado
    {
        private IEmpleado _empleado;

        public ContextEmpleado(IEmpleado empleado)
        {
            _empleado = empleado;
        }

        public decimal CalcularImpuesto(decimal salario)
        {
            return _empleado.CalcularImpuesto(salario);
        }


    }
}
