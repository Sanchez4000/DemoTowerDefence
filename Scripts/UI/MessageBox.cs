using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Assets.Scripts.UI
{
    public class MessageBox : MonoBehaviour
    {
        private enum MessageState
        {
            Showed,
            Visible,
            Hided
        }

        public static MessageBox Instance { get; private set; }

        [SerializeField] private TextMeshProUGUI _textField;
        [SerializeField] private Color _defaulTextColor;
        [SerializeField] [Range(0, 5f)] private float _showTime = 0.01f;
        [SerializeField] [Range(0, 5f)] private float _hideTime = 0.01f;

        private bool _isActive = false;
        private MessageState _state = MessageState.Visible;
        private float _messageTime = 0;
        private float _timer = 0;

        private void Start()
        {
            Instance = this;
            _textField.text = "";
        }
        private void Update()
        {
            if (_isActive)
            {
                switch (_state)
                {
                    case MessageState.Showed:
                        {
                            if ((_timer -= Time.unscaledDeltaTime) < 0)
                            {
                                _timer = 0;
                            }

                            Color currentColor = _textField.color;
                            currentColor.a = 1 - _timer / _showTime;
                            _textField.color = currentColor;

                            if (_timer == 0)
                            {
                                _state = MessageState.Visible;
                                _timer = _messageTime;
                            }
                            break;
                        }
                    case MessageState.Visible:
                        {
                            _timer -= Time.unscaledDeltaTime;

                            if (_timer < 0)
                            {
                                _state = MessageState.Hided;
                                _timer = _hideTime;
                            }
                            break;
                        }
                    case MessageState.Hided:
                        {
                            if ((_timer -= Time.unscaledDeltaTime) < 0)
                            {
                                _timer = 0;
                            }

                            Color currentColor = _textField.color;
                            currentColor.a = _timer / _showTime;
                            _textField.color = currentColor;

                            if (_timer == 0)
                            {
                                _isActive = false;
                            }
                            break;
                        }
                    default:
                        throw new System.Exception($"Unknown state value in {name}");
                }
            }
        }

        public void ShowMessage(string message, float time = 5f)
        {
            ShowMessage(message, _defaulTextColor, time);
        }
        public void ShowMessage(string message, Color color, float time = 5f)
        {
            _isActive = true;
            _state = MessageState.Showed;
            _textField.text = message;
            _textField.color = color;
            _messageTime = time;
            _timer = _showTime;
        }
    }
}