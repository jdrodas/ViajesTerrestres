namespace ViajesTerrestres
{
    public class Viaje
    {
        //Los atributos
        private string destino, diaSemana, conductor;
        private int cantidadPasajeros;

        //El constructor de la clase
        public Viaje()
        {
            destino = string.Empty;
            diaSemana = string.Empty;
            conductor = string.Empty;
            cantidadPasajeros = 0;
        }

        //Las propiedades para manipular los atributos
        public string Destino
        {
            get { return destino; }
            set { destino = value; }
        }

        public string DiaSemana
        {
            get { return diaSemana; }
            set { diaSemana = value; }
        }

        public string Conductor
        {
            get { return conductor; }
            set { conductor = value; }
        }

        public int CantidadPasajeros
        {
            get { return cantidadPasajeros; }
            set { cantidadPasajeros = value; }
        }
    }
}
