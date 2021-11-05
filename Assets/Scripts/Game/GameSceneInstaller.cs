using Game.Character;
using Menu;
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
        private PlayerController playerController;

        [SerializeField]
        private CameraController cameraController;

        public override void InstallBindings()
        {
            this.Container.BindInstances(
                this.gameController,
                this.pauseMenuController,
                this.playerController,
                this.cameraController
            );
        }
    }
}