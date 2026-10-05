namespace FrankenToilet.Config

open PluginConfig.API
open PluginConfig.API.Decorators
open PluginConfig.API.Fields

type BananaStudioPanel(parentPanel) as panel =
    inherit ConfigPanel(parentPanel, "Bananastudio", "Bananastudio_panel")

    member val EnableAchievements          = BoolField(panel, "Enable minecraft style achievements", "Bananastudio.EnableAchievements", true)
    member val EnableAdsOnDeath            = BoolField(panel, "Enable ads on death", "Bananastudio.EnableAdsOnDeath", true)
    member val EnablePlayerBuffs           = BoolField(panel, "Enable player buffs", "Bananastudio.EnablePlayerBuffs", true)
    member val EnablePlushiesFalling       = BoolField(panel, "Enable plushies falling on the main menu", "Bananastudio.EnablePlushiesFalling", true)
    member val EnableSpecialBossHealthBars = BoolField(panel, "Enable special boss health bars", "Bananastudio.EnableSpecialBossHealthBars", true)

    member val MinosOverrideChance                = FloatSliderField(panel, "Override boss with minos chance", "Bananastudio.MinosOverrideChance", (0f, 100f), 55f, 0)
    member val ReplaceDoorTexturesWithMemesChance = FloatSliderField(panel, "Chance to replace door with meme textures", "Bananastudio.ReplaceDoorTexturesWithMemesChance", (0f, 100f), 75f, 0)


    member val EvilV1Header = ConfigHeader(panel, "Evil V1 Settings")
    member val EnableEVILV1 = BoolField(panel, "Enable evil V1", "Bananastudio.EnableEVILV1", true)
    member val EvilV1SpawnChance = FloatSliderField(panel, "Evil v1 spawn chance (the rest of the chance is used for player buffs)", "Bananastudio.EVILV1SpawnChance", (0f, 100f), 35f, 0)


    member val ImplosionHeader = ConfigHeader(panel, "Implosion Settings")
    member val ImplosionRadius = FloatField(panel, "Implosion radius", "Bananastudio.ImplosionRadius", 30f)
    member val EnableImplosionsOnEnemyDeath = BoolField(panel, "Enable implosions on enemy death", "Bananastudio.EnableImplosionsOnEnemyDeath", true)