using Content.Shared.Hands;
using Content.Shared.Interaction.Components;
using Content.Shared.Interaction.Events;
using Content.Shared.Inventory.Events;

namespace Content.Server.Interaction;

public sealed class DeleteOnDropSystem : EntitySystem
{
    [Dependency] private readonly IEntityManager _entityManager = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<DeleteOnDropComponent, GotUnequippedEvent>(OnUnequip);
        SubscribeLocalEvent<DeleteOnDropComponent, GotUnequippedHandEvent>(OnUnequipHand);
        SubscribeLocalEvent<DeleteOnDropComponent, DroppedEvent>(OnDropped);
    }

    private void OnUnequip(EntityUid uid, DeleteOnDropComponent item, GotUnequippedEvent args)
    {
        if (!item.DeleteOnDrop || !_entityManager.EntityExists(uid))
            return;

        _entityManager.DeleteEntity(uid);
    }

    private void OnUnequipHand(EntityUid uid, DeleteOnDropComponent item, GotUnequippedHandEvent args)
    {
        if (!item.DeleteOnDrop || !_entityManager.EntityExists(uid))
            return;

        _entityManager.DeleteEntity(uid);
    }

    private void OnDropped(EntityUid uid, DeleteOnDropComponent item, DroppedEvent args)
    {
        if (!item.DeleteOnDrop || !_entityManager.EntityExists(uid))
            return;

        _entityManager.DeleteEntity(uid);
    }
}

