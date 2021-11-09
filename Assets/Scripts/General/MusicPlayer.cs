using System;
using UnityEngine;
using UnityEngine.Audio;

namespace GameJam
{
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField]
        private AudioMixer audioMixer;
        
        [SerializeField]
        private AudioSource audioSource;

        private void Start()
        {
            this.audioSource.Play();
        }

        public void Stop()
        {
            this.audioSource.Stop();
        }

        private void Update()
        {
            if (!this.audioSource.isPlaying)
            {
                this.audioSource.Play();
            }
        }
    }
}
