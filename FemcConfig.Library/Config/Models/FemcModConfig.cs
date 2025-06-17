using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;

namespace FemcConfig.Library.Config.Models;

/// <summary>
/// Should match Config.cs from FEMC mod:
/// https://github.com/MadMax1960/Femc-Reloaded-Project/blob/main/code/p3rpc.femc/p3rpc.femc/Config.cs
/// </summary>
public partial class FemcModConfig : ObservableObject
{
    [Category("Battle Music")]
    [Description("Enable Karma's Pull the Trigger?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool karmaAdv = true;

    [Category("Battle Music")]
    [Description("Enable Mosq's Pull the Trigger?")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool mosqAdv = true;

    [Category("Battle Music")]
    [Description("Enable EidieK87's Pull the Trigger?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool eidAdv = true;

    [Category("Battle Music")]
    [Description("Enable EidieK87's Danger Zone?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool eidDis = true;

    [Category("Battle Music")]
    [Description("Enable Mosq's Wiping All Out?")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool mosqNom = true;

    [Category("Battle Music")]
    [Description("Enable Karma's Wiping All Out?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool karmaNom = true;

    [Category("Battle Music")]
    [Description("Enable Stella and GillStudio's Wiping All Out?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool sgNom = true;

    [Category("Battle Music")]
    [Description("Enable Atlus's Wiping All Out?")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool p3pNom = true;

    [Category("Battle Music")]
    [Description("Enable Stella and GillStudio's Danger Zone?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool sgDis = true;

    [Category("Battle Music")]
    [Description("Enable Karma's Danger Zone?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool karmaDis = true;

    [Category("Battle Music")]
    [Description("Enable Mosq's Danger Zone?")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool mosqDis = true;

    [Category("Battle Music")]
    [Description("Enable EidieK87's Danger Zone?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool edDis = true;

    [Category("Battle Music")]
    [Description("Enable Atlus's Danger Zone?")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool p3pDis = true;

    [Category("Battle Music")]
    [Description("Enable Atlus's It's Going Down Now?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool itGoingDown = true;

    [Category("Battle Music")]
    [Description("Enable Jen's It's Going Down Now?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool jenAdv = true;

    [Category("Music")]
    [Description("Enable Way of Life by Jen as the daytime music?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool wayOfLifeJen = true;

    [Category("Battle Music")]
    [Description("Enable Atlus's Master of Tartarus -Reload-?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool masterTar = true;

    [Category("Battle Music")]
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
    [DefaultValue(false)]
    [ObservableProperty]
    private bool nightWand = true;

    [Category("Music")]
    [Description("Enable Night Color Your Night as the night music?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool peaColNight = true;

    [Category("Music")]
    [Description("Enable When the Moon's Reaching Out Stars as the daytime music?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool moon = true;

    [Category("Music")]
    [Description("Enable Way of Life by Super M Plush, Mosq, Karma, and Cora as the daytime music?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool wayLifeVocal = true;

    [Category("Music")]
    [Description("Enable Way of Life by Mosq as the daytime music?")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool wayOfLife = true;

    [Category("Music")]
    [Description("Enable Way of Life as the daytime music?")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool wayOfLifeP3P = true;

    [Category("Music")]
    [Description("Enable Way of Life -Deep inside my mind Remix- as the daytime music?")]
    [DefaultValue(true)]
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
    [DefaultValue(true)]
    [ObservableProperty]
    private bool bMD = true;

    [Category("Music")]
    [Description("Enable Master of Shadow -Reload- to be the music played during boss battles?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool bMS = true;

    [Category("Music")]
    [Description("Enable Master of Shadow Fate Mix to be the music played during boss battles?")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool bMSF = true;

    [Category("Voice")]
    [Description("Enable Gio's Gendered Audio?")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool bluehairandpronounce = true;

    [ObservableProperty]
    private ConfigColor _MailIconOuterCircleColorEx = ConfigColor.MellodiColorMid1;

    [ObservableProperty]
    private ConfigColor _MailIconInnerCircleColorEx = ConfigColor.MailIconInnerColor;

    [ObservableProperty]
    private ConfigColor _CampHighColor = ConfigColor.CampBgColor;

    [ObservableProperty]
    private ConfigColor _CampHighColorGradation = ConfigColor.CampBgColor;

    [ObservableProperty]
    private ConfigColor _CampMiddleColor = ConfigColor.CampBgColor;

    [ObservableProperty]
    private ConfigColor _CampLowColor = ConfigColor.CampBgColor;

    [ObservableProperty]
    private ConfigColor _DateTimePanelTopTextColor = ConfigColor.DarkColor;

    [ObservableProperty]
    private ConfigColor _DateTimePanelBottomTextColor = ConfigColor.MidColor;

    [ObservableProperty]
    private ConfigColor _DateTimePanelWaterColor = ConfigColor.DateTimeWaterColor;

    [ObservableProperty]
    private ConfigColor _TextBoxBackFillColor = ConfigColor.TextBoxBackFillColor;

    [ObservableProperty]
    private ConfigColor _TextBoxFrontFillColor = ConfigColor.TextBoxFrontFillColor;

    [ObservableProperty]
    private ConfigColor _TextBoxFrontBorderColor = ConfigColor.DarkColor;

    [ObservableProperty]
    private ConfigColor _TextBoxSpeakerNameTriangle = ConfigColor.TextBoxSpeakerNameTriangle;

    [ObservableProperty]
    private ConfigColor _TextBoxSpeakerName = ConfigColor.LightColor;

    [ObservableProperty]
    private ConfigColor _TextBoxLeftHaze = ConfigColor.TextBoxLeftHaze;

    [ObservableProperty]
    private ConfigColor _MindWindowOuterBorderNew = ConfigColor.MindWindowOuterBorder;

    [ObservableProperty]
    private ConfigColor _MindWindowInnerColorNew = ConfigColor.MindWindowInnerColor;

    [ObservableProperty]
    private ConfigColor _MindWindowOuterHazeEx = new ConfigColor(ConfigColor.MellodiColorLight3.R, ConfigColor.MellodiColorLight3.G, ConfigColor.MellodiColorLight3.B, 128);
    

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _MindWindowBgDotsNew = ConfigColor.MindWindowOuterBorder;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _MinimapPlaceNameBgColor = ConfigColor.DarkColor;

    [ObservableProperty]
    private ConfigColor _CheckPromptBackBoxColorNew = ConfigColor.CheckPromptBgBox;

    [ObservableProperty]
    private ConfigColor _CheckPromptFrontBoxColorNew = ConfigColor.MellodiColorDark3;

    [ObservableProperty]
    private ConfigColor _CheckPromptFrontBoxColorHighNew = ConfigColor.CheckPromptFgBox;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _BustupShadowColor = ConfigColor.DarkColor;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _CampMenuItemColor1 = ConfigColor.CampMenuItemColor1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _CampMenuItemColor2 = ConfigColor.CampMenuItemColor2;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _CampMenuItemColor3 = ConfigColor.CampMenuItemColor3;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _CampMenuItemColorNoSel = ConfigColor.CampMenuItemColorNoSel;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _CampSkillTextColor = ConfigColor.MellodiColorLight1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _CampSkillTextColorNoSel = ConfigColor.MellodiColorLight3;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _CampSkillTextColorCurrSel = ConfigColor.MellodiColorDark2;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _SocialStatsCircleAcademicsColor = ConfigColor.SocialStatsAcademics;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _SocialStatsCircleCharmColor = ConfigColor.SocialStatsCharm;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _SocialStatsCircleCourageColor = ConfigColor.SocialStatsCourage;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _CampItemMenuCharacterTopColor = ConfigColor.DarkColor;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _CampItemMenuCharacterBottomColor = ConfigColor.DarkColor;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _MsgAssistBgColor = ConfigColor.MellodiColorMid2;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _TownMapBorderColor = ConfigColor.MellodiColorDark3;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _TownMapTextColor = ConfigColor.MellodiColorMid1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _CampSocialLinkLight = ConfigColor.MellodiColorLight2;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _CampSocialLinkDark = ConfigColor.MellodiColorDark3;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _CampSocialLinkDetailDescBg = ConfigColor.MellodiColorDark3;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _CampSocialLinkDetailDescTriangle = ConfigColor.MellodiColorMid1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _CampSocialLinkDetailDescName = ConfigColor.MellodiColorLight1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _ArcanaCardFallColor1 = ConfigColor.MellodiColorMid1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _ArcanaCardFallColor2 = ConfigColor.MellodiColorMid2;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _ArcanaCardFallColor3 = ConfigColor.MellodiColorMid3;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _CampCalendarSundayColor = ConfigColor.MellodiColorLight3;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _CampCalendarSundayColor2 = ConfigColor.MellodiColorLight1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _CampCalendarTextColor = ConfigColor.MellodiColorDark3;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _CampCalendarHighlightColor = ConfigColor.MellodiColorLight1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _CampCalendarPartTimeJobBackground = ConfigColor.MellodiColorDark1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _PartyPanelBgColor = ConfigColor.MellodiColorMid2;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _ButtonPromptHighlightColor = ConfigColor.MellodiColorLight3;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _ButtonPromptTriangleColor = ConfigColor.MellodiColorMid2;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _BackLogBlackboardColor = ConfigColor.BackLogBlackBoard;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _BackLogGladationColor = ConfigColor.MellodiColorMid2;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _BackLogBlueboardColorEx = ConfigColor.MellodiColorMid2;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _BackLogTitleColor = ConfigColor.MellodiColorMid2;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _BackLogTexColorSelected = ConfigColor.MellodiColorLight3;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _BackLogTexColorUnselectedEx = ConfigColor.MellodiColorDark1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _LocationSelectBgColor = ConfigColor.MellodiColorMid1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _LocationSelectMarkerColor = ConfigColor.MellodiColorMid2;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _LocationSelectSelColor = ConfigColor.MellodiColorMid1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _TimeSkipColor = ConfigColor.MellodiColorMid1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _NextDayBandColor = ConfigColor.MellodiColorDark1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _NextDayTextColor = ConfigColor.MellodiColorMid3;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _NextDayMoonShadowColor = ConfigColor.DayChangeMoonShadow;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _NextDayRipple = ConfigColor.MellodiColorMid1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _ShopPayColor = ConfigColor.MellodiColorLight3;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _ShopFillColor = ConfigColor.MellodiColorMid1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _ShopShadowColor = ConfigColor.MellodiColorMid2;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _ShopPayUnselColor = ConfigColor.MellodiColorMid4;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _GetItemBgMaskColor = ConfigColor.GetItemFillMask;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _GetItemBgColor = ConfigColor.MellodiColorMid2;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _GetItemGotTextColor = ConfigColor.GetItemGotTextColor;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _GetItemCountBgColor = ConfigColor.MellodiColorMid1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _MindSelActiveTextColor = ConfigColor.MellodiColorMid1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _MindSelWindowFill = ConfigColor.MellodiColorMid1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _MindSelWindowBorder = ConfigColor.MellodiColorMid2;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _MindSelectDotColor = ConfigColor.MindSelectDotColor;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _GenericSelectCharacterBackplate = ConfigColor.MellodiColorMid1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _GenericSelectListColorMorning = ConfigColor.MellodiColorMid2;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _GenericSelectListColorAfterSchool = ConfigColor.MellodiColorMid1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _GenericSelectListColorNight = ConfigColor.MellodiColorMid3;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _GenericSelectTitle = ConfigColor.MellodiColorMid1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _GenericSelectCharacterShadow = ConfigColor.MellodiColorMid4;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _MsgSimpleSelectTextColor = ConfigColor.MellodiColorMid1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _MsgSimpleSelectBoxShadow = ConfigColor.MellodiColorDark1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _MsgSimpleSelectShadowEx = ConfigColor.TextBoxFrontFillColor;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _MsgSimpleSelectBorderColorEx = ConfigColor.MellodiColorDark3;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _MsgSimpleSystemLightColor = ConfigColor.MellodiColorMid1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _MsgSimpleSystemDarkColor = ConfigColor.MsgWindowSystemDark;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _MsgSimpleSystemGradationColor = ConfigColor.MellodiColorDark3;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _PersonaStatusSkillListBg = ConfigColor.PersonaStatusSkillListBg;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _PersonaStatusSkillListBg2 = ConfigColor.MellodiColorMid1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _PersonaStatusSkillListCheckboardAlt = ConfigColor.PersonaStatusSkillListCheckboardAlt;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _PersonaSkillListNextSkillColor = ConfigColor.MellodiColorMid1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _PersonaSkillListNextLevelColor = ConfigColor.MellodiColorLight3;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _PersonaSkillListNextSkillInfoName = ConfigColor.MellodiColorLight1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _PersonaStatusPlayerInfoColor = ConfigColor.MellodiColorMid2;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _PersonaStatusInfoSelPersonaColor1 = ConfigColor.MellodiColorLight3;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _PersonaStatusInfoSelPersonaColor2 = ConfigColor.MellodiColorMid2;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _PersonaStatusParamColor = ConfigColor.MellodiColorDark3;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _PersonaStatusCommentaryTitleColor = ConfigColor.MellodiColorLight1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _PersonaStatusBaseStat = ConfigColor.MellodiColorLight3;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _PersonaStatusAttributeOutline = ConfigColor.MellodiColorMid1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _NetworkDailyActionStickyNoteBgColor1 = ConfigColor.NetStickyNoteBgColor1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _NetworkDailyActionStickyNoteBgColor2 = ConfigColor.MellodiColorMid1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _NetworkDailyActionStickyNoteDotColor1 = ConfigColor.MellodiColorLight2;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _NetworkDailyActionStickyNoteDotColor2 = ConfigColor.MellodiColorLight3;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _NetworkDailyActionStickyNoteTextColor1 = ConfigColor.NetStickyNoteTextColor1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _NetworkDailyActionStickyNoteTextColor2 = ConfigColor.MellodiColorLight1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _NetworkDailyActionBlueBgColor = ConfigColor.MellodiColorMid4;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _NetworkDailyActionNetworkIcon = ConfigColor.MellodiColorMid1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _SimpleShopInfoColor = ConfigColor.MellodiColorMid1;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _CutinOuterHighlight = ConfigColor.MellodiColorMid2;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _CutinEmotionGradient = ConfigColor.MellodiColorLight3;

    [Category("Ui Colors")]
    [ObservableProperty]
    private ConfigColor _CutinEmotionTint = ConfigColor.MellodiColorMid2;

    [ObservableProperty]
    private ConfigColor _TitleMenuSelRectColor = ConfigColor.MellodiColorMid1;

    [ObservableProperty]
    private ConfigColor _LocalStaffRollHeader = ConfigColor.MellodiColorLight3;

    [ObservableProperty]
    private ConfigColor _DifficultySelectBgColor = ConfigColor.MellodiColorDark3;

    [ObservableProperty]
    private ConfigColor _WipeBgColor = ConfigColor.MellodiColorDark3;

    [ObservableProperty]
    private ConfigColor _CampItemStatValuePadColor = ConfigColor.MellodiColorDark1;

    [ObservableProperty]
    private ConfigColor _CampItemStatValueValColor = ConfigColor.MellodiColorMid2;

    [ObservableProperty]
    private ConfigColor _CampEquipOverviewListType = ConfigColor.MellodiColorMid3;

    [ObservableProperty]
    private ConfigColor _CampPersonaArcanaPhraseColor = ConfigColor.MellodiColorLight3;

    [ObservableProperty]
    private ConfigColor _CampPersonaNameColor = ConfigColor.MellodiColorLight3;

    [ObservableProperty]
    private ConfigColor _CampPersonaArcanaBgColor = ConfigColor.MellodiColorDark3;

    [ObservableProperty]
    private ConfigColor _CampStatusKotoneLineColor = ConfigColor.MellodiColorLight3;

    [ObservableProperty]
    private ConfigColor _CampStatusInactiveMemberBgTartarus = ConfigColor.InactivePartyMemberTartarusBG;

    [ObservableProperty]
    private ConfigColor _CampStatusInactiveMemberDetailsPalePinkTartarus = ConfigColor.InactivePartyMemberPalePink;

    [ObservableProperty]
    private ConfigColor _CampStatusInactiveMemberDetailsDarkPinkTartarus = ConfigColor.InactivePartyMemberDarkPink;

    [ObservableProperty]
    private ConfigColor _CampStatusInactiveMemberHPBarTartarus = ConfigColor.InactivePartyMemberHPColor;

    [ObservableProperty]
    private ConfigColor _TownMapLocationDetailsBgTint = ConfigColor.MellodiColorMid1;

    [ObservableProperty]
    private ConfigColor _TownMapLocationDetailsTopLeftBg = ConfigColor.MellodiColorMid2;

    [ObservableProperty]
    private ConfigColor _TownMapLocationDetailsTopLeftText = ConfigColor.MellodiColorMid1;

    [ObservableProperty]
    private ConfigColor _TownMapSelectedMarkerOutline = ConfigColor.MellodiColorMid2;

    [ObservableProperty]
    private ConfigColor _SocialStatsUpText = ConfigColor.MellodiColorLight3;

    [ObservableProperty]
    private ConfigColor _SocialStatsPulseCircleColorMain = ConfigColor.MellodiColorLight3;

    [ObservableProperty]
    private ConfigColor _SocialStatsPulseCircleColorFade = ConfigColor.MellodiColorMid1;

    [ObservableProperty]
    private ConfigColor _MsgAssistTextBgColor = ConfigColor.MellodiColorDark3;

    [ObservableProperty]
    private ConfigColor _LocationSelMapBg = ConfigColor.MellodiColorDark3;

    [ObservableProperty]
    private ConfigColor _LocationSelMapLabel = ConfigColor.LocationSelectMapLabel;

    [ObservableProperty]
    private ConfigColor _MsgSystemPicBorderColor = ConfigColor.MellodiColorDark1;

    [ObservableProperty]
    private ConfigColor _TutorialListEntryColor = ConfigColor.MellodiColorLight3;

    [ObservableProperty]
    private ConfigColor _TutorialBgColor = ConfigColor.MellodiColorDark3;

    [ObservableProperty]
    private ConfigColor _MissingLastSighted = ConfigColor.MellodiColorLight3;

    [ObservableProperty]
    private ConfigColor _MissingPageBg = ConfigColor.MellodiColorDark3;

    [ObservableProperty]
    private ConfigColor _MissingTextLight = ConfigColor.MellodiColorLight3;

    [ObservableProperty]
    private ConfigColor _MissingTextDark = ConfigColor.MellodiColorDark3;

    [ObservableProperty]
    private ConfigColor _MissingSortTriangle = ConfigColor.MellodiColorMid2;


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
    private bool _EnableMessageScript = true;

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

    [Category("Debug")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool _DebugDrawOgSelBox = true;

    [Description("This is an enumerable.")]
    [Category("3D Options")]
    [DefaultValue(HairType.MudkipsHair)]
    [ObservableProperty]
    private HairType _HairTrue = HairType.MudkipsHair;

    public enum HairType
    {
        MudkipsHair,
        KotoneBeanHair
    }

    [Description("The group photo")]
    [Category("2D Options")]
    [DefaultValue(GroupEventtype.bichelle)]
    [ObservableProperty]
    private GroupEventtype _GroupEventTrue = GroupEventtype.bichelle;

    public enum GroupEventtype
    {
        bichelle,
        ely
    }

    [Description("The photos from the Kyoto trip")]
    [Category("2D Options")]
    [DefaultValue(KyotoEventtype.ely)]
    [ObservableProperty]
    private KyotoEventtype _KyotoEventTrue = KyotoEventtype.ely;

    public enum KyotoEventtype
    {
        ely
    }

    [Description("The AOA Image.")]
    [Category("2D Options")]
    [DefaultValue(AOAType.Fernando)]
    [ObservableProperty]
    private AOAType _AOATrue = AOAType.Ely;

	public enum AOAType
    {
        Ely,
        Chrysanthie,
        Fernando,
        Monica,
        RonaldReagan,
        esaadrien,
        mekki,
        shiosakana,
        shiosakanaAlt,
        Nami,
        AngieDaGorl,
        StupidAle
    }

    [Description("The AOA Foreground Text.")]
    [Category("2D Options")]
    [DefaultValue(AOATextType.SorryBoutThat)]
    [ObservableProperty]
    private AOATextType _AOAText = AOATextType.SorryBoutThat;

    public enum AOATextType
    {
		DontLookBack,
		SorryBoutThat,
		PerfectlyAccomplished
	}


    [Description("The Bustup.")]
    [Category("2D Options")]
    [DefaultValue(BustupType.Neptune)]
    [ObservableProperty]
    private BustupType _BustupTrue = BustupType.Neptune;

	public enum BustupType
    {
        Neptune,
        Ely,
        Esa,
        Betina,
        Anniversary,
        JustBlue,
        Sav,
        Doodled,
        RonaldReagan,
        ElyAlt,
        Yuunagi,
        cielbell,
        axolotl,
        ghostedtoast,
        Strelko,
        gackt,
        Jackie,
        Lisa,
        BetaFemcByMae,
        crezzstar,
        crezzstarAlt,
        AngieDaGorl,
        namiweiko,
        chitu,
        shiosakana,
        samythecoolkid,
        Mixi_xiMi,
        StupidAle,
        Kiara,
        Autumn,
        p3pYuha
    }

    [Description("The Glass Shard in that one menu when pausing.")]
    [Category("2D Options")]
    [DefaultValue(ShardType.Esa)]
    [ObservableProperty]
    private ShardType _ShardTrue = ShardType.Esa;

	public enum ShardType
    {
        Esa,
        Ely,
        ElyAlt,
        Shiosakana,
        namiweiko,
        AngieDaGorl,
        StupidAle
    }

    [Description("The Level Up :adachitrue:.")]
    [Category("2D Options")]
    [DefaultValue(LevelUpType.Esa)]
    [ObservableProperty]
    private LevelUpType _LevelUpTrue = LevelUpType.Esa;

    public enum LevelUpType
    {
        Esa,
        Ely,
        shiosakana,
        ElyAlt,
        AngieDaGorl
    }

    [Description("The face icons in battle and pause menu")]
	[Category("2D Options")]
	[DefaultValue(PartyPanelType.Esa)]
	[ObservableProperty]
	private PartyPanelType _PartyPanelTrue = PartyPanelType.Esa;

	public enum PartyPanelType
	{
		Kris,
		Esa
	}

	[Description("Cutin Movie")]
    [Category("2D Options")]
    [DefaultValue(CutinType.berrycha)]
    [ObservableProperty]
    private CutinType _CutinTrue = CutinType.berrycha;

    public enum CutinType
    {
        berrycha,
        ElyandPatmandx,
        Mekki,
        shiosakana
    }

    [Description("The Voice of Kotone.")]
    [Category("Voice")]
    [DefaultValue(VoiceType.Mellodi)]
    [ObservableProperty]
    private VoiceType _VoiceTrue = VoiceType.Mellodi;

    public enum VoiceType
    {
        Mellodi,
        MellodiSilly,
        Japanese
    }

    [Category("Fun Stuff")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool _KotoneRoom = false;

    [Category("Fun Stuff")]
    [DefaultValue(false)]
    private bool _GregoryHouseRatPoisonDeliverySystem = false;

    [Description("Gives FemC Nagitanas for weapons")]
    [Category("3D Options")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool _NagiWeap = true;

	[Description("THIS MIGHT BREAK SOME STUFF, ITS A TEST FOR PEOPLE WHO WANT TO, PLEASE GO IN EXPECTING ERRORS")]
	[Category("3D Options")]
	[DefaultValue(true)]
    [ObservableProperty]
	private bool _SkirtEtcFix = true;

    [Category("Theo")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool _TheodorefromAlvinandTheChipmunks = false; // soon this should be a whole thing, movies, bustups, etc 
}