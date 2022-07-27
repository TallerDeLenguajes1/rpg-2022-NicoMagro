using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
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
        var url = $"https://api.disneyapi.dev/characters";
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.ContentType = "application/json";
        request.Accept = "application/json";

        using (WebResponse response = request.GetResponse())
        {
            using (Stream strReader = response.GetResponseStream())
            {
                if (strReader == null) return;
                using (StreamReader objReader = new StreamReader(strReader))
                {
                    string responseBody = objReader.ReadToEnd();
                    rere disney = JsonSerializer.Deserialize<rere>(responseBody);
                    List<string> nombres = new List<string>();
                    foreach (var item in disney.data)
                    {
                        nombres.Add(item.name);
                    }
                    Nombre = nombres[rnd.Next(0,50)];
                }
            }
        } 
            string[] tipos = new string[]{"Templario", "Hechicero", "Guarda Bosques", "Necromancer", "NightBlade"};
            string[] apodos = new string[]{"Torcuato", "Paton", "Gervasio", "Narigon", "Fafa", "Retruco"};
            Tipo = tipos[rnd.Next(0,5)];
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