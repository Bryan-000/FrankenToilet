namespace FrankenToilet;

using System;
using PluginConfig.API;
using PluginConfig.API.Decorators;
using PluginConfig.API.Fields;

public static partial class ConfigManager
{
    public static PluginConfigurator config;

    public static AlmaPanel alma;
    public static BananaStudioPanel Bananastudio;
    public static BlaixenUPanel BlaixenU;
    public static BobTheCornPanel bobthecorn;
    public static BryanPanel Bryan;
    public static PlonkPanel Plonk;

    public static void Initialize()
    {
        if (config != null)
            return;

        config = PluginConfigurator.Create(MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_GUID);

        alma = new(config.rootPanel);
        Bananastudio = new(config.rootPanel);
        BlaixenU = new(config.rootPanel);
        bobthecorn = new(config.rootPanel);
        Bryan = new(config.rootPanel);
        Plonk = new(config.rootPanel);

        /*
        ConfigPanel CorePanel = new ConfigPanel(config.rootPanel, "Core", "Core_panel");
        ConfigPanel dolfelivePanel = new ConfigPanel(config.rootPanel, "dolfelive", "dolfelive_panel");
        ConfigPanel doomahrealPanel = new ConfigPanel(config.rootPanel, "doomahreal", "doomahreal_panel");
        ConfigPanel duvizPanel = new ConfigPanel(config.rootPanel, "duviz", "duviz_panel");
        ConfigPanel earthlingPanel = new ConfigPanel(config.rootPanel, "earthling", "earthling_panel");
        ConfigPanel flazhikPanel = new ConfigPanel(config.rootPanel, "flazhik", "flazhik_panel");
        ConfigPanel greycsontPanel = new ConfigPanel(config.rootPanel, "greycsont", "greycsont_panel");
        ConfigPanel lakeullPanel = new ConfigPanel(config.rootPanel, "lakeull", "lakeull_panel");
        ConfigPanel mercyPanel = new ConfigPanel(config.rootPanel, "mercy", "mercy_panel");
        ConfigPanel prideuniquePanel = new ConfigPanel(config.rootPanel, "prideunique", "prideunique_panel");
        ConfigPanel somebillyPanel = new ConfigPanel(config.rootPanel, "somebilly", "somebilly_panel");
        ConfigPanel triggeredidiotPanel = new ConfigPanel(config.rootPanel, "triggeredidiot", "triggeredidiot_panel");
        */
    }
}