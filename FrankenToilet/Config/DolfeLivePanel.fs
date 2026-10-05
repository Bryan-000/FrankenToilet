namespace FrankenToilet.Config

open PluginConfig.API
open PluginConfig.API.Decorators
open PluginConfig.API.Fields

type DolfeLivePanel(parentPanel) as panel =
    inherit ConfigPanel(parentPanel, "dolfelive", "dolfelive_panel")

    member val EnableSin = BoolField(panel, "Enable Sin (Grace)", "dolfelive.EnableSin", true)