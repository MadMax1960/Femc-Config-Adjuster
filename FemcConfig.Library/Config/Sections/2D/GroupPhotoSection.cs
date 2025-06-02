using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections;

public class GroupPhotoSection : ISection
{
    public string Name { get; } = "Group Photo";

    public string Description { get; } = "The group photo taken ingame.";

    public SectionCategory Category { get; } = SectionCategory.TwoD;

    public ModOption[] Options { get; }

    public GroupPhotoSection(AppService app)
    {
        var ctx = app.GetContext();
        this.Options =
        [
            new ModOption(ctx)
            {
                InternalName = "group_ely",
                Authors = [Author.Ely],
                Enable = (ctx) => ctx.FemcConfig.Settings.GroupEventTrue = Models.FemcModConfig.GroupEventtype.ely,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.GroupEventTrue == Models.FemcModConfig.GroupEventtype.ely,
            },
            new ModOption(ctx)
            {
                InternalName = "group_bichelle",
                Authors = [Author.Bichelle],
                Enable = (ctx) => ctx.FemcConfig.Settings.GroupEventTrue = Models.FemcModConfig.GroupEventtype.bichelle,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.GroupEventTrue == Models.FemcModConfig.GroupEventtype.bichelle,
            },
        ];
    }
}