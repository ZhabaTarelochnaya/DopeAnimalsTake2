using System;
using System.Collections.Generic;
using GameLogic.Gameplay.Entities;
using GameLogic.Gameplay.State;

namespace GameLogic.State
{
    [Serializable]
    public class GameData
    {
        public List<InteractableData> Interactables = new();
        public int GlobalEntityId;
        public int CreateEntityId() => GlobalEntityId++;
    }
}