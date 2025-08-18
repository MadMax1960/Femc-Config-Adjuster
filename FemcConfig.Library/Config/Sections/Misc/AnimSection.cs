using FemcConfig.Library.Config.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FemcConfig.Library.Config.Sections.Misc
{
    public class AnimSection : ISection
    {
        public string Name { get; } = string.IsNullOrEmpty(Localisation.LocalisationResources.Resources.FunStuff)
            ? Localisation.LocalisationResources.Resources.ResourceManager.GetString("Animations", System.Globalization.CultureInfo.InvariantCulture) ?? string.Empty
            : Localisation.LocalisationResources.Resources.FunStuff;

        public string Description { get; } = string.IsNullOrEmpty(Localisation.LocalisationResources.Resources.FunStuffDesc)
            ? Localisation.LocalisationResources.Resources.ResourceManager.GetString("AnimationsDesc", System.Globalization.CultureInfo.InvariantCulture) ?? string.Empty
            : Localisation.LocalisationResources.Resources.FunStuffDesc;

        public SectionCategory Category { get; } = SectionCategory.Misc;

        public ModOption[] Options { get; }

        public AnimSection(AppService app)
        {
            var ctx = app.GetContext();
            this.Options =
            [
                new ModOption(ctx)
                {
                    InternalName = "anim_original",
                    Name = "Original Animations",
                    Authors = [Author.Femc],
                    Enable = (ctx) => ctx.FemcConfig.Settings.AnimTrue = Models.FemcModConfig.AnimType.OriginalAnims,
                    Disable = (ctx) => ctx.FemcConfig.Settings.AnimTrue = Models.FemcModConfig.AnimType.OriginalAnims,
                    IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.AnimTrue == Models.FemcModConfig.AnimType.OriginalAnims,
                },
                new ModOption(ctx)
                {
                    InternalName = "anim_custom",
                    Name = "Custom Animations",
                    Authors = [Author.Femc],
                    Enable = (ctx) => ctx.FemcConfig.Settings.AnimTrue = Models.FemcModConfig.AnimType.CustomAnims,
                    Disable = (ctx) => ctx.FemcConfig.Settings.AnimTrue = Models.FemcModConfig.AnimType.CustomAnims,
                    IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.AnimTrue == Models.FemcModConfig.AnimType.CustomAnims,
                },
                new ModOption(ctx)
                {
                    InternalName = "anim_funny",
                    Name = "Very Funny Animations",
                    Authors = [Author.Femc],
                    Enable = (ctx) => ctx.FemcConfig.Settings.AnimTrue = Models.FemcModConfig.AnimType.VeryFunnyAnims,
                    Disable = (ctx) => ctx.FemcConfig.Settings.AnimTrue = Models.FemcModConfig.AnimType.VeryFunnyAnims,
                    IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.AnimTrue == Models.FemcModConfig.AnimType.VeryFunnyAnims,
                },
            ];
        }
    }
}
