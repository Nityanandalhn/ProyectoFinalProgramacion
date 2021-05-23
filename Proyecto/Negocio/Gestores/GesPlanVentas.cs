using Datos;
using System.Collections.Generic;

namespace Negocio
{
    /// <summary>
    /// Clase encargada de gestionar todo lo relacionado con uno o varios planes de venta.
    /// </summary>
    class GesPlanVentas
    {
        public PlanVentas PlanVentas { get; set; }
        public List<PlanVentas> Planes { get; private set; }
        public int LineasModificadas { get; private set; }
        public string Error { get; private set; }

        /// <summary>
        /// Devuelve un nuevo gestor de planes de venta con una listado de todos los planes
        /// encontrados en la base de datos.
        /// </summary>
        public GesPlanVentas()
        {
            BuscarTodosPlanes();

            if(Planes == null)
                Planes = new List<PlanVentas>();
        }
        /// <summary>
        /// Reemplaza el listado de planes de venta por un nuevo listado extraido desde la base de datos.
        /// </summary>
        public void BuscarTodosPlanes()
        {
            BuscarPlanes("", "", "", "");
        }
        /// <summary>
        /// Reemplaza el listado de planes de venta por un nuevo listado extraido desde la base de datos
        /// en función de los filtros pasados por parámetro.
        /// Es posible ignorar un filtro pasando un string vacío en su lugar.
        /// </summary>
        /// <param name="tipo">Tipo de plan de ventas</param>
        /// <param name="comidas">Siglas del plan de comidas ofrecido</param>
        /// <param name="precio">Precio por noche</param>
        /// <param name="temporada">Identificador por si se crean diferentes planes para temporadas concretas</param>
        public void BuscarPlanes(string tipo, string comidas, string precio, string temporada)
        {
            string busqueda = "where 1=1";
            busqueda += tipo == ""  ? "" : $" and tipo='{tipo}'";
            busqueda += comidas == "" ? "" : $" and comidas='{comidas}'";
            busqueda += precio == "" ? "" : $" and precio_por_noche='{precio}'";
            busqueda += temporada == "" ? "" : $" and temporada='{temporada}'";

            BaseDatos.Consulta($"select * from plan_ventas {busqueda}");
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
            Planes = new List<PlanVentas>();

            while (BaseDatos.ResultadoConsulta != null && BaseDatos.ResultadoConsulta.Read())
            {
                if (int.TryParse(BaseDatos.ResultadoConsulta["precio_por_noche"].ToString(), out int precio))
                {
                    Planes.Add(new PlanVentas()
                    {
                        Temporada = BaseDatos.ResultadoConsulta["temporada"].ToString(),
                        Comidas = BaseDatos.ResultadoConsulta["comidas"].ToString(),
                        Tipo = BaseDatos.ResultadoConsulta["tipo"].ToString(),
                        Precio = precio
                    });
                }
            }

            Planes.Sort((p1, p2) => {
                if (p1.Temporada == p2.Temporada)
                    return p1.Precio.CompareTo(p2.Precio);
                return p1.Temporada.CompareTo(p2.Temporada);
            });
        }
        /// <summary>
        /// Si el plan de ventas gestionado actualmente existe, lo modifica en la base de datos.
        /// En caso contraro, inserta un nuevo plan con los datos actuales en la base de datos.
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
            string sql = "insert into plan_ventas (temporada,tipo,precio_por_noche,comidas) " +
                $"values ('{PlanVentas.Temporada}','{PlanVentas.Tipo}','{PlanVentas.Precio}','{PlanVentas.Comidas}')";

            BaseDatos.Modificacion(sql);
            Error = BaseDatos.Error;
        }

        private void Modificar()
        {
            string sql = "update plan_ventas set" +
                $" temporada='{PlanVentas.Temporada}'," +
                $" precio_por_noche='{PlanVentas.Precio}'," +
                $" comidas='{PlanVentas.Comidas}'" +
                $" where tipo='{PlanVentas.Tipo}'";

            LineasModificadas = BaseDatos.Modificacion(sql);
            Error = BaseDatos.Error;
        }
        /// <summary>
        /// Si existe, elimina el plan de ventas actual de la base de datos.
        /// </summary>
        public void Eliminar()
        {
            if (Existe())
            {
                string sql = $"delete from plan_ventas where tipo='{PlanVentas.Tipo}'";

                LineasModificadas = BaseDatos.Modificacion(sql);

                if (BaseDatos.Error.Contains("foreign key constraint fails"))
                    Error = "No se puede eliminar mientras existan reservas vinculadas a este plan.";
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
            BaseDatos.Consulta($"select tipo from plan_ventas where tipo='{PlanVentas.Tipo}'");
            Error = BaseDatos.Error;

            return BaseDatos.ResultadoConsulta != null;
        }
    }
}
