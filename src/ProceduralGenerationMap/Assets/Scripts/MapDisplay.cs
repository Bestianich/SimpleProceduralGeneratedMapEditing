using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    [SerializeField] private Renderer _textureRenderer;

    public void DrawTexture(Texture2D texture)
    {
       
        _textureRenderer.material.mainTexture = texture;
        _textureRenderer.transform.localScale = new Vector3(texture.width, 1, texture.height);
    }

    public Texture2D GetTexture()
    {
        return _textureRenderer.material.mainTexture as Texture2D;
    }
}
