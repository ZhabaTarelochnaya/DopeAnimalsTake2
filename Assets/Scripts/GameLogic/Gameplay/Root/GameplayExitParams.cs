using DopeAnimals.GameLogic.MainMenu.Params;

namespace GameLogic.Gameplay.Root
{
    public class GameplayExitParams
    {
        public GameplayExitParams(MainMenuEnterParams mainMenuEntryParams)
        {
            MainMenuEnterParams = mainMenuEntryParams;
        }
        public MainMenuEnterParams MainMenuEnterParams { get; }
    }
}