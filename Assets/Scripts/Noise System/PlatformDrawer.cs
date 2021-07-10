using System.Collections.Generic;
using UnityEngine;

public class PlatformDrawer : MonoBehaviour
{
    public Map map;

    [SerializeField]
    private GameObject platformPrefab;

    private float[] heightMap => map.heightMap;

    private List<GameObject> platforms = new List<GameObject>();

    public void DrawPlatforms()
    {
        for (int i = 0; i < platforms.Count; i++)
        {
            if (Application.isPlaying)
                Destroy(platforms[i]);
            else
                DestroyImmediate(platforms[i]);
        }

        platforms.Clear();

        for (int i = 0; i < heightMap.Length; i++)
        {
            float height = heightMap[i];
            height -= 0.5f;
            height *= (platformPrefab.transform.localScale.x / platformPrefab.transform.localScale.y) * 10f;

            Vector2 position = new Vector2((i - (heightMap.Length / 2f)) * platformPrefab.transform.localScale.x / 2.5f, height);
            platforms.Add(Instantiate(platformPrefab, position, Quaternion.identity));
        }

        for (int i = 0; i < platforms.Count; i++)
        {
            Transform platform = platforms[i].transform;
            if (i == (platforms.Count - 1))
            {
                platform.localRotation = platforms[i - 1].transform.localRotation;
                break;
            }

            Transform nextPlatform = platforms[i + 1].transform;

            Vector2 direction = nextPlatform.position - platform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            platform.localRotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
