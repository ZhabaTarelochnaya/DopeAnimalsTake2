using UnityEngine;

namespace GameLogic.Gameplay.Entities.Data
{
    [CreateAssetMenu(fileName = "InteractableData", menuName = "GameLogic/InteractableData")]
    public class InteractableSettings : ScriptableObject
    {
        public string Name;
        public string InteractionType;
    }
}