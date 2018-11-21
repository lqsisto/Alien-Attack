using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
/*
public class Autosave : MonoBehaviour
{

    // Use this for initialization
    void Start()
    { }
         [InitializeOnLoad]
    public class AutosaveOnRun
    {
        static AutosaveOnRun()
        {
            EditorApplication.playmodeStateChanged = () =>
            {
                if (EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isPlaying)
                {
                    Debug.Log("Auto-Saving scene before entering Play mode.");
                    EditorSceneManager.SaveOpenScenes();
                    AssetDatabase.SaveAssets();
                }
            };
        }
    }
}
*/