using System.Collections;
using UnityEngine;

namespace GameJam
{
    public class Vignette : MonoBehaviour
    {
        [SerializeField]
        private RectTransform topPart;

        [SerializeField]
        private RectTransform bottomPart;

        [SerializeField]
        private float partHeight = 138;

        private float _position;

        public bool Visible
        {
            get => this.topPart.gameObject.activeInHierarchy && this.bottomPart.gameObject.activeInHierarchy;
            set
            {
                this.topPart.gameObject.SetActive(value);
                this.bottomPart.gameObject.SetActive(value);
            }
        }

        public float Position
        {
            get => this._position;
            set
            {
                this._position = value;

                var topPartPos = this.topPart.anchoredPosition;
                topPartPos.y = this.partHeight - this._position * this.partHeight;
                this.topPart.anchoredPosition = topPartPos;

                var bottomPartPos = this.bottomPart.anchoredPosition;
                bottomPartPos.y = -(this.partHeight - this._position * this.partHeight);
                this.bottomPart.anchoredPosition = bottomPartPos;
            }
        }

        public void FadeIn(float duration)
        {
            this.StartCoroutine(this.FadeIn_Coroutine(duration));
        }

        public void FadeOut(float duration)
        {
            this.StartCoroutine(this.FadeOut_Coroutine(duration));
        }

        private IEnumerator FadeIn_Coroutine(float duration)
        {
            this.Visible = true;
            this.Position = 0;

            for (float time = 0; time < duration; time += Time.deltaTime)
            {
                this.Position = time / duration;
                yield return null;
            }

            this.Position = 1;
        }

        public IEnumerator FadeOut_Coroutine(float duration)
        {
            this.Position = 1;

            for (float time = 0; time < duration; time += Time.deltaTime)
            {
                this.Position = 1 - time / duration;
                yield return null;
            }

            this.Visible = false;
        }
    }
}