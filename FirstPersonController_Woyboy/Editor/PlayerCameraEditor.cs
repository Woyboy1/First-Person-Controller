using UnityEngine;
using UnityEditor;

namespace FirstPersonController_Woyboy
{
    [CustomEditor(typeof(PlayerCameraController))]
    public class PlayerCameraEditor : Editor
    {
        #region Fields

        private SerializedProperty vcam;
        private SerializedProperty fov;
        private SerializedProperty invertCamera;
        private SerializedProperty cameraCanMove;
        private SerializedProperty mouseSensitivity;
        private SerializedProperty maxLookAngle;
        private SerializedProperty lockCursor;
        private SerializedProperty headBob;

        private SerializedProperty enableZoom;
        private SerializedProperty holdToZoom;
        private SerializedProperty zoomKey;
        private SerializedProperty zoomFOV;
        private SerializedProperty zoomStepTime;

        #endregion

        private void OnEnable()
        {
            vcam = serializedObject.FindProperty("vcam");
            fov = serializedObject.FindProperty("fov");
            invertCamera = serializedObject.FindProperty("invertCamera");
            cameraCanMove = serializedObject.FindProperty("cameraCanMove");
            mouseSensitivity = serializedObject.FindProperty("mouseSensitivity");
            maxLookAngle = serializedObject.FindProperty("maxLookAngle");
            lockCursor = serializedObject.FindProperty("lockCursor");
            headBob = serializedObject.FindProperty("headBob");

            enableZoom = serializedObject.FindProperty("enableZoom");
            holdToZoom = serializedObject.FindProperty("holdToZoom");
            zoomKey = serializedObject.FindProperty("zoomKey");
            zoomFOV = serializedObject.FindProperty("zoomFOV");
            zoomStepTime = serializedObject.FindProperty("zoomStepTime");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            #region Header styles

            // Header1
            GUIStyle headerStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = 23,
                fontStyle = FontStyle.Normal,
                alignment = TextAnchor.MiddleLeft,
            };

            headerStyle.normal.textColor = Color.yellow;

            // Header 2
            GUIStyle headerStyleTwo = new GUIStyle(GUI.skin.label)
            {
                fontSize = 16,
                fontStyle = FontStyle.Normal,
                alignment = TextAnchor.MiddleLeft,
            };

            headerStyleTwo.normal.textColor = Color.white;

            // Header 3
            GUIStyle headerStyleThree = new GUIStyle(GUI.skin.label)
            {
                fontSize = 17,
                fontStyle = FontStyle.Normal,
                alignment = TextAnchor.MiddleLeft,
            };

            headerStyleThree.normal.textColor = Color.white;

            #endregion

            GUI.enabled = false;
            EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour((PlayerCameraController)target), typeof(MonoScript), false);
            GUI.enabled = true;

            GUILayout.Space(10);
            GUILayout.Label("Player Camera Controller", headerStyle);
            GUILayout.Space(5);
            GUILayout.Label("by Woyboy", headerStyleTwo);
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider); // Line

            GUILayout.Space(15);

            GUILayout.Label("Camera Settings", headerStyleThree);
            EditorGUILayout.PropertyField(vcam);
            EditorGUILayout.PropertyField(fov);
            EditorGUILayout.PropertyField(lockCursor);
            EditorGUILayout.PropertyField(invertCamera);
            EditorGUILayout.PropertyField(cameraCanMove);
            EditorGUILayout.PropertyField(mouseSensitivity);
            EditorGUILayout.PropertyField(maxLookAngle);
            EditorGUILayout.PropertyField(headBob);

            GUILayout.Space(10);
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider); // Line

            GUILayout.Label("Zoom Settings", headerStyleThree);
            EditorGUILayout.PropertyField(enableZoom);
            EditorGUILayout.PropertyField(holdToZoom);
            EditorGUILayout.PropertyField(zoomKey);
            EditorGUILayout.PropertyField(zoomFOV);
            EditorGUILayout.PropertyField(zoomStepTime);

            serializedObject.ApplyModifiedProperties();

            // base.OnInspectorGUI();
        }
    }
}