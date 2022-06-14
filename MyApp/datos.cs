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
    public DateTime FechaNac {get; set;}
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
        Tipo = tipos[rnd.Next(0,5)];
        Nombre = nombres[rnd.Next(0,8)];
        Apodo = apodos[rnd.Next(0,6)];
        FechaNac = RandomDay();
        edad = calcularEdad(FechaNac);
        Salud = 3000;
    }

    DateTime fechaActual = DateTime.Today;
    public int calcularEdad(DateTime FechaNacimiento){
        edad = fechaActual.Year - FechaNacimiento.Year;
        if(FechaNacimiento.Month > fechaActual.Month){
            edad = edad-1;
        }
        return edad;
    }
    public DateTime RandomDay() {
        DateTime start = new DateTime(1722, 1, 1); 
        Random gen = new Random(); 
        int range = (DateTime.Today - start).Days; 
        return start.AddDays(gen.Next(range)); 
    }
}