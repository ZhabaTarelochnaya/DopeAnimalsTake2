using GameLogic.Gameplay.Services;
using GameLogic.Gameplay.State;
using R3;

namespace GameLogic.Gameplay.Entities
{
    public class InteractableViewModel
    {
        readonly InteractableState _state;
        readonly InteractionService _interactionService;
        public readonly int Id;
        public ReadOnlyReactiveProperty<bool> IsInteractable { get; }
        public Subject<EInteractableType> Interaction { get; } = new();
        public InteractableViewModel(InteractableState state, InteractionService interactionService)
        {
            Id = state.Id;
            _state = state;
            _interactionService = interactionService;
            IsInteractable = state.IsInteractable;
            Interaction.Subscribe(t => 
            {
                interactionService.Interact(Id, t);
            });
        }
    }
}