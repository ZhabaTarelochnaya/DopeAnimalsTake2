using GameLogic.Gameplay.Entities;
using GameLogic.Gameplay.State;
using UnityEngine;
using R3;
using ObservableCollections;
namespace GameLogic.Gameplay.Root
{
    public class GameplayRootBinder : MonoBehaviour
    {
        [SerializeField] InteractableBinder _interactablePrefab;
        
        public void Bind(GameplayRootViewModel viewModel)
        {
            
        }
    }
}