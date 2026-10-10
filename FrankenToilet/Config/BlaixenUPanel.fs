namespace FrankenToilet.Config

open PluginConfig.API
open PluginConfig.API.Decorators
open PluginConfig.API.Fields

type BlaixenUPanel(parentPanel) as panel =
    inherit ConfigPanel(parentPanel, "BlaixenU", "BlaixenU_panel")

    member val EnablePopups       = BoolField(panel, "Enable popups on screen", "BlaixenU.EnablePopups", true)
    member val MaxPopups          = IntField(panel, "Max popups", "BlaixenU.MaxPopups", 5)
    member val PopupsMinSpawnTime = IntField(panel, "Popups min spawn time", "BlaixenU.PopupsMinSpawnTime", 15)
    member val PopupsMaxSpawnTime = IntField(panel, "Popups max spawn time", "BlaixenU.PopupsMaxSpawnTime", 60)

