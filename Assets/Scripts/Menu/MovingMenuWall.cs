using UnityEngine;

namespace GameJam
{
    public class MovingMenuWall : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed;

        [SerializeField]
        private Vector3 moveDirection;

        void Start()
        {
        }

        void Update()
        {
            this.transform.Translate(this.moveSpeed * Time.deltaTime * this.moveDirection);
        }
    }
}