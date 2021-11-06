using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameJam
{
    public class EndScreen : MonoBehaviour
    {
        [Inject]
        private ScreenController screenController;

        private InputAction anyButtonInput = new InputAction(type: InputActionType.PassThrough, binding: "*/<Button>");

        private void Start()
        {
            this.screenController.FadeOutBlack(0, 4f);
        }

        void Update()
        {
            if (this.anyButtonInput.triggered)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}