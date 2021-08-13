using System;
using UnityEngine;
using Assets.Scripts.UI;

namespace Assets.Scripts.Gameplay
{
    public enum DayState
    {
        Day,
        Night
    }

    public class TimeOfDay : MonoBehaviour
    {
        public static TimeOfDay Instance { get; private set; }

        [SerializeField] private Light _globalLight;
        [SerializeField] private Color _dayLightColor;
        [SerializeField] private Color _nightLightColor;
        [SerializeField] private float _dayLength;
        [SerializeField] private float _nightLength;

        private float _currentStateTimer = 0f;
        private DayState _dayState = DayState.Night;
        private int _currentDay = 0;

        public event Action OnStateChanged;

        public DayState DayState => _dayState;
        public float DayLength => _dayLength;
        public float NightLength => _nightLength;
        public float CurrentTime => _currentStateTimer;
        public int CurrentDay => _currentDay;

        private void Awake()
        {
            Instance = this;
            _dayState = DayState.Night;
            _currentStateTimer = _nightLength;
            _globalLight.color = _nightLightColor;
        }
        private void Update()
        {
            _currentStateTimer -= Time.deltaTime;
            SetLight();

            if (_currentStateTimer <= 0)
            {
                ChangeState();
            }
        }

        private void ChangeState()
        {
            if (_dayState == DayState.Day)
            {
                _dayState = DayState.Night;
                _currentStateTimer = _nightLength;
                _currentDay++;

                PlayerData.Instance.AddMoney(_currentDay * 100);
                MessageBox.Instance.ShowMessage($"End day reward\n+{_currentDay * 100}$");
            }
            else
            {
                _dayState = DayState.Day;
                _currentStateTimer = _dayLength;
            }
            OnStateChanged?.Invoke();
        }
        private void SetLight()
        {
            float timeLength = 0;
            if (_dayState == DayState.Day)
            {
                timeLength = _dayLength;
            }
            else
            {
                timeLength = _nightLength;
            }
            
            if (_dayState == DayState.Day)
            {
                _globalLight.color = Color.Lerp(_nightLightColor, _dayLightColor, _currentStateTimer / timeLength);
            }
            else
            {
                _globalLight.color = Color.Lerp(_dayLightColor, _nightLightColor, _currentStateTimer / timeLength);
            }
        }
    }
}