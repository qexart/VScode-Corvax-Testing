using Content.Server.Maps;
using Content.Shared.Whitelist;
using Robust.Shared.Map;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;

namespace Content.Server._FNStation.StationCentcomm;

[RegisterComponent]
public sealed partial class StationCentCommFNSComponent : Component
{
    [DataField(customTypeSerializer:typeof(PrototypeIdSerializer<GameMapPrototype>), required: true)]
    public string Station = default!;

    [DataField]
    public EntityUid Entity = EntityUid.Invalid;

    [DataField]
    public EntityWhitelist? ShuttleWhitelist;

    public MapId MapId = MapId.Nullspace;
}
