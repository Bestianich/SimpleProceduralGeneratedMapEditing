using System;
using UnityEditor;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private DrawMode _drawMode;
    [SerializeField] private int _seed;
    [SerializeField] private int _mapWidth;
    [SerializeField] private int _mapHeight;
    [SerializeField] private float _noiseScale;
    [SerializeField] private bool _autoUpdate;
    [SerializeField] private int _octaves;
    [SerializeField] [Range(0, 1)] private float _persistance;
    [SerializeField] private float _lacunarity;
    [SerializeField] private MapDisplay _mapDisplay;
    [SerializeField] private TerrainType[] _terrainType;
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
        float[,] noiseMap = Noise.GenerateNoiseMap(_mapWidth, _mapHeight, _noiseScale, _seed , _octaves, _persistance, _lacunarity);
        Color[] colorMap = new Color[_mapWidth * _mapHeight];
        for (int y = 0; y < _mapHeight; y++)
        {
            for (int x = 0; x < _mapWidth; x++)
            {
                float currentHeight = noiseMap[x, y];
                for (int i = 0; i < _terrainType.Length; i++)
                {
                    if (currentHeight <= _terrainType[i].height)
                    {
                        colorMap[y * _mapWidth + x] = _terrainType[i].colour;
                        break;
                    }
                }
            }
        }

        if (_drawMode == DrawMode.ColourMap)
        {
            _mapDisplay.DrawTexture(TextureGenerator.TextureFromColourMap(colorMap , _mapWidth , _mapHeight));
        }
        else
        {
            _mapDisplay.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap));    
        }
    }
}

[Serializable] 
public enum DrawMode
{
    NoiseMap,
    ColourMap
};
