using MySql.Data.MySqlClient;

namespace Datos
{
    static class BaseDatos
    {
        static public string Error { get; private set; }
        static public int NumRegModif { private set; get; }

        /// <summary>
        /// Resultados de la última consulta enviada a la base de datos.
        /// </summary>
        static public MySqlDataReader ResultadoConsulta { get; private set; }

        // método que conecta directamante, es decir, tiene los datos
        static private MySqlConnection Conectar()
        {
            string cadenaConexion =
            "datasource=127.0.0.1;port=3306;username=root;password=;database=proyectoprog;";
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            return (conexionBD);
        }

        //consulta de tipo SELECT
        /// <summary>
        /// Entabla conexión con la base de datos, ejecuta la consulta pasada por parámetro,
        /// y almacena los resultados en la propiedad ResultadoConsulta.
        /// </summary>
        /// <param name="sql">Consulta a procesar en lenguaje sql.</param>
        static public void Consulta(string sql)
        {
            Error = "";
            ResultadoConsulta = null;
            MySqlConnection conexionBD = Conectar();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                conexionBD.Open();
                MySqlDataReader reader = comando.ExecuteReader();
                NumRegModif = 0;

                if (reader.HasRows)
                {
                    ResultadoConsulta = reader;
                }
                else
                {
                    ResultadoConsulta = null;
                }
            }
            catch (MySqlException ex)
            {
                Error = ex.Message;
                NumRegModif = -1;
                ResultadoConsulta = null;
            }
        }

        //consulta de acción SELECT, UPDATE Y DELETE se devuelve el número de registros afectados
        /// <summary>
        /// Entabla conexión con la base de datos, ejecuta la consulta pasada por parámetro,
        /// e inmediatamente termina la conexión una vez ejecutada la consulta.
        /// </summary>
        /// <param name="sql">Consulta a procesar en lenguaje sql.</param>
        /// <returns>Cantidad de líneas modificadas.</returns>
        static public int Modificacion(string sql)
        {
            Error = "";
            MySqlConnection conexionBD = Conectar();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                conexionBD.Open();
                NumRegModif = comando.ExecuteNonQuery();
                return NumRegModif;
            }
            catch (MySqlException ex)
            {
                Error = ex.Message;
                NumRegModif = -1;
                return NumRegModif;
            }
            finally { conexionBD.Close(); }
        }
    }
}