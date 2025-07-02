using System;
using UnityEngine;

    public class InteractableMap : MonoBehaviour
    {
        [SerializeField] private Texture2D _texture;
        [SerializeField] private TerrainType[] _terrainTypes;
        [SerializeField] private int _brushSize = 1; 
        

        private void Update()
        {
            var mousePos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            Physics.Raycast(ray , out RaycastHit hit);
            //Debug.Log(hit.textureCoord);
            
            Vector2Int pixelPosition = new Vector2Int((int)(hit.textureCoord.x  *100), (int)(hit.textureCoord.y * 100));
            if (Input.GetMouseButton(0))
            {
                for (int i = 0; i < _brushSize; i++)
                {
                    for (int j = 0; j < _brushSize; j++)
                    {
                        _texture.SetPixel(pixelPosition.x + i,pixelPosition.y + j, Color.red);        
                    }
                }
                //_texture.SetPixel(pixelPosition.x,pixelPosition.y, Color.red);
                _texture.Apply();
            }
        }

        public void SetTexture(Texture2D texture)
        {
            _texture = texture;
        }
    }
