using System;
using UnityEngine;

    public class InteractableMap : MonoBehaviour
    {
        [SerializeField] Texture2D _texture;
        [SerializeField] TerrainType[] _terrainTypes;
        

        private void Update()
        {
            var mousePos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            Physics.Raycast(ray , out RaycastHit hit);
            //Debug.Log(hit.textureCoord);
            
            Vector2Int pixelPosition = new Vector2Int((int)(hit.textureCoord.x  *100), (int)(hit.textureCoord.y * 100));
            if (Input.GetMouseButtonDown(0))
            {
                
                _texture.SetPixel(pixelPosition.x,pixelPosition.y, Color.red);
                _texture.Apply();
            }
        }

        public void SetTexture(Texture2D texture)
        {
            _texture = texture;
        }
    }
