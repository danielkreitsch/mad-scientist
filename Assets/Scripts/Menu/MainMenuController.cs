using General;
using UnityEngine;
using Zenject;

namespace Menu
{
    public class MainMenuController : MonoBehaviour
    {
        [Inject]
        private ScreenController screenController;

        [Inject]
        private MusicPlayer musicPlayer;

        [Inject]
        private DefaultScreenScene defaultScreenScene;

        [Inject]
        private MainScreenScene mainScreenScene;

        [Inject]
        private MainScreen mainScreen;
        
        [Inject]
        private CreditsScreen creditsScreen;
        
        private bool startTrigger = false;

        void Awake()
        {
            this.defaultScreenScene.gameObject.SetActive(false);
            this.mainScreenScene.gameObject.SetActive(true);
            this.mainScreen.gameObject.SetActive(true);
            this.creditsScreen.gameObject.SetActive(false);
        }

        private void Start()
        {
            //this.musicPlayer.Play("DarkForest");
        }

        public void StartGame()
        {
            throw new System.NotImplementedException();
        }
    }
}