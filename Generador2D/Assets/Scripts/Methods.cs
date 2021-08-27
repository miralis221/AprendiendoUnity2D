using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Methods
{
    /// <summary>
    /// Genera un array bidimensional
    /// </summary>
    /// <param name="ancho">ancho del mapa 2D</param>
    /// <param name="alto">alto del mapa 2D</param>
    /// <param name="vacio">verdadero si queremos iniciar a 0, si no, todo a 1</param>
    /// <returns>Devuelve el mapa 2D generado</returns>
    public static int[,] GenerateArray(int ancho,int alto, bool vacio)
    {
        int[,] mapa = new int[ancho, alto];
        for (int x = 0; x < ancho; x++)
        {
            for (int y = 0; y < alto; y++)
            {
                if (vacio)
                {
                    mapa[x, y] = 0;
                }
                else
                {
                    mapa[x, y] = 1;
                }

            }
        }
        return mapa;
    } 
    /// <summary>
    /// Genera el mapa de tiles con la informacion indicada en "mapa"
    /// </summary>
    /// <param name="mapa">informacion que se utilizara para generar el mapa de tiles</param>
    /// <param name="tileMap">Hace referencia al mapa de tiles donde se generara el mapa</param>
    /// <param name="tile">Lo que se utilizara para generar el mapa</param>
    public static void GenerateMap(int[,] mapa, Tilemap tileMap, TileBase tile)
    {
        // Limpiar el mapa de casillas para empezar con uno vacio
        tileMap.ClearAllTiles();

        for (int x = 0; x < mapa.GetUpperBound(0); x++)
        {
            for (int y = 0; y < mapa.GetUpperBound(1); y++)
            {
                if (mapa[x,y] == 1)
                {
                    tileMap.SetTile(new Vector3Int(x,y,0),tile);
                }
            }
        }
    }

    public static int[,] PerlinNoise(int[,] mapa, float semilla)
    {
        int newPoint;

        float reduction = 0.5f;

        for (int X = 0; X < mapa.GetUpperBound(0); X++)
        {
            newPoint = Mathf.FloorToInt((Mathf.PerlinNoise(X, semilla) - reduction) * mapa.GetUpperBound(1));
            newPoint += (mapa.GetUpperBound(1) / 2);
            for (int y = newPoint; y >= 0; y--)
            {
                mapa[X, y] = 1;
            }
        }
        return mapa;
    }

    /// <summary>
    /// Modifica el mapa creando un terreno usando Perlin Noise
    /// </summary>
    /// <param name="mapa"> El mapa que vamos a editar</param>
    /// <param name="semilla"> La semilla para la generacion del PerlinNoise</param>
    /// <param name="interval"> El intervalo en el que grabaremos la altura</param>1
    /// <returns> El mapa modificado</returns>
    public static int[,] PerlinNoiseSuavizado(int[,] mapa, float semilla, int interval)
    {
        if (interval > 1)
        {
            Vector2Int actualPos, antPos;
            List<int> ruidoX = new List<int>();
            List<int> ruidoY = new List<int>();

            int newPoint, points;

            // Genera el ruido
            for (int x = 0; x < mapa.GetUpperBound(0); x+= interval)
            {
                newPoint = Mathf.FloorToInt(Mathf.PerlinNoise(x,semilla)* mapa.GetUpperBound(1));
                ruidoY.Add(newPoint);
                ruidoX.Add(x);
            }
            points = ruidoY.Count;

            for (int i = 1; i < points; i++)
            {
                actualPos = new Vector2Int(ruidoX[i],ruidoY[i]);
                antPos = new Vector2Int(ruidoX[i - 1], ruidoY[i - 1]);

                Vector2 diference = actualPos - antPos;
                float cambioEnAltura = diference.y / interval;
                float alturaActual = antPos.y;

                for (int x = antPos.x; x < actualPos.x && x < mapa.GetUpperBound(0); x++)
                {
                    for (int y = Mathf.FloorToInt(alturaActual); y >= 0; y--)
                    {
                        mapa[x, y] = 1;
                    }
                    alturaActual += cambioEnAltura;
                }

            }
        }
        else
        {
            mapa = PerlinNoise(mapa,semilla);
        }

        return mapa;
    }

    public static int[,] RandomWalk(int[,] mapa, float semilla)
    {

        return mapa;
    }

}
