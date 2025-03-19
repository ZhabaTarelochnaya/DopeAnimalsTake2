using DopeAnimals.GameLogic.MainMenu.Params;
using GameLogic.Gameplay.Root;
using GameLogic.Root;
using R3;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameLogic.MainMenu.Root
{
    public class MainMenuEntryPoint : MonoBehaviour
    {
        [FormerlySerializedAs("_sceneUIRootPrefab")] [SerializeField] MainMenuUIRoot sceneMainMenuUIRootPrefab;
        public Observable<MainMenuExitParams> Run(UIRoot uiRoot, MainMenuEnterParams enterParams)
        {
            MainMenuUIRoot mainMenuUIScene = Instantiate(sceneMainMenuUIRootPrefab);
            uiRoot.AttachSceneUI(mainMenuUIScene.gameObject);

            var exitSignalSubject = new Subject<Unit>();
            mainMenuUIScene.Bind(exitSignalSubject);

            var gameplayEnterParams = new GameplayEnterParams(0);
            var mainMenuExitParams = new MainMenuExitParams(gameplayEnterParams);
            var exitToGameplaySignal = exitSignalSubject.Select(_ => mainMenuExitParams);

            return exitToGameplaySignal;
        }
    }
}