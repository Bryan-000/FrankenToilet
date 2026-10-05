namespace FrankenToilet.Config

open PluginConfig.API
open PluginConfig.API.Decorators
open PluginConfig.API.Fields

type PlonkPanel(parentPanel) as panel =
    inherit ConfigPanel(parentPanel, "Plonk", "Plonk_panel")

    member val EnableGravitySwapOnJump       = BoolField(panel, "Enable random gravity swap on jump", "Plonk.EnableGravitySwapOnJump", true)
    member val EnableRandomGravitySwapOnTime = BoolField(panel, "Enable random gravity swap on time", "Plonk.EnableRandomGravitySwapOnTime", true)

    member val RandomGravitySwapMaxTime = FloatField(panel, "Random gravity swap maximum time (in seconds)", "Plonk.RandomGravitySwapMaxTime", 10f)
    member val RandomGravitySwapMinTime = FloatField(panel, "Random gravity swap minimum time (in seconds)", "Plonk.RandomGravitySwapMinTime", 1f)