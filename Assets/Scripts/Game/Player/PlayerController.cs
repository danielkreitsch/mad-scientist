using Development.Debugging;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Serialization;
using Utility;
using Zenject;

namespace GameJam
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [Inject]
        private PlayerControls playerControls;
        
        [Inject]
        private DebugScreen debugScreen;

        [Inject]
        private GameController gameController;
        
        [Inject]
        private CameraController cameraController;

        [Inject]
        private Tank tank;

        [SerializeField]
        private Scientist scientist;

        [SerializeField]
        private LayerMask aimLayer;

        [SerializeField]
        private Transform rotatingTransform;

        [SerializeField]
        private float walkSpeed = 5;

        [Header("Dashing")]
        [SerializeField]
        private float dashForce = 10;

        [SerializeField]
        private float dashDuration = 1;

        private Rigidbody rb;

        private bool dashing = false;

        void Awake()
        {
            this.rb = this.GetComponent<Rigidbody>();
        }
    
        void Update()
        {
            var movementInput = this.playerControls.Default.Move.ReadValue<Vector2>();
            
            this.ProcessMovement(movementInput.x, movementInput.y);
            
            this.ProcessAimingAngle(Mouse.current.position.ReadValue());
            
            this.ProcessShooting(Input.GetMouseButton(0));

            this.ProcessInteractions(this.playerControls.Default.Interact.triggered);
            
            this.debugScreen.Set("Player", "HP", this.scientist.Health);
        }

        private void ProcessMovement(float horizontalInput, float verticalInput)
        {
            if (!this.dashing)
            {
                float cameraYAngle = 45;
                var cosOfCameraAngle = Mathf.Cos(cameraYAngle * Mathf.Deg2Rad);
                var sinOfCameraAngle = Mathf.Sin(cameraYAngle * Mathf.Deg2Rad);
                var horizontalInputInWorld = horizontalInput * cosOfCameraAngle + verticalInput * sinOfCameraAngle;
                var verticalInputInWorld = horizontalInput * -sinOfCameraAngle + verticalInput * cosOfCameraAngle;
                var walkDirection = new Vector3(horizontalInputInWorld, 0, verticalInputInWorld).normalized;
                this.rb.velocity = walkDirection * walkSpeed;
                this.rotatingTransform.rotation = Quaternion.LookRotation(walkDirection);
            }

            if (this.playerControls.Default.Dodge.triggered)
            {
                this.rb.velocity = Vector3.zero;
                this.rb.AddForce(this.rotatingTransform.forward.normalized * this.dashForce, ForceMode.Impulse);
                this.dashing = true;
                this.gameObject.layer = LayerMask.NameToLayer("InvincibleScientist");
                this.GetComponent<NavMeshObstacle>().enabled = false;
                this.Invoke(() =>
                {
                    this.dashing = false;
                    this.gameObject.layer = LayerMask.NameToLayer("Scientist");
                    this.GetComponent<NavMeshObstacle>().enabled = true;
                }, this.dashDuration);
            }
        }
        
        private void ProcessAimingAngle(Vector2 mousePosition)
        {
            Ray ray = this.cameraController.Camera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100, this.aimLayer))
            {
                var mousePositionInWorld = hit.point;
                this.scientist.AimingAngle = Vector3.SignedAngle(Vector3.forward, new Vector3(mousePositionInWorld.x, this.transform.position.y, mousePositionInWorld.z) - this.transform.position, Vector3.up);
                this.debugScreen.Set("Player", "Aiming Angle", this.scientist.AimingAngle);
            }
        }

        private void ProcessShooting(bool buttonPressing)
        {
            if (buttonPressing)
            {
                this.scientist.Shoot();
            }
        }
        
        private void ProcessInteractions(bool buttonPressed)
        {
            if (buttonPressed)
            {
                var distanceToTank = Vector3.Distance(this.transform.position, this.tank.transform.position);
                if (distanceToTank < 3)
                {
                    this.tank.OnInteract();
                }
            }
        }
    }
}
