using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections;

public interface ISection
{
    string Name { get; }

    SectionCategory Category { get; }

    ModOption[] Options { get; }
}
