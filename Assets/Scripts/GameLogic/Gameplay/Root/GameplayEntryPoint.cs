using System.IO;
using BaCon;
using DopeAnimals.GameLogic.MainMenu.Params;
using GameLogic.Root;
using R3;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameLogic.Gameplay.Root
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] GameplayUIRoot _gameplayUIRootPrefab;
        [SerializeField] PlayerController _playerPrefab;
        [SerializeField] Transform _playerSpawnPoint;
        public Observable<GameplayExitParams> Run(DIContainer gameplayContainer, GameplayEnterParams enterParams)
        {
            GameplayRegistrations.Register(gameplayContainer, enterParams);
            
            var camera = GameObject.FindGameObjectWithTag("CinemachineCamera");
            var cameraComponent = camera.GetComponent<CinemachineCamera>();
            _playerPrefab.Cam = cameraComponent;
            var player = Instantiate(_playerPrefab);
            player.Cam = cameraComponent;
            player.transform.position = _playerSpawnPoint.position;
            gameplayContainer.RegisterInstance(player);

            var uiRoot = gameplayContainer.Resolve<UIRoot>();
            var uiScene = Instantiate(_gameplayUIRootPrefab);
            uiRoot.AttachSceneUI(uiScene.gameObject);
            
            var exitSceneSignalSubj = new Subject<Unit>();
            var mainMenuEnterParams = new MainMenuEnterParams();
            var exitParams = new GameplayExitParams(mainMenuEnterParams);
            Observable<GameplayExitParams> exitToMainMenuSceneSignal = exitSceneSignalSubj.Select(_ => exitParams);

            return exitToMainMenuSceneSignal;
        }
    }
}