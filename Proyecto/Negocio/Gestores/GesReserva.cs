using Datos;
using System;
using System.Collections.Generic;

namespace Negocio
{
    /// <summary>
    /// Clase encargada de gestionar todo lo relacionado con una o varias reservas.
    /// </summary>
    class GesReserva
    {
        public Reserva Reserva { get; set; }
        public List<Reserva> Reservas { get; private set; }
        public GesCliente GesCliente { get; private set; }
        public GesEmpleado GesEmpleado { get; private set; }
        public GesHabitacion GesHabitacion { get; private set; }
        public GesPlanVentas GesPlanVentas { get; private set; }
        public string Error { get; private set; }
        public int LineasModificadas { get; private set; }

        /// <summary>
        /// Devuelve un nuevo gestor de reservas, inicializado con un gestor de datos por cada tabla relacionada,
        /// y con un listado de todas las reservas existentes en la base de datos.
        /// </summary>
        public GesReserva()
        {
            GesCliente = new GesCliente();
            GesEmpleado = new GesEmpleado();
            GesHabitacion = new GesHabitacion();
            GesPlanVentas = new GesPlanVentas();
            Reserva = new Reserva();

            BuscarTodasReservas();

            if(Reservas == null)
                Reservas = new List<Reserva>();
        }
        /// <summary>
        /// Añade una reserva a la base de datos, comprobando que la reserva sea posible de efectuar.
        /// </summary>
        /// <param name="fechaEntrada">Fecha de entrada del cliente</param>
        /// <param name="fechaSalida">Fecha de salida del cliente</param>
        /// <param name="origen">Origen de la reserva (Teléfono, Web, E-mail, Recepción...)</param>
        /// <param name="descuento">Porcentaje de descuento de la reserva</param>
        public void NuevaReserva(DateTime fechaEntrada, DateTime fechaSalida, string origen, float descuento)
        {
            if(fechaEntrada < DateTime.Now.AddDays(-1))
            {
                Error = $"La fecha de entrada no puede ser anterior a la fecha actual. {DateTime.Now:yyyy-MM-dd}";
            }
            else if(fechaEntrada >= fechaSalida)
            {
                Error = "La fecha de salida debe ser posterior a la de entrada.";
            }
            else if (HabitacionDisponible(fechaEntrada, fechaSalida, Reserva.CodHabitacion))
            {
                IntroducirReserva(fechaEntrada, fechaSalida, origen, descuento);
            }
            else
                Error = "Habitación ocupada, escoge otra habitación para la reserva.";
        }

        private void IntroducirReserva(DateTime fechaEntrada, DateTime fechaSalida, string origen, float descuento)
        {
            string sql = "insert into reservas(dni_emp, dni_cli, cod_hab, tpo_vnt, fch_rva, fch_ent," +
                "fch_sal, origen, prc_desc) values(" +
                $"'{Reserva.DniEmpleado}'," +
                $"'{Reserva.DniCliente}'," +
                $"'{Reserva.CodHabitacion}'," +
                $"'{Reserva.PlanVenta}'," +
                $"'{DateTime.Now:yyyy-MM-dd HH:mm:ss}'," +
                $"'{fechaEntrada:yyyy-MM-dd HH:mm:ss}'," +
                $"'{fechaSalida:yyyy-MM-dd HH:mm:ss}'," +
                $"'{origen}'," +
                $"'{descuento}')";

            LineasModificadas = BaseDatos.Modificacion(sql);
            Error = BaseDatos.Error;
        }

        private bool HabitacionDisponible(DateTime fechaEntrada, DateTime fechaSalida, string codHab)
        {
            string sql = $"select * from reservas where fch_ent<'{fechaSalida:yyyy-MM-dd}' and cod_hab='{codHab}'" +
                $" and fch_sal>'{fechaEntrada:yyyy-MM-dd}'";

            BaseDatos.Consulta(sql);
            Error = BaseDatos.Error;

            return BaseDatos.ResultadoConsulta == null;
        }

        /// <summary>
        /// Reemplaza la reserva individual que está siendo gestionada por otra existente en la base de datos.
        /// </summary>
        /// <param name="codReserva">Código de la reserva</param>
        public void RecuperarReserva(int codReserva)
        {
            BaseDatos.Consulta($"select * from reservas where cod_rva='{codReserva}'");
            Error = BaseDatos.Error;

            if (BaseDatos.ResultadoConsulta != null && BaseDatos.ResultadoConsulta.Read())
            {
                ActualizarReserva();
                MapearGestores();
            }
            else if (Error == "")
                Error = "Reserva no encontrada";
        }
        /// <summary>
        /// Reemplaza los componentes individuales de cada gestor de las varias tablas relacionadas
        /// con la reserva, en base a los datos de la reserva que está siendo gestionada actualmente.
        /// </summary>
        public void MapearGestores()
        {
            GesCliente.Cliente = GesCliente.Clientes.Find(c => c.Dni == Reserva.DniCliente);
            GesEmpleado.Empleado = GesEmpleado.Empleados.Find(e => e.Dni == Reserva.DniEmpleado);
            GesHabitacion.Habitacion = GesHabitacion.Habitaciones.Find(h => h.Cod == Reserva.CodHabitacion);
            GesPlanVentas.PlanVentas = GesPlanVentas.Planes.Find(pv => pv.Tipo == Reserva.PlanVenta);
        }

        private void ActualizarReserva()
        {
            int.TryParse(BaseDatos.ResultadoConsulta["cod_rva"].ToString(), out int cod);
            float.TryParse(BaseDatos.ResultadoConsulta["prc_desc"].ToString(), out float descuento);
            DateTime.TryParse(BaseDatos.ResultadoConsulta["fch_rva"].ToString(), out DateTime fRva);
            DateTime.TryParse(BaseDatos.ResultadoConsulta["fch_ent"].ToString(), out DateTime fEnt);
            DateTime.TryParse(BaseDatos.ResultadoConsulta["fch_sal"].ToString(), out DateTime fSal);

            Reserva = new Reserva()
            {
                Codigo = cod,
                DniEmpleado = BaseDatos.ResultadoConsulta["dni_emp"].ToString(),
                DniCliente = BaseDatos.ResultadoConsulta["dni_cli"].ToString(),
                CodHabitacion = BaseDatos.ResultadoConsulta["cod_hab"].ToString(),
                PlanVenta = BaseDatos.ResultadoConsulta["tpo_vnt"].ToString(),
                FechaReserva = fRva,
                Origen = BaseDatos.ResultadoConsulta["origen"].ToString(),
                Descuento = descuento,
                FechaEntrada = fEnt,
                FechaSalida = fSal
            };
        }
        /// <summary>
        /// Reemplaza el listado de reservas por uno nuevo extraido desde la base de datos.
        /// </summary>
        public void BuscarTodasReservas()
        {
            BuscarReservas("", "", "", "", "", "", "","","","");
        }

        /// <summary>
        /// Reemplaza el listado de reservas por uno nuevo extraido desde la base de datos en función a los
        /// diferentes filtros pasados por parámetro.
        /// Es posible ignorar un filtro pasando un string vacío en su lugar.
        /// </summary>
        /// <param name="codRva">Código de la reserva</param> 
        /// <param name="dniEmpleado">Dni del empleado</param> 
        /// <param name="dniCliente">Dni del cliente</param> 
        /// <param name="codHab">Código de la habitación</param> 
        /// <param name="planVenta">Plan de ventas aplicado</param> 
        /// <param name="fRva">Fecha de realización de la reserva</param> 
        /// <param name="fEnt">Fecha de entrada del cliente</param> 
        /// <param name="fSal">Fecha de salida del cliente</param> 
        /// <param name="origen">Origen de la reserva</param> 
        /// <param name="descuento">Porcentaje de descuento</param> 
        public void BuscarReservas(string codRva, string dniEmpleado, string dniCliente, string codHab, string planVenta,
            string fRva, string fEnt, string fSal, string origen, string descuento)
        {
            string busqueda = "where 1=1";
            busqueda += codRva == "" ? "" : $" and cod_rva='{codRva}'";
            busqueda += dniEmpleado == "" ? "" : $" and dni_emp='{dniEmpleado}'";
            busqueda += dniCliente == "" ? "" : $" and dni_cli='{dniCliente}'";
            busqueda += codHab == "" ? "" : $" and cod_hab='{codHab}'";
            busqueda += planVenta == "" ? "" : $" and tpo_vnt='{planVenta}'";
            busqueda += fRva == "" ? "" : $" and fch_rva='{fRva}'";
            busqueda += fEnt == "" ? "" : $" and fch_ent='{fEnt}'";
            busqueda += fSal == "" ? "" : $" and fch_sal='{fSal}'";
            busqueda += origen == "" ? "" : $" and origen='{origen}'";
            busqueda += descuento == "" ? "" : $" and prc_desc='{descuento}'";

            BaseDatos.Consulta($"select * from reservas {busqueda}");
            Error = BaseDatos.Error;

            if (BaseDatos.ResultadoConsulta != null)
            {
                ListarUltimaConsulta();
            }
            else if (Error == "")
            {
                Error = "Sin resultados.";
            }
        }

        private void ListarUltimaConsulta()
        {
            Reservas = new List<Reserva>();

            while (BaseDatos.ResultadoConsulta != null && BaseDatos.ResultadoConsulta.Read())
            {
                AgregarResultado();
            }

            Reservas.Sort((r1, r2) => r1.FechaEntrada.CompareTo(r2.FechaEntrada));
        }

        private void AgregarResultado()
        {
            int.TryParse(BaseDatos.ResultadoConsulta["cod_rva"].ToString(), out int cod);
            float.TryParse(BaseDatos.ResultadoConsulta["prc_desc"].ToString(), out float descuento);
            DateTime.TryParse(BaseDatos.ResultadoConsulta["fch_rva"].ToString(), out DateTime fRva);
            DateTime.TryParse(BaseDatos.ResultadoConsulta["fch_ent"].ToString(), out DateTime fEnt);
            DateTime.TryParse(BaseDatos.ResultadoConsulta["fch_sal"].ToString(), out DateTime fSal);

            Reservas.Add(new Reserva()
            {
                Codigo = cod,
                DniEmpleado = BaseDatos.ResultadoConsulta["dni_emp"].ToString(),
                DniCliente = BaseDatos.ResultadoConsulta["dni_cli"].ToString(),
                CodHabitacion = BaseDatos.ResultadoConsulta["cod_hab"].ToString(),
                PlanVenta = BaseDatos.ResultadoConsulta["tpo_vnt"].ToString(),
                FechaReserva = fRva,
                Origen = BaseDatos.ResultadoConsulta["origen"].ToString(),
                Descuento = descuento,
                FechaEntrada = fEnt,
                FechaSalida = fSal
            });
        }

        /// <summary>
        /// Si existe, modifica los detalles de la reserva actual en la base de datos en base a los datos
        /// de la reserva gestionada actualmente.
        /// </summary>
        public void Editar()
        {
            if (Existe())
                Modificar();
            else
                Error = "Reserva no encontrada";
        }

        private void Modificar()
        {
            string sql = "update reservas set" +
                $" dni_cli='{Reserva.DniCliente}'," +
                $" dni_emp='{Reserva.DniEmpleado}'," +
                $" fch_sal='{Reserva.FechaSalida:yyyy-MM-dd HH:mm:ss}'," +
                $" fch_ent='{Reserva.FechaEntrada:yyyy-MM-dd HH:mm:ss}'," +
                $" fch_rva='{Reserva.FechaReserva:yyyy-MM-dd HH:mm:ss}'," +
                $" prc_desc='{Reserva.Descuento}'," +
                $" tpo_vnt='{Reserva.PlanVenta}'," +
                $" origen='{Reserva.Origen}'," +
                $" cod_hab='{Reserva.CodHabitacion}'" +
                $" where cod_rva='{Reserva.Codigo}'";

            LineasModificadas = BaseDatos.Modificacion(sql);
            Error = BaseDatos.Error;
        }

        /// <summary>
        /// Si existe, elimina de la base de datos la reserva gestionada actualmente.
        /// </summary>
        public void Eliminar()
        {
            if (Existe())
            {
                string sql = $"delete from reservas where cod_rva='{Reserva.Codigo}'";

                LineasModificadas = BaseDatos.Modificacion(sql);

                Error = BaseDatos.Error;
            }
            else
            {
                Error = "Código no encontrado";
            }
        }

        private bool Existe()
        {
            BaseDatos.Consulta($"select cod_rva from reservas where cod_rva='{Reserva.Codigo}'");
            Error = BaseDatos.Error;

            return BaseDatos.ResultadoConsulta != null;
        }
    }
}
