using UnityEngine;

namespace Development.ExecutableBuilder
{
    [CreateAssetMenu(fileName = "New Executable Builder Settings", menuName = "Project Settings/Executable Builder Settings")]
    public class ExecutableBuilderSettings : ScriptableObject
    {
        [SerializeField]
        private string buildsFolder = null;

        [SerializeField]
        private string executableName = null;

        [SerializeField]
        private bool runAfterBuild = false;

        public string BuildsFolder => this.buildsFolder;

        public string ExecutableName => this.executableName;

        public bool RunAfterBuild => this.runAfterBuild;
    }
}