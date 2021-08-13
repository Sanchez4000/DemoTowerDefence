using System;
using UnityEngine;

namespace Assets.Scripts.UI.Windows
{
    public abstract class Window : MonoBehaviour
    {
        protected event Action OnOpen;
        protected event Action OnClose;

        public bool IsOpened => gameObject.activeSelf;

        public void Open()
        {
            if (GameplayUI.Instance.AnyWindowIsOpened)
                return;            

            gameObject.SetActive(true);
            OnOpen?.Invoke();
        }
        public void Close()
        {
            gameObject.SetActive(false);
            OnClose?.Invoke();
        }
    }
}