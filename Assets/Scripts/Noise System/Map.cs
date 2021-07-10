using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    [Header("Dimensions")]

    [SerializeField]
    private int width = 10;
    
    [SerializeField]
    private float scale = 0.5f;

    [SerializeField]
    private float offset;

    [Header("Height Map")]

    public float[] heightMap;

    [SerializeField]
    private bool updateOnValidate;

    [HideInInspector]
    public float seed;

    private void Start() => GenerateMap();

    private void OnValidate()
    {
        if (updateOnValidate)
            GenerateMap();
    }

    private void GenerateMap()
        => heightMap = NoiseGenerator.Generate(width, scale, offset, seed);

    public void GenerateSeed()
    {
        seed = Random.Range(0, 10000);
        GenerateMap();
    }
}
