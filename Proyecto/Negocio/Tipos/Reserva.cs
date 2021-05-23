using Negocio.Utils;
using System;

namespace Negocio
{
    /// <summary>
    /// Clase encargada de mantener la estructura de una reserva en la base de datos.
    /// </summary>
    class Reserva
    {
        public string DniEmpleado { get;  set; }
        public int Codigo { get;  set; }
        public DateTime FechaReserva { get;  set; }
        public string DniCliente { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public string CodHabitacion { get; set; }
        public string PlanVenta { get; set; }
        public string Origen { get; set; }
        public float Descuento { get; set; }
        /// <summary>
        /// Devuelve una reserva nueva rellena con el empleado que ha iniciado sesión autoasignado como empleado
        /// que ha creado la reserva, y con fecha de creación igual al día actual del sistema.
        /// </summary>
        public Reserva()
        {
            DniEmpleado = Login.EmpleadoActivo.Dni;
            FechaReserva = DateTime.Now;
        }

        public Reserva(string dniCliente, DateTime fechaEntrada, DateTime fechaSalida, string codHabitacion, 
            string planVenta, string origen, float descuento)
        {
            DniEmpleado = Login.EmpleadoActivo.Dni;
            FechaReserva = DateTime.Now;
            DniCliente = dniCliente;
            FechaEntrada = fechaEntrada;
            FechaSalida = fechaSalida;
            CodHabitacion = codHabitacion;
            PlanVenta = planVenta;
            Origen = origen;
            Descuento = descuento;
        }
    }
}
