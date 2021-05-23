namespace Negocio
{
    /// <summary>
    /// Clase encargada de mantener la estructura de un cliente en la base de datos.
    /// </summary>
    class Cliente
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get;set; }
        public string Email { get; set; }
        public string Pais { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        /// <summary>
        /// Devuelve un nuevo cliente vacío.
        /// </summary>
        public Cliente()
        {
        }

        public Cliente(string dni, string nombre, string apellidos, 
            string email, string pais, string direccion, string telefono)
        {
            Dni = dni;
            Nombre = nombre;
            Apellidos = apellidos;
            Email = email;
            Pais = pais;
            Direccion = direccion;
            Telefono = telefono;
        }
        /// <summary>
        /// Genera el nombre completo del cliente.
        /// </summary>
        /// <returns>Nombre Apellidos</returns>
        public string NombreCompleto()
        {
            return $"{Nombre} {Apellidos}";
        }
    }
}
