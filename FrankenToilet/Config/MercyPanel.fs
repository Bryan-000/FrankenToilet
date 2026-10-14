namespace FrankenToilet.Config

type MercyPanel(parentPanel) as panel =
    inherit Panel(parentPanel, "Mercy", "mercy_panel")

    member val SugoiPopup = Bool(panel, "Enable Sugoi Popup", "mercy.SugoiPopup", true)
    member val PiercerMods = Bool(panel, "Enable Default Piercer Mods", "mercy.PiercerMods", true)
    member val PartyMode = Bool(panel, "Enable Party Mode", "mercy.PartyMode", true)
    member val QuickTimeChallenges = Bool(panel, "Enable Quick Time Challenges", "mercy.QuickTimeChallenges", true)
    member val GameplayTips = Bool(panel, "Enable Gameplay Tips", "mercy.GameplayTips", true)
    member val LevelingSystem = Bool(panel, "Enable Leveling System", "mercy.LevelingSystem", true)
    member val CursorUnlock = Bool(panel, "Enable Cursor Unlock", "mercy.CursorUnlock", true)
    member val NewFeatureAlert = Bool(panel, "New Feature Alert", "mercy.NewFeatureAlert", true)