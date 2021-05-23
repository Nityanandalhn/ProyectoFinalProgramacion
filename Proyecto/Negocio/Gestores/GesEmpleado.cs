using Datos;
using System.Collections.Generic;

namespace Negocio
{
    /// <summary>
    /// Clase encargada de gestionar todo lo relacionado con uno o varios empleados,
    /// exceptuando sus credenciales de acceso a la aplicación.
    /// </summary>
    class GesEmpleado
    {
        public Empleado Empleado { get; set; }
        public List<Empleado> Empleados { get; private set; }
        public int LineasModificadas { get; private set; }
        public string Error { get; private set; }

        /// <summary>
        /// Devuelve un nuevo gestor de empleados con un listado de todos los empleados
        /// encontrados en la base de datos.
        /// </summary>
        public GesEmpleado()
        {
            BuscarTodos();
            if (Empleados == null)
                Empleados = new List<Empleado>();
        }

        /// <summary>
        /// Reemplaza el listado de empleados por uno nuevo extraido desde la base de datos. Excluyendo
        /// los datos de acceso a la aplicación.
        /// </summary>
        public void BuscarTodos()
        {
            BuscarEmpleados("", "", "", "", "", "", "", "", "");
        }

        /// <summary>
        /// Reemplaza el listado de empleados por uno nuevo extraido desde la base de datos, en función de
        /// los filtros pasados como parámetro. Excluyendo los datos de acceso a la aplicación.
        /// Es posible ignorar un filtro pasando un string vacío en su lugar.
        /// </summary>
        /// <param name="nombre">Nombre del empleado</param>
        /// <param name="apellidos">Apellidos del empleado</param>
        /// <param name="email">Dirección de correo electrónico del empleado</param>
        /// <param name="tlf">Teléfono del empleado</param>
        /// <param name="dni">DNI o NIF del empleado</param>
        /// <param name="turno">Turno del empleado</param>
        /// <param name="direccion">Dirección física del empleado</param>
        /// <param name="tipo">Tipo de empleado (Recepción,Limpieza,Gerencia...)</param>
        /// <param name="salario">Salario del empleado</param>
        public void BuscarEmpleados(string nombre, string apellidos, string email, string tlf,
            string dni, string turno, string direccion, string tipo, string salario)
        {
            string busqueda = "where 1=1";
            busqueda += nombre == "" ? "" : $" and nombre like '{nombre}%'";
            busqueda += apellidos == "" ? "" : $" and apellidos like '{apellidos}%'";
            busqueda += email == "" ? "" : $" and email like '{email}%'";
            busqueda += tlf == "" ? "" : $" and tlf='{tlf}'";
            busqueda += dni == "" ? "" : $" and dni like '{dni}%'";
            busqueda += turno == "" ? "" : $" and turno like '{turno}%'";
            busqueda += direccion == "" ? "" : $" and direccion like '{direccion}%'";
            busqueda += tipo == "" ? "" : $" and tipo like '{tipo}%'";
            busqueda += salario == "" ? "" : $" and salario='{salario}'";

            BaseDatos.Consulta("select nombre,apellidos,email,tlf,dni,turno,direccion,tipo,salario" +
                $" from empleados {busqueda}");
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
            Empleados = new List<Empleado>();

            while (BaseDatos.ResultadoConsulta != null && BaseDatos.ResultadoConsulta.Read())
            {
                Empleados.Add(new Empleado()
                {
                    Apellidos = BaseDatos.ResultadoConsulta["apellidos"].ToString(),
                    Telefono = BaseDatos.ResultadoConsulta["tlf"].ToString(),
                    Direccion = BaseDatos.ResultadoConsulta["direccion"].ToString(),
                    Dni = BaseDatos.ResultadoConsulta["dni"].ToString(),
                    Nombre = BaseDatos.ResultadoConsulta["nombre"].ToString(),
                    Email = BaseDatos.ResultadoConsulta["email"].ToString(),
                    Salario = float.Parse(BaseDatos.ResultadoConsulta["salario"].ToString()),
                    Tipo = BaseDatos.ResultadoConsulta["tipo"].ToString(),
                    Turno = BaseDatos.ResultadoConsulta["turno"].ToString()
                });
            }

            Empleados.Sort((e1, e2) =>
            {
                if (e1.Nombre == e2.Nombre)
                    return e1.Apellidos.CompareTo(e2.Apellidos);
                return e1.Nombre.CompareTo(e2.Nombre);
            });
        }

        /// <summary>
        /// Si existe, modifica los detalles del empleado gestionado en la base de datos.
        /// En caso contrario, introduce un nuevo empleado en la base de datos con los datos
        /// del empleado gestionado actualmente.
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
            string sql = "insert into empleados (dni,nombre,apellidos,tlf,direccion,email,salario,tipo,turno) " +
                $"values ('{Empleado.Dni}','{Empleado.Nombre}','{Empleado.Apellidos}','{Empleado.Telefono}'" +
                $",'{Empleado.Direccion}','{Empleado.Email}','{Empleado.Salario}','{Empleado.Tipo}','{Empleado.Turno}')";

            BaseDatos.Modificacion(sql);
            Error = BaseDatos.Error;
        }

        private void Modificar()
        {
            string sql = "update empleados set" +
                $" tlf='{Empleado.Telefono}'," +
                $" apellidos='{Empleado.Apellidos}'," +
                $" nombre='{Empleado.Nombre}'," +
                $" email='{Empleado.Email}'," +
                $" direccion='{Empleado.Direccion}'," +
                $" tipo='{Empleado.Tipo}'," +
                $" turno='{Empleado.Turno}'," +
                $" salario='{Empleado.Salario}'" +
                $" where dni='{Empleado.Dni}'";

            LineasModificadas = BaseDatos.Modificacion(sql);
            Error = BaseDatos.Error;
        }

        /// <summary>
        /// Si existe, elimina el empleado gestionado actualmente de la base de datos.
        /// </summary>
        public void Eliminar()
        {
            if (Existe())
            {
                string sql = $"delete from empleados where dni='{Empleado.Dni}'";

                LineasModificadas = BaseDatos.Modificacion(sql);

                if (BaseDatos.Error.Contains("foreign key constraint fails"))
                    Error = "No se puede eliminar mientras existan reservas vinculadas a este empleado.";
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
            BaseDatos.Consulta($"select dni from empleados where dni='{Empleado.Dni}'");
            Error = BaseDatos.Error;

            return BaseDatos.ResultadoConsulta != null;
        }
    }
}
