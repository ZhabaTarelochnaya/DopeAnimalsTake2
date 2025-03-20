using GameLogic.Gameplay.Entities;
using ObservableCollections;
using R3;
using System.Linq;
using GameLogic.Gameplay.State;

namespace GameLogic.State
{
    public class GameState
    {
        readonly GameData _gameData;
        public GameState(GameData gameData)
        {
            _gameData = gameData;
        }
        public int CreateEntityId() => _gameData.CreateEntityId();
    }
}