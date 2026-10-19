namespace FrankenToilet.Config

type BobTheCornPanel(parentPanel) as panel =
    inherit Panel(parentPanel, "BobTheCorn", "bobthecorn_panel")

    member val EnableUltraClicker = Bool(panel, "Enable ultra clicker (available in the sandbox)", "bobthecorn.EnableUltraClicker", true)