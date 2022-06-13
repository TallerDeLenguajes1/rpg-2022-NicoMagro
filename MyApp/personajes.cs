public class personajes
{
    private datos data;
    private caracteristicas caract;

    public datos Datos
    {
        get => data;
        set => data = value;
    }

    public caracteristicas Caract
    {
        get => caract;
        set => caract = value;
    }

    public personajes(datos dat, caracteristicas carac)
    {
        Datos = dat;
        Caract = carac;
    }
}