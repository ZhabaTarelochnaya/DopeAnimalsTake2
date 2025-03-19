using System;

namespace GameLogic.Gameplay.Entities
{
    public class InteractableData : IEntity
    {
        public int Id {get; set;}
        public string Type {get; set;}
        public bool IsInteractable {get; set;}
    }
}