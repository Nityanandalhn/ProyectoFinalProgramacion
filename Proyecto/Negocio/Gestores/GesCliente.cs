using Datos;
using System.Collections.Generic;

namespace Negocio
{
    /// <summary>
    /// Clase encargada de gestionar todo lo relacionado con uno o varios clientes.
    /// </summary>
    class GesCliente
    {
        public Cliente Cliente { get; set; }
        public List<Cliente> Clientes { get; private set; }
        public string Error { get; private set; }
        public int LineasModificadas { get; private set; }

        /// <summary>
        /// Devuelve un nuevo gestor de clientes con un listado de todos los clientes
        /// encontrados en la base de datos.
        /// </summary>
        public GesCliente()
        {
            BuscarTodos();

            if (Clientes == null)
                Clientes = new List<Cliente>();
        }

        /// <summary>
        /// Reemplaza el listado de clientes por uno nuevo extraido desde la base de datos.
        /// </summary>
        public void BuscarTodos()
        {
            BuscarClientes("", "", "", "", "", "", "");
        }

        /// <summary>
        /// Reemplaza el listado de clientes por uno nuevo extraido desde la base de datos
        /// en función a los filtros pasados como parámetro.
        /// Es posible ignorar un filtro pasando un string vacío en su lugar.
        /// </summary>
        /// <param name="nombre">Nombre del cliente</param>
        /// <param name="apellidos">Apellidos del cliente</param>
        /// <param name="email">Dirección de correo electrónico del cliente</param>
        /// <param name="tlf">Teléfono del cliente</param>
        /// <param name="dni">DNI o NIF del cliente</param>
        /// <param name="pais">País de residencia habitual del cliente</param>
        /// <param name="direccion">Dirección física del cliente</param>
        public void BuscarClientes(string nombre, string apellidos, string email, string tlf,
            string dni, string pais, string direccion)
        {
            string busqueda = "where 1=1";
            busqueda += nombre == "" ? "" : $" and nombre='{nombre}'";
            busqueda += apellidos == "" ? "" : $" and apellidos='{apellidos}'";
            busqueda += email == "" ? "" : $" and email='{email}'";
            busqueda += tlf == "" ? "" : $" and tlf='{tlf}'";
            busqueda += dni == "" ? "" : $" and dni_pasaporte='{dni}'";
            busqueda += pais == "" ? "" : $" and pais='{pais}'";
            busqueda += direccion == "" ? "" : $" and direccion='{direccion}'";

            BaseDatos.Consulta($"select * from clientes {busqueda}");
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
            Clientes = new List<Cliente>();

            while (BaseDatos.ResultadoConsulta != null && BaseDatos.ResultadoConsulta.Read())
            {
                Clientes.Add(new Cliente()
                {
                    Apellidos = BaseDatos.ResultadoConsulta["apellidos"].ToString(),
                    Telefono = BaseDatos.ResultadoConsulta["tlf"].ToString(),
                    Direccion = BaseDatos.ResultadoConsulta["direccion"].ToString(),
                    Dni = BaseDatos.ResultadoConsulta["dni_pasaporte"].ToString(),
                    Nombre = BaseDatos.ResultadoConsulta["nombre"].ToString(),
                    Email = BaseDatos.ResultadoConsulta["email"].ToString(),
                    Pais = BaseDatos.ResultadoConsulta["pais"].ToString(),
                });
            }

            Clientes.Sort((c1, c2) =>
            {
                if (c1.Nombre == c2.Nombre)
                    return c1.Apellidos.CompareTo(c2.Apellidos);
                return c1.Nombre.CompareTo(c2.Nombre);
            });
        }

        /// <summary>
        /// Si el cliente gestionado actualmente existe, lo modifica en la base de datos.
        /// En caso contrario, introduce un nuevo cliente en la base de datos con los datos actuales.
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
            string sql = "insert into clientes (dni_pasaporte,nombre,apellidos,tlf,direccion,email,pais) " +
                $"values ('{Cliente.Dni}','{Cliente.Nombre}','{Cliente.Apellidos}','{Cliente.Telefono}'" +
                $",'{Cliente.Direccion}','{Cliente.Email}','{Cliente.Pais}')";

            BaseDatos.Modificacion(sql);
            Error = BaseDatos.Error;
        }

        private void Modificar()
        {
            string sql = "update clientes set" +
                $" tlf='{Cliente.Telefono}'," +
                $" apellidos='{Cliente.Apellidos}'," +
                $" nombre='{Cliente.Nombre}'," +
                $" email='{Cliente.Email}'," +
                $" direccion='{Cliente.Direccion}'," +
                $" pais='{Cliente.Pais}'" +
                $" where dni_pasaporte='{Cliente.Dni}'";

            LineasModificadas = BaseDatos.Modificacion(sql);
            Error = BaseDatos.Error;
        }

        /// <summary>
        /// Si existe el cliente gestionado actualmente, lo elimina de la base de datos.
        /// </summary>
        public void Eliminar()
        {
            if (Existe())
            {
                string sql = $"delete from clientes where dni_pasaporte='{Cliente.Dni}'";

                LineasModificadas = BaseDatos.Modificacion(sql);

                if (BaseDatos.Error.Contains("foreign key constraint fails"))
                    Error = "No se puede eliminar mientras existan reservas vinculadas a este cliente.";
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
            BaseDatos.Consulta($"select dni_pasaporte from clientes where dni_pasaporte='{Cliente.Dni}'");
            Error = BaseDatos.Error;

            return BaseDatos.ResultadoConsulta != null;
        }
    }
}
