namespace Negocio
{
    /// <summary>
    /// Clase encargada de mantener la estructura de una habitación en la base de datos.
    /// </summary>
    class Habitacion
    {
        public string Cod { get => _cod; set => _cod = value.PadLeft(4, '0'); }
        private string _cod;
        public int Camas { get; set; }
        public string Planta { get; set; }
        public int MaxHuespedes { get; set; }
        /// <summary>
        /// Devuelve una nueva habitación vacía.
        /// </summary>
        public Habitacion()
        {
        }

        public Habitacion(string cod, int camas, string planta, int maxHuespedes)
        {
            Cod = cod;
            Camas = camas;
            Planta = planta;
            MaxHuespedes = maxHuespedes;
        }
    }
}
