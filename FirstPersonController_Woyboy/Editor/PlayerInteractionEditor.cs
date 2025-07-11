using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerInteractionController))]
public class PlayerInteractionEditor : Editor
{
    private SerializedProperty playerCamera;
    private SerializedProperty interactDistance;
    private SerializedProperty interactableMask;
    private SerializedProperty interactKey;

    private void OnEnable()
    {
        playerCamera = serializedObject.FindProperty("playerCamera");
        interactDistance = serializedObject.FindProperty("interactDistance");
        interactableMask = serializedObject.FindProperty("interactableMask");
        interactKey = serializedObject.FindProperty("interactKey");
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
        EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour((PlayerInteractionController)target), typeof(MonoScript), false);
        GUI.enabled = true;

        GUILayout.Space(10);
        GUILayout.Label("Player Interaction Controller", headerStyle);
        GUILayout.Space(5);
        GUILayout.Label("by Woyboy", headerStyleTwo);
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider); // Line

        GUILayout.Space(15);

        GUILayout.Label("Interaction Settings", headerStyleThree);
        EditorGUILayout.PropertyField(playerCamera);
        EditorGUILayout.PropertyField(interactDistance);
        EditorGUILayout.PropertyField(interactableMask);
        EditorGUILayout.PropertyField(interactKey);

        serializedObject.ApplyModifiedProperties();
    }
}
