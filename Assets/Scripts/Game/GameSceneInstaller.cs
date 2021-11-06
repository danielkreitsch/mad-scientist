using GameJam;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField]
        private GameController gameController;

        [SerializeField]
        private PauseMenuController pauseMenuController;
        
        [SerializeField]
        private CameraController cameraController;

        [SerializeField]
        private Tank tank;

        public override void InstallBindings()
        {
            this.Container.BindInstances(
                this.gameController,
                this.pauseMenuController,
                this.cameraController,
                this.tank
            );
        }
    }
}