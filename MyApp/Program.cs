using System.Text.Json;

List<personajes> jugadores = new List<personajes>();
List<personajes> ganadores = new List<personajes>();
Console.WriteLine("Bienvenidos a ...");
Console.WriteLine("SON 8 LOS VALIENTES COMBATIENTES QUE SE ENFRENTARAN EN BUSCA DE LA GLORIA ETERNA");

string path = @"C:\Users\anico\workspace\tallerI\RPG-2022-NICOMAGRO\MyApp";
if (!File.Exists(path + @"/jugadores.json"))
{
    File.Create(path + @"/jugadores.json").Close();
}
path += @"/jugadores.json";


string ruta = @"C:\Users\anico\workspace\tallerI\rpg-2022-NicoMagro\MyApp\ganadores.csv";
System.Console.WriteLine("1)Ver registro de los ganadores anteriores");
System.Console.WriteLine("2)Continuar al juego");
System.Console.WriteLine("Seleccione una opcion: ");
int option = Convert.ToInt32(Console.ReadLine());
if (option == 1)
{
    leerGanadores(ruta);
}
File.Delete(ruta);

System.Console.WriteLine("Como desea crear los nuevos jugadores?");
System.Console.WriteLine("1)De forma aleatoria.");
System.Console.WriteLine("2)Crearlos mediante un archivo json.");
System.Console.WriteLine("Seleccione una opcion: ");
int respuesta = 1;

respuesta = eleccionTipoCreacion(ref jugadores, path);

var options = new JsonSerializerOptions { WriteIndented = true };
string listaJson = JsonSerializer.Serialize(jugadores, options);

File.WriteAllText(path, listaJson);

Console.WriteLine("Datos de los personajes creados: ");
mostrarJugadores(jugadores);

int demora = 35;
int eliminar = 999;
int stage = 4;
for (int i = 0; i < 3; i++)
{
    if (jugadores.Count > stage)
    {
        switch (stage)
        {
            case 4:
                MostrarDelay("\n\n\n================", demora);
                MostrarDelay("CUARTOS DE FINAL", demora);
                MostrarDelay("================\n", demora);
                break;

            case 2:
                MostrarDelay("\n\n\n===========", demora);
                MostrarDelay("SEMIFINALES", demora);
                MostrarDelay("===========\n", demora);
                break;

            case 1:
                MostrarDelay("\n\n\n==========", demora);
                MostrarDelay("GRAN FINAL", demora);
                MostrarDelay("==========\n", demora);
                break;
            default: break;
        }
        for (int j = 0; j < stage; j++)
        {
            eliminar = combate(jugadores, ganadores, eliminar, j);
        }
        stage = stage / 2;
    }
}
MostrarDelay($"{jugadores[0].Datos.Nombre.ToUpper()} ES EL GANADOR DEL TORNEOO!!!!\n", 60);

System.Console.WriteLine(@"__________________________________________________
____________________________1111__________________
___________________________11_1¶¶1________________
___________________________11_1__¶¶1______________
___________________________11_1¶1_1¶¶_____________
___________________________11_1¶¶¶1_¶¶1___________
____________________________1_1¶¶¶¶1_1¶1__________
___________________________11_1¶¶¶¶¶¶11¶¶_________
___________________________1__¶1¶¶¶¶¶¶11¶1________
___________________________1_1¶1¶¶¶¶¶1¶11¶1_______
_____________________11¶__11_¶¶1¶¶¶¶¶¶1¶1¶¶_______
____________________111¶¶¶1_1¶1¶¶¶¶¶¶¶1¶¶1¶¶______
____________________1_11_1_1¶¶1¶¶¶¶¶¶¶¶1¶1¶¶______
____________________11¶¶111¶¶11¶¶1¶¶¶¶¶1¶¶1¶1_____
____________________11¶¶11¶111¶¶¶__¶¶¶¶1¶¶1¶¶_____
___________________11¶1¶¶1111¶¶¶¶___¶¶¶¶1¶¶¶¶1____
__________________1¶¶11¶¶¶¶¶¶¶¶¶1___1¶¶¶1¶1¶¶1____
__________________¶¶¶11¶¶¶¶¶¶¶¶¶_____¶¶¶1¶¶¶¶¶____
_________________¶¶¶11¶¶¶¶¶¶11¶1_____¶¶¶1¶¶¶¶¶____
_________________¶¶¶11¶¶¶¶¶¶______1__¶¶¶1¶¶¶¶1____
________________1¶¶11¶¶¶¶¶¶______11__¶¶¶¶¶¶¶¶1____
________________1¶¶1¶¶¶¶¶¶___11111___¶¶1¶¶¶¶¶_____
_________________¶¶1¶¶¶¶¶1___1111____¶¶1¶¶¶¶______
__________________¶¶¶¶¶¶¶__111111___¶¶11¶¶¶_______
___________________¶¶¶¶¶¶_1111111__¶¶¶¶¶¶¶________
_______________1111111¶¶¶__1__111_¶¶¶¶¶1__________
_______________¶1_______11_111___1¶11¶1__11_______
________________11111¶1111111¶_11_________¶¶1_____
_________________¶1111111111¶¶_111_11_1¶1¶¶¶______
__________________¶111111111¶111111111¶¶¶¶________
__________________111¶11¶11¶¶¶¶1¶¶1¶1¶¶¶¶_________
__________________¶11111111¶¶¶11¶11¶¶¶¶¶__________
__________________1111111111¶11¶11111¶¶¶__________
___________________1¶1111111¶1¶11¶1¶¶¶1___________
___________________11111111¶111111¶¶¶¶____________
___________________11111111¶¶¶11111¶¶1____________
____________________1111111¶¶111111¶¶_____________
____________________1111111¶¶111111¶¶_____________
____________________1111111¶¶111111¶¶_____________
____________________¶111111¶111111¶¶1_____________
____________________¶11111¶¶¶11111¶¶______________
____________________¶11111¶¶¶11111¶¶______________
___________________1¶11111¶¶_11111¶¶______________
____________________¶111111¶¶1111¶¶1______________
____________________1111111¶¶1111¶¶_______________
____________________111111¶¶11111¶¶_______________
____________________¶111111¶1111¶¶1_______________
____________________111111¶¶1111¶¶1_______________
____________________111111¶¶111¶¶¶________________
____________________11111¶¶111¶¶¶1________________
____________________11111¶¶111¶¶¶_________________
____________________11111¶¶111¶¶__________________
__________________1111111¶¶11¶¶¶__________________
________________1¶¶11¶¶¶¶¶¶11¶¶¶__________________
______________1¶¶¶¶¶11111111¶¶¶¶1_________________
____________11¶111____1____¶¶¶¶¶__________________
_1111111111111_111¶¶¶¶¶¶¶¶¶¶¶¶¶¶__________________
_________111111¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶___________________
_11111111¶¶¶¶¶¶¶¶¶¶¶¶111¶111¶¶____________________
_¶¶¶11¶¶¶¶¶¶¶¶¶¶¶¶¶¶11111_11¶1____________________
_111¶¶¶¶¶¶¶¶11111______1¶11¶¶_____________________
_¶¶¶¶11_____________1111¶11¶¶_____________________
_____________________111¶11¶¶_____________________
_____________________1¶¶¶¶¶¶______________________
_____________________11¶1¶¶1______________________
__________________________________________________
__________________________________________________
");

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



escribirGanadores(ganadores, ruta);

leerGanadores(ruta);




personajes subirEstadisticas(personajes luchador)
{
    luchador.Datos.Salud += 300;
    luchador.Caract.Fuerza += 2;
    luchador.Caract.Destreza += 1;

    return luchador;
}

static void escribirGanadores(List<personajes> ganadores, string ruta)
{
    using (StreamWriter file = new StreamWriter(ruta, true))
    {
        file.WriteLine("\n\n==========Lista de Ganadores==========");
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
}

static void leerGanadores(string ruta)
{
    string line = "";
    using (StreamReader file = File.OpenText(ruta))
    {
        line = file.ReadToEnd();
        Console.WriteLine(line);
        file.Close();
    }
}

static int eleccionTipoCreacion(ref List<personajes> jugadores, string path)
{
    int respuesta = Convert.ToInt32(Console.ReadLine());
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
            }
            break;
    }

    return respuesta;
}

static void mostrarJugadores(List<personajes> jugadores)
{
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
}

int combate(List<personajes> jugadores, List<personajes> ganadores, int eliminar, int j)
{
    int delay = 30;
    for (int c = 0; c < 3; c++)
    {
        bool victoria = false;
        var batalla = new pelea();
        jugadores[j].Datos.Salud = batalla.ronda(jugadores[j + 1], jugadores[j]);
        if (jugadores[j].Datos.Salud <= 0)
        {
            MostrarDelay($"{jugadores[j + 1].Datos.Nombre} ha ganado el combate!!\n\n", delay);
            eliminar = j;
            jugadores[j + 1] = subirEstadisticas(jugadores[j + 1]);
            ganadores.Add(jugadores[j + 1]);
            c = 3;
            victoria = true;
        }
        if (victoria == false)
        {
            jugadores[j + 1].Datos.Salud = batalla.ronda(jugadores[j], jugadores[j + 1]);
            if (jugadores[j + 1].Datos.Salud <= 0)
            {
                MostrarDelay($"{jugadores[j].Datos.Nombre} ha ganado el combate!!\n\n", delay);
                eliminar = j + 1;
                jugadores[j] = subirEstadisticas(jugadores[j]);
                ganadores.Add(jugadores[j]);
                c = 3;
            }
        }
    }
    if (jugadores[j].Datos.Salud > 0 && jugadores[j + 1].Datos.Salud > 0)
    {
        if (jugadores[j].Datos.Salud > jugadores[j + 1].Datos.Salud)
        {
            MostrarDelay($"{jugadores[j].Datos.Nombre} ha ganado el combate!!\n\n", delay);
            eliminar = j + 1;
            jugadores[j] = subirEstadisticas(jugadores[j]);
            ganadores.Add(jugadores[j]);
        }
        else if (jugadores[j].Datos.Salud < jugadores[j + 1].Datos.Salud)
        {
            MostrarDelay($"{jugadores[j + 1].Datos.Nombre} ha ganado el combate!!\n\n", delay);
            eliminar = j;
            jugadores[j + 1] = subirEstadisticas(jugadores[j + 1]);
            ganadores.Add(jugadores[j + 1]);
        }
    }
    jugadores.RemoveAt(eliminar);
    return eliminar;
}

static void MostrarDelay(string cadena, int delay)
{
    foreach(char c in cadena)
    {
        Console.Write(c);
        Thread.Sleep(delay);
    }
}