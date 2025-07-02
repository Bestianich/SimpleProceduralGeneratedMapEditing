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
            Debug.Log(hit.textureCoord);
            Vector2 pixelPosition = new Vector2(hit.textureCoord.x , hit.textureCoord.y);
            if (Input.GetMouseButtonDown(0))
            {
                foreach (Color pixel in _texture.GetPixels())
                {
                    pixel = new Color(0, 0, 0, 0);
                }
                _texture.SetPixel((int)pixelPosition.x, (int)pixelPosition.y, Color.red);
            }
        }

        public void SetTexture(Texture2D texture)
        {
            _texture = texture;
        }
    }
