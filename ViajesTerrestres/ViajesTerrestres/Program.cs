/*
Descripción del problema:

Se desea llevar control de la cantidad de buses que diariamente salen
a un destino particular, buscando identificar cual es el día de la 
semana con menos frecuencia de viajes y cual es el destino con más pasajeros.

Para ello, un viaje será registrado con un día de la semana,
un destino y una cantidad de pasajeros.

Se incluirán todos los días de la semana y se ingresarán 5 destinos.
Se solicitará la cantidad de viajes, mientras que la cantidad de pasajeros
será un valor aleatorio entre 5 y 40.
*/

using System;

namespace ViajesTerrestres
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programa para simular viajes terrestres");
            Console.WriteLine("Se ingresarán 5 destinos para viajar toda la semana");

            string[] losDiasSemana = {
                                        "Lunes",
                                        "Martes",
                                        "Miércoles",
                                        "Jueves",
                                        "Viernes",
                                        "Sàbado",
                                        "Domingo"};

            string[] losConductores = {
                        "Juan Rodas", 
                        "Gustavo Lora",
                        "David Barros",
                        "Nicolás Correa"
                        "Juan Builes"
            };

            Console.WriteLine("Ingresa los destinos de los viajes");

            int cantidadDestinos = 5;
            string[] losDestinos = new string[cantidadDestinos];

            int destinoActual = 1;

            //Aqui ingresamos los destinos que utilizaremos
            while (destinoActual <= cantidadDestinos)
            {
                Console.Write($"\nIngresa el destino No. {destinoActual}: ");
                losDestinos[destinoActual - 1] = Console.ReadLine()!;

                if (string.IsNullOrEmpty(losDestinos[destinoActual - 1]))
                    Console.WriteLine("El destino no debe ser vacío. Intenta nuevamente");
                else
                    destinoActual++;
            }

            bool datoCorrecto = false;
            int cantidadViajes = 0;

            //Aqui identificamos la cantidad de viaje
            do
            {
                try
                {
                    Console.Write("\nIngresa la cantidad de viajes: ");
                    cantidadViajes = int.Parse(Console.ReadLine()!);

                    if (cantidadViajes > 0)
                        datoCorrecto = true;
                    else
                        Console.WriteLine("La cantidad de viajes debe ser mayor que cero.");
                }
                catch (FormatException unError)
                {
                    Console.WriteLine("La cantidad de viajes debe ser mayor que cero.");
                    Console.Write(unError.Message);
                }
            }
            while (datoCorrecto == false);

            //Aqui inicializamos el arreglo de viajes
            Viaje[] losViajes = new Viaje[cantidadViajes];
            Random aleatorio = new Random();

            for (int i = 0; i < losViajes.Length; i++)
            {
                losViajes[i] = new Viaje();
                losViajes[i].DiaSemana = losDiasSemana[aleatorio.Next(losDiasSemana.Length)];
                losViajes[i].Destino = losDestinos[aleatorio.Next(losDestinos.Length)];
                losViajes[i].CantidadPasajeros = aleatorio.Next(5, 41);
                losViajes[i].Conductor = losConductores[aleatorio.Next(losConductores.Length)];
            }

            //Aqui visualizamos los viajes generados
            Console.WriteLine("\nLos viajes registrados son:");

            for (int i = 0; i < losViajes.Length; i++)
            {
                Console.WriteLine($"\nViaje No. {i + 1}");
                Console.WriteLine($"Dia de la semana: {losViajes[i].DiaSemana}, " +
                    $"Destino: {losViajes[i].Destino}, Cantidad Pasajeros: " +
                    $"{losViajes[i].CantidadPasajeros}\n" +
                    $"Conductor: {losViajes[i].Conductor}");
            }

            //Aqui visualizamos los viajes por Conductor
            int[] viajesPorConductor = TotalizaViajesPorConductor(losViajes, losConductores);
            Console.WriteLine("\nLos viajes por conductor fueron:");

            for (int i = 0; i < losConductores.Length; i++)
            {
                Console.WriteLine($"Conductor: {losConductores[i]}, Total viajes: " +
                    $"{viajesPorConductor[i]}");
            }


            //Aqui visualizamos los viajes por día de la semana
            int[] totalViajesPorDia = TotalizaViajesPorDia(losViajes, losDiasSemana);
            Console.WriteLine("\nLos viajes por dia fueron:");

            for (int i = 0; i < losDiasSemana.Length; i++)
            {
                Console.WriteLine($"Día: {losDiasSemana[i]}, Total viajes: " +
                    $"{totalViajesPorDia[i]}");
            }

            string diaMenosViajado = ObtieneDiaMenosViajado(losViajes, losDiasSemana);

            Console.WriteLine($"\nEl primer día de la semana menos viajado fue: {diaMenosViajado}");

            //Aqui visualizamos los viajes por destino
            int[] totalViajesPorDestino = TotalizaViajesPorDestino(losViajes, losDestinos);
            Console.WriteLine("\nLos viajes por destinos fueron:");

            for (int i = 0; i < losDestinos.Length; i++)
            {
                Console.WriteLine($"Día: {losDestinos[i]}, Total viajes: " +
                    $"{totalViajesPorDestino[i]}");
            }

            string destinoMasViajado = ObtieneDestinoMasViajado(losViajes, losDestinos);

            Console.WriteLine($"\nEl primer destino más viajado fue: {destinoMasViajado}");


        }

        static int[] TotalizaViajesPorDestino(Viaje[] losViajes, string[] losDestinos)
        {
            int[] viajesPorDestino = new int[losDestinos.Length];

            for (int i = 0; i < losViajes.Length; i++)
            {
                for (int j = 0; j < losDestinos.Length; j++)
                {
                    if (losViajes[i].Destino == losDestinos[j])
                        viajesPorDestino[j]++;
                }
            }

            return viajesPorDestino;
        }

        static string ObtieneDestinoMasViajado(Viaje[] losViajes, string[] losDestinos)
        {
            int[] viajesPorDestino = TotalizaViajesPorDestino(losViajes, losDestinos);

            int posicionDestinoMayor = 0;
            int viajesMayores = viajesPorDestino[posicionDestinoMayor];

            for (int i = 1; i < viajesPorDestino.Length; i++)
            {
                if (viajesPorDestino[i] > viajesMayores)
                {
                    viajesMayores = viajesPorDestino[i];
                    posicionDestinoMayor = i;
                }
            }

            return losDestinos[posicionDestinoMayor];
        }

        static int[] TotalizaViajesPorDia(Viaje[] losViajes, string[] losDias)
        {
            int[] viajesPorDia = new int[losDias.Length];

            for (int i = 0; i < losViajes.Length; i++)
            {
                for (int j = 0; j < losDias.Length; j++)
                {
                    if (losViajes[i].DiaSemana == losDias[j])
                        viajesPorDia[j]++;
                }
            }

            return viajesPorDia;
        }

        static string ObtieneDiaMenosViajado(Viaje[] losViajes, string[] losDias)
        {
            int[] viajesPorDia = TotalizaViajesPorDia(losViajes, losDias);

            int posicionDiaMenor = 0;
            int viajesMenores = viajesPorDia[posicionDiaMenor];

            for (int i = 1; i < viajesPorDia.Length; i++)
            {
                if (viajesPorDia[i] < viajesMenores)
                {
                    viajesMenores = viajesPorDia[i];
                    posicionDiaMenor = i;
                }
            }

            return losDias[posicionDiaMenor];
        }


        static int[] TotalizaViajesPorConductor(Viaje[] losViajes, string[] losConductores)
        {
            int[] totalesViajes = new int[losConductores.Length];

            for (int i = 0; i < losViajes.Length; i++)
            {
                for (int j = 0; j < losConductores.Length; j++)
                {
                    if (losViajes[i].Conductor == losConductores[j])
                        totalesViajes[j]++;
                }
            }

            return totalesViajes;
        }
    }
}
