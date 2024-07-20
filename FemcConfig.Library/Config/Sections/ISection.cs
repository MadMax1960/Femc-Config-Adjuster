using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections;

public interface ISection
{
    string Name { get; }

    SectionCategory Category { get; }

    public string Description { get; }

    ModOption[] Options { get; }
}
