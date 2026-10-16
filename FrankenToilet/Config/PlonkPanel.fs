namespace FrankenToilet.Config

open System

type PlonkPanel(parentPanel) as panel =
    inherit Panel(parentPanel, "Plonk", "Plonk_panel")

    member val GravitySwapType = Dropdown(panel, "Gravity swap type", "Plonk.GravitySwapType", GravitySwapTypes.PlayerOnly)

    member val EnableGravitySwapOnJump       = Bool(panel, "Enable random gravity swap on jump", "Plonk.EnableGravitySwapOnJump", false)
    member val EnableRandomGravitySwapOnTime = Bool(panel, "Enable random gravity swap on time", "Plonk.EnableRandomGravitySwapOnTime", true)

    member val RandomGravitySwapMaxTime = Float(panel, "Random gravity swap maximum time (in seconds)", "Plonk.RandomGravitySwapMaxTime", 10f)
    member val RandomGravitySwapMinTime = Float(panel, "Random gravity swap minimum time (in seconds)", "Plonk.RandomGravitySwapMinTime", 1f)

and [<Flags>] GravitySwapTypes =
    | None       = 0b00
    | PlayerOnly = 0b01
    | EnemyOnly  = 0b10
    | Both       = 0b11