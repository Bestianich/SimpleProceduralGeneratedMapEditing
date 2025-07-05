using System;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;


public class BrushManager : MonoBehaviour
{
    Regex regex = new Regex("^[0-9]*$");

    public void ChangeBrushSize(TextMeshProUGUI textField)
    {
        Debug.Log(textField.text);
        Brush.size = int.Parse(textField.text.Remove(textField.text.Length - 1));
    }
}
