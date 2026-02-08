using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FemcConfig.Library.Config.Models;

/// <summary>
/// Should match Config.cs from FEMC mod:
/// https://github.com/MadMax1960/Femc-Reloaded-Project/blob/main/code/p3rpc.femc/p3rpc.femc/Config.cs
/// </summary>
public partial class FemcModConfig : ObservableObject
{
    // --- 2D Options ---
    [Description("The portrait used when finishing battles with an all-out attack initiated by FEMC.")]
    [Category("2D Options")]
    [DefaultValue(AOAType.esaadrien)]
    [ObservableProperty]
    private AOAType _AOATrue = AOAType.esaadrien;

    public enum AOAType { Ely, Chrysanthie, Fernando, Monica, RonaldReagan, esaadrien, mekki, shiosakana, shiosakanaAlt, Nami, AngieDaGorl, StupidAle, cielbell }

    [Description("The text used when finishing battles with an all-out attack initiated by FEMC.")]
    [Category("2D Options")]
    [DefaultValue(AOATextType.SorryBoutThat)]
    [ObservableProperty]
    private AOATextType _AOAText = AOATextType.SorryBoutThat;

    public enum AOATextType { DontLookBack, SorryBoutThat, PerfectlyAccomplished }

    [Description("The character portrait used in textboxes.")]
    [Category("2D Options")]
    [DefaultValue(BustupType.Esa)]
    [ObservableProperty]
    private BustupType _BustupTrue = BustupType.Esa;

    public enum BustupType { Neptune, Ely, Esa, Betina, Anniversary, JustBlue, Sav, Doodled, RonaldReagan, ElyAlt, Yuunagi, cielbell, axolotl, ghostedtoast, Strelko, gackt, Jackie, Lisa, BetaFemcByMae, crezzstar, crezzstarAlt, AngieDaGorl, namiweiko, chitu, shiosakana, samythecoolkid, Mixi_xiMi, StupidAle, Kiara, Autumn, p3pYuha, Maru, purpleoctogamer, purpleoctogamerAlt, Anonymousfluffi, woodwhite, Milky }

    [Description("The animation played occasionally when attacking weaknesses or hitting criticals.")]
    [Category("2D Options")]
    [DefaultValue(CutinType.Mekki)]
    [ObservableProperty]
    private CutinType _CutinTrue = CutinType.Mekki;

    public enum CutinType { berrycha, ElyandPatmandx, Mekki, shiosakana }

    [Description("The group photo taken during a certain event.")]
    [Category("2D Options")]
    [DefaultValue(GroupEventtype.mekki)]
    [ObservableProperty]
    private GroupEventtype _GroupEventTrue = GroupEventtype.mekki;

    public enum GroupEventtype { bichelle, ely, mekki }

    [Description("The photos taken during the Kyoto trip.")]
    [Category("2D Options")]
    [DefaultValue(KyotoEventtype.mekki)]
    [ObservableProperty]
    private KyotoEventtype _KyotoEventTrue = KyotoEventtype.mekki;

    public enum KyotoEventtype { ely, mekki }

    [Description("The character art used for the level up screen.")]
    [Category("2D Options")]
    [DefaultValue(LevelUpType.Esa)]
    [ObservableProperty]
    private LevelUpType _LevelUpTrue = LevelUpType.Esa;

    public enum LevelUpType { Esa, Ely, shiosakana, ElyAlt, AngieDaGorl, samythecoolkid }

    [Description("The character icon on the right when dungeon crawling or in combat.")]
    [Category("2D Options")]
    [DefaultValue(PartyPanelType.Esa)]
    [ObservableProperty]
    private PartyPanelType _PartyPanelTrue = PartyPanelType.Esa;

    public enum PartyPanelType { Kris, Esa }

    [Description("The character art used in the status menu.")]
    [Category("2D Options")]
    [DefaultValue(ShardType.Esa)]
    [ObservableProperty]
    private ShardType _ShardTrue = ShardType.Esa;

    public enum ShardType { Esa, Ely, ElyAlt, Shiosakana, namiweiko, AngieDaGorl, StupidAle, samythecoolkid }

    // --- 3D Options ---
    [Description("Choose from a few animations.")]
    [Category("3D Options")]
    [DefaultValue(AnimType.OriginalAnims)]
    [ObservableProperty]
    private AnimType _AnimTrue = AnimType.OriginalAnims;

    public enum AnimType { OriginalAnims, CustomAnims, VeryFunnyAnims }

    [Description("The hair model used on FEMC.")]
    [Category("3D Options")]
    [DefaultValue(HairType.MudkipsHair)]
    [ObservableProperty]
    private HairType _HairTrue = HairType.MudkipsHair;

    public enum HairType { MudkipsHair, KotoneBeanHair }

    [Description("Changes FEMC's weapons from 1h swords to naginatas.")]
    [Category("3D Options")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool _NagiWeap = true;

    // --- Voice ---
    [Description("The voice used ingame for FEMC.")]
    [Category("Voice")]
    [DefaultValue(VoiceType.Mellodi)]
    [ObservableProperty]
    private VoiceType _VoiceTrue = VoiceType.Mellodi;

    public enum VoiceType { Mellodi, MellodiSilly, Lantana, Japanese }

    [Category("Voice")]
    [Description("Uses custom voice lines to refer to FEMC with she/her pronouns where applicable.")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool bluehairandpronounce = true;

    // --- Battle Music - Advantage ---
    [Category("Battle Music - Advantage")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool karmaAdv = false;

    [Category("Battle Music - Advantage")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool mosqAdv = true;

    [Category("Battle Music - Advantage")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool eidAdv = false;

    [Category("Battle Music - Advantage")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool itGoingDown = false;

    // --- Battle Music - Normal ---
    [Category("Battle Music - Normal")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool mosqNom = true;

    [Category("Battle Music - Normal")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool karmaNom = false;

    [Category("Battle Music - Normal")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool sgNom = false;

    [Category("Battle Music - Normal")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool p3pNom = false;

    [Category("Battle Music - Normal")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool p3MidNomF = false;

    [Category("Battle Music - Normal")]
<<<<<<< Updated upstream
=======
    [Description("Enable EidieK87's Wiping All Out?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool eidNom = false;

    [Category("Tartarus Boss Music")]
    [Description("Enable Stella and GillStudio's Danger Zone?")]
>>>>>>> Stashed changes
    [DefaultValue(false)]
    [ObservableProperty]
    private bool eidNom = false;

    [Category("Battle Music - Normal")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool restlessNom = false;

    [Category("Battle Music - Normal")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool massDes = false;

    // --- Tartarus Boss Music ---
    [Category("Tartarus Boss Music")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool sgDis = false;

    [Category("Tartarus Boss Music")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool eidDis = false;

    [Category("Tartarus Boss Music")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool karmaDis = false;

    [Category("Tartarus Boss Music")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool mosqDis = true;

    [Category("Tartarus Boss Music")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool p3pDis = false;

    [Category("Tartarus Boss Music")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool restlessDis = false;

    [Category("Tartarus Boss Music")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool masterTar = false;

<<<<<<< Updated upstream
    // --- Special Boss Music ---
    [Category("Special Boss Music")]
=======
    [Category("Battle Music - Normal")]
    [Description("Enable Atlus's Mass Destruction -Reload-?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool massDes = true;

    [Category("Music")]
    [Description("Enable Color Your Night as the night music?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool colNight = true;


    [Category("Music")]
    [Description("Enable Moonlight by MOSQ as the night music?")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool esaComm = true;

    [Category("Music")]
    [Description("Enable Midnight Reverie as the night music?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool midNight = true;

    [Category("Music")]
    [Description("Enable Time (Night Version) by Mosq as the night music?")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool femNight = true;

    [Category("Music")]
    [Description("Enable Time (Night Version GabiShy Remix) as the night music?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool gabiFemNight = true;

    [Category("Music")]
    [Description("Enable Night Wanderer as the night music?")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool nightWand = true;

    [Category("Music")]
    [Description("Enable When the Moon's Reaching Out Stars as the daytime music?")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool moon = true;

    [Category("Music")]
    [Description("Enable A Way of Life (Restless Artist).\nMultiple songs can be chosen for randomization!")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool restlessWayofLife = true;

    [Category("Music")]
    [Description("Enable Way of Life by Super M Plush, Mosq, Karma, and Cora as the daytime music?")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool wayLifeVocal = true;

    [Category("Music")]
    [Description("Enable Way of Life by Mosq as the daytime music?")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool wayOfLife = true;

    [Category("Music")]
    [Description("Enable Way of Life as the daytime music?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool wayOfLifeP3P = true;

    [Category("Music")]
    [Description("Enable Way of Life -Deep inside my mind Remix- as the daytime music?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool wayOfLifeRemix = true;

    [Category("Music")]
    [Description("Enable Want to Be Close -Reload- as the daytime music inside the school (Phase 1)?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool wantClose = true;

    [Category("Music")]
    [Description("Enable Time by Mosq as the daytime music inside the school?")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool timeSchool = true;

    [Category("Music")]
    [Description("Enable Time -Reload- by GabiShy and Mosq as the daytime music inside the school?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool gabiTimeSchool = true;

    [Category("School Music (1st semester)")]
    [Description("Enable Time ATLUS Kitajoh Remix from P3D as the 1st semester school music.\nMultiple songs can be chosen for randomization!")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool timeSchoolP3D = true;

    [Category("Music")]
    [Description("Enable Time as the daytime music inside the school?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool timeSchoolP3P = true;

    [Category("Music")]
    [Description("Enable Joy to be the music played during social link events?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool joy = true;

    [Category("Music")]
    [Description("Enable Mosq's After School to be the music played during social link events?")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool afterSchool = true;

    [Category("Music")]
    [Description("Enable After School (P3P) to be the music played during social link events?")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool afterSchoolP3P = true;

    [Category("Music")]
    [Description("Enable Changing Seasons as the daytime music inside the school?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool seasons = true;

    [Category("Music")]
    [Description("Enable Sun by Mosq as the daytime music inside the school?")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool sun = true;

    [Category("Music")]
    [Description("Enable Sun by MineFormer as the daytime music inside the school?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool sunMForm = true;

    [Category("Music")]
    [Description("Enable Sun as the daytime music inside the school?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool sunP3P = true;

    [Category("Music")]
    [Description("Enable Soul Phrase as the music played during the battle with Nyx?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool soulPK = true;

    [Category("Music")]
    [Description("Enable Burn My Dread as the music played during the battle with Nyx?")]
>>>>>>> Stashed changes
    [DefaultValue(true)]
    [ObservableProperty]
    private bool bMD = true;

    [Category("Special Boss Music")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool soulPK = false;

    // --- Daytime Music ---
    [Category("Daytime Music")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool wayOfLife = false;

    [Category("Daytime Music")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool wayOfLifeJen = false;

    [Category("Daytime Music")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool wayLifeVocal = true;

    [Category("Daytime Music")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool wayOfLifeP3P = false;

    [Category("Daytime Music")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool wayOfLifeRemix = false;

    [Category("Daytime Music")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool wayOfLifeP3D = false;

    [Category("Daytime Music")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool moon = true;

    [Category("Daytime Music")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool restlessWayofLife = true;

    // --- School Music (1st semester) ---
    [Category("School Music (1st semester)")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool timeSchool = false;

    [Category("School Music (1st semester)")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool gabiTimeSchool = true;

    [Category("School Music (1st semester)")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool timeSchoolP3P = false;

    [Category("School Music (1st semester)")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool timeSchoolP3D = false;

    [Category("School Music (1st semester)")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool wantClose = false;

    // --- School Music (2nd semester) ---
    [Category("School Music (2nd semester)")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool sun = true;

    [Category("School Music (2nd semester)")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool sunMForm = false;

    [Category("School Music (2nd semester)")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool sunP3P = false;

    [Category("School Music (2nd semester)")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool seasons = false;

    // --- Night Music ---
    [Category("Night Music")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool femNight = false;

    [Category("Night Music")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool gabiFemNight = false;

    [Category("Night Music")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool midNight = false;

    [Category("Night Music")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool nightWand = true;

    [Category("Night Music")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool esaComm = false;

    [Category("Night Music")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool colNight = false;

    // --- Event Music ---
    [Category("Event Music")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool afterSchool = true;

    [Category("Event Music")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool afterSchoolP3P = false;

    [Category("Event Music")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool joy = false;

    // --- Fun Stuff ---
    [Category("Fun Stuff")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool kotoneRoom = false;

    [Category("Fun Stuff")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool gregoryHouseRatPoisonDeliverySystem = false;

    [Category("Fun Stuff")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool otomeArcade = false;

    // --- Theo ---
    [Category("Theo")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool _TheodorefromAlvinandTheChipmunks = false;

    // --- Testing ---
    [Category("Testing")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool deckCompatibilitySwitch = false;

    [Category("Testing")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool testiclesEventsDorm = true;

    // --- UI Components ---

    [Category("UI Components")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool _EnableMailIcon = true;

    [Category("UI Components")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool _EnableDateTimePanel = true;

    [Category("UI Components")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool _EnableCampMenu = true;

    [Category("UI Components")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool _EnableTextbox = true;

    [Category("UI Components")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool _EnableMindMessageBox = true;

    [Category("UI Components")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool _EnableInteractPrompt = true;

    [Category("UI Components")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool _EnableMinimap = true;

    [Category("UI Components")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool _EnableBustup = true;

    [Category("UI Components")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool _EnableTownMap = true;

    [Category("UI Components")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool _EnablePartyPanel = true;

    [Category("UI Components")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool _EnableTimeSkip = true;

    [Category("UI Components")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool _EnableGetItem = true;

    [Category("UI Components")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool _EnableNetworkFeatures = true;

    [Category("UI Components")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool _EnableShop = true;

    [Category("UI Components")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool _EnablePersonaStatus = true;

    [Category("UI Components")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool _EnableBacklog = true;

    [Category("UI Components")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool _EnableButtonPrompts = true;

    [Category("UI Components")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool _EnableTitleMenu = true;

    [Category("UI Components")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool _EnableStaffRoll = true;

    [Category("UI Components")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool _EnableCutin = true;

    [Category("UI Components")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool _EnableWipe = true;

    [Category("UI Components")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool _EnableBattle = true;

    [Category("UI Components")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool _EnableItemList = true;

    [Category("UI Components")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool _EnableCommunity = true;

    [Category("UI Components")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool _EnableGuidance = true;

    // --- UI Colors ---
    [ObservableProperty] private ConfigColor _MailIconOuterCircleColorEx = new ConfigColor(0x90, 0x21, 0x4D, 0xAF);
    [ObservableProperty] private ConfigColor _MailIconInnerCircleColorEx = new ConfigColor(0xFF, 0x5C, 0x94, 0xFF);
    [ObservableProperty] private ConfigColor _CampHighColor = new ConfigColor(0xFF, 0x9B, 0xCE, 0xFF);
    [ObservableProperty] private ConfigColor _CampHighColorGradation = new ConfigColor(0xE3, 0x96, 0xB9, 0xFF);
    [ObservableProperty] private ConfigColor _CampMiddleColor = new ConfigColor(0xE2, 0x5C, 0xA4, 0xFF);
    [ObservableProperty] private ConfigColor _CampLowColor = new ConfigColor(0x9F, 0x1D, 0x91, 0xFF);
    [ObservableProperty] private ConfigColor _DateTimePanelTopTextColor = new ConfigColor(0x50, 0x0A, 0x35, 0xF5);
    [ObservableProperty] private ConfigColor _DateTimePanelBottomTextColor = new ConfigColor(0xFF, 0xD6, 0xAE, 0xFF);
    [ObservableProperty] private ConfigColor _DateTimePanelBottomColor = new ConfigColor(0xFF, 0x8B, 0x8B, 0xFF);
    [ObservableProperty] private ConfigColor _DateTimePanelWaterColor = new ConfigColor(0xFF, 0x5C, 0x94, 0xFF);
    [ObservableProperty] private ConfigColor _TextBoxBackFillColor = new ConfigColor(0xE5, 0x46, 0x7D, 0xFF);
    [ObservableProperty] private ConfigColor _TextBoxFrontFillColor = new ConfigColor(0x22, 0x00, 0x15, 0xFF);
    [ObservableProperty] private ConfigColor _TextBoxFrontBorderColor = new ConfigColor(0xFA, 0x50, 0x8B, 0xFF);
    [ObservableProperty] private ConfigColor _TextBoxSpeakerNameTriangle = new ConfigColor(0x34, 0x06, 0x1C, 0xFF);
    [ObservableProperty] private ConfigColor _TextBoxSpeakerNameTriangleFront = new ConfigColor(0xEB, 0x46, 0x7F, 0xFF);
    [ObservableProperty] private ConfigColor _TextBoxSpeakerName = new ConfigColor(0xFF, 0xE6, 0xBF, 0xFF);
    [ObservableProperty] private ConfigColor _TextBoxLeftHaze = new ConfigColor(0x79, 0x07, 0x2A, 0xFF);
    [ObservableProperty] private ConfigColor _MindWindowOuterBorderNew = new ConfigColor(0xBE, 0x1C, 0x53, 0xFF);
    [ObservableProperty] private ConfigColor _MindWindowInnerColorNew = new ConfigColor(0x39, 0x03, 0x21, 0xFF);
    [ObservableProperty] private ConfigColor _MindWindowBgDotsNew = new ConfigColor(0xA6, 0x06, 0x52, 0xFF);
    [ObservableProperty] private ConfigColor _MinimapPlaceNameBgColor = new ConfigColor(0x73, 0x18, 0x3C, 0xF5);
    [ObservableProperty] private ConfigColor _CheckPromptBackBoxColorNew = new ConfigColor(0xFA, 0x50, 0x8B, 0xFF);
    [ObservableProperty] private ConfigColor _CheckPromptFrontBoxColorNew = new ConfigColor(0x22, 0x00, 0x15, 0xFF);
    [ObservableProperty] private ConfigColor _CheckPromptFrontBoxColorHighNew = new ConfigColor(0x61, 0x00, 0x2C, 0xFF);
    [ObservableProperty] private ConfigColor _BustupShadowColor = new ConfigColor(0xD8, 0x39, 0x70, 0xFF);
    [ObservableProperty] private ConfigColor _CampMenuItemColor1 = new ConfigColor(0xFF, 0xED, 0xC9, 0xFF);
    [ObservableProperty] private ConfigColor _CampMenuItemColor2 = new ConfigColor(0xFF, 0xD7, 0x9D, 0xFF);
    [ObservableProperty] private ConfigColor _CampMenuItemColor3 = new ConfigColor(0xFF, 0xBA, 0x67, 0xFF);
    [ObservableProperty] private ConfigColor _CampMenuItemColorNoSel = new ConfigColor(0xFF, 0xB2, 0x9E, 0xFF);
    [ObservableProperty] private ConfigColor _CampSkillTextColor = new ConfigColor(0xFF, 0xE7, 0xAD, 0xFF);
    [ObservableProperty] private ConfigColor _CampSkillTextColorNoSel = new ConfigColor(0x3D, 0x03, 0x1C, 0xFF);
    [ObservableProperty] private ConfigColor _CampSkillTextColorCurrSel = new ConfigColor(0x3D, 0x03, 0x1C, 0xFF);
    [ObservableProperty] private ConfigColor _SocialStatsCircleAcademicsColor = new ConfigColor(0xA0, 0x0C, 0x42, 0xFF);
    [ObservableProperty] private ConfigColor _SocialStatsCircleCharmColor = new ConfigColor(0xFF, 0x8F, 0xEC, 0xFF);
    [ObservableProperty] private ConfigColor _SocialStatsCircleCourageColor = new ConfigColor(0xF5, 0x62, 0xA7, 0xFF);
    [ObservableProperty] private ConfigColor _CampItemMenuCharacterTopColor = new ConfigColor(0xDD, 0x76, 0x8C, 0xFF);
    [ObservableProperty] private ConfigColor _CampItemMenuCharacterBottomColor = new ConfigColor(0x5B, 0x0C, 0x33, 0xFF);
    [ObservableProperty] private ConfigColor _MsgAssistBgColor = new ConfigColor(0xFF, 0x4A, 0x77, 0xFF);
    [ObservableProperty] private ConfigColor _TownMapBorderColor = new ConfigColor(0x49, 0x04, 0x28, 0xFF);
    [ObservableProperty] private ConfigColor _TownMapTextColor = new ConfigColor(0xFF, 0x58, 0x85, 0xFF);
    [ObservableProperty] private ConfigColor _CampSocialLinkLight = new ConfigColor(0xFF, 0xE7, 0xAD, 0xFF);
    [ObservableProperty] private ConfigColor _CampSocialLinkDark = new ConfigColor(0x49, 0x04, 0x2E, 0xFF);
    [ObservableProperty] private ConfigColor _CampSocialLinkDetailDescBg = new ConfigColor(0x49, 0x04, 0x21, 0xFF);
    [ObservableProperty] private ConfigColor _CampSocialLinkDetailDescTriangle = new ConfigColor(0xE1, 0x2D, 0x69, 0xFF);
    [ObservableProperty] private ConfigColor _CampSocialLinkDetailDescName = new ConfigColor(0xFF, 0xE7, 0xAD, 0xFF);
    [ObservableProperty] private ConfigColor _ArcanaCardFallColor1 = new ConfigColor(0xD6, 0x54, 0x8D, 0xFF);
    [ObservableProperty] private ConfigColor _ArcanaCardFallColor2 = new ConfigColor(0xD6, 0x54, 0x8D, 0xFF);
    [ObservableProperty] private ConfigColor _ArcanaCardFallColor3 = new ConfigColor(0xD6, 0x54, 0x8D, 0xFF);
    [ObservableProperty] private ConfigColor _CampCalendarSundayColor = new ConfigColor(0xFF, 0x00, 0x00, 0xFF);
    [ObservableProperty] private ConfigColor _CampCalendarSundayColor2 = new ConfigColor(0xEE, 0x00, 0x00, 0xFF);
    [ObservableProperty] private ConfigColor _CampCalendarTextColor = new ConfigColor(0x3D, 0x03, 0x1C, 0xFF);
    [ObservableProperty] private ConfigColor _CampCalendarHighlightColor = new ConfigColor(0x46, 0xE7, 0xFF, 0xFF);
    [ObservableProperty] private ConfigColor _CampCalendarPartTimeJobBackground = new ConfigColor(0xB6, 0x3F, 0x67, 0xFF);
    [ObservableProperty] private ConfigColor _PartyPanelBgColor = new ConfigColor(0xE9, 0x57, 0x80, 0xFF);
    [ObservableProperty] private ConfigColor _ButtonPromptHighlightColor = new ConfigColor(0xFF, 0x58, 0x6A, 0xFF);
    [ObservableProperty] private ConfigColor _ButtonPromptTriangleColor = new ConfigColor(0xFF, 0x58, 0x6A, 0xFF);
    [ObservableProperty] private ConfigColor _BackLogBlackboardColor = new ConfigColor(0x25, 0x00, 0x16, 0xFF);
    [ObservableProperty] private ConfigColor _BackLogGladationColor = new ConfigColor(0xFF, 0x4A, 0x77, 0xFF);
    [ObservableProperty] private ConfigColor _BackLogBlueboardColorEx = new ConfigColor(0xFF, 0x4A, 0x77, 0xFF);
    [ObservableProperty] private ConfigColor _BackLogTitleColor = new ConfigColor(0xFF, 0x4A, 0x88, 0xFF);
    [ObservableProperty] private ConfigColor _BackLogTexColorSelected = new ConfigColor(0xFF, 0x89, 0xA6, 0xFF);
    [ObservableProperty] private ConfigColor _BackLogTexColorUnselectedEx = new ConfigColor(0xB6, 0x3F, 0x67, 0xFF);
    [ObservableProperty] private ConfigColor _LocationSelectBgColor = new ConfigColor(0xFF, 0x58, 0x9F, 0xFF);
    [ObservableProperty] private ConfigColor _LocationSelectMarkerColor = new ConfigColor(0xFF, 0x4A, 0x94, 0xFF);
    [ObservableProperty] private ConfigColor _LocationSelectSelColor = new ConfigColor(0xFF, 0x58, 0x95, 0xFF);
    [ObservableProperty] private ConfigColor _TimeSkipColor = new ConfigColor(0xFF, 0x58, 0x8A, 0xFF);
    [ObservableProperty] private ConfigColor _NextDayBandColor = new ConfigColor(0xB6, 0x3F, 0x67, 0xFF);
    [ObservableProperty] private ConfigColor _NextDayTextColor = new ConfigColor(0xCD, 0x62, 0x89, 0xFF);
    [ObservableProperty] private ConfigColor _NextDayMoonShadowColor = new ConfigColor(0xA3, 0x26, 0x50, 0xFF);
    [ObservableProperty] private ConfigColor _NextDayRipple = new ConfigColor(0xFF, 0x58, 0x6A, 0xFF);
    [ObservableProperty] private ConfigColor _ShopPayColor = new ConfigColor(0xFF, 0xB3, 0xCA, 0xFF);
    [ObservableProperty] private ConfigColor _ShopFillColor = new ConfigColor(0xFF, 0x58, 0xA4, 0xFF);
    [ObservableProperty] private ConfigColor _ShopShadowColor = new ConfigColor(0xB6, 0x15, 0x5C, 0xFF);
    [ObservableProperty] private ConfigColor _ShopPayUnselColor = new ConfigColor(0xD4, 0x45, 0x92, 0xFF);
    [ObservableProperty] private ConfigColor _GetItemBgMaskColor = new ConfigColor(0x54, 0x0D, 0x54, 0xFF);
    [ObservableProperty] private ConfigColor _GetItemBgColor = new ConfigColor(0xFF, 0x4A, 0x8E, 0xFF);
    [ObservableProperty] private ConfigColor _GetItemGotTextColor = new ConfigColor(0xFF, 0x41, 0xC8, 0xFF);
    [ObservableProperty] private ConfigColor _GetItemCountBgColor = new ConfigColor(0xFF, 0x58, 0x9A, 0xFF);
    [ObservableProperty] private ConfigColor _MindSelActiveTextColor = new ConfigColor(0xDE, 0x12, 0x74, 0xFF);
    [ObservableProperty] private ConfigColor _MindSelWindowFill = new ConfigColor(0x34, 0x06, 0x1C, 0xFF);
    [ObservableProperty] private ConfigColor _MindSelWindowBorder = new ConfigColor(0x34, 0x06, 0x1C, 0xFF);
    [ObservableProperty] private ConfigColor _MindSelectDotColor = new ConfigColor(0x67, 0x00, 0x00, 0xFF);
    [ObservableProperty] private ConfigColor _GenericSelectCharacterBackplate = new ConfigColor(0xFF, 0x58, 0x8A, 0xFF);
    [ObservableProperty] private ConfigColor _GenericSelectListColorMorning = new ConfigColor(0xFF, 0x4A, 0x88, 0xFF);
    [ObservableProperty] private ConfigColor _GenericSelectListColorAfterSchool = new ConfigColor(0xFF, 0x58, 0x9A, 0xFF);
    [ObservableProperty] private ConfigColor _GenericSelectListColorNight = new ConfigColor(0xCD, 0x62, 0x9E, 0xFF);
    [ObservableProperty] private ConfigColor _GenericSelectTitle = new ConfigColor(0xFF, 0x58, 0x9F, 0xFF);
    [ObservableProperty] private ConfigColor _GenericSelectCharacterShadow = new ConfigColor(0xD4, 0x45, 0x80, 0xFF);
    [ObservableProperty] private ConfigColor _MsgSimpleSelectTextColor = new ConfigColor(0xFF, 0x58, 0x95, 0xFF);
    [ObservableProperty] private ConfigColor _MsgSimpleSelectShadowEx = new ConfigColor(0x49, 0x04, 0x21, 0xFF);
    [ObservableProperty] private ConfigColor _MsgSimpleSelectBorderColorEx = new ConfigColor(0x49, 0x04, 0x21, 0xFF);
    [ObservableProperty] private ConfigColor _MsgSimpleFillColor = new ConfigColor(0xD4, 0x15, 0x5F, 0xFF);
    [ObservableProperty] private ConfigColor _MsgSimpleSystemLightColor = new ConfigColor(0xFF, 0x58, 0x8A, 0xFF);
    [ObservableProperty] private ConfigColor _MsgSimpleSystemDarkColor = new ConfigColor(0x2F, 0x00, 0x1C, 0xFF);
    [ObservableProperty] private ConfigColor _MsgSimpleSystemGradationColor = new ConfigColor(0x49, 0x04, 0x28, 0xFF);
    [ObservableProperty] private ConfigColor _PersonaStatusSkillListBg = new ConfigColor(0x2A, 0x00, 0x1D, 0xFF);
    [ObservableProperty] private ConfigColor _PersonaStatusSkillListBg2 = new ConfigColor(0xE9, 0x47, 0x7E, 0xFF);
    [ObservableProperty] private ConfigColor _PersonaStatusSkillListCheckboardAlt = new ConfigColor(0x55, 0x1F, 0x3F, 0xFF);
    [ObservableProperty] private ConfigColor _PersonaSkillListNextSkillColor = new ConfigColor(0xFB, 0x67, 0x96, 0xFF);
    [ObservableProperty] private ConfigColor _PersonaSkillListNextLevelColor = new ConfigColor(0xFF, 0xE2, 0x89, 0xFF);
    [ObservableProperty] private ConfigColor _PersonaSkillListNextSkillInfoName = new ConfigColor(0xFF, 0xDD, 0x9B, 0xFF);
    [ObservableProperty] private ConfigColor _PersonaStatusPlayerInfoColor = new ConfigColor(0xFF, 0xF5, 0x9E, 0xFF);
    [ObservableProperty] private ConfigColor _PersonaStatusInfoSelPersonaColor1 = new ConfigColor(0xFF, 0xF5, 0x9E, 0xFF);
    [ObservableProperty] private ConfigColor _PersonaStatusInfoSelPersonaColor2 = new ConfigColor(0xE0, 0x3F, 0x74, 0xFF);
    [ObservableProperty] private ConfigColor _PersonaStatusParamColor = new ConfigColor(0xF4, 0x5A, 0x85, 0xFF);
    [ObservableProperty] private ConfigColor _PersonaStatusCommentaryTitleColor = new ConfigColor(0xFF, 0xE2, 0x9E, 0xFF);
    [ObservableProperty] private ConfigColor _PersonaStatusBaseStat = new ConfigColor(0xFF, 0xE2, 0x9E, 0xFF);
    [ObservableProperty] private ConfigColor _PersonaStatusAttributeOutline = new ConfigColor(0xE9, 0x47, 0x7E, 0xFF);
    [ObservableProperty] private ConfigColor _NetworkDailyActionStickyNoteBgColor1 = new ConfigColor(0xD8, 0x3D, 0x8F, 0xFF);
    [ObservableProperty] private ConfigColor _NetworkDailyActionStickyNoteBgColor2 = new ConfigColor(0xFF, 0x58, 0x8F, 0xFF);
    [ObservableProperty] private ConfigColor _NetworkDailyActionStickyNoteDotColor1 = new ConfigColor(0xFE, 0x9D, 0xB6, 0xFF);
    [ObservableProperty] private ConfigColor _NetworkDailyActionStickyNoteDotColor2 = new ConfigColor(0xFF, 0x89, 0xB5, 0xFF);
    [ObservableProperty] private ConfigColor _NetworkDailyActionStickyNoteTextColor1 = new ConfigColor(0xFF, 0xD1, 0xDC, 0xFF);
    [ObservableProperty] private ConfigColor _NetworkDailyActionStickyNoteTextColor2 = new ConfigColor(0xFF, 0xBD, 0xCE, 0xFF);
    [ObservableProperty] private ConfigColor _NetworkDailyActionBlueBgColor = new ConfigColor(0xD4, 0x45, 0x92, 0xFF);
    [ObservableProperty] private ConfigColor _NetworkDailyActionNetworkIcon = new ConfigColor(0xFF, 0x58, 0x8F, 0xFF);
    [ObservableProperty] private ConfigColor _SimpleShopInfoColor = new ConfigColor(0xFF, 0x58, 0x6A, 0xFF);
    [ObservableProperty] private ConfigColor _CutinOuterHighlight = new ConfigColor(0xFF, 0x4A, 0x8E, 0xFF);
    [ObservableProperty] private ConfigColor _CutinEmotionGradient = new ConfigColor(0xFF, 0x89, 0xA6, 0xFF);
    [ObservableProperty] private ConfigColor _CutinEmotionTint = new ConfigColor(0xFF, 0x4A, 0x8E, 0xFF);
    [ObservableProperty] private ConfigColor _TitleMenuSelRectColor = new ConfigColor(0xFF, 0x58, 0x92, 0xFF);
    [ObservableProperty] private ConfigColor _LocalStaffRollHeader = new ConfigColor(0xFF, 0x89, 0xA6, 0xFF);
    [ObservableProperty] private ConfigColor _DifficultySelectBgColor = new ConfigColor(0x49, 0x04, 0x21, 0xFF);
    [ObservableProperty] private ConfigColor _WipeBgColor = new ConfigColor(0x49, 0x04, 0x27, 0xFF);
    [ObservableProperty] private ConfigColor _CampItemStatValuePadColor = new ConfigColor(0xBC, 0x81, 0x5D, 0xFF);
    [ObservableProperty] private ConfigColor _CampItemStatValueValColor = new ConfigColor(0xFE, 0xE6, 0xAD, 0xFF);
    [ObservableProperty] private ConfigColor _CampEquipOverviewListType = new ConfigColor(0xF6, 0xCD, 0x95, 0xFF);
    [ObservableProperty] private ConfigColor _CampPersonaArcanaPhraseColor = new ConfigColor(0xFF, 0xF5, 0x9E, 0xFF);
    [ObservableProperty] private ConfigColor _CampPersonaNameColor = new ConfigColor(0xFF, 0xF5, 0x9E, 0xFF);
    [ObservableProperty] private ConfigColor _CampPersonaArcanaBgColor = new ConfigColor(0x49, 0x04, 0x21, 0xFF);
    [ObservableProperty] private ConfigColor _CampStatusKotoneLineColor = new ConfigColor(0xFF, 0x89, 0xA6, 0xFF);
    [ObservableProperty] private ConfigColor _CampStatusInactiveMemberBgTartarus = new ConfigColor(0x63, 0x27, 0x3E, 0xFF);
    [ObservableProperty] private ConfigColor _CampStatusInactiveMemberDetailsPalePinkTartarus = new ConfigColor(0xED, 0xC0, 0xD8, 0xFF);
    [ObservableProperty] private ConfigColor _CampStatusInactiveMemberDetailsDarkPinkTartarus = new ConfigColor(0x78, 0x19, 0x46, 0xFF);
    [ObservableProperty] private ConfigColor _CampStatusInactiveMemberHPBarTartarus = new ConfigColor(0x8B, 0x0D, 0x51, 0xFF);
    [ObservableProperty] private ConfigColor _TownMapLocationDetailsBgTint = new ConfigColor(0xDD, 0x74, 0xA1, 0xFF);
    [ObservableProperty] private ConfigColor _TownMapLocationDetailsTopLeftBg = new ConfigColor(0xF4, 0x41, 0x7F, 0xFF);
    [ObservableProperty] private ConfigColor _TownMapLocationDetailsTopLeftText = new ConfigColor(0xA7, 0x1D, 0x5B, 0xFF);
    [ObservableProperty] private ConfigColor _TownMapSelectedMarkerOutline = new ConfigColor(0xFF, 0x4A, 0x77, 0xFF);
    [ObservableProperty] private ConfigColor _SocialStatsUpText = new ConfigColor(0xFF, 0xE7, 0xAD, 0xFF);
    [ObservableProperty] private ConfigColor _SocialStatsPulseCircleColorMain = new ConfigColor(0xFF, 0xE7, 0xAD, 0xFF);
    [ObservableProperty] private ConfigColor _SocialStatsPulseCircleColorFade = new ConfigColor(0xFF, 0x58, 0x6A, 0xFF);
    [ObservableProperty] private ConfigColor _MsgAssistTextBgColor = new ConfigColor(0x49, 0x04, 0x21, 0xFF);
    [ObservableProperty] private ConfigColor _LocationSelMapBg = new ConfigColor(0x5B, 0x2B, 0x41, 0xFF);
    [ObservableProperty] private ConfigColor _LocationSelMapLabel = new ConfigColor(0x1F, 0x11, 0x17, 0xFF);
    [ObservableProperty] private ConfigColor _MsgSystemPicBorderColor = new ConfigColor(0xB6, 0x3F, 0x7A, 0xFF);
    [ObservableProperty] private ConfigColor _TutorialListEntryColor = new ConfigColor(0xFF, 0xE4, 0xA3, 0xFF);
    [ObservableProperty] private ConfigColor _TutorialBgColor = new ConfigColor(0x49, 0x04, 0x28, 0xFF);
    [ObservableProperty] private ConfigColor _MissingLastSighted = new ConfigColor(0xFF, 0x89, 0xA6, 0xFF);
    [ObservableProperty] private ConfigColor _MissingPageBg = new ConfigColor(0x49, 0x04, 0x21, 0xFF);
    [ObservableProperty] private ConfigColor _MissingTextLight = new ConfigColor(0xFF, 0x89, 0xA6, 0xFF);
    [ObservableProperty] private ConfigColor _MissingTextDark = new ConfigColor(0x49, 0x04, 0x21, 0xFF);
    [ObservableProperty] private ConfigColor _MissingSortTriangle = new ConfigColor(0xFF, 0x86, 0x83, 0xFF);
    [ObservableProperty] private ConfigColor _NamiTopAColor = new ConfigColor(0xF4, 0xE2, 0xB6, 0xFF);
    [ObservableProperty] private ConfigColor _NamiTopBColor = new ConfigColor(0xCD, 0xC9, 0xB7, 0xFF);
    [ObservableProperty] private ConfigColor _NamiSkillAColor = new ConfigColor(0xFF, 0xE5, 0xA9, 0xFF);
    [ObservableProperty] private ConfigColor _NamiSkillBColor = new ConfigColor(0xFF, 0xE5, 0xA9, 0xFF);
    [ObservableProperty] private ConfigColor _NamiItemAColor = new ConfigColor(0xFF, 0xE5, 0xA9, 0xFF);
    [ObservableProperty] private ConfigColor _NamiItemBColor = new ConfigColor(0xFF, 0xE5, 0xA9, 0xFF);
    [ObservableProperty] private ConfigColor _NamiEquipAColor = new ConfigColor(0xF4, 0xE2, 0xB6, 0xFF);
    [ObservableProperty] private ConfigColor _NamiEquipBColor = new ConfigColor(0xFD, 0xB3, 0x9D, 0xFF);
    [ObservableProperty] private ConfigColor _NamiPersonaAColor = new ConfigColor(0xFF, 0xE5, 0xA9, 0xFF);
    [ObservableProperty] private ConfigColor _NamiPersonaBColor = new ConfigColor(0xFF, 0xE5, 0xA9, 0xFF);
    [ObservableProperty] private ConfigColor _NamiStatusAColor = new ConfigColor(0xF4, 0xE2, 0xB6, 0xFF);
    [ObservableProperty] private ConfigColor _NamiStatusBColor = new ConfigColor(0xFD, 0xB3, 0x9D, 0xFF);
    [ObservableProperty] private ConfigColor _NamiQuestAColor = new ConfigColor(0xF4, 0xE2, 0xB6, 0xFF);
    [ObservableProperty] private ConfigColor _NamiQuestBColor = new ConfigColor(0xFD, 0xB3, 0x9D, 0xFF);
    [ObservableProperty] private ConfigColor _NamiCommuAColor = new ConfigColor(0xF4, 0xE2, 0xB6, 0xFF);
    [ObservableProperty] private ConfigColor _NamiCommuBColor = new ConfigColor(0xFD, 0xB3, 0x9D, 0xFF);
    [ObservableProperty] private ConfigColor _NamiCalendarAColor = new ConfigColor(0xF4, 0xE2, 0xB6, 0xFF);
    [ObservableProperty] private ConfigColor _NamiCalendarBColor = new ConfigColor(0xFD, 0xB3, 0x9D, 0xFF);
    [ObservableProperty] private ConfigColor _NamiSystemAColor = new ConfigColor(0xFF, 0xE5, 0xA9, 0xFF);
    [ObservableProperty] private ConfigColor _NamiSystemBColor = new ConfigColor(0xFF, 0xE5, 0xA9, 0xFF);
    [ObservableProperty] private ConfigColor _NamiTutorialAColor = new ConfigColor(0xF4, 0xE2, 0xB6, 0xFF);
    [ObservableProperty] private ConfigColor _NamiTutorialBColor = new ConfigColor(0xFF, 0xB7, 0x97, 0xFF);
    [ObservableProperty] private ConfigColor _NamiConfigAColor = new ConfigColor(0xF4, 0xE2, 0xB6, 0xFF);
    [ObservableProperty] private ConfigColor _NamiConfigBColor = new ConfigColor(0xFF, 0xD3, 0xB5, 0xFF);
    [ObservableProperty] private ConfigColor _GradAUpColorHigh = new ConfigColor(0xFF, 0xFF, 0xFF, 0xFF);
    [ObservableProperty] private ConfigColor _GradBUpColorHigh = new ConfigColor(0x64, 0xFF, 0x3B, 0xFF);
    [ObservableProperty] private ConfigColor _GradBDownColorHigh = new ConfigColor(0xFF, 0xCE, 0xAA, 0xFF);
    [ObservableProperty] private ConfigColor _GradAUpColorMid = new ConfigColor(0xFF, 0xFF, 0xFF, 0xFF);
    [ObservableProperty] private ConfigColor _GradBUpColorMid = new ConfigColor(0xFF, 0xEA, 0x00, 0xFF);
    [ObservableProperty] private ConfigColor _GradBDownColorMid = new ConfigColor(0xFF, 0xD1, 0x00, 0xFF);
    [ObservableProperty] private ConfigColor _GradAUpColorLow = new ConfigColor(0xFF, 0xFF, 0xFF, 0xFF);
    [ObservableProperty] private ConfigColor _GradBUpColorLow = new ConfigColor(0xFF, 0x00, 0x00, 0xFF);
    [ObservableProperty] private ConfigColor _GradBDownColorLow = new ConfigColor(0xFF, 0x00, 0x00, 0xFF);
    [ObservableProperty] private ConfigColor _HeroCaptureBgColor = new ConfigColor(0xE8, 0x64, 0xBC, 0xFF);
    [ObservableProperty] private ConfigColor _MissingDetailFemcChairsShadow = new ConfigColor(0x36, 0x0C, 0x18, 0xFF);
    [ObservableProperty] private ConfigColor _RequestBackCard = new ConfigColor(0x60, 0x00, 0x2A, 0xFF);
    [ObservableProperty] private ConfigColor _RequestBackSquares = new ConfigColor(0x38, 0x00, 0x19, 0xFF);
    [ObservableProperty] private ConfigColor _RequestBackCardDetail = new ConfigColor(0x2E, 0x09, 0x19, 0xFF);
    [ObservableProperty] private ConfigColor _RequestBackCardRightDownDetail = new ConfigColor(0x5D, 0x00, 0x2C, 0xFF);
    [ObservableProperty] private ConfigColor _RequestDetailFemcChairsShadow = new ConfigColor(0x48, 0x11, 0x23, 0xFF);
    [ObservableProperty] private ConfigColor _RequestTaskFont = new ConfigColor(0xFF, 0xC8, 0x91, 0xFF);
    [ObservableProperty] private ConfigColor _RequestDetailsFont = new ConfigColor(0xFF, 0xE7, 0xAD, 0xFF);
    [ObservableProperty] private ConfigColor _RequestDetailCompleted = new ConfigColor(0x43, 0x0D, 0x1B, 0xFF);
    [ObservableProperty] private ConfigColor _RequestDetailBackgroundCompleted = new ConfigColor(0x8C, 0x09, 0x3D, 0xFF);
    [ObservableProperty] private ConfigColor _RequestDetailEarned = new ConfigColor(0xFF, 0xD3, 0x91, 0xFF);
    [ObservableProperty] private ConfigColor _RequestDifficultyRankUp = new ConfigColor(0x17, 0x03, 0x0C, 0xFF);
    [ObservableProperty] private ConfigColor _RequestDifficultyRankDown = new ConfigColor(0x41, 0x03, 0x22, 0xFF);
    [ObservableProperty] private ConfigColor _RequestDifficultyIndicator = new ConfigColor(0x71, 0x0D, 0x3E, 0xFF);
    [ObservableProperty] private ConfigColor _RequestDifficultyFont = new ConfigColor(0x7D, 0x25, 0x36, 0xFF);
    [ObservableProperty] private ConfigColor _RequestStatusFontTagBack = new ConfigColor(0xFF, 0xE7, 0xAD, 0xFF);
    [ObservableProperty] private ConfigColor _RequestStatusTagFont = new ConfigColor(0x68, 0x01, 0x3D, 0xFF);
    [ObservableProperty] private ConfigColor _RequestStatusTagUnderlay = new ConfigColor(0x6A, 0x00, 0x42, 0xFF);
    [ObservableProperty] private ConfigColor _MusicNotesColor = new ConfigColor(0xFF, 0x8F, 0xB6, 0xFF);
    [ObservableProperty] private ConfigColor _PartyPanelMissingHealthSp = new ConfigColor(0x68, 0x01, 0x08, 0xFF);
    [ObservableProperty] private ConfigColor _CampColorTransition = new ConfigColor(0xFF, 0x89, 0xA6, 0xFF);
    [ObservableProperty] private ConfigColor _CampSkillCardBackground = new ConfigColor(0x78, 0x68, 0x6F, 0xFF);
    [ObservableProperty] private ConfigColor _CampSkillCardFrame = new ConfigColor(0x65, 0x35, 0x48, 0xFF);
    [ObservableProperty] private ConfigColor _CampSkillCardFemc = new ConfigColor(0x21, 0x08, 0x12, 0xFF);
    [ObservableProperty] private ConfigColor _CampFemcShadow = new ConfigColor(0xB7, 0x9A, 0xA0, 0xFF);
    [ObservableProperty] private ConfigColor _CampHighlightedColor = new ConfigColor(0x32, 0xBE, 0xFF, 0xFF);
    [ObservableProperty] private ConfigColor _CampHighlightedLowerColor = new ConfigColor(0x00, 0xD8, 0xFF, 0xFF);
    [ObservableProperty] private ConfigColor _CampHighlightedMidColor = new ConfigColor(0x00, 0x00, 0x00, 0xFF);
    [ObservableProperty] private ConfigColor _CampSocialLinkArcanaHighlightedColor = new ConfigColor(0x6D, 0x03, 0x0D, 0x7F);
    [ObservableProperty] private ConfigColor _CampSystemStartFallingWordsColor = new ConfigColor(0x86, 0x02, 0x4B, 0xFF);
    [ObservableProperty] private ConfigColor _CampSystemEndFallingWordsColor = new ConfigColor(0xA6, 0x09, 0x6F, 0xFF);
    [ObservableProperty] private ConfigColor _EquipSquareBack = new ConfigColor(0x49, 0x04, 0x2E, 0xFF);
    [ObservableProperty] private ConfigColor _EquipTitleBackground = new ConfigColor(0x3B, 0x02, 0x25, 0xFF);
    [ObservableProperty] private ConfigColor _EquipEffectColor = new ConfigColor(0x55, 0x1F, 0x3B, 0xFF);
    [ObservableProperty] private ConfigColor _CampScreenshotFilterKeyframe1 = new ConfigColor(0x0C, 0x01, 0x05, 0xFF);
    [ObservableProperty] private ConfigColor _CampScreenshotFilterKeyframe2 = new ConfigColor(0xCC, 0x19, 0x52, 0xFF);
    [ObservableProperty] private ConfigColor _CampScreenshotFilterKeyframe3 = new ConfigColor(0xF2, 0x26, 0x67, 0xFF);
    [ObservableProperty] private ConfigColor _CampScreenshotFilterKeyframe4 = new ConfigColor(0xFF, 0xFF, 0xFF, 0xFF);
    [ObservableProperty] private ConfigColor _CampShardsKeyframe1 = new ConfigColor(0xFF, 0x4D, 0x70, 0x66);
    [ObservableProperty] private ConfigColor _CampShardsKeyframe2 = new ConfigColor(0x64, 0x96, 0xFB, 0xD6);
    [ObservableProperty] private ConfigColor _CampShardsKeyframe3 = new ConfigColor(0x7E, 0x80, 0xFB, 0xF5);
    [ObservableProperty] private ConfigColor _CampShardsKeyframe4 = new ConfigColor(0xFF, 0x83, 0x8A, 0xFF);
    [ObservableProperty] private ConfigColor _CampShardsKeyframe5 = new ConfigColor(0xFF, 0xC5, 0x85, 0xDF);
    [ObservableProperty] private ConfigColor _CampShardsKeyframe6 = new ConfigColor(0xB8, 0x1C, 0x3B, 0xCB);
    [ObservableProperty] private ConfigColor _CampShardsKeyframe7 = new ConfigColor(0xED, 0x5F, 0x9D, 0xA9);
    [ObservableProperty] private ConfigColor _QuestFemcChairsShadow = new ConfigColor(0x58, 0x0F, 0x36, 0xFF);
    [ObservableProperty] private ConfigColor _MainToggler = new ConfigColor(0x2E, 0x09, 0x17, 0xFF);
    [ObservableProperty] private ConfigColor _SecondaryToggler = new ConfigColor(0x2F, 0x12, 0x1E, 0xFF);
    [ObservableProperty] private ConfigColor _PersonaStatusHighlightedColor = new ConfigColor(0x00, 0xD8, 0xFF, 0x99);
    [ObservableProperty] private ConfigColor _SkillCardSkillBg = new ConfigColor(0x66, 0x2B, 0x47, 0xFF);
    [ObservableProperty] private ConfigColor _SkillCardSelectedSkillAnimation = new ConfigColor(0xD1, 0x62, 0x87, 0xFF);
    [ObservableProperty] private ConfigColor _SkillDescriptionMainBg = new ConfigColor(0x57, 0x21, 0x3D, 0xFF);
    [ObservableProperty] private ConfigColor _SkillDescriptionCornerBg = new ConfigColor(0x7D, 0x4D, 0x66, 0xFF);
    [ObservableProperty] private ConfigColor _NoneSkillColor = new ConfigColor(0x9F, 0x83, 0x8C, 0xFF);
    [ObservableProperty] private ConfigColor _SelectedSkillFontColor = new ConfigColor(0x2A, 0x00, 0x12, 0xFF);
    [ObservableProperty] private ConfigColor _SwapSkillShadowSelectedFontColor = new ConfigColor(0xFE, 0x9B, 0xB8, 0xFF);
    [ObservableProperty] private ConfigColor _SwapSkillUnselectedFontColor = new ConfigColor(0x9E, 0x3C, 0x5E, 0xFF);
    [ObservableProperty] private ConfigColor _SwapSkillUnselectedBgColor = new ConfigColor(0xFD, 0x75, 0x9B, 0xFF);
    [ObservableProperty] private ConfigColor _InheritableSkillTick = new ConfigColor(0xCC, 0x7C, 0x93, 0xFF);
    [ObservableProperty] private ConfigColor _InheritableSkillTickBg = new ConfigColor(0x71, 0x36, 0x4D, 0xFF);
    [ObservableProperty] private ConfigColor _NextSkillZero = new ConfigColor(0x99, 0x53, 0x64, 0xFF);
    [ObservableProperty] private ConfigColor _NextSkillOutterOutlineColor = new ConfigColor(0x59, 0x02, 0x23, 0xFF);
    [ObservableProperty] private ConfigColor _NextSkillInnerOutlineColor = new ConfigColor(0xFD, 0x9B, 0xB7, 0xFF);
    [ObservableProperty] private ConfigColor _PersonaFusionShadow = new ConfigColor(0x30, 0x10, 0x27, 0xFF);
    [ObservableProperty] private ConfigColor _PersonaSocialLinkInheritance = new ConfigColor(0x6E, 0x03, 0x0A, 0xFF);
    [ObservableProperty] private ConfigColor _MutationStripColor = new ConfigColor(0xC6, 0x00, 0x35, 0xFF);
    [ObservableProperty] private ConfigColor _PersonaLvlUpSkillListNextSkillColor = new ConfigColor(0xFF, 0x7D, 0xA9, 0xFF);
    [ObservableProperty] private ConfigColor _FusionTopRightIndicatorColors = new ConfigColor(0xFF, 0xBD, 0xCE, 0xFF);
    [ObservableProperty] private ConfigColor _BtlResultSquaresColor = new ConfigColor(0xD1, 0x00, 0x5A, 0xFF);
    [ObservableProperty] private ConfigColor _PartyPanelFemcBgColor = new ConfigColor(0xFF, 0x89, 0xA6, 0xFF);
    [ObservableProperty] private ConfigColor _DataColumnColor = new ConfigColor(0x92, 0x72, 0x7B, 0xFF);
    [ObservableProperty] private ConfigColor _SelectedSortColumnTitle = new ConfigColor(0xFF, 0xF4, 0xE9, 0xFF);
    [ObservableProperty] private ConfigColor _SimpleShopHighlightedColor = new ConfigColor(0xED, 0x6D, 0x91, 0xFF);
    [ObservableProperty] private ConfigColor _SimpleShopBlurFilterColor = new ConfigColor(0x68, 0x01, 0x08, 0xFF);
    [ObservableProperty] private ConfigColor _SimpleShopZeroFontColor = new ConfigColor(0xFF, 0x00, 0x00, 0xFF);
    [ObservableProperty] private ConfigColor _SimpleShopBuyShadowColor = new ConfigColor(0xEB, 0x44, 0x7D, 0xFF);
    [ObservableProperty] private ConfigColor _SimpleShopBuyFontColor = new ConfigColor(0x5C, 0x00, 0x06, 0xFF);
    [ObservableProperty] private ConfigColor _DateTimePanelWeekdayTriangleColor = new ConfigColor(0x24, 0x07, 0x09, 0xFF);
    [ObservableProperty] private ConfigColor _ItemListHighlightedColor = new ConfigColor(0xFF, 0x75, 0x9C, 0xFF);
    [ObservableProperty] private ConfigColor _MinimapFieldInnerCircle = new ConfigColor(0xEB, 0x00, 0x4E, 0xFF);
    [ObservableProperty] private ConfigColor _MinimapFieldOutterCircle = new ConfigColor(0x2B, 0x10, 0x13, 0xFF);
    [ObservableProperty] private ConfigColor _MinimapLocationsHighStrip = new ConfigColor(0x2B, 0x10, 0x13, 0xFF);
    [ObservableProperty] private ConfigColor _MinimapLocationsLowerStrip = new ConfigColor(0xEB, 0x00, 0x4E, 0xFF);
    [ObservableProperty] private ConfigColor _MinimapLocationsSelectionColor = new ConfigColor(0xE1, 0x14, 0x51, 0xFF);
    [ObservableProperty] private ConfigColor _PreviewRoundedOutline = new ConfigColor(0xFD, 0x9B, 0xB7, 0xFF);
    [ObservableProperty] private ConfigColor _PreviewTaintColor = new ConfigColor(0xBB, 0x96, 0xA0, 0xFF);
    [ObservableProperty] private ConfigColor _LocationSubtleShadowColor = new ConfigColor(0x53, 0x00, 0x04, 0xFF);
    [ObservableProperty] private ConfigColor _MiniLocationCircleColor = new ConfigColor(0xEB, 0x44, 0x7D, 0xFF);
    [ObservableProperty] private ConfigColor _SaveLoadScreenshotFilterKeyframe1 = new ConfigColor(0x99, 0x25, 0x60, 0xFF);
    [ObservableProperty] private ConfigColor _SaveLoadScreenshotFilterKeyframe2 = new ConfigColor(0xCC, 0x19, 0x6B, 0xFF);
    [ObservableProperty] private ConfigColor _SaveLoadScreenshotFilterKeyframe3 = new ConfigColor(0xF2, 0x26, 0x86, 0xFF);
    [ObservableProperty] private ConfigColor _MailStartAnimationColor = new ConfigColor(0xC2, 0x00, 0x44, 0xFF);
    [ObservableProperty] private ConfigColor _CampConfigurationLightReflectiveColor1 = new ConfigColor(0xFF, 0x2E, 0x70, 0xFF);
    [ObservableProperty] private ConfigColor _CampConfigurationLightReflectiveColor2 = new ConfigColor(0xFF, 0x60, 0x92, 0xFF);
    [ObservableProperty] private ConfigColor _SaveLoadGradientBottomTopColor = new ConfigColor(0xB2, 0x22, 0x62, 0xFF);
    [ObservableProperty] private ConfigColor _SaveLoadGradientBottomColor = new ConfigColor(0xB2, 0x22, 0x62, 0xFF);
    [ObservableProperty] private ConfigColor _SaveLoadGradientTopColor = new ConfigColor(0xFF, 0xDE, 0x99, 0xFF);
    [ObservableProperty] private ConfigColor _SaveLoadGradientTopBottomColor = new ConfigColor(0xFF, 0x8C, 0xA8, 0xFF);
    [ObservableProperty] private ConfigColor _PersonaStatusDeepColorFilter = new ConfigColor(0xFF, 0x00, 0x58, 0xA9);
    [ObservableProperty] private ConfigColor _PersonaStatusMediumStrongColorFilter = new ConfigColor(0x77, 0x00, 0x42, 0xFF);
    [ObservableProperty] private ConfigColor _PersonaStatusSoftColorFilter = new ConfigColor(0x8B, 0x01, 0x48, 0xFF);
    [ObservableProperty] private ConfigColor _PersonaStatusInheritanceSquareColor = new ConfigColor(0x00, 0xD8, 0xFF, 0x00);
    [ObservableProperty] private ConfigColor _PersonaStatusStripColor = new ConfigColor(0xF4, 0x5A, 0x85, 0xFF);
    [ObservableProperty] private ConfigColor _PersonaStatusWavesStripColor = new ConfigColor(0x00, 0xD8, 0xFF, 0xFF);
    [ObservableProperty] private ConfigColor _PersonaStatusMMUnk1 = new ConfigColor(0x00, 0xD8, 0xFF, 0xB2);
    [ObservableProperty] private ConfigColor _PersonaStatusMMUnk2 = new ConfigColor(0x00, 0xD8, 0xFF, 0x00);
    [ObservableProperty] private ConfigColor _PersonaStatusMMUnk3 = new ConfigColor(0x00, 0xD8, 0xFF, 0xFF);
    [ObservableProperty] private ConfigColor _PersonaStatusMMUnk4 = new ConfigColor(0x00, 0xD8, 0xFF, 0xFF);
    [ObservableProperty] private ConfigColor _QuestElizabethTopGradient1 = new ConfigColor(0xAD, 0x00, 0x4C, 0xCC);
    [ObservableProperty] private ConfigColor _QuestElizabethBottomGradient = new ConfigColor(0xAD, 0x00, 0x89, 0x00);
    [ObservableProperty] private ConfigColor _QuestElizabethTopGradient2 = new ConfigColor(0xC3, 0x5E, 0x04, 0x00);
    [ObservableProperty] private ConfigColor _PersonaStatusScreenshotFilterKeyframe1 = new ConfigColor(0xB3, 0x00, 0x5D, 0xFF);
    [ObservableProperty] private ConfigColor _PersonaStatusScreenshotFilterKeyframe2 = new ConfigColor(0xCC, 0x19, 0x71, 0xFF);
    [ObservableProperty] private ConfigColor _PersonaStatusScreenshotFilterKeyframe3 = new ConfigColor(0xD9, 0x99, 0xAA, 0xFF);
    [ObservableProperty] private ConfigColor _PersonaStatusScreenshotFilterKeyframe4 = new ConfigColor(0xE5, 0xCC, 0xD7, 0xFF);
    [ObservableProperty] private ConfigColor _CampCalendarScreenshotFilterKeyframe1 = new ConfigColor(0xCC, 0x40, 0x6A, 0xFF);
    [ObservableProperty] private ConfigColor _CampCalendarScreenshotFilterKeyframe2 = new ConfigColor(0xE6, 0x66, 0x8A, 0xFF);
    [ObservableProperty] private ConfigColor _CampCalendarScreenshotFilterKeyframe3 = new ConfigColor(0xEF, 0x0E, 0x64, 0xFF);
    [ObservableProperty] private ConfigColor _CampCalendarScreenshotFilterKeyframe4 = new ConfigColor(0xED, 0x57, 0xAC, 0xFF);
    [ObservableProperty] private ConfigColor _CampMainMenuConfigScreenshotFilterKeyframe1 = new ConfigColor(0x4D, 0x00, 0x26, 0xFF);
    [ObservableProperty] private ConfigColor _CampMainMenuConfigScreenshotFilterKeyframe2 = new ConfigColor(0x66, 0x00, 0x36, 0xFF);
    [ObservableProperty] private ConfigColor _CampMainMenuConfigScreenshotFilterKeyframe3 = new ConfigColor(0x99, 0x00, 0x47, 0xFF);
    [ObservableProperty] private ConfigColor _CampMainMenuConfigScreenshotFilterKeyframe4 = new ConfigColor(0xCA, 0x73, 0x8F, 0xFF);
    [ObservableProperty] private ConfigColor _PartyMemberSilhouetteSelectionColor = new ConfigColor(0xFE, 0x9B, 0xB8, 0xFF);
    [ObservableProperty] private ConfigColor _JyokyoHelpUnkColor1 = new ConfigColor(0xFF, 0x2D, 0x7E, 0xFF);
    [ObservableProperty] private ConfigColor _JyokyoHelpWindowIn1 = new ConfigColor(0x23, 0x12, 0x1B, 0xE5);
    [ObservableProperty] private ConfigColor _JyokyoHelpWindowOut = new ConfigColor(0x4B, 0x30, 0x3D, 0xFF);
    [ObservableProperty] private ConfigColor _JyokyoHelpWindowIn2 = new ConfigColor(0x23, 0x12, 0x1B, 0xBF);
    [ObservableProperty] private ConfigColor _JyokyoHelpColorGradation = new ConfigColor(0x40, 0x26, 0x34, 0x66);
    [ObservableProperty] private ConfigColor _MailRunningFigureColor = new ConfigColor(0xEA, 0x00, 0x4A, 0xFF);
    [ObservableProperty] private ConfigColor _MailDarkRunningFigureColor = new ConfigColor(0x3F, 0x00, 0x14, 0xFF);
    [ObservableProperty] private ConfigColor _MailSelectedSubjectColor = new ConfigColor(0xFF, 0x4A, 0x77, 0xFF);
    [ObservableProperty] private ConfigColor _HighlightedSelectionColor = new ConfigColor(0xFF, 0x00, 0x62, 0xFF);
    [ObservableProperty] private ConfigColor _MailDetailTitleHighlightedColor = new ConfigColor(0xFF, 0x58, 0x92, 0xFF);
    [ObservableProperty] private ConfigColor _MailDetailDarkTitleHighlightedColor = new ConfigColor(0x80, 0x08, 0x45, 0xFF);
    [ObservableProperty] private ConfigColor _BtlWaterCausticColor = new ConfigColor(0xFF, 0x00, 0x6A, 0xFF);
    [ObservableProperty] private ConfigColor _BtlHighlightedColor = new ConfigColor(0x00, 0xF0, 0xFF, 0xFF);
    [ObservableProperty] private ConfigColor _BtlResultLvlUpLeftSquareColor = new ConfigColor(0x3B, 0x02, 0x07, 0xFF);
    [ObservableProperty] private ConfigColor _BtlResultLvlUpLargeStripColor = new ConfigColor(0xFF, 0x73, 0x98, 0xFF);
    [ObservableProperty] private ConfigColor _BtlResultLvlUpLargeStripShadowColor = new ConfigColor(0x3E, 0x05, 0x0B, 0xFF);
    [ObservableProperty] private ConfigColor _BtlResultLvlUpShortStripColor = new ConfigColor(0x54, 0x03, 0x1D, 0xFF);
    [ObservableProperty] private ConfigColor _BtlResultLvlUpItemFontColor = new ConfigColor(0xFF, 0xA2, 0x85, 0xFF);
    [ObservableProperty] private ConfigColor _BtlResultLvlUpItemZeroFontColor = new ConfigColor(0xF7, 0x5D, 0x72, 0xFF);
    [ObservableProperty] private ConfigColor _BtlResultFemcLvlUpPersonaSilhouetteColor = new ConfigColor(0x5F, 0x00, 0x1C, 0xFF);
    [ObservableProperty] private ConfigColor _BtlResultFemcLvlUpPersonaInfoFont = new ConfigColor(0xE3, 0x14, 0x65, 0xFF);
    [ObservableProperty] private ConfigColor _CmmuRankUpBG3MiddownColor = new ConfigColor(0x21, 0x12, 0x2B, 0xFF);
    [ObservableProperty] private ConfigColor _CmmuRankUpBG4Color = new ConfigColor(0xCF, 0xB4, 0xE5, 0xFF);
    [ObservableProperty] private ConfigColor _CmmuRankUpColor1 = new ConfigColor(0xA9, 0x43, 0x60, 0xFF);
    [ObservableProperty] private ConfigColor _CmmuRankUpColor2 = new ConfigColor(0xDC, 0x3C, 0x6C, 0xFF);
    [ObservableProperty] private ConfigColor _CmmuRankUpColor3 = new ConfigColor(0xF5, 0x43, 0x78, 0xFF);
    [ObservableProperty] private ConfigColor _CmmuRankUpKeyframe1 = new ConfigColor(0x99, 0x26, 0x47, 0xFF);
    [ObservableProperty] private ConfigColor _CmmuRankUpKeyframe2 = new ConfigColor(0xCC, 0x33, 0x5C, 0xFF);
    [ObservableProperty] private ConfigColor _CmmuRankUpKeyframe3 = new ConfigColor(0xD9, 0x33, 0x62, 0xFF);
    [ObservableProperty] private ConfigColor _CmmuRankUpKeyframe4 = new ConfigColor(0xFF, 0x4D, 0x7C, 0xFF);
    [ObservableProperty] private ConfigColor _CmmuRankUpKeyframe5 = new ConfigColor(0xFF, 0xB3, 0xC9, 0xFF);
    [ObservableProperty] private ConfigColor _CmmuRankUpStripColorUp = new ConfigColor(0xA6, 0x2E, 0x4E, 0xFF);
    [ObservableProperty] private ConfigColor _CmmuRankUpStripColorDown = new ConfigColor(0xA6, 0x08, 0x56, 0xFF);
    [ObservableProperty] private ConfigColor _CmmuRankUpDarkCardColor = new ConfigColor(0x4D, 0x08, 0x19, 0xFF);
    [ObservableProperty] private ConfigColor _CmmuRankUpLightCardColor = new ConfigColor(0xF6, 0x00, 0x6F, 0xFF);
    [ObservableProperty] private ConfigColor _CmmuRankUpMaxColor = new ConfigColor(0xB3, 0x52, 0x6D, 0xFF);
    [ObservableProperty] private ConfigColor _PersonaStatusHighlightedLine = new ConfigColor(0x00, 0xD8, 0xFF, 0xFF);
    [ObservableProperty] private ConfigColor _ShuffleCardTypeFontColor = new ConfigColor(0x43, 0x02, 0x28, 0xFF);
    [ObservableProperty] private ConfigColor _ShuffleCardTypeAndRhomb = new ConfigColor(0xFF, 0x9A, 0xB7, 0xFF);
    [ObservableProperty] private ConfigColor _ShuffleOwnedFontColor = new ConfigColor(0x43, 0x02, 0x28, 0xFF);
    [ObservableProperty] private ConfigColor _ShuffleOwnedCountFontColor = new ConfigColor(0x5A, 0x05, 0x36, 0xFF);
    [ObservableProperty] private ConfigColor _ShuffleOwnedLeftZeroFontColor = new ConfigColor(0xFF, 0x9A, 0xCA, 0xFF);
    [ObservableProperty] private ConfigColor _ShuffleBigBGCardsColor1 = new ConfigColor(0xA1, 0x18, 0x60, 0xFF);
    [ObservableProperty] private ConfigColor _ShuffleArcanaSymbolColor = new ConfigColor(0x97, 0x33, 0x5C, 0xFF);
    [ObservableProperty] private ConfigColor _ShufflePersonaOverstockBG = new ConfigColor(0xC0, 0x25, 0x6D, 0xFF);
    [ObservableProperty] private ConfigColor _ShuffleDownGradient = new ConfigColor(0xFF, 0x67, 0xA3, 0xFF);
    [ObservableProperty] private ConfigColor _ShuffleDownGradientArcanaSelection = new ConfigColor(0x83, 0x0A, 0x4A, 0xFF);
    [ObservableProperty] private ConfigColor _ShuffleBigBGCardsColor2 = new ConfigColor(0xCC, 0x2A, 0x60, 0xFF);
    [ObservableProperty] private ConfigColor _ShuffleTopGradientAndCardsTaint = new ConfigColor(0xBD, 0x1A, 0x5B, 0xFF);
    [ObservableProperty] private ConfigColor _ShuffleTitleUnderlayColor1 = new ConfigColor(0xC2, 0x14, 0x58, 0xFF);
    [ObservableProperty] private ConfigColor _ShuffleTitleUnderlayColor2 = new ConfigColor(0x7D, 0x07, 0x46, 0xFF);
    [ObservableProperty] private ConfigColor _ShuffleTitleFontColor = new ConfigColor(0x66, 0x00, 0x37, 0xFF);
    [ObservableProperty] private ConfigColor _ShuffleUnkColor1 = new ConfigColor(0xB8, 0x1D, 0x58, 0xFF);
    [ObservableProperty] private ConfigColor _ShuffleUnkColor2 = new ConfigColor(0xB8, 0x1D, 0x58, 0xFF);
    [ObservableProperty] private ConfigColor _ShuffleUnkColor3 = new ConfigColor(0xB8, 0x1D, 0x58, 0xFF);
    [ObservableProperty] private ConfigColor _ShuffleUnkColor4 = new ConfigColor(0xB8, 0x1D, 0x58, 0xFF);
    [ObservableProperty] private ConfigColor _ShuffleUnkColor5 = new ConfigColor(0xB8, 0x1D, 0x58, 0xFF);
    [ObservableProperty] private ConfigColor _ShuffleUnkColor6 = new ConfigColor(0x77, 0x00, 0x45, 0xFF);
    [ObservableProperty] private ConfigColor _OverstockFontEquippedArcanaColor = new ConfigColor(0xD4, 0x7E, 0x6A, 0xFF);
    [ObservableProperty] private ConfigColor _OverstockFontSelectedArcanaColor = new ConfigColor(0x44, 0x04, 0x27, 0xFF);
    [ObservableProperty] private ConfigColor _OverstockBGSelectedColor = new ConfigColor(0xFF, 0xE2, 0x9E, 0xFF);
    [ObservableProperty] private ConfigColor _OverstockFontUnselectedNameArcanaColor = new ConfigColor(0xFF, 0xE2, 0x9E, 0xFF);
    [ObservableProperty] private ConfigColor _OverstockBGUnselectedColor = new ConfigColor(0x44, 0x04, 0x27, 0xFF);
    [ObservableProperty] private ConfigColor _OverstockTitleColor = new ConfigColor(0xB9, 0x00, 0x56, 0xFF);
    [ObservableProperty] private ConfigColor _EquipTriangleColor = new ConfigColor(0xFF, 0xA1, 0xCA, 0xFF);
    [ObservableProperty] private ConfigColor _HandwritingGradationColor1 = new ConfigColor(0xFF, 0xA4, 0xC7, 0xFF);
    [ObservableProperty] private ConfigColor _HandwritingGradationColor2 = new ConfigColor(0xFF, 0x00, 0x66, 0xFF);
    [ObservableProperty] private ConfigColor _CampStatsMenuUnderlay = new ConfigColor(0x40, 0x01, 0x0A, 0xFF);
    [ObservableProperty] private ConfigColor _CampHighlightedDark = new ConfigColor(0x00, 0x30, 0x42, 0xFF);
    [ObservableProperty] private ConfigColor _AccessIconColor1 = new ConfigColor(0x7C, 0x03, 0x18, 0xFF);
    [ObservableProperty] private ConfigColor _AccessIconColor2 = new ConfigColor(0x80, 0x20, 0x36, 0xFF);
    [ObservableProperty] private ConfigColor _AccessIconColor3 = new ConfigColor(0x66, 0x05, 0x1B, 0xFF);
    [ObservableProperty] private ConfigColor _HighlightedUpDownArrows = new ConfigColor(0x00, 0xD8, 0xFF, 0xFF);
    [ObservableProperty] private ConfigColor _CampEquipCompareCircle = new ConfigColor(0x5F, 0x00, 0x20, 0xFF);
    [ObservableProperty] private ConfigColor _CampEquipCompareFemcShadowCircle = new ConfigColor(0xB0, 0x9C, 0xA2, 0xFF);
    [ObservableProperty] private ConfigColor _DayChangeBGColor = new ConfigColor(0x27, 0x18, 0x1F, 0xFF);
    [ObservableProperty] private ConfigColor _RequestReportBG = new ConfigColor(0xA3, 0x20, 0x5F, 0xFF);
    [ObservableProperty] private ConfigColor _RequestChairsColor = new ConfigColor(0x76, 0x01, 0x3D, 0xFF);
    [ObservableProperty] private ConfigColor _StatusShardsColor = new ConfigColor(0xDD, 0x63, 0x8B, 0xFF);
    [ObservableProperty] private ConfigColor _FallingNineColor = new ConfigColor(0xA3, 0x80, 0x8A, 0xFF);
    [ObservableProperty] private ConfigColor _SkillGunColor = new ConfigColor(0xC5, 0x85, 0x85, 0xFF);
    [ObservableProperty] private ConfigColor _StatsGekkoukanDark = new ConfigColor(0x9C, 0x6B, 0x79, 0xFF);
    [ObservableProperty] private ConfigColor _StatsFontColor = new ConfigColor(0xB5, 0xB4, 0xB4, 0xFF);
    [ObservableProperty] private ConfigColor _StatsShadowColor = new ConfigColor(0x66, 0x08, 0x29, 0xFF);
    [ObservableProperty] private ConfigColor _StatusDetailTitleAndGekkoukanDark = new ConfigColor(0x2B, 0x1E, 0x22, 0xFF);
    [ObservableProperty] private ConfigColor _StatusDetailMainBackground = new ConfigColor(0x46, 0x3D, 0x40, 0xFF);
    [ObservableProperty] private ConfigColor _CmmuStatusStrip = new ConfigColor(0x9F, 0x00, 0x4B, 0xFF);
    [ObservableProperty] private ConfigColor _StatusDetailBigShard = new ConfigColor(0x87, 0x6F, 0x7B, 0xFF);
    [ObservableProperty] private ConfigColor _SocialStatsTriangle = new ConfigColor(0x30, 0x22, 0x29, 0xFF);
    [ObservableProperty] private ConfigColor _StatusDetailTagColors = new ConfigColor(0x4D, 0x34, 0x3D, 0xFF);
    [ObservableProperty] private ConfigColor _StatusTheurgyBigShard = new ConfigColor(0x75, 0x4D, 0x5F, 0xFF);
    [ObservableProperty] private ConfigColor _StatusTheurgyDetailTitlesFont = new ConfigColor(0x67, 0x47, 0x60, 0xFF);
    [ObservableProperty] private ConfigColor _StatusTheurgyDetailBGColor = new ConfigColor(0x4B, 0x2B, 0x40, 0xFF);
    [ObservableProperty] private ConfigColor _StatusDetailTransitionBGLight = new ConfigColor(0xD8, 0xD1, 0xD4, 0xFF);
    [ObservableProperty] private ConfigColor _StatusDetailTransitionBGDark = new ConfigColor(0xC1, 0xB0, 0xB6, 0xFF);
    [ObservableProperty] private ConfigColor _EquipDotsColor = new ConfigColor(0x90, 0x36, 0x55, 0xFF);
    [ObservableProperty] private ConfigColor _CalendarPastDay = new ConfigColor(0xC8, 0x91, 0xA5, 0xFF);
    [ObservableProperty] private ConfigColor _CalendarHighlightedDay = new ConfigColor(0x07, 0x40, 0xFD, 0xFF);
    [ObservableProperty] private ConfigColor _CalendarHighlightedJob = new ConfigColor(0x00, 0x00, 0xF1, 0xFF);
    [ObservableProperty] private ConfigColor _CalendarJobDetailFont = new ConfigColor(0xFF, 0xBD, 0xCE, 0xFF);
    [ObservableProperty] private ConfigColor _CampItemEffectBG = new ConfigColor(0xFF, 0xBD, 0xCE, 0xFF);
    [ObservableProperty] private ConfigColor _CampItemEffectFont = new ConfigColor(0x49, 0x04, 0x21, 0xFF);
    [ObservableProperty] private ConfigColor _ShiftFromColor = new ConfigColor(0xFF, 0x05, 0x13, 0xFF);
    [ObservableProperty] private ConfigColor _ShiftToMiddleColor = new ConfigColor(0xFF, 0x17, 0x23, 0xFF);
    [ObservableProperty] private ConfigColor _ShiftToUpDownColor = new ConfigColor(0xFF, 0x5C, 0x49, 0xFF);
    [ObservableProperty] private ConfigColor _CampConfSelTexColor = new ConfigColor(0xFF, 0xFC, 0x9F, 0xFF);
    [ObservableProperty] private ConfigColor _CampConfOptFmtBgColor = new ConfigColor(0x1A, 0x00, 0x10, 0xFF);
    [ObservableProperty] private ConfigColor _CampConfSelNameColor = new ConfigColor(0xFF, 0xFC, 0x9F, 0xFF);
    [ObservableProperty] private ConfigColor _CampConfigControlSetInactive = new ConfigColor(0xFF, 0xAC, 0x8C, 0xFF);
    [ObservableProperty] private ConfigColor _CampConfigOptionUnselectedArea = new ConfigColor(0xEE, 0x8A, 0x7C, 0xFF);
    [ObservableProperty] private ConfigColor _CampConfigBooleanUnselectedArea = new ConfigColor(0xDF, 0x9A, 0x87, 0xFF);
    [ObservableProperty] private ConfigColor _CampConfigMusicPlayerGlow = new ConfigColor(0xFF, 0xFC, 0x9F, 0xFF);
    [ObservableProperty] private ConfigColor _CampConfigTopDescColor = new ConfigColor(0xFF, 0xFC, 0x9F, 0xFF);
    [ObservableProperty] private ConfigColor _CampConfigBgColor = new ConfigColor(0x55, 0x1E, 0x3F, 0xFF);
    [ObservableProperty] private ConfigColor _CampConfigPlistHeadColor = new ConfigColor(0xE2, 0x41, 0x89, 0xFF);
    [ObservableProperty] private ConfigColor _EquipPMUnavailableParallelogram = new ConfigColor(0xB6, 0x3F, 0x68, 0xFF);
    [ObservableProperty] private ConfigColor _CampRootHighlightedColor1 = new ConfigColor(0x00, 0xF9, 0xFF, 0xFF);
    [ObservableProperty] private ConfigColor _CampRootHighlightedColor2 = new ConfigColor(0x00, 0xD2, 0xFF, 0xFF);
    [ObservableProperty] private ConfigColor _SaveLoadHighlightedOption = new ConfigColor(0x00, 0xF0, 0xFF, 0xFF);
    [ObservableProperty] private ConfigColor _SaveLoadAccentColor = new ConfigColor(0xF2, 0xC9, 0x95, 0xFF);
    [ObservableProperty] private ConfigColor _SaveLoadSlotBox = new ConfigColor(0x48, 0x04, 0x2D, 0xFF);
    [ObservableProperty] private ConfigColor _SaveLoadCornerTriangle = new ConfigColor(0x36, 0x00, 0x21, 0xFF);
    [ObservableProperty] private ConfigColor _SaveLoadUnhighlightedNumber = new ConfigColor(0x5D, 0x0B, 0x34, 0xFF);
    [ObservableProperty] private ConfigColor _SaveLoadSelectedSlotBox = new ConfigColor(0xF4, 0x3A, 0x75, 0xFF);
    [ObservableProperty] private ConfigColor _SaveLoadGrey = new ConfigColor(0x3F, 0x39, 0x39, 0xFF);
    [ObservableProperty] private ConfigColor _PersonaStatusEquipBonusColor = new ConfigColor(0x00, 0xD8, 0xFF, 0xFF);
    [ObservableProperty] private ConfigColor _CampSystemCurveColor = new ConfigColor(0xAC, 0x27, 0xBF, 0xFF);
    [ObservableProperty] private ConfigColor _MsgSimpleSelectBgFill = new ConfigColor(0xB5, 0x3C, 0x66, 0xFF);
    [ObservableProperty] private ConfigColor _MsgSimpleSelectBgMainColor = new ConfigColor(0xFF, 0xAF, 0x00, 0xFF);
    [ObservableProperty] private ConfigColor _CampKotoneShadowColor = new ConfigColor(0xFF, 0xD4, 0xA0, 0xFF);
    [ObservableProperty] private ConfigColor _CampKotoneShadowColor2 = new ConfigColor(0xFF, 0xAD, 0x9D, 0xFF);
    [ObservableProperty] private ConfigColor _CampKotoneInnerShadowColor = new ConfigColor(0xFF, 0xDE, 0x8E, 0xFF);
    [ObservableProperty] private ConfigColor _FadeManager1 = new ConfigColor(0xFF, 0x82, 0x91, 0xFF);
    [ObservableProperty] private ConfigColor _FadeManager2 = new ConfigColor(0x22, 0xD7, 0xFA, 0xFF);
    [ObservableProperty] private ConfigColor _FadeManager3 = new ConfigColor(0xCA, 0x08, 0x5E, 0xFF);
    [ObservableProperty] private ConfigColor _FadeManager4 = new ConfigColor(0x02, 0x2E, 0x33, 0xFF);
    [ObservableProperty] private ConfigColor _FadeManager5 = new ConfigColor(0xFF, 0x82, 0x91, 0xFF);
    [ObservableProperty] private ConfigColor _FadeManager6 = new ConfigColor(0x57, 0x05, 0x2F, 0xFF);
    [ObservableProperty] private ConfigColor _FadeManager7 = new ConfigColor(0xE3, 0x14, 0x55, 0xFF);
    [ObservableProperty] private ConfigColor _BtlGuardTopLeftText = new ConfigColor(0xAA, 0x0E, 0x53, 0xFF);
    [ObservableProperty] private ConfigColor _BtlGuardBottomRightText = new ConfigColor(0x64, 0x06, 0x38, 0xFF);
    [ObservableProperty] private ConfigColor _BtlGuardMisc = new ConfigColor(0xAA, 0x0E, 0x53, 0xFF);
    [ObservableProperty] private ConfigColor _BtlGuardTopLeftBG = new ConfigColor(0xF3, 0x26, 0x6D, 0xFF);
    [ObservableProperty] private ConfigColor _BtlGuardBottomRightBG = new ConfigColor(0x89, 0x0A, 0x49, 0xFF);
    [ObservableProperty] private ConfigColor _BtlEncountWipe = new ConfigColor(0xFF, 0x46, 0x77, 0xFF);
    [ObservableProperty] private ConfigColor _BtlItemList1 = new ConfigColor(0xFF, 0x00, 0x00, 0xFF);
    [ObservableProperty] private ConfigColor _BtlItemList2 = new ConfigColor(0x00, 0xFF, 0x04, 0xFF);
    [ObservableProperty] private ConfigColor _BtlItemList3 = new ConfigColor(0xB6, 0x19, 0x52, 0xFF);
    [ObservableProperty] private ConfigColor _BtlItemList4 = new ConfigColor(0xC7, 0x1F, 0x5C, 0xFF);
    [ObservableProperty] private ConfigColor _BtlItemList5 = new ConfigColor(0xFF, 0x73, 0x98, 0xFF);
    [ObservableProperty] private ConfigColor _BtlItemListAccent = new ConfigColor(0xFF, 0xED, 0x8E, 0xFF);
    [ObservableProperty] private ConfigColor _BtlItemModelDarkColor = new ConfigColor(0x94, 0x15, 0x43, 0xFF);
    [ObservableProperty] private ConfigColor _BtlItemModelLightColor = new ConfigColor(0xAC, 0x16, 0x4C, 0xFF);
    [ObservableProperty] private ConfigColor _BtlPromiseCommon1 = new ConfigColor(0xB9, 0x00, 0x52, 0xFF);
    [ObservableProperty] private ConfigColor _BtlPromiseCommon2 = new ConfigColor(0xA3, 0x5F, 0x81, 0xFF);
    [ObservableProperty] private ConfigColor _BtlPromiseCommon3 = new ConfigColor(0xFF, 0x73, 0x98, 0xFF);
    [ObservableProperty] private ConfigColor _BtlPromiseCommon4 = new ConfigColor(0x7A, 0x0C, 0x48, 0xFF);
    [ObservableProperty] private ConfigColor _BtlPromiseCommon5 = new ConfigColor(0x6D, 0x32, 0x53, 0xFF);
    [ObservableProperty] private ConfigColor _BtlPromiseCommonHighlight = new ConfigColor(0x00, 0xDA, 0xFF, 0xFF);
    [ObservableProperty] private ConfigColor _BtlResultLvlUpTopExpBGColor = new ConfigColor(0x69, 0x08, 0x33, 0xFF);
    [ObservableProperty] private ConfigColor _BtlResultLvlUpTopItemNumColor = new ConfigColor(0xFF, 0xB3, 0x7F, 0xFF);
    [ObservableProperty] private ConfigColor _BtlResultLvlUpTopItemNumColorDark = new ConfigColor(0xF6, 0x82, 0xAE, 0xFF);
    [ObservableProperty] private ConfigColor _BtlResultLvlUpParallelogram = new ConfigColor(0xB6, 0x18, 0x52, 0xFF);
    [ObservableProperty] private ConfigColor _BtlResultLvlUpBgPanel = new ConfigColor(0xB3, 0x18, 0x51, 0xFF);
    [ObservableProperty] private ConfigColor _BtlResultLvlUpBgBehindPanel = new ConfigColor(0xB6, 0x18, 0x52, 0xFF);
    [ObservableProperty] private ConfigColor _BtlSkillListAccentColor = new ConfigColor(0xFF, 0xED, 0x8E, 0xFF);
    [ObservableProperty] private ConfigColor _BtlSkillListUnk1 = new ConfigColor(0x88, 0x12, 0x3F, 0xFF);
    [ObservableProperty] private ConfigColor _BtlSkillListUnk2 = new ConfigColor(0x1F, 0xFF, 0x00, 0xFF);
    [ObservableProperty] private ConfigColor _BtlSkillListUnk3 = new ConfigColor(0xC1, 0x21, 0x66, 0xFF);
    [ObservableProperty] private ConfigColor _BtlSkillListUnk4 = new ConfigColor(0xA8, 0x14, 0x46, 0xFF);
    [ObservableProperty] private ConfigColor _BtlSkillListUnk5 = new ConfigColor(0x88, 0x0A, 0x49, 0xFF);
    [ObservableProperty] private ConfigColor _BtlSkillListUnk6 = new ConfigColor(0xA3, 0x14, 0x44, 0xFF);
    [ObservableProperty] private ConfigColor _BtlSkillListUnk7 = new ConfigColor(0x5C, 0x02, 0x34, 0xFF);
    [ObservableProperty] private ConfigColor _BtlSkillListUnk8 = new ConfigColor(0xFF, 0x73, 0x9C, 0xFF);
    [ObservableProperty] private ConfigColor _BtlSkillListUnk9 = new ConfigColor(0xFF, 0x73, 0x9C, 0xFF);
    [ObservableProperty] private ConfigColor _BtlSkillListUnk10 = new ConfigColor(0xFF, 0x73, 0xD2, 0xFF);
    [ObservableProperty] private ConfigColor _BtlSkillListModelColor = new ConfigColor(0xE3, 0x6B, 0xA2, 0xFF);
    [ObservableProperty] private ConfigColor _MsgSimpleBgColor = new ConfigColor(0x23, 0x12, 0x19, 0xFF);
    [ObservableProperty] private ConfigColor _MsgSimpleUnselectedTextColor = new ConfigColor(0xFC, 0xF0, 0xF4, 0xFF);
    [ObservableProperty] private ConfigColor _MsgSimpleSystemTutorialTitleFontColor = new ConfigColor(0x26, 0x00, 0x10, 0xFF);
    [ObservableProperty] private ConfigColor _CampSystemNoTutorialColor = new ConfigColor(0xFF, 0xBD, 0xCE, 0xFF);
    [ObservableProperty] private ConfigColor _CampTutorialBattleKeyframe1 = new ConfigColor(0x00, 0x00, 0x00, 0xFF);
    [ObservableProperty] private ConfigColor _CampTutorialBattleKeyframe2 = new ConfigColor(0x1D, 0x00, 0x0F, 0xFF);
    [ObservableProperty] private ConfigColor _CampTutorialBattleKeyframe3 = new ConfigColor(0x33, 0x00, 0x1A, 0xFF);
    [ObservableProperty] private ConfigColor _CampTutorialBattleKeyframe4 = new ConfigColor(0x3F, 0x03, 0x23, 0xFF);
    [ObservableProperty] private ConfigColor _CampTutorialFusionKeyframe1 = new ConfigColor(0x00, 0x00, 0x00, 0xFF);
    [ObservableProperty] private ConfigColor _CampTutorialFusionKeyframe2 = new ConfigColor(0x3F, 0x03, 0x23, 0xFF);
    [ObservableProperty] private ConfigColor _CampTutorialFusionKeyframe3 = new ConfigColor(0x41, 0x05, 0x2A, 0xFF);
    [ObservableProperty] private ConfigColor _CampTutorialFusionKeyframe4 = new ConfigColor(0x33, 0x06, 0x4C, 0xFF);
    [ObservableProperty] private ConfigColor _CampTutorialDailyKeyframe1 = new ConfigColor(0x00, 0x00, 0x00, 0xFF);
    [ObservableProperty] private ConfigColor _CampTutorialDailyKeyframe2 = new ConfigColor(0x9E, 0x08, 0x47, 0xFF);
    [ObservableProperty] private ConfigColor _CampTutorialDailyKeyframe3 = new ConfigColor(0x8C, 0x14, 0x4C, 0xFF);
    [ObservableProperty] private ConfigColor _CampTutorialDailyKeyframe4 = new ConfigColor(0x46, 0x20, 0x00, 0xFF);
    [ObservableProperty] private ConfigColor _CampTutorialDictionaryKeyframe1 = new ConfigColor(0x00, 0x00, 0x00, 0xFF);
    [ObservableProperty] private ConfigColor _CampTutorialDictionaryKeyframe2 = new ConfigColor(0x33, 0x00, 0x1E, 0xFF);
    [ObservableProperty] private ConfigColor _CampTutorialDictionaryKeyframe3 = new ConfigColor(0x7F, 0x00, 0x3D, 0xFF);
    [ObservableProperty] private ConfigColor _CampTutorialDungeonKeyframe1 = new ConfigColor(0x00, 0x00, 0x00, 0xFF);
    [ObservableProperty] private ConfigColor _CampTutorialDungeonKeyframe2 = new ConfigColor(0x29, 0x00, 0x15, 0xFF);
    [ObservableProperty] private ConfigColor _CampTutorialDungeonKeyframe3 = new ConfigColor(0x39, 0x00, 0x1B, 0xFF);
    [ObservableProperty] private ConfigColor _CampTutorialDungeonKeyframe4 = new ConfigColor(0x00, 0x33, 0x0D, 0xFF);
    [ObservableProperty] private ConfigColor _CampTutorialSystemKeyframe1 = new ConfigColor(0x00, 0x00, 0x00, 0xFF);
    [ObservableProperty] private ConfigColor _CampTutorialSystemKeyframe2 = new ConfigColor(0x40, 0x00, 0x1D, 0xFF);
    [ObservableProperty] private ConfigColor _CampTutorialSystemKeyframe3 = new ConfigColor(0x99, 0x33, 0x63, 0xFF);
    [ObservableProperty] private ConfigColor _BtlTheurgySpark1 = new ConfigColor(0xEA, 0x4A, 0xA3, 0xFF);
    [ObservableProperty] private ConfigColor _BtlTheurgyPersonalityDescription = new ConfigColor(0xFF, 0xE9, 0xAC, 0xFF);
    [ObservableProperty] private ConfigColor _BtlTheurgySpark2 = new ConfigColor(0xDC, 0x3F, 0x8C, 0xFF);
    [ObservableProperty] private ConfigColor _BtlTheurgyDescription = new ConfigColor(0xFF, 0xE9, 0xAC, 0xFF);
    [ObservableProperty] private ConfigColor _BtlTheurgyBarHighlight = new ConfigColor(0xCC, 0x22, 0x60, 0xFF);
    [ObservableProperty] private ConfigColor _BtlTheurgyBGColour = new ConfigColor(0xCC, 0x22, 0x60, 0xFF);
    [ObservableProperty] private ConfigColor _BtlTheurgyPersonaShadow = new ConfigColor(0xFF, 0x5F, 0xAA, 0xFF);
    [ObservableProperty] private ConfigColor _BtlTheurgyPersonaShadow2 = new ConfigColor(0x6B, 0x3D, 0x5F, 0xFF);
    [ObservableProperty] private ConfigColor _BtlTheurgyPersonalityCircleHighlight = new ConfigColor(0x45, 0x27, 0x45, 0xFF);
    [ObservableProperty] private ConfigColor _BtlTheurgyPersonalityCircleBG = new ConfigColor(0x4B, 0x2B, 0x46, 0xFF);
    [ObservableProperty] private ConfigColor _BtlTheurgyPersonalityTitle = new ConfigColor(0x67, 0x47, 0x5B, 0xFF);
    [ObservableProperty] private ConfigColor _BtlTheurgyModelColour1 = new ConfigColor(0x99, 0x15, 0x44, 0xFF);
    [ObservableProperty] private ConfigColor _BtlTheurgyPersonalityCircleDescription = new ConfigColor(0x85, 0x3D, 0x52, 0xFF);
    [ObservableProperty] private ConfigColor _BtlTheurgyUnk15 = new ConfigColor(0x00, 0xD6, 0xFF, 0xFF);
    [ObservableProperty] private ConfigColor _BtlTheurgyModelColour2 = new ConfigColor(0xCC, 0x22, 0x60, 0xFF);
    [ObservableProperty] private ConfigColor _EditRootFillColor = new ConfigColor(0xE5, 0x5E, 0x84, 0xFF);
    [ObservableProperty] private ConfigColor _EditSkillFillColor = new ConfigColor(0xE5, 0x5E, 0x84, 0xFF);
    [ObservableProperty] private ConfigColor _EditItemFillColor = new ConfigColor(0xE5, 0x5E, 0x84, 0xFF);
    [ObservableProperty] private ConfigColor _EditEquipFillColor = new ConfigColor(0xE5, 0x5E, 0x84, 0xFF);
    [ObservableProperty] private ConfigColor _EditStatusFillColor = new ConfigColor(0xE5, 0x5E, 0x84, 0xFF);
    [ObservableProperty] private ConfigColor _EditQuestFillColor = new ConfigColor(0xE5, 0x5E, 0x84, 0xFF);
    [ObservableProperty] private ConfigColor _EditCommuFillColor = new ConfigColor(0xFF, 0x93, 0xB2, 0xFF);
    [ObservableProperty] private ConfigColor _EditSystemFillColor = new ConfigColor(0xE5, 0x5E, 0x84, 0xFF);
    [ObservableProperty] private ConfigColor _EditConfigFillColor = new ConfigColor(0x81, 0x2C, 0x61, 0xFF);
    [ObservableProperty] private ConfigColor _BustupUniverseAmbientColor = new ConfigColor(0xFF, 0x7C, 0xB5, 0xFF);
    [ObservableProperty] private ConfigColor _BustupUniverseLightColor = new ConfigColor(0xFF, 0xE6, 0x7C, 0xFF);
    [ObservableProperty] private ConfigColor _BtlTopUnk1 = new ConfigColor(0xFF, 0x71, 0xBD, 0xFF);
    [ObservableProperty] private ConfigColor _BtlTopMainCircleColor = new ConfigColor(0xFF, 0x6F, 0xC1, 0xFF);
    [ObservableProperty] private ConfigColor _BtlTopCharOutlineColor = new ConfigColor(0xDD, 0x0B, 0x73, 0xFF);
    [ObservableProperty] private ConfigColor _BtlTopTheurgyCircleColor = new ConfigColor(0x6E, 0x05, 0x40, 0xFF);
    [ObservableProperty] private ConfigColor _BtlGuiDamageTextColor1 = new ConfigColor(0x72, 0x08, 0x4B, 0xFF);
    [ObservableProperty] private ConfigColor _BtlGuiDamageTextColor2 = new ConfigColor(0xFF, 0x82, 0xC1, 0xFF);
    [ObservableProperty] private ConfigColor _BtlGuiDamageTextColor3 = new ConfigColor(0xFF, 0x82, 0xC1, 0xFF);
    [ObservableProperty] private ConfigColor _BtlGuiOneMoreColor1 = new ConfigColor(0xFF, 0x85, 0xAF, 0xFF);
    [ObservableProperty] private ConfigColor _BtlGuiOneMoreColor2 = new ConfigColor(0xDD, 0x18, 0x5D, 0xFF);
    [ObservableProperty] private ConfigColor _BtlGuiOneMoreColor3 = new ConfigColor(0xA3, 0x17, 0x50, 0xFF);
    [ObservableProperty] private ConfigColor _BtlGuiRush1 = new ConfigColor(0xD4, 0x17, 0x64, 0xFF);
    [ObservableProperty] private ConfigColor _BtlGuiRush2 = new ConfigColor(0x67, 0x0A, 0x3F, 0xFF);
    [ObservableProperty] private ConfigColor _BtlSkillName1 = new ConfigColor(0xFF, 0x87, 0xB8, 0xFF);
    [ObservableProperty] private ConfigColor _BtlSkillName2 = new ConfigColor(0xD4, 0x13, 0x68, 0xFF);
    [ObservableProperty] private ConfigColor _BtlSkillName3 = new ConfigColor(0x8D, 0x13, 0x60, 0xFF);
    [ObservableProperty] private ConfigColor _BtlTargetInfo1 = new ConfigColor(0xCA, 0x2B, 0x67, 0xFF);
    [ObservableProperty] private ConfigColor _BtlTargetInfo2 = new ConfigColor(0x94, 0x17, 0x56, 0xFF);
    [ObservableProperty] private ConfigColor _BtlTargetInfo3 = new ConfigColor(0x94, 0x17, 0x56, 0xFF);
    [ObservableProperty] private ConfigColor _BtlTargetInfo4 = new ConfigColor(0xF1, 0x8D, 0xCC, 0xFF);
    [ObservableProperty] private ConfigColor _BtlTargetPanel1 = new ConfigColor(0xEE, 0x50, 0xA0, 0xFF);
    [ObservableProperty] private ConfigColor _BtlTargetPanel2 = new ConfigColor(0x83, 0x1E, 0x57, 0xFF);
    [ObservableProperty] private ConfigColor _BtlTargetPanel3 = new ConfigColor(0xFA, 0x7C, 0xB7, 0xFF);
    [ObservableProperty] private ConfigColor _BtlTargetPanel4 = new ConfigColor(0xFF, 0x9C, 0xC4, 0xFF);
    [ObservableProperty] private ConfigColor _BtlTargetPanel5 = new ConfigColor(0xEE, 0x50, 0xA0, 0xFF);
    [ObservableProperty] private ConfigColor _BtlAdvantageBGColor = new ConfigColor(0xD2, 0x0B, 0x63, 0xFF);
    [ObservableProperty] private ConfigColor _BtlAdvantageLine = new ConfigColor(0xD2, 0x0B, 0x63, 0xFF);
    [ObservableProperty] private ConfigColor _BtlAdvantageSEESBG = new ConfigColor(0xD2, 0x0B, 0x63, 0xFF);
    [ObservableProperty] private ConfigColor _AccessIconTalk00Color1 = new ConfigColor(0xFF, 0x93, 0xA4, 0xFF);
    [ObservableProperty] private ConfigColor _AccessIconTalk00Color2 = new ConfigColor(0xD0, 0x39, 0x54, 0xFF);
    [ObservableProperty] private ConfigColor _AccessIconTalk01Color1 = new ConfigColor(0x7D, 0x06, 0x1F, 0xFF);
    [ObservableProperty] private ConfigColor _AccessIconTalk02Color1 = new ConfigColor(0x50, 0x00, 0x1B, 0xFF);
    [ObservableProperty] private ConfigColor _TownMapHighlightedArrows = new ConfigColor(0x00, 0xD8, 0xFF, 0xFF);
    [ObservableProperty] private ConfigColor _GuidanceMainBGColor = new ConfigColor(0x48, 0x44, 0x46, 0xFF);
    [ObservableProperty] private ConfigColor _GuidanceSquareColor = new ConfigColor(0x72, 0x6C, 0x6E, 0xFF);
    [ObservableProperty] private ConfigColor _GuidanceExclamationGlowColor = new ConfigColor(0xFF, 0x00, 0x6A, 0xFF);
    [ObservableProperty] private ConfigColor _GuidanceExclamationMainColor = new ConfigColor(0xFC, 0xBB, 0xD6, 0xFF);
    [ObservableProperty] private ConfigColor _EndGameFirstGlowColor = new ConfigColor(0x8F, 0x00, 0x34, 0xFF);
    [ObservableProperty] private ConfigColor _EndGameFirstFontColor = new ConfigColor(0xFF, 0x00, 0x62, 0xFF);
    [ObservableProperty] private ConfigColor _EndGameFirstBGColor = new ConfigColor(0xFC, 0xF0, 0xF6, 0xFF);
    [ObservableProperty] private ConfigColor _EndGamePreSecondFontTint1 = new ConfigColor(0x97, 0x01, 0x38, 0xFF);
    [ObservableProperty] private ConfigColor _EndGamePreSecondFontTint2 = new ConfigColor(0xB7, 0x01, 0x4A, 0xFF);
    [ObservableProperty] private ConfigColor _EndGameSecondGlowColor1 = new ConfigColor(0x9D, 0x3D, 0x62, 0xFF);
    [ObservableProperty] private ConfigColor _EndGameSecondGlowColor2 = new ConfigColor(0xCD, 0x00, 0x4B, 0xFF);
    [ObservableProperty] private ConfigColor _EndGameSecondFontGlowColor1 = new ConfigColor(0xFE, 0x55, 0x96, 0xFF);
    [ObservableProperty] private ConfigColor _EndGameSecondFontGlowColor2 = new ConfigColor(0xFE, 0x14, 0x6E, 0xFF);
    [ObservableProperty] private ConfigColor _EndGameSecondFontGlowColor3 = new ConfigColor(0xFF, 0x12, 0x75, 0xFF);
    [ObservableProperty] private ConfigColor _DUISituationHelp1 = new ConfigColor(0xB8, 0x00, 0x55, 0xFF);
    [ObservableProperty] private ConfigColor _DUISituationHelp2 = new ConfigColor(0xCA, 0x24, 0x64, 0xFF);
    [ObservableProperty] private ConfigColor _DUISituationHelp3 = new ConfigColor(0x70, 0x26, 0x46, 0xFF);
    [ObservableProperty] private ConfigColor _DUISituationHelp4 = new ConfigColor(0x23, 0x12, 0x1B, 0xFF);
    [ObservableProperty] private ConfigColor _BtlGuiDamageColor = new ConfigColor(0xFF, 0x82, 0xC1, 0xFF);
    [ObservableProperty] private ConfigColor _MailDrawMainColor = new ConfigColor(0xD4, 0x2E, 0x65, 0xFF);
    [ObservableProperty] private ConfigColor _MailDrawColor1 = new ConfigColor(0xCE, 0x2C, 0x62, 0xFF);
    [ObservableProperty] private ConfigColor _MailDrawColor2 = new ConfigColor(0xE0, 0x37, 0x70, 0xFF);
    [ObservableProperty] private ConfigColor _BtlGuiTotalDamageColor = new ConfigColor(0xFF, 0x38, 0x95, 0xFF);
    [ObservableProperty] private ConfigColor _BtlGuiTotalDamageNumberDropshadowColor2 = new ConfigColor(0x28, 0x02, 0x1B, 0xFF);
    [ObservableProperty] private ConfigColor _BtlStupidCircleBehind = new ConfigColor(0xEC, 0x4F, 0x85, 0xFF);
    [ObservableProperty] private ConfigColor _BtlTheurgyArrows = new ConfigColor(0x00, 0xD6, 0xFF, 0xFF);
    [ObservableProperty] private ConfigColor _MsgAssistSupportFontColor = new ConfigColor(0xEA, 0x17, 0x5D, 0xFF);
    [ObservableProperty] private ConfigColor _MsgWindowSystemNetworkBgColor = new ConfigColor(0xC9, 0x00, 0x54, 0xFF);
    [ObservableProperty] private ConfigColor _NetworkDailyActionSecondBlueBgColor = new ConfigColor(0x2E, 0x10, 0x1C, 0xE5);
    [ObservableProperty] private ConfigColor _MusicNotesBgColor = new ConfigColor(0xFF, 0x1F, 0x75, 0xFF);
    [ObservableProperty] private ConfigColor _BtlStrategyInstructAccent = new ConfigColor(0xFF, 0xD3, 0x99, 0xFF);
    [ObservableProperty] private ConfigColor _BtlStrategyInstructColor1 = new ConfigColor(0xB3, 0x18, 0x51, 0xFF);
    [ObservableProperty] private ConfigColor _BtlStrategyInstructColor2 = new ConfigColor(0xB3, 0x18, 0x51, 0xFF);
    [ObservableProperty] private ConfigColor _BtlStrategyInstructColor3 = new ConfigColor(0x66, 0x05, 0x39, 0xFF);
    [ObservableProperty] private ConfigColor _BtlStrategyInstructColorHighlight = new ConfigColor(0x00, 0xC2, 0xFF, 0xFF);
    [ObservableProperty] private ConfigColor _SocialStatsParticlesColor = new ConfigColor(0xFF, 0x36, 0x83, 0xFF);
}