using Development.Debugging;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Serialization;
using Zenject;

namespace GameJam
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [Inject]
        private PlayerControls playerControls;
        
        [Inject]
        private DebugScreen debugScreen;
        
        [Inject]
        private CameraController cameraController;


        [SerializeField]
        private Scientist scientist;
        
        [SerializeField]
        private LayerMask aimLayer;

        [SerializeField]
        private float walkSpeed = 5;
        
        private CharacterController characterController;

        void Awake()
        {
            this.characterController = this.GetComponent<CharacterController>();
        }
    
        void Update()
        {
            var movementInput = this.playerControls.Default.Move.ReadValue<Vector2>();
            
            this.ProcessMovement(movementInput.x, movementInput.y);
            
            this.ProcessLookDirection(Mouse.current.position.ReadValue());
            
            this.ProcessShooting(this.playerControls.Default.Shoot.triggered);
        }

        private void ProcessMovement(float horizontalInput, float verticalInput)
        {
            float cameraYAngle = 45;
            var cosOfCameraAngle = Mathf.Cos(cameraYAngle * Mathf.Deg2Rad);
            var sinOfCameraAngle = Mathf.Sin(cameraYAngle * Mathf.Deg2Rad);
            var horizontalInputInWorld = horizontalInput * cosOfCameraAngle + verticalInput * sinOfCameraAngle;
            var verticalInputInWorld = horizontalInput * -sinOfCameraAngle + verticalInput * cosOfCameraAngle;
            var walkDirection = new Vector3(horizontalInputInWorld, 0, verticalInputInWorld).normalized;
            this.characterController.Move(walkDirection * walkSpeed * Time.deltaTime);

            if (this.transform.position.y > 0)
            {
                this.transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);
            }
        }
        
        private void ProcessLookDirection(Vector2 mousePosition)
        {
            Ray ray = this.cameraController.Camera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100, this.aimLayer))
            {
                var mousePositionInWorld = hit.point;
                this.transform.LookAt(new Vector3(mousePositionInWorld.x, this.transform.position.y, mousePositionInWorld.z));
            }
        }

        private void ProcessShooting(bool buttonPressed)
        {
            if (buttonPressed)
            {
                this.scientist.Shoot();
            }
        }
    }
}