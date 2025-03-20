using System.Linq;
using ObservableCollections;
using R3;

namespace GameLogic.Gameplay.State
{
    public class GameplayState
    {
        GameplayData _data;
        public ObservableList<InteractableState> Interactables { get; } 
        public GameplayState(GameplayData data)
        {
            _data = data;
            Interactables = new ObservableList<InteractableState>();
            data.Interactables.ForEach(i => Interactables.Add(new InteractableState(i)));
            Interactables.ObserveAdd().Subscribe(e =>
            {
                var addedInteractable = e.Value;
                data.Interactables.Add(addedInteractable.Origin);
            });
            Interactables.ObserveRemove().Subscribe(e =>
            {
                var removedInteractable = e.Value;
                var removedLevelState = data.Interactables.FirstOrDefault(b => b.Id == removedInteractable.Id);
                data.Interactables.Remove(removedLevelState);
            });
        }
    }
}