using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum Algoritmo
{
    PerlinNoise,
    PerlinNoiseSuavizado
}

public class Generator : MonoBehaviour
{
    [Header("Referencias")]
    public Tilemap tileMap;
    public TileBase tile;

    [Header("Dimensiones")]
    public int Ancho = 60;
    public int Alto = 34;

    [Header("Semilla")]
    public bool SemillaAleatoria = true;
    public float Semilla = 0;

    [Header("Algoritmo")]
    public Algoritmo algoritmo = Algoritmo.PerlinNoise;


    [Header("Perlin Noise Suavizado")]
    public int Intervalo = 2;


    // Start is called before the first frame update
    public void GenerateMap()
    {
        tileMap.ClearAllTiles();
        int[,] mapa;

        if (SemillaAleatoria)
        {
            Semilla = Random.Range(0f,1000f);
        }

        switch (algoritmo)
        {
            case Algoritmo.PerlinNoise:
                mapa = Methods.GenerateArray(Ancho, Alto, true);
                mapa = Methods.PerlinNoise(mapa, Semilla);
                Methods.GenerateMap(mapa, tileMap, tile);
                break;
            case Algoritmo.PerlinNoiseSuavizado:
                mapa = Methods.GenerateArray(Ancho, Alto, true);
                mapa = Methods.PerlinNoiseSuavizado(mapa, Semilla, Intervalo);
                Methods.GenerateMap(mapa, tileMap, tile);
                break;
            default:
                break;
        }

        //Methods.GenerateMap(mapa, tileMap, tile);
        //int[,] mapa = Methods.GenerateArray(Ancho, Alto, false);
        //Methods.GenerateMap(mapa,tileMap,tile);
    }

    public void ClearMap()
    {
        tileMap.ClearAllTiles();
    }
}
