using System;
using GameLogic.Gameplay.State;
using R3;

namespace GameLogic.Gameplay.Entities
{
    public interface IInteractable
    {
        string Name { get; }
        void Bind(Subject<InteractableState> interactedWithSignal);
        void Interact();
    }
}