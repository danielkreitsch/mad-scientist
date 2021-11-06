using Development.Debugging;
using UnityEngine;
using Zenject;

namespace GameJam
{
    public class ProjectInstaller : MonoInstaller
    {
        [Header("References")]
        [SerializeField]
        private DebugScreen debugScreen;

        [SerializeField]
        private InputHelper inputHelper;

        [SerializeField]
        private ScreenController screenController;

        [SerializeField]
        private MusicPlayer musicPlayer;

        [Header("Settings")]
        [SerializeField]
        private bool debugMode;

        private CameraControls cameraControls;

        private DeveloperControls developerControls;

        private MenuControls menuControls;

        private PlayerControls playerControls;

        public override void InstallBindings()
        {
            this.cameraControls = new CameraControls();
            this.cameraControls.Default.Enable();
            
            this.developerControls = new DeveloperControls();
            this.developerControls.Default.Enable();
            
            this.menuControls = new MenuControls();
            this.menuControls.Default.Enable();
            
            this.playerControls = new PlayerControls();
            this.playerControls.Default.Enable();
            
            this.Container.BindInstances(
                this.debugScreen,
                this.inputHelper,
                this.screenController,
                this.musicPlayer,
                this.cameraControls,
                this.developerControls,
                this.menuControls,
                this.playerControls
            );
        }
    }
}