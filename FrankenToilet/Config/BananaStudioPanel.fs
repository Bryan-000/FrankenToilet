namespace FrankenToilet.Config

type BananaStudioPanel(parentPanel) as panel =
    inherit Panel(parentPanel, "BananaStudio", "Bananastudio_panel")

    member val EnableAchievements          = Bool(panel, "Enable minecraft style achievements", "Bananastudio.EnableAchievements", true)
    member val EnableAdsOnDeath            = Bool(panel, "Enable ads on death", "Bananastudio.EnableAdsOnDeath", true)
    member val EnablePlayerBuffs           = Bool(panel, "Enable player buffs", "Bananastudio.EnablePlayerBuffs", true)
    member val EnablePlushiesFalling       = Bool(panel, "Enable plushies falling on the main menu", "Bananastudio.EnablePlushiesFalling", true)
    member val EnableSpecialBossHealthBars = Bool(panel, "Enable special boss health bars", "Bananastudio.EnableSpecialBossHealthBars", true)

    member val MinosOverrideChance                = FloatSlider(panel, "Override boss with minos chance", "Bananastudio.MinosOverrideChance", (0f, 100f), 55f, 0)
    member val ReplaceDoorTexturesWithMemesChance = FloatSlider(panel, "Chance to replace door with meme textures", "Bananastudio.ReplaceDoorTexturesWithMemesChance", (0f, 100f), 75f, 0)


    member val EvilV1Header = Header(panel, "Evil V1 Settings")
    member val EnableEVILV1 = Bool(panel, "Enable evil V1", "Bananastudio.EnableEVILV1", true)
    member val EvilV1SpawnChance = FloatSlider(panel, "Evil v1 spawn chance (the rest of the chance is used for player buffs)", "Bananastudio.EVILV1SpawnChance", (0f, 100f), 35f, 0)


    member val ImplosionHeader = Header(panel, "Implosion Settings")
    member val ImplosionRadius = Float(panel, "Implosion radius", "Bananastudio.ImplosionRadius", 30f)
    member val EnableImplosionsOnEnemyDeath = Bool(panel, "Enable implosions on enemy death", "Bananastudio.EnableImplosionsOnEnemyDeath", true)