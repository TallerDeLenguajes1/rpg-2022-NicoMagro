public class caracteristicas
{
    private int velocidad;
    private int destreza;
    private int fuerza;
    private int nivel;
    private int armadura;


    public int Velocidad
    {
        get => velocidad;
        set => velocidad = value;
    }

    public int Destreza
    {
        get => destreza;
        set => destreza = value;
    }

    public int Fuerza
    {
        get => fuerza;
        set => fuerza = value;
    }

    public int Nivel
    {
        get => nivel;
        set => nivel = value;
    }

    public int Armadura
    {
        get => armadura;
        set => armadura = value;
    }

    public caracteristicas()
    {
        Random rnd = new Random();
        Velocidad = rnd.Next(1,10);
        Destreza = rnd.Next(1,5);
        Fuerza = rnd.Next(1,10);
        Nivel = rnd.Next(1,10);
        Armadura = rnd.Next(1,10);
    }
}