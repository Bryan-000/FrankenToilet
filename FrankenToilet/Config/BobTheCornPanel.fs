namespace FrankenToilet.Config

open PluginConfig.API
open PluginConfig.API.Decorators
open PluginConfig.API.Fields

type BobTheCornPanel(parentPanel) as panel =
    inherit ConfigPanel(parentPanel, "bobthecorn", "bobthecorn_panel")

    member val EnableUltraClicker = BoolField(panel, "Enable ultra clicker (available in the sandbox)", "bobthecorn.EnableUltraClicker", true)