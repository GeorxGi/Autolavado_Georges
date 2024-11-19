public static class Servicios
{
    /// <summary>
    /// Lista con todos los servicios que ofrece el autolavado
    /// Balanceo - Aceite - Aspirado - Lavado - Secado
    /// </summary>
    public static readonly string[] ServiciosDisp = ["Balanceo", "Aceite", "Aspirado", "Lavado", "Secado"];
}

public readonly struct InterfaceColors
{
    public static readonly Color Negro = Color.FromArgb(51, 51, 51);
    public static readonly Color Turqueza = Color.FromArgb(72, 229, 194);
    public static readonly Color Blanco = Color.FromArgb(252, 250, 249);
    public static readonly Color Arena = Color.FromArgb(243, 211, 189);
    public static readonly Color Gris = Color.FromArgb(94, 94, 94);
}
public struct Vehiculo
{
    public string Tipo, Modelo, Placa;
}
public struct Datos
{
    public string Nombre, Apellido;
}