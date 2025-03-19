using GameLogic.Gameplay.Entities;
using ObservableCollections;
using R3;
using System.Linq;

namespace GameLogic.State
{
    public class GameState
    {
        readonly GameData _gameData;
        public ObservableList<InteractableState> Interactables { get; } 
        public GameState(GameData gameData)
        {
            _gameData = gameData;
            Interactables = new ObservableList<InteractableState>();
            gameData.Interactables.ForEach(i => Interactables.Add(new InteractableState(i)));
            Interactables.ObserveAdd().Subscribe(e =>
            {
                var addedLevel = e.Value;
                gameData.Interactables.Add(addedLevel.Origin);
            });
            Interactables.ObserveRemove().Subscribe(e =>
            {
                var removedLevel = e.Value;
                var removedLevelState = gameData.Interactables.FirstOrDefault(b => b.Id == removedLevel.Id);
                gameData.Interactables.Remove(removedLevelState);
            });
        }
        public int CreateEntityId() => _gameData.CreateEntityId();
    }
}