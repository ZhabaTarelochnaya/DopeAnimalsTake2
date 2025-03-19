using System.Collections;
using BaCon;
using DopeAnimals.GameLogic.MainMenu.Params;
using GameLogic.Gameplay.Root;
using GameLogic.MainMenu.Root;
using GameLogic.Utils;
using R3;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameLogic.Root
{
    public class GameEntryPoint
    {
        static GameEntryPoint _instance;
        readonly DIContainer _rootContainer = new();
        DIContainer _cachedSceneContainer;
        Coroutines _coroutines;
        readonly UIRoot _uiRoot;
        GameEntryPoint()
        {
            _coroutines = new GameObject("[COROUTINES]").AddComponent<Coroutines>();
            Object.DontDestroyOnLoad(_coroutines.gameObject);

            var prefabUIRoot = Resources.Load<UIRoot>("Prefabs/UIRoot");
            _uiRoot = Object.Instantiate(prefabUIRoot);
            Object.DontDestroyOnLoad(_uiRoot.gameObject);
            _rootContainer.RegisterInstance(_uiRoot);
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void AutostartGame()
        {
            _instance = new GameEntryPoint();
            _instance.RunGame();
        }
        public void RunGame()
        {
            
#if UNITY_EDITOR
            string sceneName = SceneManager.GetActiveScene().name;
            if (sceneName == SceneNames.Gameplay)
            {
                var enterParams = new GameplayEnterParams(0);
                _coroutines.StartCoroutine(LoadAndStartGameplay(enterParams));
                return;
            }

            if (sceneName == SceneNames.MainMenu)
            {
                _coroutines.StartCoroutine(LoadAndStartMainMenu());
                return;
            }

            if (sceneName != SceneNames.Boot)
            {
                return;
            }
#endif
            _coroutines.StartCoroutine(LoadAndStartMainMenu());
        }

        IEnumerator LoadAndStartMainMenu(MainMenuEnterParams enterParams = null)
        {
            yield return LoadScene(SceneNames.Boot);
            yield return LoadScene(SceneNames.MainMenu);
            yield return null;
            var sceneEntryPoint = Object.FindFirstObjectByType<MainMenuEntryPoint>();
            sceneEntryPoint.Run(_uiRoot, enterParams).Subscribe(mainMenuExitParams =>
            {
                var targetSceneName = mainMenuExitParams.TargetSceneEnterParams.SceneName;
                if (targetSceneName == SceneNames.Gameplay)
                {
                    _coroutines.StartCoroutine(LoadAndStartGameplay(
                        (GameplayEnterParams)mainMenuExitParams.TargetSceneEnterParams));
                }
            });
        }

        IEnumerator LoadAndStartGameplay(GameplayEnterParams enterParams)
        {
            _uiRoot.ShowLoagingScreen();
            _cachedSceneContainer?.Dispose();

            yield return LoadScene(SceneNames.Boot);
            yield return LoadScene(SceneNames.Gameplay);
            yield return null;
            
            var gameplayEntryPoint = Object.FindFirstObjectByType<GameplayEntryPoint>();
            DIContainer gameplayContainer = _cachedSceneContainer = new DIContainer(_rootContainer);
            gameplayEntryPoint.Run(gameplayContainer, enterParams).Subscribe(gameplayExitParams =>
            {
                _coroutines.StartCoroutine(LoadAndStartMainMenu(gameplayExitParams.MainMenuEnterParams));
            });

            _uiRoot.HideLoadingScreen();
        }
        IEnumerator LoadScene(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
        }
    }
}