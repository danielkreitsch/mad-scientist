#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Development.ExecutableBuilder
{
    public class ExecutableBuilder
    {
        [MenuItem("Build/Windows")]
        public static void BuildForWindows_Click()
        {
            var settings = Resources.Load<ExecutableBuilderSettings>("ExecutableBuilderSettings");

            // Clone scenes
            List<string> scenePaths = new List<string>();
            foreach (var scene in EditorBuildSettings.scenes)
            {
                if (scene.enabled)
                {
                    scenePaths.Add(scene.path);
                }
            }

            // Build and get the path of the executable
            string executablePath = ExecutableBuilder.BuildForWindows(scenePaths.ToArray(), settings.BuildsFolder, settings.ExecutableName);

            // Run the executable if the user wants to
            if (settings.RunAfterBuild)
            {
                ExecutableBuilder.RunExecutable(executablePath);
            }
        }

        private static string BuildForWindows(string[] scenes, string buildsDirectory, string executableName)
        {
            for (int i = 0; i < scenes.Length; i++)
            {
                string scene = scenes[i];

                if (!scene.Contains("Scenes/"))
                {
                    scene = "Scenes/" + scene;
                }

                if (!scene.Contains("Assets/"))
                {
                    scene = "Assets/" + scene;
                }

                if (!scene.EndsWith(".unity"))
                {
                    scene = scene + ".unity";
                }

                scenes[i] = scene;
            }

            string buildDirectory = buildsDirectory + "/Windows/" + DateTime.Now.ToString("yyyy-MM-dd");

            // Create build directory
            Directory.CreateDirectory(buildDirectory);

            // Build into build directory
            string executablePath = buildDirectory + "/" + executableName + ".exe";
            EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, BuildTarget.StandaloneWindows);
            BuildPipeline.BuildPlayer(scenes, executablePath, BuildTarget.StandaloneWindows, BuildOptions.None);

            return executablePath;
        }

        private static void RunExecutable(string executablePath)
        {
            Process process = new Process();
            process.StartInfo.FileName = executablePath;
            process.Start();
        }
    }
}

#endif