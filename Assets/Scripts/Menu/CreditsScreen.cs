using UnityEngine;
using Zenject;

namespace GameJam
{
    public class CreditsScreen : MonoBehaviour
    {
        [Inject]
        private DefaultScreenScene defaultScreenScene;

        [Inject]
        private MainScreenScene mainScreenScene;

        [Inject]
        private MainScreen mainScreen;

        [Inject]
        private MenuControls menuControls;

        void Update()
        {
            if (this.menuControls.Default.Back.triggered)
            {
                this.gameObject.SetActive(false);
                this.mainScreenScene.gameObject.SetActive(true);
                this.defaultScreenScene.gameObject.SetActive(false);
                this.mainScreen.gameObject.SetActive(true);
            }
        }
    }
}