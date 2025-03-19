using GameLogic.Root;
using GameLogic.Utils;

namespace GameLogic.Gameplay.Root
{
    public class GameplayEnterParams : ISceneParams
    {
        public GameplayEnterParams(int levelId)
        {
            LevelId = levelId;
        }
        public int LevelId { get; }
        public string SceneName => SceneNames.Gameplay;
    }
}