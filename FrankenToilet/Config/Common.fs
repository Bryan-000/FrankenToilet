namespace FrankenToilet.Config

open PluginConfig.API
open PluginConfig.API.Decorators
open PluginConfig.API.Fields
open System

[<AutoOpen>]
module internal Common =
    type Header = ConfigHeader
    type Panel = ConfigPanel
    
    type Dropdown<'T when 'T : (new : unit -> 'T) and 'T : struct and 'T :> ValueType> = EnumField<'T>
    type FloatSlider = FloatSliderField
    type Float = FloatField
    type Bool = BoolField
    type Int = IntField