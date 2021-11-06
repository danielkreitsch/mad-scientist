using System.Collections;
using Game;
using UnityEngine;
using Zenject;

namespace GameJam
{
    public class PauseMenuController : MonoBehaviour
    {
        /*[Inject]
        private MenuControls menuControls;

        [Inject]
        private CameraController cameraController;
        
        [SerializeField]
        private GameObject menuScene;

        [SerializeField]
        private GameObject menuCanvas;
        
        private bool pause;

        private bool animating;

        public bool Pause
        {
            get => this.pause;
            set
            {
                if (this.pause != value)
                {
                    this.pause = value;
                    foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
                    {
                        foreach (IPausable pausable in obj.GetComponents<IPausable>())
                        {
                            pausable.Pause = value;
                        }
                    }
                }
            }
        }

        private void Awake()
        {
            this.menuScene.SetActive(false);
            this.menuCanvas.SetActive(false);
        }

        private void Update()
        {
            if (this.animating)
            {
                return;
            }

            if (this.menuControls.Default.OpenPauseMenu.triggered)
            {
                if (this.Pause)
                {
                    this.StartCoroutine(this.StopPause_Coroutine());
                }
                else
                {
                    this.StartCoroutine(this.StartPause_Coroutine());
                }
            }
        }

        private IEnumerator StartPause_Coroutine()
        {
            this.Pause = true;
            yield return null;
        }

        private IEnumerator StopPause_Coroutine()
        {
            this.Pause = false;
            yield return null;
        }*/
    }
}