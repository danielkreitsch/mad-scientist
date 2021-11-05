using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace General
{
    public class InputHelper : MonoBehaviour
    {
        public UnityEvent OnMouseMove;

        private Vector3 savedMousePosition;

        public static bool IsHovering(RectTransform rectTransform)
        {
            return rectTransform.rect.Contains(rectTransform.InverseTransformPoint(Mouse.current.position.ReadValue()));
        }

        public static Vector2 GetRelativeCursorPosition(RectTransform rectTransform)
        {
            var mousePos = rectTransform.InverseTransformPoint(Mouse.current.position.ReadValue());
            return new Vector2(mousePos.x - rectTransform.anchorMin.x, mousePos.y - rectTransform.anchorMin.y);
        }

        void Update()
        {
            if (Vector3.Distance(this.savedMousePosition, Mouse.current.position.ReadValue()) > 0.01f)
            {
                this.savedMousePosition = Mouse.current.position.ReadValue();
                this.OnMouseMove.Invoke();
            }
        }
    }
}