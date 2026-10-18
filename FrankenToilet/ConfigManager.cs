namespace FrankenToilet;

using PluginConfig.API;
using FrankenToilet.Config;

public static class ConfigManager
{
    public static PluginConfigurator? config;

    public static AlmaPanel Alma;
    public static BananaStudioPanel BananaStudio;
    public static BlaixenUPanel BlaixenU;
    public static BobTheCornPanel BobTheCorn;
    public static BryanPanel Bryan;
    public static DolfeLivePanel DolfeLive;
    public static DoomahRealPanel Doomah;
    public static DuvizPanel Duviz;
    public static EarthlingPanel Earthling;
    public static FlazhikPanel Flazhik;
    public static GreycsontPanel Greycsont;
    public static LakeullPanel Lakeull;
    public static PlonkPanel Plonk;

    public static void Initialize()
    {
        if (config != null)
            return;

        config = PluginConfigurator.Create(MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_GUID);

                Alma = new(config.rootPanel);
        BananaStudio = new(config.rootPanel);
            BlaixenU = new(config.rootPanel);
          BobTheCorn = new(config.rootPanel);
               Bryan = new(config.rootPanel);
           DolfeLive = new(config.rootPanel);
              Doomah = new(config.rootPanel);
               Duviz = new(config.rootPanel);
           Earthling = new(config.rootPanel);
             Flazhik = new(config.rootPanel);
           Greycsont = new(config.rootPanel);
             Lakeull = new(config.rootPanel);
               Plonk = new(config.rootPanel);
    }
}