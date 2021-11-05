using UnityEngine;
using Zenject;

namespace Menu
{
    public class MainMenuSceneInstaller : MonoInstaller
    {
        [SerializeField]
        private MainMenuController mainMenuController;

        [SerializeField]
        private DefaultScreenScene defaultScreenScene;

        [SerializeField]
        private MainScreenScene mainScreenScene;

        [SerializeField]
        private MainScreen mainScreen;

        [SerializeField]
        private CreditsScreen creditsScreen;

        public override void InstallBindings()
        {
            this.Container.BindInstances(
                this.mainMenuController,
                this.defaultScreenScene,
                this.mainScreenScene,
                this.mainScreen,
                this.creditsScreen
            );
        }
    }
}