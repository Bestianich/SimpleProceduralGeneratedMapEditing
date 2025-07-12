using UnityEngine;

public static class Noise
{
    public static float[,] GenerateNoiseMap(int width, int height , float scale , int seed, int octaves, float persistance , float lacunarity)
    {

        if (scale <= 0)
        {
            scale = 0.001f;
        }
        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;
        float[,] noiseMap = new float[width, height];

        // for (int y = 0; y < height; y++)
        // {
        //     for (int x = 0; x < width; x++)
        //     {
        //         float sampleX = x / scale;
        //         float sampleY = y / scale;
        //         float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
        //         noiseMap[x, y] = perlinValue;
        //         
        //     }
        // }
        //
        // return noiseMap;
        //
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;
                for (int i = 0; i < octaves; i++)
                {
                    float sampleX = x / scale * frequency;
                    float sampleY = y / scale * frequency;
                    float perlinValue = Mathf.PerlinNoise(sampleX + seed, sampleY + seed) * 2 - 1;
                    noiseHeight += perlinValue * amplitude;
                    noiseMap[x, y] = perlinValue;
                    amplitude *= persistance;
                    frequency *= lacunarity;
                }
        
                if (noiseHeight > maxNoiseHeight)
                {
                    maxNoiseHeight = noiseHeight;
                } else if (noiseHeight < minNoiseHeight)
                {
                    minNoiseHeight = noiseHeight;
                }
                noiseMap[ x , y] = noiseHeight; 
        
            }
        }
        
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);
            }
        }
        
        return noiseMap;
    }
}
