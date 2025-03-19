using GameLogic.State;
using R3;

namespace GameLogic.Gameplay.Entities
{
    public class InteractableState : IEntityState
    {
        public int Id { get; }
        public string InteractableTypeId { get; }
        public InteractableData Origin { get; }
        public ReactiveProperty<bool> IsInteractable { get; }

        public InteractableState(InteractableData interactableData)
        {
            Origin = interactableData;
            Id = interactableData.Id;
            IsInteractable = new ReactiveProperty<bool>(interactableData.IsInteractable);

            IsInteractable.Skip(1).Subscribe(e => interactableData.IsInteractable = e);
        }
    }
}