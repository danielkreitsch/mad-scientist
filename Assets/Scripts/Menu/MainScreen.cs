using System.Linq;
using General;
using ModestTree;
using UnityEngine;
using UnityEngine.InputSystem;
using Utility;
using Zenject;

namespace Menu
{
    public class MainScreen : MonoBehaviour
    {
        [Inject]
        private InputHelper inputHelper;
        
        [Inject]
        private MenuControls menuControls;

        [Inject]
        private MainMenuController mainMenuController;

        [Inject]
        private DefaultScreenScene defaultScreenScene;

        [Inject]
        private MainScreenScene mainScreenScene;
        
        [Inject]
        private CreditsScreen creditsScreen;

        [Header("References")]
        [SerializeField]
        private GameObject continueButton;

        private MainScreenOption[] options;

        public MainScreenOption SelectedOption { get; set; }
        
        public void OnSelect_Start()
        {
            this.mainMenuController.StartGame();
        }

        public void OnSelect_Credits()
        {
            this.gameObject.SetActive(false);
            this.defaultScreenScene.gameObject.SetActive(true);
            this.mainScreenScene.gameObject.SetActive(false);
            this.creditsScreen.gameObject.SetActive(true);
        }

        public void OnSelect_Exit()
        {
            Application.Quit();
        }

        void Start()
        {
            this.options = this.GetComponentsInChildren<MainScreenOption>();

            this.SelectedOption = this.options[0];

            this.inputHelper.OnMouseMove.AddListener(this.OnMouseMove);

            this.menuControls.Default.Down.performed += this.OnDownPress;

            this.menuControls.Default.Up.performed += this.OnUpPress;
        }

        private void OnMouseMove()
        {
            var hoveredOption = this.options.FirstOrDefault(option => InputHelper.IsHovering(option.RectTransform));
            if (hoveredOption != null)
            {
                this.SelectedOption = hoveredOption;
            }
        }

        private void OnDownPress(InputAction.CallbackContext ctx)
        {
            int index;
            if (this.SelectedOption)
            {
                index = this.options.IndexOf(this.SelectedOption) + 1;
            }
            else
            {
                index = 0;
            }
            this.SelectedOption = this.options[index.Mod(this.options.Length)];
        }

        private void OnUpPress(InputAction.CallbackContext ctx)
        {
            int index;
            if (this.SelectedOption)
            {
                index = this.options.IndexOf(this.SelectedOption) - 1;
            }
            else
            {
                index = 0;
            }
            this.SelectedOption = this.options[index.Mod(this.options.Length)];
        }
    }
}