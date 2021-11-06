using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace GameJam
{
    public class CameraController : MonoBehaviour
    {
        [Header("General")]
        [SerializeField]
        private new UnityEngine.Camera camera;

        [SerializeField]
        private Transform _observed;

        [SerializeField]
        private float mouseOffsetInfluence = 1;
        
        [SerializeField]
        private float movementInterpolationTime;
        
        private Vector3 baseOffset;
        
        private Vector3 movementVelocity;

        public UnityEngine.Camera Camera => this.camera;
        
        public Transform Observed
        {
            get => this._observed;
            set => this._observed = value;
        }
        
        private void Start()
        {
            this.baseOffset = this.Camera.transform.localPosition;
            this.transform.position = this.Observed.transform.position;
        }

        private void LateUpdate()
        {
            var targetPosition = this.Observed.transform.position;
            this.transform.position = Vector3.SmoothDamp(this.transform.position, targetPosition, ref this.movementVelocity, this.movementInterpolationTime);

            Vector2 mousePosition = Mouse.current.position.ReadValue();
            var mouseXFromCenter = (mousePosition.x - 0.5f * Screen.width) / Screen.width * 2;
            var mouseYFromCenter = (mousePosition.y - 0.5f * Screen.height) / Screen.height * 2;

            float cameraYAngle = 45;
            var cosOfCameraAngle = Mathf.Cos(cameraYAngle * Mathf.Deg2Rad);
            var sinOfCameraAngle = Mathf.Sin(cameraYAngle * Mathf.Deg2Rad);
            var mouseOffsetXInWorld = mouseXFromCenter * cosOfCameraAngle + mouseYFromCenter * sinOfCameraAngle;
            var mouseOffsetYInWorld = mouseXFromCenter * -sinOfCameraAngle + mouseYFromCenter * cosOfCameraAngle;
            var mouseOffsetInWorld = new Vector3(mouseOffsetXInWorld, 0, mouseOffsetYInWorld);
            
            this.Camera.transform.localPosition = this.baseOffset + mouseOffsetInWorld * this.mouseOffsetInfluence;
        }
    }
}
