using UnityEditor;

[CustomEditor(typeof(GamePiece))]
public class GamePieceCustomInspector : Editor {

    /// <summary>
    /// Creates our own custom inspector for the GamePiece class
    /// </summary>
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();  //Used to make sure the regular InspectorGUI is still used

        var gp = (GamePiece)target;

        EditorGUILayout.LabelField("Row", gp.Row.ToString());           //Label the row into the inspector
        EditorGUILayout.LabelField("Column", gp.Column.ToString());     //Label the column into the inpector
    }
}
