using System.Collections.Generic;
using GameLogic.Gameplay.Commands;
using GameLogic.Gameplay.Entities;
using GameLogic.Gameplay.State;
using GameLogic.State.Command;
using ObservableCollections;
using R3;

namespace GameLogic.Gameplay.Services
{
    public class InteractionService
    {
        readonly ICommandProcessor _cmd;
        readonly ObservableList<InteractableViewModel> _allInteractables = new();
        readonly Dictionary<int, InteractableViewModel> _interactableMap = new();
        public IObservableCollection<InteractableViewModel> AllInteractables => _allInteractables;

        public InteractionService(ObservableList<InteractableState> interactables, PlayerController controller,
            ICommandProcessor cmd)
        {
            _cmd = cmd;
            foreach (var interactable in interactables)
            {
                CreateInteractableViewModel(interactable);
            }
            interactables.ObserveAdd().Subscribe(e =>
            {
                CreateInteractableViewModel(e.Value);
            });
            interactables.ObserveRemove().Subscribe(e =>
            {
                RemoveInteractableViewModel(e.Value);
            });
        }
        void CreateInteractableViewModel(InteractableState interactableState)
        {
            var interacctableViewModel = new InteractableViewModel(interactableState, this);
            _interactableMap[interactableState.Id] = interacctableViewModel;
            _allInteractables.Add(interacctableViewModel);
        }
        void RemoveInteractableViewModel(InteractableState interactableState)
        {
            if (_interactableMap.TryGetValue(interactableState.Id, out var interactableViewModel))
            {
                _interactableMap.Remove(interactableState.Id);
                _allInteractables.Remove(interactableViewModel);
            }
        }
        public bool Interact(int interactableId, EInteractableType interactableType)
        {
            return _cmd.Process(new CmdInteract(interactableId, interactableType));
        }
        // public bool PlaceInteractable(string interactableTypeId, Vector3 position, bool isInteractable = true)
        // {
        //     return _cmd.Process(new CmdPlaceInteractable(interactableTypeId, position, isInteractable));
        // }
        // public bool RemoveInteractable(int Id)
        // {
        //     return _cmd.Process(new CmdRemoveInteractable(Id));
        // }
    }
}