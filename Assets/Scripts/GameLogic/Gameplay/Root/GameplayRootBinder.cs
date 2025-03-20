using GameLogic.Gameplay.Entities;
using UnityEngine;
using R3;
using ObservableCollections;
namespace GameLogic.Gameplay.Root
{
    public class GameplayRootBinder : MonoBehaviour
    {
        [SerializeField] InteractableBinder _interactablePrefab;
        [SerializeField] GameObject _interactablesParent;
        public void Bind(GameplayRootViewModel viewModel)
        {
            foreach (var interactable in _interactablesParent.GetComponentsInChildren<InteractableBinder>())
            {
                viewModel.AllInteractables.Add(interactable);
            };
        }
    }
}