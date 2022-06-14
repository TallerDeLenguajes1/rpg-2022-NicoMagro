List<personajes> jugadores = new List<personajes>();
Console.WriteLine("Bienvenidos a ...");
Console.WriteLine("Ingrese la cantidad de luchadores que batallaran en esta arena mortal");
int cantidad = Convert.ToInt32(Console.ReadLine());
for (int i = 0; i < cantidad; i++)
{
    datos dato = new datos();
    caracteristicas caract = new caracteristicas();
    personajes jugador = new personajes(dato, caract);
    jugadores.Add(jugador);   
}

Console.WriteLine("Datos de los personajes creados: ");
int j = 1;
foreach (personajes jugador in jugadores)
{
    Console.WriteLine($"PELADOR {j}");
    Console.WriteLine($"Nombre del jugador: {jugador.Datos.Nombre}");
    Console.WriteLine($"Apodo: {jugador.Datos.Apodo}");
    Console.WriteLine($"Tipo: {jugador.Datos.Tipo}");
    Console.WriteLine($"Fecha de Nacimiento: {jugador.Datos.FechaNac}");
    Console.WriteLine($"Edad: {jugador.Datos.Edad}");
    Console.WriteLine($"Salud: {jugador.Datos.Salud}");
    Console.WriteLine("\n\n");
    j++;
}

Console.WriteLine("================================================================");
Console.WriteLine("Elije al luchador que seguira tus instrucciones en este siniestro mundo");
Console.WriteLine("(Debe ser el numero los mencionados previamente)");
int eleccion = Convert.ToInt32(Console.ReadLine());
personajes principal = jugadores[eleccion-1];

jugadores.RemoveAt(eleccion - 1);

Console.WriteLine($"El personaje elegido es: {principal.Datos.Nombre}");
Console.WriteLine("Buena suerte en tu aventura junto a tu luchador");

var batalla = new pelea();

principal.Datos.Salud = batalla.ronda(jugadores[0], principal);