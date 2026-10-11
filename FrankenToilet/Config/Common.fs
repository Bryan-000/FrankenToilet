namespace FrankenToilet.Config

open PluginConfig.API
open PluginConfig.API.Decorators
open PluginConfig.API.Fields

[<AutoOpen>]
module internal Common =
    type Header = ConfigHeader
    type Panel = ConfigPanel
    
    type FloatSlider = FloatSliderField
    type Float = FloatField
    type Bool = BoolField
    type Int = IntField