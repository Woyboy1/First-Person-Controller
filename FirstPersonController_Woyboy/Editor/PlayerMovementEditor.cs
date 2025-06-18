using UnityEngine;
using UnityEditor;
using Cinemachine.Editor;

[CustomEditor(typeof(PlayerMovement))]
public class PlayerMovementEditor : Editor
{
    #region Fields

    private SerializedProperty playerCanMoveProp;
    private SerializedProperty walkSpeedProp;
    private SerializedProperty gravityProp;
    private SerializedProperty jumpHeightProp;
    private SerializedProperty stepInterval;

    private SerializedProperty canSprint;
    private SerializedProperty sprintKey;
    private SerializedProperty sprintSpeed;

    private SerializedProperty groundCheckProp;
    private SerializedProperty groundDistanceProp;
    private SerializedProperty groundMaskProp;

    #endregion

    private void OnEnable()
    {
        playerCanMoveProp = serializedObject.FindProperty("playerCanMove");
        walkSpeedProp = serializedObject.FindProperty("walkSpeed");
        gravityProp = serializedObject.FindProperty("gravity");
        jumpHeightProp = serializedObject.FindProperty("jumpHeight");
        stepInterval = serializedObject.FindProperty("stepInterval");

        canSprint = serializedObject.FindProperty("canSprint");
        sprintKey = serializedObject.FindProperty("sprintKey");
        sprintSpeed = serializedObject.FindProperty("sprintSpeed");

        groundCheckProp = serializedObject.FindProperty("groundCheck");
        groundDistanceProp = serializedObject.FindProperty("groundDistance");
        groundMaskProp = serializedObject.FindProperty("groundMask");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

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

        GUI.enabled = false;
        EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour((PlayerMovement)target), typeof(MonoScript), false);
        GUI.enabled = true;

        GUILayout.Space(10);
        GUILayout.Label("Player Movement", headerStyle);
        GUILayout.Space(5);
        GUILayout.Label("by Woyboy", headerStyleTwo);
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider); // Line

        GUILayout.Space(15);

        GUILayout.Label("Movement Settings", headerStyleThree);
        EditorGUILayout.PropertyField(playerCanMoveProp);
        EditorGUILayout.PropertyField(walkSpeedProp);
        EditorGUILayout.PropertyField(gravityProp);
        EditorGUILayout.PropertyField(jumpHeightProp);
        EditorGUILayout.PropertyField(stepInterval);

        GUILayout.Space(10);
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider); // Line

        GUILayout.Label("Sprinting Settings", headerStyleThree);
        EditorGUILayout.PropertyField(canSprint);
        EditorGUILayout.PropertyField(sprintKey);
        EditorGUILayout.PropertyField(sprintSpeed);

        GUILayout.Space(10);
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider); // Line

        // Ground Check
        GUILayout.Label("Ground Check", headerStyleThree);
        EditorGUILayout.PropertyField(groundCheckProp, new GUIContent("Ground Check"), true);
        EditorGUILayout.PropertyField(groundDistanceProp);
        EditorGUILayout.PropertyField(groundMaskProp);

        GUILayout.Space(10);
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider); // Line

        serializedObject.ApplyModifiedProperties();
    }
}
