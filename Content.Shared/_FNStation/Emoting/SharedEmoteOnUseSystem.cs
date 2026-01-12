using Content.Shared.Actions;
using Content.Shared.Hands.EntitySystems;
using Content.Shared.Interaction;
using Content.Shared.Interaction.Events;
using Content.Shared.Chat.Prototypes;
using Content.Shared.Emoting;
using Content.Shared.Popups;
using Content.Shared.Speech;
using Content.Shared._FNStation.Emoting.Components;
using Robust.Shared.Containers;
using Robust.Shared.Network;
using Robust.Shared.Timing;
using Robust.Shared.Random;

namespace Content.Shared._FNStation.Emoting;

public abstract class SharedEmoteOnUseSystem : EntitySystem
{
    [Dependency] private readonly SharedHandsSystem _hands = default!;
    [Dependency] private readonly INetManager _net = default!;
    [Dependency] private readonly SharedPopupSystem _popup = default!;
    [Dependency] private readonly IGameTiming _timing = default!;
    [Dependency] private readonly SharedTransformSystem _transform = default!;
    [Dependency] private readonly SharedUserInterfaceSystem _ui = default!;


    public override void Initialize()
    {
        SubscribeLocalEvent<BaseMessageOnUseComponent, UseInHandEvent>(OnMessageOnUseInHand);
    }
//        var user = args.Uid;
//        {
//            _popup.PopupEntity(component, user, user, PopupType.MediumCaution);
//            return;
//        }
    private void OnMessageOnUseInHand(EntityUid uid, BaseMessageOnUseComponent component, UseInHandEvent args)
    {
        // Intentionally not checking whether the interaction has already been handled.
        TryMessage(uid, component, args.User);

        if (component.Handle)
            args.Handled = true;
    }
    protected void TryMessage(EntityUid uid, BaseMessageOnUseComponent component, EntityUid? user=null)
    {
        if (component.ChatMessages == null)
            return;

        if (component.ChatTriggers == null)
            return;

        // check if proto has valid message for chat
        if (component.Message)
        {
            {
                _popup.PopupEntity($"Message", uid, PopupType.MediumCaution);
                return;
            }
        }
    }
}
