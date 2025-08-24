using FemcConfig.Library.Config.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FemcConfig.Library.Config.Sections.Misc
{
    public class FunStuffSection : ISection
    {
        public string Name { get; } = string.IsNullOrEmpty(Localisation.LocalisationResources.Resources.FunStuff)
            ? Localisation.LocalisationResources.Resources.ResourceManager.GetString("FunStuff", System.Globalization.CultureInfo.InvariantCulture) ?? string.Empty
            : Localisation.LocalisationResources.Resources.FunStuff;

        public string Description { get; } = string.IsNullOrEmpty(Localisation.LocalisationResources.Resources.FunStuffDesc)
            ? Localisation.LocalisationResources.Resources.ResourceManager.GetString("FunStuffDesc", System.Globalization.CultureInfo.InvariantCulture) ?? string.Empty
            : Localisation.LocalisationResources.Resources.FunStuffDesc;

        public SectionCategory Category { get; } = SectionCategory.Misc;

        public ModOption[] Options { get; }

        public FunStuffSection(AppService app)
        {
            var ctx = app.GetContext();
            this.Options =
            [
                new ModOption(ctx)
                {
                    InternalName = "fun_stuff_dorm",
                    Name = "Test Dorm Room Swap and Hot Spring Event",
                    Authors = [Author.Femc],
                    Enable = (ctx) => ctx.FemcConfig.Settings.TesticlesDorm = true,
                    Disable = (ctx) => ctx.FemcConfig.Settings.TesticlesDorm = false,
                    IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.TesticlesDorm,
                },
                new ModOption(ctx)
                {
                    InternalName = "fun_stuff_room",
                    Name = "Kotone Room",
                    Authors = [Author.Bichelle, Author.Ely, Author.redmages, Author.Betina, Author.blodhgar, Author.nanometer,Author.ateliebiabonne, Author.Shiosakana, Author.Cielbell, Author.Crezzstar, Author.Esa, Author.Adrien, Author.Mekki],
                    Enable = (ctx) => ctx.FemcConfig.Settings.KotoneRoom = true,
                    Disable = (ctx) => ctx.FemcConfig.Settings.KotoneRoom = false,
                    IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.KotoneRoom,
                },
                new ModOption(ctx)
                {
                    InternalName = "fun_stuff_apron",
                    Name = "Gregory House Apron",
                    Authors = [Author.Femc],
                    Enable = (ctx) => ctx.FemcConfig.Settings.GregoryHouseRatPoisonDeliverySystem = true,
                    Disable = (ctx) => ctx.FemcConfig.Settings.GregoryHouseRatPoisonDeliverySystem = false,
                    IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.GregoryHouseRatPoisonDeliverySystem,
                },
                new ModOption(ctx)
                {
                    InternalName = "fun_stuff_arcade",
                    Name = "Otome Arcade Game",
                    Authors = [Author.euphonia],
                    Enable = (ctx) => ctx.FemcConfig.Settings.OtomeArcade = true,
                    Disable = (ctx) => ctx.FemcConfig.Settings.OtomeArcade = false,
                    IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.OtomeArcade,
                },
            ];
        }
    }
}
