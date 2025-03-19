using R3;
using UnityEngine;

namespace GameLogic.MainMenu
{
    public class MainMenuUIRoot : MonoBehaviour
    {
        Subject<Unit> _exitSceneSignalSubject;
        public void HandleGoToGameplayButtonClick()
        {
            _exitSceneSignalSubject.OnNext(Unit.Default);
        }
        public void Bind(Subject<Unit> exitSceneSignalSubject)
        {
            _exitSceneSignalSubject = exitSceneSignalSubject;
        }
    }
}