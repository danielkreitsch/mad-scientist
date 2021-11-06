using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace GameJam
{
    public class LeaveButton : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField]
        private UnityEvent onSelect;

        [SerializeField]
        private UnityEvent onUnselect;

        private RectTransform rectTransform;

        private bool isSelectedBefore;

        public RectTransform RectTransform => this.rectTransform;

        public bool IsSelected { get; set; }

        void Start()
        {
            this.rectTransform = this.GetComponent<RectTransform>();
        }

        void Update()
        {
            this.IsSelected = InputHelper.IsHovering(this.rectTransform);

            if (this.IsSelected)
            {
                if (!this.isSelectedBefore)
                {
                    this.onSelect.Invoke();
                }

                if (Mouse.current.leftButton.wasPressedThisFrame)
                {
                    SceneManager.LoadScene(0);
                }
            }
            else
            {
                if (this.isSelectedBefore)
                {
                    this.onUnselect.Invoke();
                }
            }

            this.isSelectedBefore = this.IsSelected;
        }
    }
}