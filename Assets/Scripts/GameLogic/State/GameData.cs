using System;
using System.Collections.Generic;
using GameLogic.Gameplay.Entities;

namespace GameLogic.State
{
    [Serializable]
    public class GameData
    {
        public List<InteractableData> Interactables = new List<InteractableData>();
        public int GlobalEntityId;
        public int CreateEntityId() => GlobalEntityId++;
    }
}