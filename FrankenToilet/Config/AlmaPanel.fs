namespace FrankenToilet.Config

type AlmaPanel(parentPanel) as panel =
    inherit Panel(parentPanel, "alma", "alma_panel")

    member val LevelJumpscareChance = FloatSlider(panel, "Level jumpscare chance", "alma.LevelJumpscareChance", (0f, 100f), 15f, 0)