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
                
            ];
        }
    }
}
