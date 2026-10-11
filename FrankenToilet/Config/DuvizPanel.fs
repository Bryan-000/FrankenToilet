namespace FrankenToilet.Config

type DuvizPanel(parentPanel) as panel =
    inherit Panel(parentPanel, "Duviz", "duviz_panel")
    
    member val LevelEditsHeader = Header(panel, "-- Level Edits settings --")
    member val EnableLevelEdits = Bool(panel, "Enable level edits", "duviz.EnableLevelEdits", true)
    member val LevelEdits       = LevelEditsPanel(panel)

    member val EventsHeader = Header(panel, "-- Events settings --")
    member val EnableEvents = Bool(panel, "Enable events", "duviz.EnableEvents", true)
    member val Events       = EventsPanel(panel)

    member val RevolverZoomGoBrrrrr = Bool(panel, "Revolver zoom go brrrrr",   "duviz.RevolverZoomGoBrrrrr", true)
    member val SisyphusStealsUrGuns = Bool(panel, "Sisyphus steals your guns", "duviz.SisyphusStealsUrGuns", true)
    member val NoMoreHookpoints = Bool(panel, "No more hookpoints", "duviz.NoMoreHookpoints", true)
    member val EnableSmashHP = Bool(panel, "Enable Smash bros like HP", "duviz.EnableSmashHP", true)
    member val WaterDamagesU = Bool(panel, "Water damages you", "duviz.WaterDamagesU", true)
    member val BuffLeviathan = Bool(panel, "Buff Leviathan", "duviz.BuffLeviathan", true)
    member val EnableJesus = Bool(panel, "Enable Jesus on death", "duviz.EnableJesus", true)

and LevelEditsPanel(parentPanel) as panel =
    inherit Panel(parentPanel, "Level Edits", "duviz_leveledits_panel")
    
    member val Enable1_4WideV2     = Bool(panel, "Enable 1-4 Wide V2",     "duviz.leveledits.Enable1_4WideV2",     true)
    member val Enable2_1Transgener = Bool(panel, "Enable 2-1 transsky",    "duviz.leveledits.Enable2_1Transgener", true)
    member val Enable1_SMissingTex = Bool(panel, "Remove 1-S textures",    "duviz.leveledits.Enable1_SMissingTex", true)
    member val Enable4_4MissingTex = Bool(panel, "Remove 4-4 textures",    "duviz.leveledits.Enable4_4MissingTex", true)
    member val Enable5_3Spinnnning = Bool(panel, "Enable Spinning in 5-3", "duviz.leveledits.Enable5_3Spinnnning", true)
    member val EnableWrathDrainage = Bool(panel, "Drain Wrath?",           "duviz.leveledits.EnableWrathDrainage", true)


and EventsPanel(parentPanel) as panel =
    inherit Panel(parentPanel, "Events", "duviz_events_panel")
    
    member val Explode    = Bool(panel, "Explode",                      "duviz.events.Explode",    true)
    member val NotFound   = Bool(panel, "Not found (removes textures)", "duviz.events.NotFound",   true)
    member val Minos      = Bool(panel, "Spawns minos prime",           "duviz.events.Minos",      true)
    member val Balls      = Bool(panel, "Spawns bouncy balls",          "duviz.events.Balls",      true)
    member val BlueScreen = Bool(panel, "Blue screen",                  "duviz.events.BlueScreen", true)
    member val NoWeapons  = Bool(panel, "No weapons",                   "duviz.events.NoWeapons",  true)
    member val ResetHP    = Bool(panel, "Reset percentage (aka HP)",    "duviz.events.ResetHP",    true)
    member val AddHP      = Bool(panel, "Add percentage (aka heal)",    "duviz.events.AddHP",      true)
    member val Spin       = Bool(panel, "Speennn (spins u :3)",         "duviz.events.Spin",       true)
    member val GoAway     = Bool(panel, "Go away (flings u)",           "duviz.events.GoAway",     true)
    member val Pause      = Bool(panel, "Pause (pauses the game)",      "duviz.events.Pause",      true)
    member val nOSTAMINA  = Bool(panel, "nO STAMINA",                   "duviz.events.nOSTAMINA",  true)
    member val Imagine    = Bool(panel, "Imagine (flings u more)",      "duviz.events.Image",      true)
    member val GodIsAngi  = Bool(panel, "God is angry",                 "duviz.events.GodIsAngi",  true)