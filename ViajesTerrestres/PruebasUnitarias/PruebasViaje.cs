using ViajesTerrestres;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasViaje
    {
        [TestMethod]
        public void ValidarPasajerosBogotaSonCinco()
        {
            //Arrange - Preparar
            string[] destinosPrueba = { 
                "Bogotá", 
                "Cali", 
                "Medellín" };

            Viaje[] viajesPrueba = {
                new Viaje() {Destino="Bogotá", CantidadPasajeros=1},
                new Viaje() {Destino= "Cali",CantidadPasajeros = 30},
                new Viaje() { Destino = "Medellín", CantidadPasajeros = 10 },
                new Viaje() { Destino = "Bogotá", CantidadPasajeros = 4 }
            };

            //Act - Actuar
            int[] totalesPorDestinoPrueba = Program.TotalizaPasajerosPorDestino(viajesPrueba, destinosPrueba);
            int cantidadPasajerosObtenida = totalesPorDestinoPrueba[0];
            int cantidadPasajerosEsperada = 5;

            //Assert - Validar
            Assert.AreEqual(cantidadPasajerosEsperada, cantidadPasajerosObtenida);
        }

        [TestMethod]
        public void ValidarPasajerosMedellinNoSonTres()
        {
            //Arrange - Preparar
            string[] destinosPrueba = {
                "Bogotá",
                "Cali",
                "Medellín" };

            Viaje[] viajesPrueba = {
                new Viaje() {Destino="Bogotá", CantidadPasajeros=1},
                new Viaje() {Destino= "Cali",CantidadPasajeros = 30},
                new Viaje() { Destino = "Medellín", CantidadPasajeros = 10 },
                new Viaje() { Destino = "Bogotá", CantidadPasajeros = 4 }
            };

            //Act - Actuar
            int[] totalesPorDestinoPrueba = Program.TotalizaPasajerosPorDestino(viajesPrueba, destinosPrueba);
            int cantidadEsperada = 3;
            int cantidadObtenida = totalesPorDestinoPrueba[2];

            // Assert
            Assert.AreNotEqual(cantidadEsperada, cantidadObtenida);
        }

        [TestMethod]
        public void ValidarViajesMartesSonTres()
        {
            //Arrange - Preparar
            string[] diasPrueba = {
                "Lunes",
                "Miercoles",
                "Viernes",                
                "Sábado",
                "Domingo",
                "Martes"};

            Viaje[] viajesPrueba = {
                new Viaje() {DiaSemana="Martes"},
                new Viaje() {DiaSemana= "Lunes"},
                new Viaje() {DiaSemana = "Viernes"},
                new Viaje() {DiaSemana= "Miercoles"},
                new Viaje() {DiaSemana = "Martes" },
                new Viaje() {DiaSemana= "Lunes"},
                new Viaje() {DiaSemana = "Martes" },
                new Viaje() {DiaSemana = "Viernes" }
            };

            //Act - Actuar - Ejecutar la función
            int[] totalesViajesPorDia = Program.TotalizaViajesPorDia(viajesPrueba, diasPrueba);
            int totalEsperado = 3;
            int totalObtenido = totalesViajesPorDia[5];

            //Assert
            Assert.AreEqual(totalEsperado, totalObtenido);
        }
    }
}