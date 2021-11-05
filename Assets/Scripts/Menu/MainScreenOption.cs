using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Menu
{
    public class MainScreenOption : MonoBehaviour
    {
        [Inject]
        private MainScreen mainScreen;

        [Inject]
        private MenuControls menuControls;

        [Header("Events")]
        [SerializeField]
        private UnityEvent onSelect;

        [SerializeField]
        private UnityEvent onUnselect;

        [SerializeField]
        private UnityEvent onSelectConfirm;

        private RectTransform rectTransform;

        private bool isSelectedBefore;

        public RectTransform RectTransform => this.rectTransform;

        public bool IsSelected
        {
            get => this.mainScreen.SelectedOption == this;
        }

        void Start()
        {
            this.rectTransform = this.GetComponent<RectTransform>();
        }

        void Update()
        {
            if (this.IsSelected)
            {
                if (!this.isSelectedBefore)
                {
                    this.onSelect.Invoke();
                }

                if (this.menuControls.Default.Select.triggered)
                {
                    this.onSelectConfirm.Invoke();
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