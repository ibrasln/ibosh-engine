using System;
using System.Collections.Generic;
using IboshEngine.Runtime.Debugger;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

namespace IboshEngine.Editor.ScriptableObjectGenerator
{
    /// <summary>
    /// Custom Editor Window for generating Scriptable Objects.
    /// </summary>
    public class ScriptableObjectGenerator : EditorWindow
    {
        private AnimBool _hasUniqueFolderPath;
        private string _folderPath;
        private List<Type> _scriptableObjectTypes;
        private readonly string _scriptableObjectsFolderPath = "Assets/ScriptableObjects";
        
        [MenuItem("Ibosh Engine/Scriptable Object Generator")]
        public static void ShowWindow()
        {
            ScriptableObjectGenerator window =
                (ScriptableObjectGenerator)GetWindowWithRect(typeof(ScriptableObjectGenerator),
                    new Rect(0, 0, 250, 500));
            window.titleContent = new("Scriptable Object Generator");
            window.Show();
        }

        private void OnEnable()
        {
            _hasUniqueFolderPath = new();
            _hasUniqueFolderPath.valueChanged.AddListener(Repaint);
            _folderPath = "Assets/Scripts";
            ScanForScriptableObjectClasses();
        }

        private void OnGUI()
        {
            EditorGUI.BeginChangeCheck();
            _hasUniqueFolderPath.target = EditorGUILayout.Toggle(
                new GUIContent("Has a unique folder path",
                    "If you want to change the folder path that will be scanned to find the scriptable object classes, press it.\n<b><i>Default Path: Assets/Scripts</i></b>"),
                _hasUniqueFolderPath.target);
            if (EditorGUI.EndChangeCheck()) GUI.tooltip = "";

            if (EditorGUILayout.BeginFadeGroup(_hasUniqueFolderPath.faded))
            {
                EditorGUI.indentLevel++;

                EditorGUI.BeginChangeCheck();
                _folderPath = EditorGUILayout.TextField(
                    new GUIContent("Folder Path",
                        "Populate this with the folder path that will be scanned to find the scriptable object classes."),
                    _folderPath);
                if (EditorGUI.EndChangeCheck()) GUI.tooltip = "";

                if (GUILayout.Button("Scan for Scriptable Object Classes")) ScanForScriptableObjectClasses();
                
                EditorGUI.indentLevel--;
            }
            EditorGUILayout.EndFadeGroup();

            if (_scriptableObjectTypes is null) return;
            
            EditorGUILayout.Space();

            EditorGUILayout.BeginVertical("Box");

            foreach (Type type in _scriptableObjectTypes)
            {
                if (GUILayout.Button($"{type.Name}"))
                {
                    CreateScriptableObjectInstance(type);
                }
            }

            EditorGUILayout.EndVertical();
        }

        /// <summary>
        /// Scans for Scriptable Object classes within the specified folder path.
        /// </summary>
        private void ScanForScriptableObjectClasses()
        {
            if (string.IsNullOrEmpty(_folderPath))
            {
                IboshDebugger.LogError("Folder path cannot be empty!", "Scriptable Object Generator",
                    IboshDebugger.DebugColor.Gray, IboshDebugger.DebugColor.Red);
                return;
            }

            _scriptableObjectTypes = new List<Type>();

            string[] guids = AssetDatabase.FindAssets("t:MonoScript", new[] { _folderPath });

            foreach (string guid in guids)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guid);
                MonoScript script = AssetDatabase.LoadAssetAtPath<MonoScript>(assetPath);
                Type type = script.GetClass();

                if (type != null && type.IsSubclassOf(typeof(ScriptableObject)))
                {
                    _scriptableObjectTypes.Add(type);
                }
            }
        }

        /// <summary>
        /// Creates an instance of the specified Scriptable Object type and saves it to the 'ScriptableObjects' folder.
        /// </summary>
        /// <param name="type">The type of the Scriptable Object to create.</param>
        private void CreateScriptableObjectInstance(Type type)
        {
            if (string.IsNullOrEmpty(_folderPath))
            {
                IboshDebugger.LogError("Folder path cannot be empty!", "Scriptable Object Generator",
                    IboshDebugger.DebugColor.Gray, IboshDebugger.DebugColor.Red);
                return;
            }

            if (!AssetDatabase.IsValidFolder(_scriptableObjectsFolderPath))
            {
                IboshDebugger.LogError("Need 'ScriptableObjects' folder to create a scriptable object!",
                    "Scriptable Object Generator", IboshDebugger.DebugColor.Gray, IboshDebugger.DebugColor.Red);
                return;
            }

            string assetPath = AssetDatabase.GenerateUniqueAssetPath($"{_scriptableObjectsFolderPath}/{type.Name}_.asset");

            ScriptableObject instance = CreateInstance(type);

            AssetDatabase.CreateAsset(instance, assetPath);
            AssetDatabase.SaveAssets();

            EditorGUIUtility.PingObject(instance);

            IboshDebugger.LogMessage($"Scriptable Object '{type.Name}' generated successfully!",
                "Scriptable Object Generator", IboshDebugger.DebugColor.Gray, IboshDebugger.DebugColor.Green);
        }
    }
}
