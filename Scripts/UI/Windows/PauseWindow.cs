using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI.Windows
{
    public class PauseWindow : Window
    {
        private void OnEnable()
        {
            Time.timeScale = 0;
        }
        private void OnDisable()
        {
            Time.timeScale = 1;
        }
    }
}