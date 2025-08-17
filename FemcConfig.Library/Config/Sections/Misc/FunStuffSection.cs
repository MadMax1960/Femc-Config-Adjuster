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
        public string Name { get; } = Localisation.LocalisationResources.Resources.Level_Up_Screen;

        public string Description { get; } = Localisation.LocalisationResources.Resources.LevelUpDesc;

        public SectionCategory Category { get; } = SectionCategory.TwoD;

        public ModOption[] Options { get; }

        public FunStuffSection(AppService app)
        {
            var ctx = app.GetContext();
            this.Options =
            [
                new ModOption(ctx)
            {
                InternalName = "level_ely",
                Authors = [Author.Ely],
                Enable = (ctx) => ctx.FemcConfig.Settings.LevelUpTrue = Models.FemcModConfig.LevelUpType.Ely,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.LevelUpTrue == Models.FemcModConfig.LevelUpType.Ely,
            },
        ];
        }
    }
}
