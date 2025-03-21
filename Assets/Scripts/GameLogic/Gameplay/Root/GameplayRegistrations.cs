using System;
using BaCon;
using GameLogic.Gameplay.Root;
using GameLogic.Gameplay.Services;
using GameLogic.Gameplay.State;
using GameLogic.State.Command;

namespace GameLogic.Gameplay
{
    public static class GameplayRegistrations
    {
        public static void Register(DIContainer container, GameplayEnterParams enterParams)
        {
            var cmd = new CommandProcessor();
            container.RegisterInstance<ICommandProcessor>(cmd);

            var player = container.Resolve<PlayerController>();
            var gameplayState = container.Resolve<GameplayState>();
            
            
            
            var interactionService = new InteractionService(gameplayState.Interactables, player, cmd);
            container.RegisterInstance(interactionService);
        }
    }
}