namespace FrankenToilet.Config

type BryanPanel(parentPanel) as panel =
    inherit Panel(parentPanel, "Bryan", "Bryan_panel")

    member val EnableBridgeBurnerTransLighting = Bool(panel, "Enable bridge burner trans lighting", "Bryan.EnableBridgeBurnerTransLighting", true)
    member val EnableCustomSkullDeathScreen    = Bool(panel, "Enable custom skull death screen", "Bryan.EnableCustomSkullDeathScreen", true)
    member val EnableStupidStyles              = Bool(panel, "Enable stupid styles messages", "Bryan.EnableStupidStyles", true)
    member val EnableTF2HeavyParryFlash        = Bool(panel, "Enable TF2 Heavy parry flash", "Bryan.EnableTF2HeavyParryFlash", true)
    member val EnableTF2HeavySkulls            = Bool(panel, "Enable TF2 Heavy skulls", "Bryan.EnableTF2HeavySkulls", true)

    member val Replace7_1Flash                    = Bool(panel, "Replace 7-1 flash", "Bryan.Replace7_1Flash", true)
    member val ReplaceHUDTabName                  = Bool(panel, "Replace HUD tab name", "Bryan.ReplaceHUDTabName", true)
    member val ReplaceMauriceModel                = Bool(panel, "Replace Maurice model", "Bryan.ReplaceMauriceModel", true)
    member val ReplaceSomethingWickedWithTF2Heavy = Bool(panel, "Replace Something Wicked with TF2 Heavy", "Bryan.ReplaceSomethingWickedWithTF2Heavy", true)
    member val ReplaceTextFonts                   = Bool(panel, "Replace text fonts", "Bryan.ReplaceTextFonts", true)
    member val ReplaceUltrakillTitleImages        = Bool(panel, "Replace ULTRAKILL title images", "Bryan.ReplaceUltrakillTitleImages", true)
    member val ReplaceVideos                      = Bool(panel, "Replace videos", "Bryan.ReplaceVideos", true)

    member val TextFuckChance               = FloatSlider(panel, "Chance for text to be gay", "Bryan.TextFuckChance", (0f, 100f), 25f, 0)
    member val TransFlagOnDeathScreenChance = FloatSlider(panel, "Trans flag on death screen chance", "Bryan.TransFlagOnDeathScreenChance", (0f, 100f), 25f, 0)

    member val DuplicateProjHeader      = Header(panel, "Duplicate projectiles Settings")
    member val DuplicateProjectiles     = Bool(panel, "Duplicate projectiles", "Bryan.DuplicateProjectiles", true)
    member val DuplicateProjectilesTime = Float(panel, "Duplicate projectiles after", "Bryan.DuplicateProjectilesTime", 0.5f)
