using GameLogic.Root;

namespace DopeAnimals.GameLogic.MainMenu.Params
{
    public class MainMenuExitParams
    {
        public ISceneParams TargetSceneEnterParams { get; }
        public MainMenuExitParams(ISceneParams targetSceneEnterParams)
        {
            TargetSceneEnterParams = targetSceneEnterParams;
        }
    }
}
