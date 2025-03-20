using GameLogic.State;
using R3;

namespace GameLogic.Gameplay.State
{
    public class InteractableState : IEntityState
    {
        public readonly InteractableData Origin;
        public string Name => Origin.Name;
        public int Id => Origin.Id;
        public EInteractableType Type => Origin.Type;
        public ReactiveProperty<bool> IsInteractable { get; }
        public InteractableState(InteractableData data)
        {
            Origin = data;
            IsInteractable.Subscribe(b => Origin.IsInteractable = b);
        }
    }
}