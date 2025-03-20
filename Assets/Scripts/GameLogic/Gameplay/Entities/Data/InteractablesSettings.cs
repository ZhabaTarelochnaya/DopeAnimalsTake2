using System.Collections.Generic;
using GameLogic.Gameplay.State;
using UnityEngine;

namespace GameLogic.Gameplay.Entities.Data
{
    [CreateAssetMenu(fileName = "InteractableSettings", menuName = "GameLogic/InteractableSettings")]
    public class InteractablesSettings : ScriptableObject
    {
        public List<InteractableSettings> AllInteractables;
    }
}