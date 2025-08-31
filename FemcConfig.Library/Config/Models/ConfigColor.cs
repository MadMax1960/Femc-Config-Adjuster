#pragma warning disable CS1591

using CommunityToolkit.Mvvm.ComponentModel;

namespace FemcConfig.Library.Config.Models;

public partial class ConfigColor : ObservableObject
{
    [ObservableProperty]
    private byte r;

    [ObservableProperty]
    private byte g;

    [ObservableProperty]
    private byte b;

    [ObservableProperty]
    private byte a;

    // Basic Color Presets
    public static readonly ConfigColor White = new ConfigColor(0xff, 0xff, 0xff, 0xff);
    public static readonly ConfigColor Black = new ConfigColor(0x0, 0x0, 0x0, 0xff);
    public static readonly ConfigColor Red = new ConfigColor(0xff, 0x0, 0x0, 0xff);
    public static readonly ConfigColor Green = new ConfigColor(0x0, 0xff, 0x0, 0xff);
    public static readonly ConfigColor Blue = new ConfigColor(0x0, 0x0, 0xff, 0xff);

    // Color Presets - For Femc Reloaded Project
    // https://github.com/MadMax1960/Femc-Reloaded-Project
    public static readonly ConfigColor LightColor = new ConfigColor(0xff, 0xbf, 0xfc, 0xff);
    public static readonly ConfigColor DarkColor = new ConfigColor(0xd4, 0x15, 0x5b, 0xff);
    public static readonly ConfigColor MidColor = new ConfigColor(0xff, 0x8f, 0xec, 0xff);

    public static readonly ConfigColor CampBgColor = new ConfigColor(0xe8, 0x64, 0xbc, 0xff);
    public static readonly ConfigColor TextBoxBackFillColor = new ConfigColor(0x6c, 0x7, 0x39, 0xff);
    public static readonly ConfigColor TextBoxFrontFillColor = new ConfigColor(0x49, 0x4, 0x21, 0xff);
    public static readonly ConfigColor CampMenuItemColor1 = new ConfigColor(0xff, 0x8f, 0xec, 0xff);
    public static readonly ConfigColor CampMenuItemColor2 = new ConfigColor(0xf7, 0x83, 0xe4, 0xff);
    public static readonly ConfigColor CampMenuItemColor3 = new ConfigColor(0xe0, 0x79, 0xcf, 0xff);
    public static readonly ConfigColor CampMenuItemColorNoSel = new ConfigColor(0xcf, 0x7c, 0xc1, 0xff);
    public static readonly ConfigColor CheckFgBorder = new ConfigColor(0x9b, 0x0b, 0x47, 0xff);
    public static readonly ConfigColor SocialStatsCourage = new ConfigColor(0xf5, 0x62, 0xa7, 0xff);
    public static readonly ConfigColor SocialStatsCharm = new ConfigColor(0xff, 0x8f, 0xec, 0xff); // same as mid color
    public static readonly ConfigColor SocialStatsAcademics = new ConfigColor(0xa0, 0x0c, 0x42, 0xff);
    public static readonly ConfigColor MailIconInnerColor = new ConfigColor(0xff, 0x7f, 0x9f, 0xff);
    public static readonly ConfigColor DateTimeWaterColor = new ConfigColor(0xf0, 0x7c, 0xcd, 0xff);
    public static readonly ConfigColor TextBoxLeftHaze = new ConfigColor(0x83, 0x06, 0x51, 0xff);
    public static readonly ConfigColor TextBoxSpeakerNameTriangle = new ConfigColor(0xc8, 0x05, 0x4b, 0xff);
    // I'd put the discord attachment here but they're time limited now
    public static readonly ConfigColor MellodiColorLight1 = new ConfigColor(0xff, 0xbd, 0xce, 0xff);
    public static readonly ConfigColor MellodiColorLight2 = new ConfigColor(0xfe, 0x9d, 0xb6, 0xff);
    public static readonly ConfigColor MellodiColorLight3 = new ConfigColor(0xff, 0x89, 0xa6, 0xff);
    public static readonly ConfigColor MellodiColorMid1 = new ConfigColor(0xd4, 0x15, 0x5b, 0xff);
    public static readonly ConfigColor MellodiColorMid2 = new ConfigColor(0xff, 0x4a, 0x77, 0xff);
    public static readonly ConfigColor MellodiColorMid3 = new ConfigColor(0xcd, 0x62, 0x90, 0xff);
    public static readonly ConfigColor MellodiColorMid4 = new ConfigColor(0xd4, 0x45, 0x92, 0xff);
    public static readonly ConfigColor MellodiColorDark1 = new ConfigColor(0xb6, 0x3f, 0x67, 0xff);
    public static readonly ConfigColor MellodiColorDark2 = new ConfigColor(0x81, 0x0, 0x6, 0xff);
    public static readonly ConfigColor MellodiColorDark3 = new ConfigColor(0x49, 0x4, 0x21, 0xff);

    public static readonly ConfigColor BackLogBlackBoard = new ConfigColor(0x09, 0x03, 0x09, 0xff);
    public static readonly ConfigColor DayChangeMoonShadow = new ConfigColor(0xa3, 0x26, 0x50, 0xff);
    public static readonly ConfigColor ShopFillColor = new ConfigColor(0xaf, 0xf, 0x6e, 0xff);
    public static readonly ConfigColor ShopShadowColor = new ConfigColor(0xff, 0x4e, 0xdc, 0xff);
    public static readonly ConfigColor GetItemFillMask = new ConfigColor(0x54, 0xd, 0x54, 0xff);
    public static readonly ConfigColor GetItemGotTextColor = new ConfigColor(0xff, 0x4a, 0xff, 0xff);
    public static readonly ConfigColor MindSelectDotColor = new ConfigColor(0x67, 0x00, 0x00, 0xff);
    public static readonly ConfigColor MsgWindowSystemDark = new ConfigColor(0x2f, 0x00, 0x14, 0xff);

    public static readonly ConfigColor PersonaStatusSkillListBg = new ConfigColor(0x2a, 0x00, 0x12, 0xff);
    public static readonly ConfigColor PersonaStatusSkillListCheckboardAlt = new ConfigColor(0x5c, 0x27, 0x3e, 0xff);
    public static readonly ConfigColor FemcShadowColor = new ConfigColor(0xb7, 0x9a, 0xa0, 0xff);

    public ConfigColor(byte R, byte G, byte B, byte A) { this.R = R; this.G = G; this.B = B; this.A = A; }

    public uint ToU32() => (uint)(R << 0x18) | (uint)(G << 0x10) | (uint)(B << 0x8) | A;
    public uint ToU32IgnoreAlpha() => (uint)(R << 0x18) | (uint)(G << 0x10) | (uint)(B << 0x8);
    public uint ToU32ARGB() => (uint)(A << 0x18) | (uint)(R << 0x10) | (uint)(G << 0x8) | B;

    // i forgot to add this to commonutils lol
    public static readonly ConfigColor NetStickyNoteBgColor1 = new ConfigColor(0xd8, 0x3d, 0x76, 0xff);
    public static readonly ConfigColor NetStickyNoteTextColor1 = new ConfigColor(0xff, 0xd1, 0xdc, 0xff);
    public static readonly ConfigColor LocationSelectMapLabel = new ConfigColor(0x1f, 0x11, 0x17, 0xff);
    public static readonly ConfigColor CheckPromptBgBox = new ConfigColor(0xa0, 0x0e, 0x4a, 0xff);
    public static readonly ConfigColor CheckPromptFgBox = new ConfigColor(0x7a, 0x2b, 0x45, 0xff);
    public static readonly ConfigColor InactivePartyMemberTartarusBG = new ConfigColor(181, 63, 104, 0xff);
    public static readonly ConfigColor InactivePartyMemberPalePink = new ConfigColor(0xed, 0xc0, 0xdb, 0xff);
    public static readonly ConfigColor InactivePartyMemberDarkPink = new ConfigColor(0x78, 0x19, 0x34, 0xff);
    public static readonly ConfigColor InactivePartyMemberHPColor = new ConfigColor(0x8b, 0x0d, 0x41, 0xff);
    public static readonly ConfigColor MindWindowOuterBorder = new ConfigColor(0xa6, 0x6, 0x52, 0xff);
    public static readonly ConfigColor MindWindowInnerColor = new ConfigColor(0x49, 0x4, 0x21, 0xff);
}
