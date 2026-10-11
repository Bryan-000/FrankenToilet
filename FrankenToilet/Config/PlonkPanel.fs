namespace FrankenToilet.Config

type PlonkPanel(parentPanel) as panel =
    inherit Panel(parentPanel, "Plonk", "Plonk_panel")

    member val EnableGravitySwapOnJump       = Bool(panel, "Enable random gravity swap on jump", "Plonk.EnableGravitySwapOnJump", true)
    member val EnableRandomGravitySwapOnTime = Bool(panel, "Enable random gravity swap on time", "Plonk.EnableRandomGravitySwapOnTime", true)

    member val RandomGravitySwapMaxTime = Float(panel, "Random gravity swap maximum time (in seconds)", "Plonk.RandomGravitySwapMaxTime", 10f)
    member val RandomGravitySwapMinTime = Float(panel, "Random gravity swap minimum time (in seconds)", "Plonk.RandomGravitySwapMinTime", 1f)