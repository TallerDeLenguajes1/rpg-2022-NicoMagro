public class datos
{
    private string tipo;
    private string nombre;
    private string apodo;
    private string fechaNac;
    private int edad;
    private int salud;


    public string Tipo
    {
        get => tipo;
        set => tipo = value;
    }
    public string Nombre
    {
        get => nombre;
        set => nombre = value;
    }
    public string Apodo
    {
        get => apodo;
        set => apodo = value;
    }
    public string FechaNac
    {
        get => fechaNac;
        set => fechaNac = value;
    }
    public int Edad
    {
        get => edad;
        set => edad = value;
    }
    public int Salud
    {
        get => salud;
        set => salud = value;
    }

    public datos()
    {
        Random rnd = new Random();
        string[] tipos = new string[]{"Templario", "Hechicero", "Guarda Bosques", "Necromancer", "NightBlade"};
        string[] nombres = new string[]{"Agni", "Alfio", "Runar", "Vikram", "Werner", "Yannick", "Baco", "Brais", "Samay"};
        string[] apodos = new string[]{"Torcuato", "Paton", "Gervasio", "Narigon", "Fafa", "Retruco"};
        string[] fechas = new string[]{"24/06/2002", "02/02/1790", "18/05/1995", "04/11/2001", "13/07/1934", "29/06/1986"};
        Tipo = tipos[rnd.Next(0,5)];
        Nombre = nombres[rnd.Next(0,8)];
        Apodo = apodos[rnd.Next(0,6)];
        FechaNac = fechas[rnd.Next(0,6)];
        string[] fecha = FechaNac.Split("/");
        edad = 2022 - Convert.ToInt32(fecha[2]);
        Salud = 100;
    }
}