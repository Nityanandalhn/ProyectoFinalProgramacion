using Datos;
using System;
using System.IO;
namespace Negocio.Utils
{
    /// <summary>
    /// Clase encargada de administrar el acceso a la aplicación.
    /// </summary>
    static class Login
    {
        public static string Error { get; private set; }
        public static Empleado EmpleadoActivo { get; private set; }
        /// <summary>
        /// Confirma la validez de los datos introducidos por parámetro.
        /// </summary>
        /// <param name="id">Identificador de sesión</param>
        /// <param name="pwd">Contraseña</param>
        /// <returns>Verdadero si existe exactamente igual en la base de datos.
        /// Falso en caso contrario.</returns>
        public static bool IniciarSesion(string id, string pwd)
        {
            BaseDatos.Consulta($"select acceso from empleados where dni='{id}'");

            Error = BaseDatos.Error;

            if (BaseDatos.ResultadoConsulta != null && BaseDatos.ResultadoConsulta.Read())
            {
                EmpleadoActivo = new Empleado()
                {
                    Dni = id
                };

                return pwd.Equals(BaseDatos.ResultadoConsulta[0]);
            }

            return false;
        }
        /// <summary>
        /// Método que altera de forma secuencial el texto que recibe por parámetro.
        /// </summary>
        /// <param name="pwd">Cadena de texto a transformar.</param>
        /// <returns>Una cadena de texto transformada.</returns>
        public static string Encriptar(string pwd)
        {
            //Despreciado para mejorarlo en un futuro por una versión incapaz de causar errores en la base de datos.
            string semilla = "190assd198saxmbcxmn1ad981hjkkasdc012hkjaskñps";
            pwd += semilla;

            long valor = 1;

            foreach (char c in pwd)
            {
                valor += c * c * c * c * c * c * c * c * 7;
            }

            valor *= valor;

            return OcultarClave(valor);
        }

        private static string OcultarClave(long valor)
        {
            string clave = valor.ToString();
            string resultado = "";

            for (int i = 1; i < clave.Length; i++)
            {
                if (i % 3 == 0)
                    resultado += ((char)(clave[i] + clave[i - 1])).ToString().ToUpper();

                if (i % 2 == 0 || i % 5 == 0)
                    resultado += i;

                if (i % 7 == 0 || i % 9 == 0)
                    resultado += resultado[(i - 5)..i];

                resultado += ((char)(clave[i] + clave[i - 1])).ToString();
            }

            return resultado;
        }
        /// <summary>
        /// Método que comprueba si existen empleados capaces de gestionar la base de datos.
        /// </summary>
        /// <returns>Verdadero si encuentra algún empleado validado. Falso en caso contrario.</returns>
        public static bool NoHayEmpleadosConAcceso()
        {
            BaseDatos.Consulta("select * from empleados where acceso != 'block'");
            Error = BaseDatos.Error;

            return BaseDatos.ResultadoConsulta == null;
        }
        /// <summary>
        /// Genera un nuevo empleado con Dni: Admin - Contraseña: admin - Nombre: Administrador.
        /// </summary>
        public static void CrearAdminAdmin()
        {
            BaseDatos.Modificacion($"insert into empleados(dni,nombre,acceso) values('Admin','Administrador','admin')");
            Error = BaseDatos.Error;
        }
        /// <summary>
        /// Almacena el string pasado como parámetro dentro del fichero "datos" para su posterior letura.
        /// </summary>
        /// <param name="id">Identificador de inicio de sesión.</param>
        public static void GuardarId(string id)
        {
            Error = "";
            try
            {
                using (StreamWriter sw = new StreamWriter("datos"))
                {
                    sw.WriteLine(id);
                }
            }
            catch (IOException)
            {
                Error = "Ha ocurrido un problema al tratar de guardar los detalles de la última sesión.";
            }
            catch (Exception)
            {
                Error = "Fallo crítico del sistema.";
            }
        }
        /// <summary>
        /// Recupera el identificador de sesión si existe en el fichero "datos"
        /// </summary>
        /// <returns>Identificador de sesión.</returns>
        public static string CargarId()
        {
            Error = "";
            try
            {
                using (StreamReader sr = new StreamReader("datos"))
                {
                    return sr.ReadLine();
                }
            }
            catch (IOException)
            {
                Error = "Ha ocurrido un problema al tratar de cargar los detalles de la última sesión.";
            }
            catch (Exception)
            {
                Error = "Fallo crítico del sistema.";
            }

            return "";
        }
    }
}
