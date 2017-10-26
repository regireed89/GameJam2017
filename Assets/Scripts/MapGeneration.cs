using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Coord
{
    public int tileX;
    public int tileY;
    public bool isWall;

    public Coord(int x, int y, bool wall)
    {
        tileX = x;
        tileY = y;
        isWall = wall;
    }
}


public class MapGeneration : MonoBehaviour
{

    public int width;
    public int height;
    public int numOfCoords;

    public List<Coord> tiles;

    public void GenerateMap()
    {
        tiles = new List<Coord>();
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x <= width && y <= height)
                {

                    tiles.Add(new Coord(x, y, false));
                    Debug.DrawLine(new Vector3(0, 0, 0), CoordToVector(tiles[numOfCoords]), Color.green, 500);
                    numOfCoords++;
                }
            }
        }
        DFS(tiles);
    }

    public Vector3 CoordToVector(Coord tile)
    {
        Vector3 point = new Vector3(-width / 2 + .5f + tile.tileX, 0, -height / 2 + .5f + tile.tileY);
        return point;
    }

    public void DFS(List<Coord> map)
    {
        int currentIndex = 0;
        List<Coord> walledMap = new List<Coord>();
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Coord mapCoord = map[currentIndex];
                Coord front = new Coord(mapCoord.tileX, mapCoord.tileY + 1, false);
                Coord back = new Coord(mapCoord.tileX, mapCoord.tileY -1, false);
                Coord left = new Coord(mapCoord.tileX -1, mapCoord.tileY, false);
                Coord right = new Coord(mapCoord.tileX + 1, mapCoord.tileY, false);
                
                int rand = UnityEngine.Random.Range(0, 4);
                switch (rand)
                {
                    case 0: //forward or up
                        front.isWall = true;
                        break;
                    case 1: //back or down
                        back.isWall = true;
                        break;
                    case 2: //left
                        left.isWall = true;
                        break;
                    case 3: //right
                        right.isWall = true;
                        break;
                }
                currentIndex++;
                for (int i = 0; i < numOfCoords; i++)
                {
                    if (map[i].tileX == front.tileX && map[i].tileY == front.tileY)
                        mapCoord = front;
                    if (map[i].tileX == back.tileX && map[i].tileY == back.tileY)
                        mapCoord = back;
                    if (map[i].tileX == left.tileX && map[i].tileY == left.tileY)
                        mapCoord = left;
                    if (map[i].tileX == right.tileX && map[i].tileY == right.tileY)
                        mapCoord = right;
                    walledMap.Add(mapCoord);
                }
            }
        }
    }

    void Start()
    {
        GenerateMap();
    }
}
