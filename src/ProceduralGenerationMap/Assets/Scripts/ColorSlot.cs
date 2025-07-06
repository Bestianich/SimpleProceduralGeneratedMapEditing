using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;


public class ColorSlot : MonoBehaviour
{
    [SerializeField] private Slider _sliderLevel;
    [SerializeField] private TMP_InputField _fieldLevel;

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
        Debug.Log(value.ToString("F2"));
        _sliderLevel.value = value;
        var str =  decimal.Parse(value.ToString("F2")).ToString("F2");
        _fieldLevel.text = str;
        
    }
}