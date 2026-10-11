namespace FrankenToilet.Config

type DoomahRealPanel(parentPanel) as panel =
    inherit Panel(parentPanel, "doomahreal", "doomahreal_panel")
    
    member val EnableCameraTilt        = Bool(panel, "Enable Camera Tilt", "doomahreal.EnableCameraTilt", true)
    member val EnableWhatsAppGabe      = Bool(panel, "Enable WhatsApp Gabe", "doomahreal.EnableWhatsAppGabe", true)
    member val EnableLastFilthStanding = Bool(panel, "Buff last enemy in an arena", "doomahreal.EnableLastFilthStanding", true)

    member val EvilScaryHeader         = Header(panel, "Evil Scary Settings")
    member val EnableEvilScary         = Bool(panel, "Enable Evil Scary", "doomahreal.EnableEvilScary", true)
    member val EvilScaryStartCounter   = Int(panel, "Spawn Evil Scary after X level loads", "doomahreal.EvilScaryStartCounter", 3)