using GameLogic.Gameplay.Services;
using GameLogic.Gameplay.State;
using GameLogic.State.Command;
using UnityEngine;

namespace GameLogic.Gameplay.Commands
{
    public class CmdInteractHandler : ICommandHandler<CmdInteract>
    {
        public bool Handle(CmdInteract command)
        {
            switch (command.Type)
            {
                case EInteractableType.SingleClick: 
                    return InteractionSingleClick.Interact(command.Id); 
                default: 
                    Debug.LogError($"Unimplemented interaction type: {command.Type}");
                    return false;
            }
        }
    }
}