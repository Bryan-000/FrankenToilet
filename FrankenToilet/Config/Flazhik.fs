namespace FrankenToilet.Config

type FlazhikPanel(parentPanel) as panel =
    inherit Panel(parentPanel, "Flazhik", "flazhik_panel")

    member val EnableSanAndreas = Bool(panel, "GTA SanAndreas", "flazhik.EnableSanAndreas", true)