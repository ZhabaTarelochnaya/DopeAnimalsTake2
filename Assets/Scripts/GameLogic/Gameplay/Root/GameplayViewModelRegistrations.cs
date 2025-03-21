using BaCon;
using GameLogic.Gameplay.Entities;
using GameLogic.Gameplay.Services;
using GameLogic.Gameplay.State;
using GameLogic.State;
using GameLogic.State.Command;

namespace GameLogic.Gameplay.Root
{
    public class GameplayViewModelRegistrations
    {
        public static void Register(DIContainer container)
        {
            var gameplayState = container.Resolve<GameplayState>();
            var interactionService = container.Resolve<InteractionService>();
            var gameplayViewModel = new GameplayRootViewModel(gameplayState, interactionService);
            container.RegisterInstance(gameplayViewModel);
        }
    }
}