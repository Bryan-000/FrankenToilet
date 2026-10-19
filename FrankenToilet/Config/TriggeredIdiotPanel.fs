namespace FrankenToilet.Config

type TriggeredIdiotPanel(parentPanel) as panel =
    inherit Panel(parentPanel, "TriggeredIdiot", "TriggeredIdiot_panel")

    member val MovementBar = Bool(panel, "Enable Movement Bar", "triggeredidiot.movementbar", true)
    member val StyleBar = Bool(panel, "Enable Style Bar", "triggeredidiot.stylebar", true)
    member val TntMult = Float(panel,"TNT Amount Multiplier","triggeredidiot.tntmult",1.0f);