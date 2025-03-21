using System.Collections.Generic;
using System.Linq;
using BaCon;
using DopeAnimals.GameLogic.MainMenu.Params;
using GameLogic.Gameplay.Entities;
using GameLogic.Gameplay.State;
using GameLogic.Root;
using GameLogic.State;
using R3;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameLogic.Gameplay.Root
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [FormerlySerializedAs("_gameplayUIRootPrefab")] [SerializeField] GameplayUIRootBinder gameplayUIRootBinderPrefab;
        [SerializeField] GameplayRootBinder _gameplayRootBinder;
        [SerializeField] PlayerController _playerPrefab;
        [SerializeField] Transform _playerSpawnPoint;
        [SerializeField] GameObject _interactablesParent;
        CompositeDisposable _disposables;
        public Observable<GameplayExitParams> Run(DIContainer gameplayContainer, GameplayEnterParams enterParams)
        {
            GameplayRegistrations.Register(gameplayContainer, enterParams);
            
            var gameState = gameplayContainer.Resolve<GameState>();
            var gameplayState = gameplayContainer.Resolve<GameplayState>();
            foreach (var interactable in _interactablesParent.GetComponentsInChildren<InteractableBinder>())
            {
                var interactableData = new InteractableData()
                {
                    Type = interactable.Type,
                    Name = interactable.Name,
                    Id = gameState.CreateEntityId()
                };
                var interactableState = new InteractableState(interactableData); 
                gameplayState.Interactables.Add(interactableState);
            }
            var gameplayViewModelContainer = new DIContainer(gameplayContainer);
            
            GameplayViewModelRegistrations.Register(gameplayViewModelContainer);
            
            
            var camera = GameObject.FindGameObjectWithTag("CinemachineCamera");
            var cameraComponent = camera.GetComponent<CinemachineCamera>();
            _playerPrefab.Cam = cameraComponent;
            var player = Instantiate(_playerPrefab);
            player.Cam = cameraComponent;
            player.transform.position = _playerSpawnPoint.position;
            gameplayContainer.RegisterInstance(player);
            
            _gameplayRootBinder.Bind(gameplayViewModelContainer.Resolve<GameplayRootViewModel>());
            
            
            var uiRoot = gameplayContainer.Resolve<UIRoot>();
            var uiScene = Instantiate(gameplayUIRootBinderPrefab);
            uiRoot.AttachSceneUI(uiScene.gameObject);
            
            var exitSceneSignalSubj = new Subject<Unit>();
            var mainMenuEnterParams = new MainMenuEnterParams();
            var exitParams = new GameplayExitParams(mainMenuEnterParams);
            Observable<GameplayExitParams> exitToMainMenuSceneSignal = exitSceneSignalSubj.Select(_ => exitParams);

            return exitToMainMenuSceneSignal;
        }
    }
}