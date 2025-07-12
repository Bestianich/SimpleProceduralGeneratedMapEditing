using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Slider = UnityEngine.UI.Slider;


public class ColorSlot : MonoBehaviour
{
    [SerializeField] private Image _colorImage;
    [SerializeField] private Slider _sliderLevel;
    [SerializeField] private TMP_InputField _fieldLevel;
    private TerrainType _terrainType;

    public TerrainType GetTerrainType()
    {
        return _terrainType;
    }

    public void SetTerrainType(TerrainType terrainType)
    {
        _colorImage.color = terrainType.color;
        _terrainType = terrainType;
    }
    
    public void GetSliderValue()
    {
        UpdateLevel(_sliderLevel.value);
    }

    public void GetFieldValue()
    {
       
        UpdateLevel(float.Parse(_fieldLevel.text));
    }
    public void UpdateLevel(float value)
    {
        value = Mathf.Clamp(value, 0,1);
        _sliderLevel.value = value;
        var str =  decimal.Parse(value.ToString("F2")).ToString("F2");
        _fieldLevel.text = str;
        _terrainType.height = float.Parse(str);
        MapGenerator.Instance.SetTerrainType(_terrainType);
    }
}