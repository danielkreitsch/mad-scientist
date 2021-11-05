using UnityEngine;

namespace Game
{
    public class CameraController : MonoBehaviour
    {
        [Header("General")]
        [SerializeField]
        private new UnityEngine.Camera camera;

        [SerializeField]
        private Transform _observed;

        public UnityEngine.Camera Camera => this.camera;
        
        void Start()
        {
        
        }

        void Update()
        {
        
        }
    }
}
