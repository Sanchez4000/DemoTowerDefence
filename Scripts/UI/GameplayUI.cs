using UnityEngine;
using Assets.Scripts.UI.Windows;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    public class GameplayUI : MonoBehaviour
    {
        public static GameplayUI Instance { get; private set; }

        [SerializeField] private List<Window> _allWindows;

        public bool AnyWindowIsOpened
        {
            get
            {
                foreach (var item in _allWindows)
                {
                    if (item.IsOpened)
                        return true;
                }

                return false;
            }
        }

        private void Start()
        {
            Instance = this;
        }

        public T GetWindow<T>() where T : Window
        {
            foreach (var item in _allWindows)
            {
                if (item is T)
                {
                    return (T)item;
                }
            }

            return null;
        }

        public void BackToMainMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void DebugApplicationQuit()
        {
            Application.Quit();
        }
    }
}