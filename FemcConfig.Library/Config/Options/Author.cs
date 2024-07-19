namespace FemcConfig.Library.Config.Options;

public record Author(string Name, string? Url = null)
{
    public static readonly Author Missing = new("Missing Author");

    public static readonly Author Neptune = new("Neptune");
    public static readonly Author Ely = new("Ely");
    public static readonly Author Esa = new("Esa");
    public static readonly Author Betina = new("Betina");
    public static readonly Author Anniversary = new("Anniversary");
    public static readonly Author JustBlue = new("Just Blue");
    public static readonly Author Sav = new("Sav");
    public static readonly Author Doodled = new("Doodled");
    public static readonly Author Ronald = new("Ronald Reagan");
    public static readonly Author Yuunagi = new("Yuunagi");
    public static readonly Author Berrycha = new("berrycha");
    public static readonly Author PatMandDX = new("PatManDX");
    public static readonly Author Chrysanthie = new("Chrysanthie");
    public static readonly Author Fernando = new("Fernando");
    public static readonly Author Monica = new("Monica");
};
