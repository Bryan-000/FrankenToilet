namespace FrankenToilet.Config

type EarthlingPanel(parentPanel) as panel =
    inherit Panel(parentPanel, "Earthling", "earthling_panel")
    
    member val BookChenifier   = Bool(panel, "Book chenifier (replaces its text)", "earthling.BookChenifier",   true)
    member val EnableBlueFilth = Bool(panel, "Enable blue filth",                  "earthling.EnableBlueFilth", true)
    member val EnableDontPlay  = Bool(panel, "Change play button to don't play",   "earthling.EnableDontPlay",  true)
    member val HandDrawnIcons  = Bool(panel, "Hand drawn weapon icons",            "earthling.HandDrawnIcons",  true)
    member val NoRocketsForYou = Bool(panel, "Blow up rockets when you ride them", "earthling.NoRocketsForYou", true)
    member val SpawnFishOnKill = Bool(panel, "Spawn fish on killing an enemy",     "earthling.SpawnFishOnKill", true)
    member val SwapFistsIHateU = Bool(panel, "Swap fists/arm colors and binds",    "earthling.SwapFistsIHateU", true)