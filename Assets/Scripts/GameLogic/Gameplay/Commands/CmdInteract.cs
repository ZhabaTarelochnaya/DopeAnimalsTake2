using GameLogic.Gameplay.State;
using GameLogic.State.Command;

namespace GameLogic.Gameplay.Commands
{
    public class CmdInteract : ICommand
    {
        public int Id { get; }
        public EInteractableType Type { get; }
        public CmdInteract(int id, EInteractableType type)
        {
            Id = id;
            Type = type;
        }
    }
}