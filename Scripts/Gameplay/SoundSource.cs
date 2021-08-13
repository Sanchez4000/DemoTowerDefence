using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class SoundSource : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        public AudioClip Sound { get; set; }

        private void Start()
        {
            _audioSource.clip = Sound;
            _audioSource.Play();
        }

        private void Update()
        {
            if (!_audioSource.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }
}