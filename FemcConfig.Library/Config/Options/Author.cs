namespace FemcConfig.Library.Config.Options;

public record Author(string Name, string? Description = null, string? Url = null)
{
    public static readonly Author Missing = new("Missing Author");

	public static readonly Author Neptune = new("Neptune", Url: "https://x.com/Neptune_NPN013");
	public static readonly Author Ely = new("Ely");
    public static readonly Author Esa = new("Esa", Url: "https://x.com/EsaBlythe");
    public static readonly Author Betina = new("Betina", Url: "https://x.com/Betina_Mascenon");
    public static readonly Author Anniversary = new("Anniversary");
    public static readonly Author JustBlue = new("Just Blue", Url: "https://x.com/blu3_vtuber?s=21");
    public static readonly Author Sav = new("Sav", Url: "https://x.com/fugoluv3r");
	public static readonly Author Doodled = new("Doodled", Url: "https://x.com/NotDoodled");
    public static readonly Author Ronald = new("Ronald Reagan", Url: "https://x.com/CatboyRonReagan");
    public static readonly Author Yuunagi = new("Yuunagi", Url: "https://www.instagram.com/35yuunagi");
    public static readonly Author Berrycha = new("berrycha", Url: "https://x.com/rmeiz147");
    public static readonly Author PatMandDX = new("PatManDX", Url: "https://x.com/PatManDX");
    public static readonly Author Chrysanthie = new("Chrysanthie", Url: "https://x.com/corodaroro");
    public static readonly Author Fernando = new("Fernando", Url: "https://x.com/HolguinDev");
    public static readonly Author Monica = new("Monica", Url: "https://x.com/MonikArtZ");
    public static readonly Author Mosq = new("Mosq", Url: "https://x.com/MOSQmusic");
    public static readonly Author Atlus = new("Atlus", Url: "Atlus.com");
    public static readonly Author Mudkip = new("MadMax1960");
};
