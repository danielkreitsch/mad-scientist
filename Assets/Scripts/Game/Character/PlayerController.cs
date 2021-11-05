using Development.Debugging;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.Character
{
    public class PlayerController : MonoBehaviour
    {
        [Inject]
        private PlayerControls playerControls;

        /*[Inject]
        private CameraController cameraController;*/

        [Inject]
        private DebugScreen debugScreen;

        [FormerlySerializedAs("characterController")]
        [SerializeField]
        private HumanController humanController;

        void Start()
        {
        
        }
    
        void Update()
        {
            var movementInput = this.playerControls.Default.Move.ReadValue<Vector2>();
            var horizontalInput = movementInput.x;
            var verticalInput = movementInput.y;

            float cameraYAngle = 45;//this.cameraController.Camera.transform.eulerAngles.y;
            
            var cosOfCameraAngle = Mathf.Cos(cameraYAngle * Mathf.Deg2Rad);
            var sinOfCameraAngle = Mathf.Sin(cameraYAngle * Mathf.Deg2Rad);
            var horizontalInputInWorld = horizontalInput * cosOfCameraAngle + verticalInput * sinOfCameraAngle;
            var verticalInputInWorld = horizontalInput * -sinOfCameraAngle + verticalInput * cosOfCameraAngle;
            var moveDirection = new Vector2(horizontalInputInWorld, verticalInputInWorld).normalized;
            
            this.humanController.Move(moveDirection);
            
            this.debugScreen.Set("Player", "Input", movementInput);
        }
    }
}
