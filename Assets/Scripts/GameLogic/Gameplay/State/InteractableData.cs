using System;

namespace GameLogic.Gameplay.State
{
    [Serializable]
    public class InteractableData
    {
        public bool IsInteractable;
        public string Name;
        public EInteractableType Type;
        public int Id;
    }
}