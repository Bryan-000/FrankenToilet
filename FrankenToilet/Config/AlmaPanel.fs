namespace FrankenToilet.Config

open PluginConfig.API
open PluginConfig.API.Decorators
open PluginConfig.API.Fields

type AlmaPanel(parentPanel) as panel =
    inherit ConfigPanel(parentPanel, "alma", "alma_panel")

    member val LevelJumpscareChance = FloatSliderField(panel, "Level jumpscare chance", "alma.LevelJumpscareChance", (0f, 100f), 15f, 0)