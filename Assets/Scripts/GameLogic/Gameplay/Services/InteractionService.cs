using BaCon;
using GameLogic.State.Command;

namespace GameLogic.Gameplay.Root
{
    public class InteractionService
    {
        DIContainer _container;
        ICommandProcessor _cmd;
        public InteractionService(DIContainer container, ICommandProcessor cmd)
        {
            _container = container;   
            _cmd = cmd;
        }
        
    }
}