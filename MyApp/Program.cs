List<personajes> jugadores = new List<personajes>();
List<personajes> ganadores = new List<personajes>();
double score = 0;
Console.WriteLine("Bienvenidos a ...");
Console.WriteLine("Ingrese la cantidad de luchadores que batallaran en esta arena mortal");
int cantidad = Convert.ToInt32(Console.ReadLine());
while (cantidad <= 1)
{
    Console.WriteLine("Elige un numero mayor que 1");
    cantidad = Convert.ToInt32(Console.ReadLine());
}
for (int z = 0; z < cantidad; z++)
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
    Console.WriteLine($"PELEADOR {j}");
    Console.WriteLine($"Nombre del jugador: {jugador.Datos.Nombre}");
    Console.WriteLine($"Apodo: {jugador.Datos.Apodo}");
    Console.WriteLine($"Tipo: {jugador.Datos.Tipo}");
    Console.WriteLine($"Fecha de Nacimiento: {jugador.Datos.FechaNac.ToShortDateString()}");
    Console.WriteLine($"Edad: {jugador.Datos.Edad}");
    Console.WriteLine($"Salud: {jugador.Datos.Salud}");
    Console.WriteLine("\n\n");
    j++;
}

Console.WriteLine("================================================================");
Console.WriteLine("Elije al luchador que seguira tus instrucciones en este siniestro mundo");
Console.WriteLine("(Debe ser el numero los mencionados previamente)");
int eleccion = Convert.ToInt32(Console.ReadLine());
personajes principal = jugadores[eleccion - 1];

jugadores.RemoveAt(eleccion - 1);

Console.WriteLine($"El personaje elegido es: {principal.Datos.Nombre}");
Console.WriteLine("Buena suerte en tu aventura junto a tu luchador");

int numPelea = 1;
int cantRondas = 0;
bool victoria = false;

while (jugadores.Count != 0 && principal.Datos.Salud > 0)
{
    Console.WriteLine($"\n\nPELEA NUMERO {numPelea}\n\n");
    while (principal.Datos.Salud > 0 && cantRondas < 3)
    {
        var batalla = new pelea();
        jugadores[0].Datos.Salud = batalla.ronda(principal, jugadores[0]);
        if (jugadores[0].Datos.Salud <= 0)
        {
            Console.WriteLine($"Tu luchador ha ganado la pelea!!");
            score += jugadores[0].Datos.Salud;
            jugadores.RemoveAt(0);
            victoria = true;
            cantRondas = 3;
            principal = subirEstadisticas(principal);
            ganadores.Add(principal);
            Console.WriteLine("Se le subieron las estadisticas a tu luchador");
        }

        if (!victoria)
        {
            principal.Datos.Salud = batalla.ronda(jugadores[0], principal);

            if (principal.Datos.Salud <= 0)
            {
                Console.WriteLine($"\n\nTu luchador {principal.Datos.Nombre} fue derrotado!");
                Console.WriteLine($"Mayor suerte la proxima!");
                ganadores.Add(jugadores[0]);
                cantRondas = 3;
            }
            cantRondas++;
        }
    }
    if (jugadores.Count != 0 && (principal.Datos.Salud < jugadores[0].Datos.Salud) && principal.Datos.Salud > 0 && jugadores[0].Datos.Salud != 3000 && cantRondas == 3)
    {
        Console.WriteLine($"\n\nTu luchador {principal.Datos.Nombre} fue derrotado!");
        Console.WriteLine($"Mayor suerte la proxima!");
        ganadores.Add(jugadores[0]);
        principal.Datos.Salud = -10;
    }
    else if (jugadores.Count != 0 && (principal.Datos.Salud > jugadores[0].Datos.Salud) && jugadores[0].Datos.Salud > 0 && cantRondas == 3)
    {
        Console.WriteLine($"\n\nTu luchador {principal.Datos.Nombre} ha ganado la pelea!!");
        jugadores.RemoveAt(0);
        cantRondas = 0;
        principal = subirEstadisticas(principal);
        ganadores.Add(principal);
        Console.WriteLine("Se le subieron las estadisticas a tu luchador");
        score += 10;
    }
    numPelea++;
    cantRondas = 0;
    victoria = false;
}

if (jugadores.Count == 0)
{
    Console.WriteLine("TU JUGADOR ES EL CAMPEON!!! FELICIDADES");
}
else
{
    Console.WriteLine("Buen intento! Tu luchador perdio pero puedes jugar otra vez!!");
}


string ruta = @"C:\Users\anico\workspace\tallerI\rpg-2022-NicoMagro\MyApp\ganadores.csv";

escribirGanadores(ganadores, ruta, score);

leerGanadores(ruta);









personajes subirEstadisticas(personajes luchador)
{
    luchador.Datos.Salud += 300;
    luchador.Caract.Fuerza += 2;
    luchador.Caract.Destreza += 1;

    return luchador;
}

static void escribirGanadores(List<personajes> ganadores, string ruta, double score)
{
    using (StreamWriter file = new StreamWriter(ruta, true))
    {
        file.WriteLine("\n\n==========Lista de Ganadores y Puntuacion Final==========");
        file.Close();
    }
    foreach (personajes item in ganadores)
    {
        string luchadorGanador = item.Datos.Nombre;
        using (StreamWriter file = File.AppendText(ruta))
        {
            file.WriteLine(luchadorGanador);
            file.Close();
        }
    }
    string puntuacion = Convert.ToString(score);
    puntuacion = "Puntuacion Final: " + puntuacion;
    using (StreamWriter file = new StreamWriter(ruta, true))
    {
        file.WriteLine(puntuacion);
        file.Close();
    }
}

static void leerGanadores(string ruta)
{
    string line = "";
    using (StreamReader file = File.OpenText(ruta))
    {
        line = file.ReadToEnd();
        Console.WriteLine(line);
        file.Close();
        File.Delete(ruta);
    }
}