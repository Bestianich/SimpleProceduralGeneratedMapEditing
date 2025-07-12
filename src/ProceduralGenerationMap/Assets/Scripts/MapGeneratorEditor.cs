#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor
{
    
    public override void OnInspectorGUI()
    {
        MapGenerator mapGenerator = (MapGenerator)target;
        if (DrawDefaultInspector())
        {
            if (mapGenerator.IsAutoUpdate())
            {
                mapGenerator.GenerateMap(MapGenerator.Instance.GetDrawMode());
            }
        }
        if (GUILayout.Button("Generate Map"))
        {
            mapGenerator.GenerateMap(MapGenerator.Instance.GetDrawMode());
        }
    }
}
#endif
