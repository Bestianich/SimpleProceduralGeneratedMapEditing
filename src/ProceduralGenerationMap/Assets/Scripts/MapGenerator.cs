using System;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private int _seed;
    [SerializeField] private int _mapWidth;
    [SerializeField] private int _mapHeight;
    [SerializeField] private float _noiseScale;
    [SerializeField] private MapDisplay _mapDisplay;
    [SerializeField] private bool _autoUpdate;
    private void Awake()
    {
        if (_mapDisplay == null)
        {
            _mapDisplay = FindFirstObjectByType<MapDisplay>();
        }
    }

    public bool IsAutoUpdate()
    {
        return _autoUpdate;
    }
    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(_mapWidth, _mapHeight, _noiseScale, _seed);
        _mapDisplay.DrawMap(noiseMap);
    }
}
