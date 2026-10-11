namespace FrankenToilet.Config

type DolfeLivePanel(parentPanel) as panel =
    inherit Panel(parentPanel, "DolfeLive", "dolfelive_panel")

    member val EnableSin = Bool(panel, "Enable Sin (Grace)", "dolfelive.EnableSin", true)