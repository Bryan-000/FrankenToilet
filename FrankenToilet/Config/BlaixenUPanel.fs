namespace FrankenToilet.Config

type BlaixenUPanel(parentPanel) as panel =
    inherit Panel(parentPanel, "BlaixenU", "BlaixenU_panel")

    member val EnablePopups       = Bool(panel, "Enable popups on screen", "BlaixenU.EnablePopups", true)
    member val MaxPopups          = Int(panel, "Max popups", "BlaixenU.MaxPopups", 5)
    member val PopupsMinSpawnTime = Int(panel, "Popups min spawn time", "BlaixenU.PopupsMinSpawnTime", 15)
    member val PopupsMaxSpawnTime = Int(panel, "Popups max spawn time", "BlaixenU.PopupsMaxSpawnTime", 60)

