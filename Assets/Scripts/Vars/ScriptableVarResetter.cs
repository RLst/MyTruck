using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace hYu
{
    public class ScriptableVarResetter : MonoBehaviour
    {
#if UNITY_EDITOR
        private void OnEnable()
        {
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }

        private void OnDisable()
        {
            EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
        }

        private void OnPlayModeStateChanged(PlayModeStateChange state)
        {
            // if (state == PlayModeStateChange.EnteredPlayMode)
            // {
            //     Debug.Log("Entered Play mode");
            // }
            // else 
            if (state == PlayModeStateChange.ExitingPlayMode)
            {
                Debug.Log("Resetting all variables");
                ResetAllScriptableVars();
            }
        }
#else
        //In play mode reset all variables to normal
        void Awake()
        {
            ResetAllScriptableVars();
        }
#endif

        void ResetAllScriptableVars()
        {
            var scriptableVars = Resources.FindObjectsOfTypeAll<ScriptableVarBase>();
            foreach (var sv in scriptableVars)
                sv.Reset();
        }
    }
}