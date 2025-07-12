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
    [SerializeField] private InteractableMap _interactableMap;
    public static MapGenerator Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
        if (_mapDisplay == null)
        {
            _mapDisplay = FindFirstObjectByType<MapDisplay>();
        }
    }

    public bool IsAutoUpdate()
    {
        return _autoUpdate;
    }

    public void GenerateMap(DrawMode drawMode)
    {
        GenerateMap(_seed , _noiseScale , _octaves , _persistance , _lacunarity , drawMode);
    }
    public void GenerateMap(int seed , float noiseScale, int octaves, float persistance, float lacunarity , DrawMode drawMode)
    {
        _seed = seed;
        _noiseScale = noiseScale;
        _octaves = octaves;
        _persistance = persistance;
        _lacunarity = lacunarity;
        _drawMode = drawMode;
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
                        colorMap[y * _mapWidth + x] = _terrainType[i].color;
                        break;
                    }
                }
            }
        }

        if (_drawMode == DrawMode.ColourMap)
        {
            _mapDisplay.DrawTexture(TextureGenerator.TextureFromColourMap(colorMap , _mapWidth , _mapHeight));
            _interactableMap.SetTexture(_mapDisplay.GetTexture());
        }
        else if (_drawMode == DrawMode.NoiseMap)
        {
            _mapDisplay.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap));    
        }
        else if (_drawMode == DrawMode.SpriteMap)
        {
            
        }
    }

    public TerrainType[] GetTerrainType()
    {
        return _terrainType;
    }

    public void SetTerrainType(TerrainType terrainType)
    {
        for (int i = 0; i < _terrainType.Length; i++)
        {
            if (_terrainType[i].color == terrainType.color)
            {
                _terrainType[i] = terrainType;
                Debug.Log(terrainType.height);
                GenerateMap(_drawMode);
                return;
            }
        }
    }
    
    public int GetSeed()
    {
        return _seed;
    }

    public float GetNoiseScale()
    {
        return _noiseScale;
    }

    public int GetOctaves()
    {
        return _octaves;
    }

    public float GetPersistance()
    {
        return _persistance;
    }

    public float GetLacunarity()
    {
        return _lacunarity;
    }

    public DrawMode GetDrawMode()
    {
        return _drawMode;
    }
}

[Serializable] 
public enum DrawMode
{
    NoiseMap,
    ColourMap,
    SpriteMap
};
