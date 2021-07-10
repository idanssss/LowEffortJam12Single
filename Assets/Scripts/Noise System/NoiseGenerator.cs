using UnityEngine;

public class NoiseGenerator : MonoBehaviour
{
    public static float[] Generate(int width, float scale, float offset, float seed)
    {
        float[] noiseMap = new float[width];

        for (int x = 0; x < width; x++)
        {
            float samplePosX = x * scale + offset;
            noiseMap[x] = Mathf.PerlinNoise(samplePosX + seed, 0);
        }

        return noiseMap;
    }
}
