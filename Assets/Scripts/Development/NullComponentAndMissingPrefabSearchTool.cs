#if UNITY_EDITOR

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Development
{
    public class NullComponentAndMissingPrefabSearchTool
    {
        private static List<string> results = new List<string>();

        [MenuItem("Tools/Log Missing Prefabs And Components")]
        public static void Search()
        {
            NullComponentAndMissingPrefabSearchTool.results.Clear();
            GameObject[] gos = SceneManager.GetActiveScene().GetRootGameObjects();
            foreach (GameObject go in gos) NullComponentAndMissingPrefabSearchTool.Traverse(go.transform);
            Debug.Log("> Total Results: " + NullComponentAndMissingPrefabSearchTool.results.Count);
            foreach (string result in NullComponentAndMissingPrefabSearchTool.results) Debug.Log("> " + result);
        }

        private static void AppendComponentResult(string childPath, int index)
        {
            NullComponentAndMissingPrefabSearchTool.results.Add("Missing Component " + index + " of " + childPath);
        }

        private static void AppendTransformResult(string childPath, string name)
        {
            NullComponentAndMissingPrefabSearchTool.results.Add("Missing Prefab for \"" + name + "\" of " + childPath);
        }

        private static void Traverse(Transform transform, string path = "")
        {
            string thisPath = path + "/" + transform.name;
            Component[] components = transform.GetComponents<Component>();
            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] == null) NullComponentAndMissingPrefabSearchTool.AppendComponentResult(thisPath, i);
            }
            for (int c = 0; c < transform.childCount; c++)
            {
                Transform t = transform.GetChild(c);
                PrefabAssetType pt = PrefabUtility.GetPrefabAssetType(t.gameObject);
                if (pt == PrefabAssetType.MissingAsset)
                {
                    NullComponentAndMissingPrefabSearchTool.AppendTransformResult(path + "/" + transform.name, t.name);
                }
                else
                {
                    NullComponentAndMissingPrefabSearchTool.Traverse(t, thisPath);
                }
            }
        }
    }
}

#endif