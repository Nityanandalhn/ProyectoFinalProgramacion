using Datos;
using System.Collections.Generic;

namespace Negocio
{
    /// <summary>
    /// Clase encargada de gestionar todo lo relacionado con una o varias habitaciones.
    /// </summary>
    class GesHabitacion
    {
        public Habitacion Habitacion { get; set; }
        public List<Habitacion> Habitaciones { get; private set; }
        public int LineasModificadas { get; private set; }
        public string Error { get; private set; }

        /// <summary>
        /// Devuelve un nuevo gestor de habitaciones con un listado de todas las habitaciones
        /// existentes en la base de datos.
        /// </summary>
        public GesHabitacion()
        {
            BuscarTodasHabitaciones();

            if(Habitaciones == null)
                Habitaciones = new List<Habitacion>();
        }

        /// <summary>
        /// Reemplaza el listado actual de habitaciones por un nuevo listado extraido desde la base de datos.
        /// </summary>
        public void BuscarTodasHabitaciones()
        {
            BuscarHabitaciones("", "", "", "");
        }

        /// <summary>
        /// Reemplaza el listado actual de habitaciones por un nuevo listado extraido desde la base de datos
        /// en función a los filtros pasados como parámetro.
        /// Es posible ignorar un filtro pasando un string vacío en su lugar.
        /// </summary>
        /// <param name="cod">Código de la habitación</param>
        /// <param name="numCamas">Cantidad de camas existentes dentro de la habitación</param>
        /// <param name="planta">Planta que ubica la habitación</param>
        /// <param name="numHuesped">Capacidad máxima de personas de la habitación</param>
        public void BuscarHabitaciones(string cod, string numCamas, string planta, string numHuesped)
        {
            string busqueda = "where 1=1";
            busqueda += cod == "" ? "" : $" and cod='{cod}'";
            busqueda += numCamas == "" ? "" : $" and camas='{numCamas}'";
            busqueda += planta == "" ? "" : $" and planta='{planta}'";
            busqueda += numHuesped == "" ? "" : $" and max_huesped='{numHuesped}'";

            BaseDatos.Consulta($"select * from habitaciones {busqueda}");
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
            Habitaciones = new List<Habitacion>();

            while (BaseDatos.ResultadoConsulta != null && BaseDatos.ResultadoConsulta.Read())
            {
                if (int.TryParse(BaseDatos.ResultadoConsulta["camas"].ToString(), out int camas)
                    && int.TryParse(BaseDatos.ResultadoConsulta["max_huesped"].ToString(), out int maxHuesped))
                {
                    Habitaciones.Add(new Habitacion()
                    {
                        Cod = BaseDatos.ResultadoConsulta["cod"].ToString(),
                        Camas = camas,
                        Planta = BaseDatos.ResultadoConsulta["planta"].ToString(),
                        MaxHuespedes = maxHuesped
                    });
                }
            }

            Habitaciones.Sort((h1,h2) => {
                if (h1.Planta == h2.Planta)
                    return h1.Cod.CompareTo(h2.Cod);
                return h1.Planta.CompareTo(h2.Planta);
            });
        }

        /// <summary>
        /// Si la habitación que está siendo gestionada existe, la modifica en la base de datos
        /// con los datos actuales.
        /// En caso contrario, inserta una nueva habitación en la base de datos con los datos actuales.
        /// </summary>
        public void Editar()
        {
            if (Existe())
                Modificar();
            else
                Insertar();
        }

        private void Insertar()
        {
            string sql = "insert into habitaciones (cod,camas,max_huesped,planta) " +
                $"values ('{Habitacion.Cod}','{Habitacion.Camas}','{Habitacion.MaxHuespedes}','{Habitacion.Planta}')";

            BaseDatos.Modificacion(sql);
            Error = BaseDatos.Error;
        }

        private void Modificar()
        {
            string sql = "update habitaciones set" +
                $" camas='{Habitacion.Camas}'," +
                $" max_huesped='{Habitacion.MaxHuespedes}'," +
                $" planta='{Habitacion.Planta}'" +
                $" where cod='{Habitacion.Cod}'";

            LineasModificadas = BaseDatos.Modificacion(sql);
            Error = BaseDatos.Error;
        }

        /// <summary>
        /// Si la habitación gestionada existe, la elimina de la base de datos.
        /// </summary>
        public void Eliminar()
        {
            if (Existe())
            {
                string sql = $"delete from habitaciones where cod='{Habitacion.Cod}'";

                LineasModificadas = BaseDatos.Modificacion(sql);

                if (BaseDatos.Error.Contains("foreign key constraint fails"))
                    Error = "No se puede eliminar mientras existan reservas vinculadas a esta habitación.";
                else
                    Error = BaseDatos.Error;
            }
            else
            {
                Error = "Código no encontrado";
            }
        }

        private bool Existe()
        {
            BaseDatos.Consulta($"select cod from habitaciones where cod='{Habitacion.Cod}'");
            Error = BaseDatos.Error;

            return BaseDatos.ResultadoConsulta != null;
        }
    }
}
