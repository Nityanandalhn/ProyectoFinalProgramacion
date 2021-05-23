namespace Negocio
{
    /// <summary>
    /// Clase encargada de mantener la estructura de un empleado en la base de datos.
    /// </summary>
    class Empleado
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public float Salario { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Turno { get; set; }
        public string Tipo { get; set; }
        /// <summary>
        /// Devuelve un nuevo empleado vacío.
        /// </summary>
        public Empleado()
        {
        }

        public Empleado(string dni, string nombre, string apellidos, float salario, string direccion, 
                         string tlf, string email, string turno, string tipo)
        {
            Dni = dni;
            Nombre = nombre;
            Apellidos = apellidos;
            Salario = salario;
            Direccion = direccion;
            Telefono = tlf;
            Email = email;
            Turno = turno;
            Tipo = tipo;
        }
        /// <summary>
        /// Genera el nombre completo del empleado.
        /// </summary>
        /// <returns>Nombre Apellidos</returns>
        public string NombreCompleto()
        {
            return $"{Nombre} {Apellidos}";
        }
    }
}
