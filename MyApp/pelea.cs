public class pelea
{
    public int ronda(personajes atacante, personajes defensor)
    {
        Random rnd = new Random();
        int disparo, efectividad, valorAtaque, defensa, maxDamage, damage;
        disparo = atacante.Caract.Destreza * atacante.Caract.Fuerza * atacante.Caract.Nivel;
        efectividad = rnd.Next(1, 100);
        valorAtaque = disparo * efectividad;
        defensa = defensor.Caract.Armadura * defensor.Caract.Velocidad;
        maxDamage = 10000;
        damage = ((valorAtaque * efectividad - defensa) / maxDamage) * 100;
        defensor.Datos.Salud -= damage;
        Console.WriteLine($"El luchador {atacante.Datos.Nombre} ataca a {defensor.Datos.Nombre}");
        Console.WriteLine($"Danio provocado: {damage}");
        Console.WriteLine($"Salud restante de {defensor.Datos.Nombre}: {defensor.Datos.Salud}\n");

        return defensor.Datos.Salud;
    }
}