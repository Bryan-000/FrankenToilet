namespace FrankenToilet.Config

type LakeullPanel(parentPanel) as panel =
    inherit Panel(parentPanel, "Lakeull", "lakeull_panel")
    
    member val ItemCooldown = FloatSlider(panel, "Item cooldown", "lakeull.ItemCooldown", (0f, 100f), 10f)
    member val EnableItems  = Bool(panel, "Enable items", "lakeull.EnableItems", true)
    member val ItemsPanel   = ItemsPanel(panel)

and ItemsPanel(parentPanel) as panel =
    inherit Panel(parentPanel, "Items", "lakeull_items_panel")
    
    // member val Bleh = Bool(panel, "Bleh", "lakeullitems.Bleh", true)
    member val KillYourself    = Bool(panel, "Self destruct/kill yourself item", "lakeullitems.KillYourself", true)
    member val BigFuckAssCoin  = Bool(panel, "Big fucking coin item", "lakeullitems.BigFuckAssCoin", true)
    member val EnableIglooItem = Bool(panel, "Enable igloo item", "lakeullitems.EnableIglooItem", true)
    member val RandomBuffUwU   = Bool(panel, "Random buff item", "lakeullitems.RandomBuffUwU", true)
    member val Gatorade        = Bool(panel, "Gatorade item", "lakeullitems.Gatorade", true)
    member val OrbitDawg       = Bool(panel, "Orbitular dog (black hole) item", "lakeullitems.OrbitDawg", true)
    member val MmmmmmmDonut    = Bool(panel, "Mmmmm... donut", "lakeullitems.MmmmmmmDonut", true)