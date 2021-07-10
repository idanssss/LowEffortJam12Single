using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    [SerializeField]
    private RawImage debugImage;

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

    private void Start() => DrawMap();

    private void OnValidate()
    {
        if (updateOnValidate)
            DrawMap();
    }

    private void DrawMap()
    {
        heightMap = NoiseGenerator.Generate(width, scale, offset, seed);

        Color[] pixels = new Color[width];

        for (int x = 0; x < width; x++)
            pixels[x] = Color.Lerp(Color.black, Color.white, heightMap[x]);

        Texture2D tex = new Texture2D(width, 1);
        tex.SetPixels(pixels);
        tex.filterMode = FilterMode.Point;
        tex.Apply();

        debugImage.texture = tex;
    }

    public void GenerateSeed()
    {
        seed = Random.Range(0, 10000);
        DrawMap();
    }
}
