using System;
using UnityEngine;

namespace Game.Character
{
    [RequireComponent(typeof(CharacterController))]
    public class HumanController : MonoBehaviour
    {
        [SerializeField]
        private float walkSpeed = 5;

        private CharacterController characterController;

        private void Awake()
        {
            this.characterController = this.GetComponent<CharacterController>();
        }

        public void Move(Vector2 direction)
        {
            this.characterController.Move(new Vector3(direction.x, 0, direction.y) * this.walkSpeed * Time.deltaTime);
        }
    }
}