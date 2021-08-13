using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Gameplay;

namespace Assets.Scripts.UI
{
    public class TimeBar : MonoBehaviour
    {
        [SerializeField] private Image _backgroundBar;
        [SerializeField] private Image _foregroundBar;
        [SerializeField] private Color _dayColor;
        [SerializeField] private Color _nightColor;

        private TimeOfDay _timeOfDayChanger;
        private DayState _dayStateLastFrame;

        private void Start()
        {
            _timeOfDayChanger = TimeOfDay.Instance;
            _dayStateLastFrame = _timeOfDayChanger.DayState;
            SetBarColors(_dayStateLastFrame);
        }
        private void Update()
        {
            float timeLength = 0f;

            if (_timeOfDayChanger.DayState == DayState.Day)
            {
                timeLength = _timeOfDayChanger.DayLength;
            }
            else
            {
                timeLength = _timeOfDayChanger.NightLength;
            }

            Vector3 newScale = new Vector3(_timeOfDayChanger.CurrentTime / timeLength, 1, 1);
            _foregroundBar.rectTransform.localScale = newScale;

            DayState dayStateCurrentFrame = _timeOfDayChanger.DayState;

            if (dayStateCurrentFrame != _dayStateLastFrame)
            {
                SetBarColors(dayStateCurrentFrame);
            }

            _dayStateLastFrame = dayStateCurrentFrame;
        }

        private void SetBarColors(DayState state)
        {
            if (state == DayState.Day)
            {
                _foregroundBar.color = _dayColor;
                _backgroundBar.color = _nightColor;
            }
            else
            {
                _foregroundBar.color = _nightColor;
                _backgroundBar.color = _dayColor;
            }
        }
    }
}