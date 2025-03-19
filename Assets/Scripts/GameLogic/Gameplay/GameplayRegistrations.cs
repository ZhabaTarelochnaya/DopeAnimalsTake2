using System;
using BaCon;
using GameLogic.Gameplay.Root;
using GameLogic.State.Command;

namespace GameLogic.Gameplay
{
    public static class GameplayRegistrations
    {
        public static void Register(DIContainer container, GameplayEnterParams enterParams)
        {
            var cmd = new CommandProcessor();
            container.RegisterInstance<ICommandProcessor>(cmd);
        }
    }
}