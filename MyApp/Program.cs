List<personajes> jugadores = new List<personajes>();
datos dato = new datos();
caracteristicas caract = new caracteristicas();
personajes jugador = new personajes(dato, caract);
jugadores.Add(jugador);

Console.WriteLine("Datos del personaje creado: ");
Console.WriteLine($"Nombre del jugador: {jugador.Datos.Nombre}");
Console.WriteLine($"Apodo: {jugador.Datos.Apodo}");
Console.WriteLine($"Tipo: {jugador.Datos.Tipo}");
Console.WriteLine($"Fecha de Nacimiento: {jugador.Datos.FechaNac}");
Console.WriteLine($"Edad: {jugador.Datos.Edad}");
Console.WriteLine($"Salud: {jugador.Datos.Salud}");