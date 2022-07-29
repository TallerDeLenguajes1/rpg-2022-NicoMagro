using System.Text.Json;

List<personajes> jugadores = new List<personajes>();
List<personajes> ganadores = new List<personajes>();
double score = 0;
Console.WriteLine("Bienvenidos a ...");
Console.WriteLine("SON 8 LOS VALIENTES COMBATIENTES QUE SE ENFRENTARAN EN BUSCA DE LA GLORIA ETERNA");

string path = @"C:\Users\anico\workspace\tallerI\RPG-2022-NICOMAGRO\MyApp";
if (!File.Exists(path + @"/jugadores.json"))
{
    File.Create(path + @"/jugadores.json").Close();
}
path += @"/jugadores.json";

System.Console.WriteLine("Desea crear los personajes de forma aleatoria? O mediante un archivo json?");
System.Console.WriteLine("1 para aleatorio, 2 para crear mediante json");
int respuesta = 1;
respuesta = Convert.ToInt32(Console.ReadLine());
switch (respuesta)
{
    case 1:
    for (int z = 0; z < 8; z++)
    {
        datos dato = new datos();
        caracteristicas caract = new caracteristicas();
        personajes jugador = new personajes(dato, caract);
        jugadores.Add(jugador);
    }
    break;
    case 2:
    jugadores = JsonSerializer.Deserialize<List<personajes>>(File.ReadAllText(path));
    break;

    default:
    while (respuesta != 1 && respuesta != 2)
    {
        respuesta = Convert.ToInt32(Console.ReadLine());
        System.Console.WriteLine("Ingresa el numero 1 o el numero 2");
    }break;
}

var options = new JsonSerializerOptions { WriteIndented = true };
string listaJson = JsonSerializer.Serialize(jugadores, options);

File.WriteAllText(path, listaJson);

Console.WriteLine("Datos de los personajes creados: ");
int p = 1;
foreach (personajes jugador in jugadores)
{
    Console.WriteLine($"PELEADOR {p}");
    Console.WriteLine($"Nombre del jugador: {jugador.Datos.Nombre}");
    Console.WriteLine($"Apodo: {jugador.Datos.Apodo}");
    Console.WriteLine($"Tipo: {jugador.Datos.Tipo}");
    Console.WriteLine($"Fecha de Nacimiento: {jugador.Datos.FechaNac.ToShortDateString()}");
    Console.WriteLine($"Edad: {jugador.Datos.Edad}");
    Console.WriteLine($"Salud: {jugador.Datos.Salud}");
    Console.WriteLine("\n\n");
    p++;
}


int eliminar = 999;
int stage = 4;
for (int i = 0; i < 3; i++)
{
    if (jugadores.Count > stage)
    {
        switch (stage)
        {
            case 4: 
            System.Console.WriteLine("CUARTOS DE FINAL");
            break;

            case 2:
            System.Console.WriteLine("SEMIFINALES");
            break;
            
            case 1:
            System.Console.WriteLine("GRAN FINAL");
            break;
            default: break;
        }
        for (int j = 0; j < stage; j++)
        {
            bool victoria2 = false;
            for (int c = 0; c < 3; c++)
            {
                bool victoria = false;
                var batalla = new pelea();
                jugadores[j].Datos.Salud = batalla.ronda(jugadores[j+1], jugadores[j]);
                if (jugadores[j].Datos.Salud <= 0)
                {
                    System.Console.WriteLine($"{jugadores[j+1].Datos.Nombre} ha ganado el combate!!");
                    eliminar = j;
                    jugadores[j+1] = subirEstadisticas(jugadores[j+1]);
                    ganadores.Add(jugadores[j+1]);
                    c = 3;
                    victoria = true;
                }
                if (victoria == false)
                {
                    jugadores[j+1].Datos.Salud = batalla.ronda(jugadores[j], jugadores[j+1]);
                    if (jugadores[j+1].Datos.Salud <= 0)
                    {
                        System.Console.WriteLine($"{jugadores[j].Datos.Nombre} ha ganado el combate!!");
                        eliminar = j+1;
                        jugadores[j] = subirEstadisticas(jugadores[j]);
                        ganadores.Add(jugadores[j]);
                        c = 3;
                        victoria2 = true;
                    }
                }
            }
            if (jugadores[j].Datos.Salud > 0 && jugadores[j+1].Datos.Salud > 0)
            {
                if (jugadores[j].Datos.Salud > jugadores[j+1].Datos.Salud)
                {
                    System.Console.WriteLine($"{jugadores[j].Datos.Nombre} ha ganado el combate!!");
                    eliminar = j+1;
                    jugadores[j] = subirEstadisticas(jugadores[j]);
                    ganadores.Add(jugadores[j]);          
                }else if (jugadores[j].Datos.Salud < jugadores[j+1].Datos.Salud)
                {
                    System.Console.WriteLine($"{jugadores[j+1].Datos.Nombre} ha ganado el combate!!");
                    eliminar = j;
                    jugadores[j+1] = subirEstadisticas(jugadores[j+1]);
                    ganadores.Add(jugadores[j+1]);               
                }
            }
            jugadores.RemoveAt(eliminar);
        }
        stage = stage / 2;
    }
}
// int numPelea = 1;
// int cantRondas = 0;
// bool victoria = false;

// while (jugadores.Count != 0 && principal.Datos.Salud > 0)
// {
//     Console.WriteLine($"\n\nPELEA NUMERO {numPelea}\n\n");
//     while (principal.Datos.Salud > 0 && cantRondas < 3)
//     {
//         var batalla = new pelea();
//         jugadores[0].Datos.Salud = batalla.ronda(principal, jugadores[0]);
//         if (jugadores[0].Datos.Salud <= 0)
//         {
//             Console.WriteLine($"Tu luchador ha ganado la pelea!!");
//             score += jugadores[0].Datos.Salud;
//             jugadores.RemoveAt(0);
//             victoria = true;
//             cantRondas = 3;
//             principal = subirEstadisticas(principal);
//             ganadores.Add(principal);
//             Console.WriteLine("Se le subieron las estadisticas a tu luchador");
//         }

//         if (!victoria)
//         {
//             principal.Datos.Salud = batalla.ronda(jugadores[0], principal);

//             if (principal.Datos.Salud <= 0)
//             {
//                 Console.WriteLine($"\n\nTu luchador {principal.Datos.Nombre} fue derrotado!");
//                 Console.WriteLine($"Mayor suerte la proxima!");
//                 ganadores.Add(jugadores[0]);
//                 cantRondas = 3;
//             }
//             cantRondas++;
//         }
//     }
//     if (jugadores.Count != 0 && (principal.Datos.Salud < jugadores[0].Datos.Salud) && principal.Datos.Salud > 0 && jugadores[0].Datos.Salud != 3000 && cantRondas == 3)
//     {
//         Console.WriteLine($"\n\nTu luchador {principal.Datos.Nombre} fue derrotado!");
//         Console.WriteLine($"Mayor suerte la proxima!");
//         ganadores.Add(jugadores[0]);
//         principal.Datos.Salud = -10;
//     }
//     else if (jugadores.Count != 0 && (principal.Datos.Salud > jugadores[0].Datos.Salud) && jugadores[0].Datos.Salud > 0 && cantRondas == 3)
//     {
//         Console.WriteLine($"\n\nTu luchador {principal.Datos.Nombre} ha ganado la pelea!!");
//         jugadores.RemoveAt(0);
//         cantRondas = 0;
//         principal = subirEstadisticas(principal);
//         ganadores.Add(principal);
//         Console.WriteLine("Se le subieron las estadisticas a tu luchador");
//         score += 10;
//     }
//     numPelea++;
//     cantRondas = 0;
//     victoria = false;
// }

// if (jugadores.Count == 0)
// {
//     Console.WriteLine("TU JUGADOR ES EL CAMPEON!!! FELICIDADES");
// }
// else
// {
//     Console.WriteLine("Buen intento! Tu luchador perdio pero puedes jugar otra vez!!");
// }


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