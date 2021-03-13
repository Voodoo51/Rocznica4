  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DungeonGenerator : MonoBehaviour
{
    [SerializeField]
    private ITilemap tilemap;

    [SerializeField]
    private Tile groundTile = null;
    [SerializeField]
    private Tile pitTile = null;
    [SerializeField]
    private Tile topWallTile = null;
    [SerializeField]
    private Tile botWallTile = null;
    [SerializeField]
    private Tilemap groundMap = null;
    [SerializeField]
    private Tilemap pitMap = null;
    [SerializeField]
    private Tilemap wallMap = null;
    [SerializeField]
    private GameObject player = null;
    [SerializeField]
    private int deviationRate = 10;
    [SerializeField]
    private int roomRate = 15;
    [SerializeField]
    private int maxRouteLength = 20;
    [SerializeField]
    private int maxRoutes = 20;
    

    private int routeCount = 0;

    [SerializeField]
    private int enemyCountToSpawn = 5;

    [SerializeField]
    private GameObject enemy = null;
    [SerializeField]
    private int enemyShotGunCountToSpawn;

    [SerializeField]
    private GameObject enemyShotGun = null;

    [SerializeField]
    private int chestCountToSpawn = 0;

    [SerializeField]
    private GameObject chest = null;

    [SerializeField]
    private GridLayout gridLayout = null;



    private void Start()
    {
        int x = 0;
        int y = 0;
        int routeLength = 0;
        GenerateSquare(x, y, 1);
        Vector2Int previousPos = new Vector2Int(x, y);
        y += 3;
        GenerateSquare(x, y, 1);
        NewRoute(x, y, routeLength, previousPos);

        

        FillWalls();
        SpawnThings();
    }

    private void FillWalls()
    {
        BoundsInt bounds = groundMap.cellBounds;
        for (int xMap = bounds.xMin - 10; xMap <= bounds.xMax + 10; xMap++)
        {
            for (int yMap = bounds.yMin - 10; yMap <= bounds.yMax + 10; yMap++)
            {
                Vector3Int pos = new Vector3Int(xMap, yMap, 0);
                Vector3Int posBelow = new Vector3Int(xMap, yMap - 1, 0);
                Vector3Int posAbove = new Vector3Int(xMap, yMap + 1, 0);
                TileBase tile = groundMap.GetTile(pos);
                TileBase tileBelow = groundMap.GetTile(posBelow);
                TileBase tileAbove = groundMap.GetTile(posAbove);
                if (tile == null)
                {
                    pitMap.SetTile(pos, pitTile);
                    if (tileBelow != null)
                    {
                        wallMap.SetTile(pos, topWallTile);
                    }
                    else if (tileAbove != null)
                    {
                        wallMap.SetTile(pos, botWallTile);
                    }
                }
            }
        }
    }

    private void SpawnThings()
    {
        BoundsInt bounds = groundMap.cellBounds;
        int enemyCount = 0;
        int enemyShotGunCount = 0;
        int chestCount = 0;
        
        
        while(enemyCount < enemyCountToSpawn)
        {
            Vector3Int pos = new Vector3Int(Random.Range(bounds.xMin,bounds.xMax), Random.Range(bounds.yMin,bounds.yMax), 0);
            TileBase tile = groundMap.GetTile(pos);
            Vector3 where = gridLayout.CellToWorld(pos);
             

            if(tile == groundTile)
            {
                if(Vector3.Distance(player.transform.position,where) > 2)
                {
                    GameObject enemyI = Instantiate(enemy,where,Quaternion.identity);
                    enemyCount++;
                }
            }
        }

        while(chestCount < chestCountToSpawn)
        {
            Vector3Int pos = new Vector3Int(Random.Range(bounds.xMin,bounds.xMax), Random.Range(bounds.yMin,bounds.yMax), 0);
            TileBase tile = groundMap.GetTile(pos);
            Vector3 where = gridLayout.CellToWorld(pos);
             

            if(tile == groundTile)
            {
                if(Vector3.Distance(player.transform.position,where) > 2)
                {
                    Instantiate(chest,where,Quaternion.identity);
                    chestCount++;
                }
            }
        }
        while(enemyShotGunCount < enemyShotGunCountToSpawn)
        {
            Vector3Int pos = new Vector3Int(Random.Range(bounds.xMin,bounds.xMax), Random.Range(bounds.yMin,bounds.yMax), 0);
            TileBase tile = groundMap.GetTile(pos);
            Vector3 where = gridLayout.CellToWorld(pos);
             

            if(tile == groundTile)
            {
                if(Vector3.Distance(player.transform.position,where) > 2)
                {
                    Instantiate(enemyShotGun,where,Quaternion.identity);
                    enemyShotGunCount++;
                }
            }
        }
        
    }

    private void NewRoute(int x, int y, int routeLength, Vector2Int previousPos)
    {
        if (routeCount < maxRoutes)
        {
            routeCount++;
            while (++routeLength < maxRouteLength)
            {
                //Initialize
                bool routeUsed = false;
                int xOffset = x - previousPos.x; //0
                int yOffset = y - previousPos.y; //3
                int roomSize = 1; //Hallway size
                if (Random.Range(1, 100) <= roomRate)
                    roomSize = Random.Range(3, 6);
                previousPos = new Vector2Int(x, y);

                //Go Straight
                if (Random.Range(1, 100) <= deviationRate)
                {
                    if (routeUsed)
                    {
                        GenerateSquare(previousPos.x + xOffset, previousPos.y + yOffset, roomSize);
                        NewRoute(previousPos.x + xOffset, previousPos.y + yOffset, Random.Range(routeLength, maxRouteLength), previousPos);
                    }
                    else
                    {
                        x = previousPos.x + xOffset;
                        y = previousPos.y + yOffset;
                        GenerateSquare(x, y, roomSize);
                        routeUsed = true;
                    }
                }

                //Go left
                if (Random.Range(1, 100) <= deviationRate)
                {
                    if (routeUsed)
                    {
                        GenerateSquare(previousPos.x - yOffset, previousPos.y + xOffset, roomSize);
                        NewRoute(previousPos.x - yOffset, previousPos.y + xOffset, Random.Range(routeLength, maxRouteLength), previousPos);
                    }
                    else
                    {
                        y = previousPos.y + xOffset;
                        x = previousPos.x - yOffset;
                        GenerateSquare(x, y, roomSize);
                        routeUsed = true;
                    }
                }
                //Go right
                if (Random.Range(1, 100) <= deviationRate)
                {
                    if (routeUsed)
                    {
                        GenerateSquare(previousPos.x + yOffset, previousPos.y - xOffset, roomSize);
                        NewRoute(previousPos.x + yOffset, previousPos.y - xOffset, Random.Range(routeLength, maxRouteLength), previousPos);
                    }
                    else
                    {
                        y = previousPos.y - xOffset;
                        x = previousPos.x + yOffset;
                        GenerateSquare(x, y, roomSize);
                        routeUsed = true;
                    }
                }

                if (!routeUsed)
                {
                    x = previousPos.x + xOffset;
                    y = previousPos.y + yOffset;
                    GenerateSquare(x, y, roomSize);
                }
            }
        }
    }

    private void GenerateSquare(int x, int y, int radius)
    {
        for (int tileX = x - radius; tileX <= x + radius; tileX++)
        {
            for (int tileY = y - radius; tileY <= y + radius; tileY++)
            {
                Vector3Int tilePos = new Vector3Int(tileX, tileY, 0);
                groundMap.SetTile(tilePos, groundTile);
            }
        }
    }
}