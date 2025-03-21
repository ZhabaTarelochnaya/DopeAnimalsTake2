using GameLogic.Gameplay.Entities;
using GameLogic.Gameplay.Services;
using GameLogic.Gameplay.State;
using GameLogic.State;
using ObservableCollections;

namespace GameLogic.Gameplay.Root
{
    public class GameplayRootViewModel
    {
        public readonly IObservableCollection<InteractableViewModel> AllInteractables;
        public GameplayRootViewModel(GameplayState gameplayState, InteractionService interactionService)
        {
            AllInteractables = interactionService.AllInteractables;
        }
    }
}