using UnityEngine;
using UnityEngine.Audio;

namespace Menu
{
    public class DefaultScreenScene : MonoBehaviour
    {
        [SerializeField]
        private AudioMixer audioMixer;

        [SerializeField]
        private float gameVolumeWhileActive = 0;

        private void OnEnable()
        {
            this.audioMixer.SetFloat("GameVolume", this.gameVolumeWhileActive);
        }

        private void OnDisable()
        {
            this.audioMixer.SetFloat("GameVolume", 0f);
        }
    }
}