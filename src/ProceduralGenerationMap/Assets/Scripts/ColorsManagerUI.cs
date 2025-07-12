using System.Collections.Generic;
using UnityEngine;

public class ColorsManagerUI : MonoBehaviour
{
    
    [SerializeField] private TerrainType[] _terrainType;
    [SerializeField] private ColorSlot _colorPrefab;
    [SerializeField] private  List<GameObject> _colorSlots;
    public static ColorsManagerUI Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        _terrainType = MapGenerator.Instance.GetTerrainType();
        GenerateColorSlot();
    }

    public void GenerateColorSlot()
    {
        foreach (var type in _terrainType)
        {
            var colorSlot = Instantiate(_colorPrefab, transform);
            colorSlot.UpdateLevel(type.height);
            colorSlot.SetTerrainType(type);
            Debug.Log(colorSlot);
            _colorSlots.Add(colorSlot.gameObject);
        }
    }
    
    
    
    
    
    
    
}
