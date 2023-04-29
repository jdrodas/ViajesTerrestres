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
            }

            //Aqui visualizamos los viajes generados
            Console.WriteLine("\nLos viajes registrados son:");

            for (int i = 0; i < losViajes.Length; i++)
            {
                Console.WriteLine($"\nViaje No. {i+1}");
                Console.WriteLine($"Dia de la semana: {losViajes[i].DiaSemana}, " +
                    $"Destino: {losViajes[i].Destino}, Cantidad Pasajeros: " +
                    $"{losViajes[i].CantidadPasajeros}");
            }
        }
    }
}