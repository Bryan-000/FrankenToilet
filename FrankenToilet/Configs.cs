namespace FrankenToilet;

using PluginConfig.API;
using PluginConfig.API.Decorators;
using PluginConfig.API.Fields;
using System;

/*
I HAD TO SCRAP THIS *WAY BETTER* DESIGN BECAUSE FUCKING C# DECIDED THAT FOR WHATEVER REASON
YOU CANT USE `this` IN A FIELD INITIALIZER

EVEN THO THEY GET COMPILED INTO CONSTRUCTORS ANYWAYS AND YOU *CAN* USE `this` IN A CONSTRUCTOR

public class Alma(ConfigPanel parentPanel) : ConfigPanel(parentPanel, "alma", "alma_panel")
{
    public FloatSliderField LevelJumpscareChance = new(this, "Level jumpscare chance", "alma.LevelJumpscareChance", (0f, 100f), 15f, 0);
}
*/
public static partial class ConfigManager
{
    public class AlmaPanel : ConfigPanel
    {
        public FloatSliderField LevelJumpscareChance;

        public AlmaPanel(ConfigPanel parentPanel) : base(parentPanel, "alma", "alma_panel")
        {
            LevelJumpscareChance = new(this, "Level jumpscare chance", "alma.LevelJumpscareChance", new Tuple<float, float>(0f, 100f), 15f, 0);
        }
    }

    public class BananaStudioPanel : ConfigPanel
    {
        public BoolField EnableAchievements;
        public BoolField EnableAdsOnDeath;
        public BoolField EnablePlayerBuffs;
        public BoolField EnablePlushiesFalling;
        public BoolField EnableSpecialBossHealthBars;

        public FloatSliderField MinosOverrideChance;
        public FloatSliderField ReplaceDoorTexturesWithMemesChance;

        public BoolField        EnableEVILV1;
        public FloatSliderField EvilV1SpawnChance;

        public FloatField ImplosionRadius;
        public BoolField  EnableImplosionsOnEnemyDeath;

        public BananaStudioPanel(ConfigPanel parentPanel) : base(parentPanel, "Bananastudio", "Bananastudio_panel")
        {
            EnableAchievements          = new(this, "Enable minecraft style achievements", "Bananastudio.EnableAchievements", true);
            EnableAdsOnDeath            = new(this, "Enable ads on death", "Bananastudio.EnableAdsOnDeath", true);
            EnablePlayerBuffs           = new(this, "Enable player buffs", "Bananastudio.EnablePlayerBuffs", true);
            EnablePlushiesFalling       = new(this, "Enable plushies falling on the main menu", "Bananastudio.EnablePlushiesFalling", true);
            EnableSpecialBossHealthBars = new(this, "Enable special boss health bars", "Bananastudio.EnableSpecialBossHealthBars", true);

            MinosOverrideChance                = new(this, "Override boss with minos chance", "Bananastudio.MinosOverrideChance", new Tuple<float, float>(0f, 100f), 55f, 0);
            ReplaceDoorTexturesWithMemesChance = new(this, "Chance to replace door with meme textures", "Bananastudio.ReplaceDoorTexturesWithMemesChance", new Tuple<float, float>(0f, 100f), 75f, 0);

            new ConfigHeader(this, "Evil V1 Settings");
            EnableEVILV1      = new(this, "Enable evil V1", "Bananastudio.EnableEVILV1", true);
            EvilV1SpawnChance = new(this, "Evil v1 spawn chance (the rest of the chance is used for player buffs)", "Bananastudio.EVILV1SpawnChance", new Tuple<float, float>(0f, 100f), 35f, 0);

            new ConfigHeader(this, "Implosion Settings");
            ImplosionRadius              = new(this, "Implosion radius", "Bananastudio.ImplosionRadius", 30f);
            EnableImplosionsOnEnemyDeath = new(this, "Enable implosions on enemy death", "Bananastudio.EnableImplosionsOnEnemyDeath", true);
        }
    }

    public class BlaixenUPanel : ConfigPanel
    {
        public BoolField EnablePopups;
        public IntField  PopupsMaxSpawnTime;
        public IntField  PopupsMinSpawnTime;

        public BlaixenUPanel(ConfigPanel parentPanel) : base(parentPanel, "BlaixenU", "BlaixenU_panel")
        {
            EnablePopups       = new(this, "Enable popups on screen", "BlaixenU.EnablePopups", true);
            PopupsMaxSpawnTime = new(this, "Popups max spawn time", "BlaixenU.PopupsMaxSpawnTime", 15);
            PopupsMinSpawnTime = new(this, "Popups min spawn time", "BlaixenU.PopupsMinSpawnTime", 5);
        }
    }

    public class BobTheCornPanel : ConfigPanel
    {
        public BoolField EnableUltraClicker;

        public BobTheCornPanel(ConfigPanel parentPanel) : base(parentPanel, "bobthecorn", "bobthecorn_panel")
        {
            EnableUltraClicker = new(this, "Enable ultra clicker (available in the sandbox)", "bobthecorn.EnableUltraClicker", true);
        }
    }

    public class BryanPanel : ConfigPanel
    {
        public BoolField  DuplicateProjectiles;
        public FloatField DuplicateProjectilesTime;

        public BoolField EnableBridgeBurnerTransLighting;
        public BoolField EnableCustomSkullDeathScreen;
        public BoolField EnableCustomStyles;
        public BoolField EnableTF2HeavyParryFlash;
        public BoolField EnableTF2HeavySkulls;

        public BoolField Replace7_1Flash;
        public BoolField ReplaceHUDTabName;
        public BoolField ReplaceMauriceModel;
        public BoolField ReplaceSomethingWickedWithTF2Heavy;
        public BoolField ReplaceTextFonts;
        public BoolField ReplaceUltrakillTitleImages;

        public FloatSliderField TextChaosChance;
        public FloatSliderField TransFlagOnDeathScreenChance;

        public BryanPanel(ConfigPanel parentPanel) : base(parentPanel, "Bryan", "Bryan_panel")
        {
            new ConfigHeader(this, "Duplicate projectiles Settings");
            DuplicateProjectiles     = new(this, "Duplicate projectiles", "Bryan.DuplicateProjectiles", true);
            DuplicateProjectilesTime = new(this, "Duplicate projectiles time", "Bryan.DuplicateProjectilesTime", 0.5f);

            EnableBridgeBurnerTransLighting = new(this, "Enable bridge burner trans lighting", "Bryan.EnableBridgeBurnerTransLighting", true);
            EnableCustomSkullDeathScreen    = new(this, "Enable custom skull death screen", "Bryan.EnableCustomSkullDeathScreen", true);
            EnableCustomStyles              = new(this, "Enable custom styles", "Bryan.EnableCustomStyles", true);
            EnableTF2HeavyParryFlash        = new(this, "Enable TF2 Heavy parry flash", "Bryan.EnableTF2HeavyParryFlash", true);
            EnableTF2HeavySkulls            = new(this, "Enable TF2 Heavy skulls", "Bryan.EnableTF2HeavySkulls", true);

            Replace7_1Flash                    = new(this, "Replace 7-1 flash", "Bryan.Replace7_1Flash", true);
            ReplaceHUDTabName                  = new(this, "Replace HUD tab name", "Bryan.ReplaceHUDTabName", true);
            ReplaceMauriceModel                = new(this, "Replace Maurice model", "Bryan.ReplaceMauriceModel", true);
            ReplaceSomethingWickedWithTF2Heavy = new(this, "Replace Something Wicked with TF2 Heavy", "Bryan.ReplaceSomethingWickedWithTF2Heavy", true);
            ReplaceTextFonts                   = new(this, "Replace text fonts", "Bryan.ReplaceTextFonts", true);
            ReplaceUltrakillTitleImages        = new(this, "Replace ULTRAKILL title images", "Bryan.ReplaceUltrakillTitleImages", true);

            TextChaosChance              = new(this, "Chance for text chaos to occur", "Bryan.TextChaosChance", new Tuple<float, float>(0f, 100f), 25f, 0);
            TransFlagOnDeathScreenChance = new(this, "Trans flag on death screen chance", "Bryan.TransFlagOnDeathScreenChance", new Tuple<float, float>(0f, 100f), 25f, 0);
        }
    }

    public class PlonkPanel : ConfigPanel
    {
        public BoolField EnableGravitySwapOnJump;
        public BoolField EnableRandomGravitySwapOnTime;

        public FloatField RandomGravitySwapMaxTime;
        public FloatField RandomGravitySwapMinTime;

        public PlonkPanel(ConfigPanel parentPanel) : base(parentPanel, "Plonk", "Plonk_panel")
        {
            EnableGravitySwapOnJump       = new(this, "Enable random gravity swap on jump", "Plonk.EnableGravitySwapOnJump", true);
            EnableRandomGravitySwapOnTime = new(this, "Enable random gravity swap on time", "Plonk.EnableRandomGravitySwapOnTime", true);

            RandomGravitySwapMaxTime = new(this, "Random gravity swap maximum time (in seconds)", "Plonk.RandomGravitySwapMaxTime", 10f);
            RandomGravitySwapMinTime = new(this, "Random gravity swap minimum time (in seconds)", "Plonk.RandomGravitySwapMinTime", 1f);
        }
    }
}