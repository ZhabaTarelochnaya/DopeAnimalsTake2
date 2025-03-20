using GameLogic.Gameplay.Entities;
using GameLogic.Gameplay.Services;
using ObservableCollections;
using R3;
namespace GameLogic.Gameplay.Root
{
    public class GameplayRootViewModel
    {
        public readonly ObservableList<InteractableViewModel> AllInteractables;
        public GameplayRootViewModel(InteractionService interactionService)
        {
            AllInteractables = interactionService.AllInteractables;
        }
    }
}