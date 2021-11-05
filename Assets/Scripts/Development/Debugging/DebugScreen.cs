using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Development.Debugging
{
    public class DebugScreen : MonoBehaviour
    {
        [SerializeField]
        private InputAction toggleTrigger;

        [SerializeField]
        private bool activeAtStart;

        [Header("References")]
        [SerializeField]
        private TextMeshProUGUI leftLabel;

        [SerializeField]
        private TextMeshProUGUI rightLabel;

        private readonly Dictionary<string, Dictionary<string, string>> categoryVariablesMap = new Dictionary<string, Dictionary<string, string>>();

        private bool _active;
        private ViewMode mode = ViewMode.Performance;

        private float fpsRefreshTimer;
        private int fps;

        public bool Active
        {
            get => this._active;
            set
            {
                this._active = value;
                this.leftLabel.gameObject.SetActive(this._active);
                this.rightLabel.gameObject.SetActive(this._active);
            }
        }

        private void Start()
        {
            if (this.activeAtStart)
            {
                this.Active = true;
            }
        }

        public void Set(string category, string name, System.Object value, bool active = true)
        {
            if (active)
            {
                if (!this.categoryVariablesMap.ContainsKey(category))
                {
                    this.categoryVariablesMap[category] = new Dictionary<string, string>();
                }

                this.categoryVariablesMap[category][name] = value?.ToString();
            }
            else
            {
                this.Unset(category, name);
            }
        }

        public void Set(string name, System.Object value, bool active = true)
        {
            this.Set("Unnamed", name, value, active);
        }

        public void Unset(string category, string name)
        {
            if (this.categoryVariablesMap.ContainsKey(category))
            {
                this.categoryVariablesMap[category].Remove(name);

                if (this.categoryVariablesMap[category].Count == 0)
                {
                    this.categoryVariablesMap.Remove(category);
                }
            }
        }

        public void ClearCategory(string category)
        {
            this.categoryVariablesMap.Remove(category);
        }

        private void Awake()
        {
            this.toggleTrigger.Enable();
        }

        private void Update()
        {
            if (this.toggleTrigger.triggered)
            {
                this.Active = !this.Active;
            }

            if (!this.Active)
            {
                return;
            }

            this.ProcessDisplayContent();
        }

        private void ProcessDisplayContent()
        {
            string leftText = "";
            foreach (KeyValuePair<string, Dictionary<string, string>> categoryVariablesMapEntry in this.categoryVariablesMap)
            {
                string category = categoryVariablesMapEntry.Key;
                Dictionary<string, string> variables = categoryVariablesMapEntry.Value;

                leftText += (leftText.Contains("\n") ? "\n" : "") + "<b>" + category + "</b>\n";
                foreach (KeyValuePair<string, string> variable in variables)
                {
                    leftText += "<color=#ddd>" + variable.Key + ":</color> " + variable.Value + "\n";
                }
            }

            string rightText = "";
            if (this.mode == ViewMode.Performance)
            {
                if (this.fpsRefreshTimer >= 0.5f)
                {
                    this.fpsRefreshTimer = 0;
                    this.UpdateFps();
                }
                this.fpsRefreshTimer += Time.deltaTime;

                rightText = "FPS: <b>" + this.fps + "</b>";
            }
            else
            {
                rightText = "";
            }

            this.leftLabel.text = leftText;
            this.rightLabel.text = rightText;
        }

        private void UpdateFps()
        {
            this.fps = (int) (1.0f / Time.smoothDeltaTime);
        }

        enum ViewMode
        {
            Performance
        }
    }
}