using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    private const long MAX_SEED = 1000;
    [SerializeField] private TMP_InputField _seedField;
    [SerializeField] private TMP_InputField _noiseField;
    [SerializeField] private TMP_InputField _octavesField;
    [SerializeField] private Slider _persistanceField;
    [SerializeField] private TMP_InputField _lacunarityField;
    private SettingsManager Instance;
    private DrawMode _drawMode;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
        
        // _seedField.text = MapGenerator.Instance.GetSeed();
        //
        // _noiseField.text = MapGenerator.Instance.GetNoiseScale() + "";
        // _octavesField.text = MapGenerator.Instance.GetOctaves().ToString();
        // _lacunarityField.text = MapGenerator.Instance.GetLacunarity().ToString();
        // _persistanceField.value = MapGenerator.Instance.GetPersistance();
    }

    public void SetDrawMode(int drawMode)
    {
        _drawMode = (DrawMode)drawMode;
        GenerateMap(false);
    }
    public void GenerateMap(bool random)
    { 
        if (random)
        {
            MapGenerator.Instance.GenerateMap((int)Random.Range(0, MAX_SEED) , Random.Range(0 , 100) , 4 , Random.Range(0 , 1) , Random.Range(0 , 20) , _drawMode);
        }
        else
        {
            MapGenerator.Instance.GenerateMap(_drawMode);
        }
    }
    
}
