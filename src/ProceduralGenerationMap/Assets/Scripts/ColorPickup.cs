using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ColorPickup : MonoBehaviour, IPointerClickHandler
{
    private Color _color;

    private void Start()
    { 
        _color = GetComponentInParent<ColorSlot>().GetTerrainType().color;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
        Brush.color = _color;
    }
}