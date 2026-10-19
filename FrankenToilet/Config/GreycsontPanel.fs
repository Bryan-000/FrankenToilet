namespace FrankenToilet.Config

type GreycsontPanel(parentPanel) as panel =
    inherit Panel(parentPanel, "Greycsont", "Greycsont_panel")

    member val OsuManiaPauseMenu   = Bool(panel, "<size=10>Show far in the blue sky [osu mania] in the pause menu", "greycsont.OsuManiaPauseMenu",   true)
    member val ChangeSsjMaxFrames  = Bool(panel, "Change max SSJ frames",                                           "greycsont.ChangeSsjMaxFrames",  true)
    member val RandomJackKnockBack = Bool(panel, "<size=13>Randomize jackhammer knockback direction",                        "greycsont.RandomJackKnockBack", true)