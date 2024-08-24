using FemcConfig.Library.Config.Models;
using FemcConfig.Library.Config.Options;
using FemcConfig.Library.Utils;
using System.Xml;

namespace FemcConfig.Library.Config.Sections;

public class IntroMovieSection : ISection
{
    /// <summary>
    /// Section name. Sets the text that appears on the side and title of page.
    /// </summary>
    public string Name { get; } = "Intro Movies";

    public string Description { get; } = "Select which movies you want to be viewed on startup. Hint: You can select multiple of them to make it randomised!";

    /// <summary>
    /// Section category, such as 2D, 3D, Audio, etc.
    /// </summary>
    public SectionCategory Category { get; } = (CheckModExistence("Persona_3_Reload_Intro_Movies")) ? SectionCategory.Addon : SectionCategory.Addon;

    /// <summary>
    /// Contains all the options that appear in the section.
    /// Set it in the constructor below.
    /// </summary>
    public ModOption[] Options { get; }

    public IntroMovieSection(AppService app)
    {
        var ctx = app.GetContext();

        // Set all the options available.
        this.Options =
        [
            // Example for a bool setting.
            /*
           new ModOption(ctx)
            {
                InternalName = "movie_P3P",
                Name = "Original Persona 3 Portable Intro",
                Authors = [Author.Atlus],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.MovieConfig!.Settings.P3p = true,
                Disable = (ctx) => ctx.MovieConfig!.Settings.P3p = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.MovieConfig!.Settings.P3p,
            },
           new ModOption(ctx)
            {
                InternalName = "movie_P3PK",
                Name = "Moonlight Daydream by the Kotone Cutscenes Team",
                Authors = [Author.Neptune, Author.Merfie, Author.Mosq, Author.Jen, Author.TTango, Author.Zeonyph],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.MovieConfig!.Settings.P3pk = true,
                Disable = (ctx) => ctx.MovieConfig!.Settings.P3pk = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.MovieConfig!.Settings.P3pk,
            },
            new ModOption(ctx)
            {
                InternalName = "movie_SP",
                Name = "Soul Phrase by Mosq",
                Authors = [Author.Mosq, Author.TheBestAstroNOT],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.MovieConfig!.Settings.Soulmosq = true,
                Disable = (ctx) => ctx.MovieConfig!.Settings.Soulmosq = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.MovieConfig!.Settings.Soulmosq,
            },*/
            //modmanager=new ModManager(Path.Join(Path.GetDirectoryName(Environment.GetEnvironmentVariable("RELOADEDIIMODS"))!, "Apps", "p3r.exe", "AppConfig.json")),
            new ModOption(ctx)
            {
                InternalName = "movie_SP",
                Name = "Movie mod enabled?",
                Authors = [Author.Mosq, Author.TheBestAstroNOT],
               
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Add("Persona_3_Reload_Intro_Movies"),
                Disable = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Remove("Persona_3_Reload_Intro_Movies"),
                //Disable = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Remove("Persona_3_Reload_Intro_Movies"),

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Contains("Persona_3_Reload_Intro_Movies")
            },
        ];
    }

    private static bool CheckModExistence(string id)
    {
        return JsonUtils.DeserializeFile<EnabledModConfiguration>(Path.Join(Path.GetDirectoryName(Environment.GetEnvironmentVariable("RELOADEDIIMODS"))!, "Apps", "p3r.exe", "AppConfig.json")).EnabledMods!.Contains(id) ? true : false;
    }

    public class EnabledModConfiguration
    {
        public List<string>? EnabledMods { get; set; }
    }

    
}
