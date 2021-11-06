using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace GameJam
{
    public class ScreenController : MonoBehaviour
    {
        [SerializeField]
        private AudioMixer audioMixer;

        [SerializeField]
        private Image blackCanvas;

        public void FadeInBlack(float duration)
        {
            this.StartCoroutine(this.FadeInBlack_Coroutine(duration));
        }

        public void FadeOutBlack(float delay, float duration, bool audioVolumeToo = false)
        {
            this.StartCoroutine(this.FadeOutBlack_Coroutine(delay, duration, audioVolumeToo));
        }

        private IEnumerator FadeInBlack_Coroutine(float duration)
        {
            this.blackCanvas.gameObject.SetActive(true);

            for (float time = 0; time < duration; time += Time.deltaTime)
            {
                var blackCanvasColor = this.blackCanvas.color;
                blackCanvasColor.a = time / duration;
                this.blackCanvas.color = blackCanvasColor;

                yield return null;
            }

            this.blackCanvas.color = new Color(0, 0, 0, 1);
        }

        private IEnumerator FadeOutBlack_Coroutine(float delay, float duration, bool audioVolumeToo)
        {
            // Black canvas
            this.blackCanvas.gameObject.SetActive(true);
            this.blackCanvas.color = new Color(0, 0, 0, 1);

            // Audio volume
            if (audioVolumeToo)
            {
                this.audioMixer.SetFloat("MasterVolume", -50);
            }

            yield return new WaitForSeconds(delay);

            for (float time = 0; time < duration; time += Time.deltaTime)
            {
                // Black canvas
                var blackCanvasColor = this.blackCanvas.color;
                blackCanvasColor.a = 1 - time / duration;
                this.blackCanvas.color = blackCanvasColor;

                // Audio volume
                if (audioVolumeToo)
                {
                    this.audioMixer.SetFloat("MasterVolume", -50 + 50 * time / duration);
                }

                yield return null;
            }

            // Black canvas
            this.blackCanvas.gameObject.SetActive(false);

            // Audio volume
            if (audioVolumeToo)
            {
                this.audioMixer.SetFloat("MasterVolume", 0);
            }
        }
    }
}