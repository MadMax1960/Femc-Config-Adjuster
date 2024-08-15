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
    public static readonly Author GabiShy = new("GabiShy", Url: "https://www.youtube.com/@gabishy");
    public static readonly Author Atlus = new("Atlus", Url: "Atlus.com");
    public static readonly Author Mudkip = new("MadMax1960");
    public static readonly Author Mineformer = new("MineFormer", Url: "https://www.youtube.com/@mineformer_");
    public static readonly Author Merfie = new("Merfie", Url: "https://www.youtube.com/@merfie-el-mas-xoro-del-caserio");
    public static readonly Author Zeonyph = new("Zeonyph", Url: "https://x.com/ZeoNyph");
    public static readonly Author Jen = new("Jen", Url: "https://www.youtube.com/channel/UCjQSQVa1-OgDmp4ypfdRbWQ");
    public static readonly Author TTango = new("Tiny Tango", Url: "https://x.com/tango_tiny");
    public static readonly Author Karma = new("Karma", Url: "https://www.youtube.com/@glimpseofamemory2743");
    public static readonly Author TheBestAstroNOT = new("TheBestAstroNOT");
    public static readonly Author Femc = new("The Femc Reloaded Mod Team", Url: "https://github.com/MadMax1960/Femc-Reloaded-Project");
    public static readonly Author EidieK87 = new("EidieK87", Url: "https://www.youtube.com/@kawaiie87");
    public static readonly Author GillStudio = new("GillStudio", Url: "https://www.youtube.com/@gillstudio");
    public static readonly Author Stella = new("Satella", Url: "https://www.youtube.com/@Satella");
};
