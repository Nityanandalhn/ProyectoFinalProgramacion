namespace Negocio
{
    /// <summary>
    /// Clase encargada de mantener la estructura de un plan de ventas de habitaciones en la base de datos.
    /// </summary>
    class PlanVentas
    {
        public string Tipo { get; set; }
        public string Comidas { get; set; }
        public string Temporada { get; set; }
        public double Precio { get; set; }
        /// <summary>
        /// Devuelve un nuevo plan de ventas vacío.
        /// </summary>
        public PlanVentas()
        {
        }

        public PlanVentas(string tipo, string comidas, string temporada, double precio)
        {
            Tipo = tipo;
            Comidas = comidas;
            Temporada = temporada;
            Precio = precio;
        }
    }
}
