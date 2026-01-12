using Content.Shared.Chat;
using Content.Shared.Chat.Prototypes;
using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;

namespace Content.Shared._FNStation.Emoting.Components;

/// <summary>
///     This component is currently used for providing access to channels for "HeadsetComponent"s.
///     It should be used for intercoms and other radios in future.
/// </summary>
public sealed partial class BaseMessageOnUseComponent : Component
{
    [DataField]
    public HashSet<ProtoId<EmotePrototype>> ChatTriggers = new();

    /// <summary>
    ///     This is the channel that will be used when using the default/department prefix (<see cref="SharedChatSystem.DefaultChannelKey"/>).
    /// </summary>
    [DataField]
    public List<EmotePrototype>? ChatMessages;

    [DataField]
    public bool Handle = true;

    [DataField, AutoNetworkedField]
    public bool Positional;

    [DataField, AutoNetworkedField]
    public bool Message;
}
