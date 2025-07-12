using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public struct TerrainType
{
    public string name;
    public float height;
    [FormerlySerializedAs("colour")] public Color color;
}
