using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FemcConfig.Library.Config.Options;


namespace FemcConfig.Library.Config.Sections.Misc
{
    public class SunsetTitleScreen : ISection
    {
        //public string Name { get; } = Localisation.LocalisationResources.Resources.SunsetTitleScreen;
        public string Name { get; } = string.IsNullOrEmpty(Localisation.LocalisationResources.Resources.SunsetTitleScreen)
            ? Localisation.LocalisationResources.Resources.ResourceManager.GetString("SunsetTitleScreen", System.Globalization.CultureInfo.InvariantCulture) ?? string.Empty
            : Localisation.LocalisationResources.Resources.SunsetTitleScreen;

        public string Description { get; } = string.IsNullOrEmpty(Localisation.LocalisationResources.Resources.SunsetTitleScreenDesc)
            ? Localisation.LocalisationResources.Resources.ResourceManager.GetString("SunsetTitleScreenDesc", System.Globalization.CultureInfo.InvariantCulture) ?? string.Empty
            : Localisation.LocalisationResources.Resources.SunsetTitleScreenDesc;

        public SectionCategory Category { get; } = SectionCategory.Misc;

        public ModOption[] Options { get; }

        public SunsetTitleScreen(AppService app)
        {
            var ctx = app.GetContext();
            this.Options =
            [
                new ModOption(ctx)
            {
                InternalName = "sunsettitlescreen",
                Name = "Sunset Title Screen",
                Authors = [Author.Femc],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.EnableSunsetTitleScreen = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.EnableSunsetTitleScreen = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.EnableSunsetTitleScreen,
            }
            ];
        }
    }
}
