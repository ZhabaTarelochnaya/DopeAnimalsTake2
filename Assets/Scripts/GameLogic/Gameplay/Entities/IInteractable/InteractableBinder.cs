using GameLogic.Gameplay.State;
using R3;
using UnityEngine;

namespace GameLogic.Gameplay.Entities
{
    public class InteractableBinder : MonoBehaviour
    {
        InteractableViewModel _viewModel;
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public EInteractableType Type { get; private set; }
        public int Id => _viewModel.Id;
        public bool IsInteractable => _viewModel.IsInteractable.CurrentValue;
        public void Interact()
        {
            _viewModel.Interaction.OnNext(Type);
        }
        public void Bind(InteractableViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.Interaction.Subscribe(_ => 
            {
                //TODO - Play some animation here.
            });
        }
    }
}