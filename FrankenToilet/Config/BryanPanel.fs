namespace FrankenToilet.Config

open PluginConfig.API
open PluginConfig.API.Decorators
open PluginConfig.API.Fields

type BryanPanel(parentPanel) as panel =
    inherit ConfigPanel(parentPanel, "Bryan", "Bryan_panel")

    member val EnableBridgeBurnerTransLighting = BoolField(panel, "Enable bridge burner trans lighting", "Bryan.EnableBridgeBurnerTransLighting", true)
    member val EnableCustomSkullDeathScreen    = BoolField(panel, "Enable custom skull death screen", "Bryan.EnableCustomSkullDeathScreen", true)
    member val EnableStupidStyles              = BoolField(panel, "Enable stupid styles messages", "Bryan.EnableStupidStyles", true)
    member val EnableTF2HeavyParryFlash        = BoolField(panel, "Enable TF2 Heavy parry flash", "Bryan.EnableTF2HeavyParryFlash", true)
    member val EnableTF2HeavySkulls            = BoolField(panel, "Enable TF2 Heavy skulls", "Bryan.EnableTF2HeavySkulls", true)

    member val Replace7_1Flash                    = BoolField(panel, "Replace 7-1 flash", "Bryan.Replace7_1Flash", true)
    member val ReplaceHUDTabName                  = BoolField(panel, "Replace HUD tab name", "Bryan.ReplaceHUDTabName", true)
    member val ReplaceMauriceModel                = BoolField(panel, "Replace Maurice model", "Bryan.ReplaceMauriceModel", true)
    member val ReplaceSomethingWickedWithTF2Heavy = BoolField(panel, "Replace Something Wicked with TF2 Heavy", "Bryan.ReplaceSomethingWickedWithTF2Heavy", true)
    member val ReplaceTextFonts                   = BoolField(panel, "Replace text fonts", "Bryan.ReplaceTextFonts", true)
    member val ReplaceUltrakillTitleImages        = BoolField(panel, "Replace ULTRAKILL title images", "Bryan.ReplaceUltrakillTitleImages", true)
    member val ReplaceVideos                      = BoolField(panel, "Replace videos", "Bryan.ReplaceVideos", true)

    member val TextFuckChance               = FloatSliderField(panel, "Chance for text to be gay", "Bryan.TextFuckChance", (0f, 100f), 25f, 0)
    member val TransFlagOnDeathScreenChance = FloatSliderField(panel, "Trans flag on death screen chance", "Bryan.TransFlagOnDeathScreenChance", (0f, 100f), 25f, 0)

    member val DuplicateProjHeader = ConfigHeader(panel, "Duplicate projectiles Settings")
    member val DuplicateProjectiles     = BoolField(panel, "Duplicate projectiles", "Bryan.DuplicateProjectiles", true)
    member val DuplicateProjectilesTime = FloatField(panel, "Duplicate projectiles after", "Bryan.DuplicateProjectilesTime", 0.5f)
