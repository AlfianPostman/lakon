using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    Vector2 worldSize = new Vector2(4, 4);
    Room[,] rooms;
    List<Vector2> takenPositions = new List<Vector2>();
    int gridSizeX, gridSizeY, numberOfRooms = 20;
    public GameObject roomWhiteObj, platformObj, targetCanvas;

    void Start ()
    {
        if (numberOfRooms >= (worldSize.x * 2) * (worldSize.y * 2))
        {
            numberOfRooms = Mathf.RoundToInt ((worldSize.x * 2) * (worldSize.y * 2));
        }
        gridSizeX = Mathf.RoundToInt(worldSize.x);
        gridSizeY = Mathf.RoundToInt(worldSize.y);
        
        CreateRooms();
        SetRoomDoors();
        DrawMap();
    }

    void CreateRooms() {
        // Setup
        rooms = new Room[gridSizeX * 2, gridSizeY * 2];
        rooms[gridSizeX, gridSizeY] = new Room(Vector2.zero, 1);
        takenPositions.Insert(0, Vector2.zero);
        Vector2 checkPos = Vector2.zero;

        // Magic Numbers for randomize
        float randomCompare = 0.2f;
        float randomCompareStart = 0.2f;
        float randomCompareEnd = 0.01f;

        // Add Rooms
        for (int i = 0; i < numberOfRooms -1; i++)
        {
            float randomPerc = ((float) i) / (((float)numberOfRooms -1));
            randomCompare = Mathf.Lerp(randomCompareStart, randomCompareEnd, randomPerc);
            
            checkPos = NewPosition();

            if (NumberofNeighbors(checkPos, takenPositions) > 1 && Random.value > randomCompare)
            {
                int iterations = 0;
                do {
                    checkPos = SelectiveNewPosition();
                    iterations++;
                } while (NumberofNeighbors(checkPos, takenPositions) > 1 && iterations < 100);

                if (iterations >= 50)
                {
                    print("error: could not create with fewer neighbors than : " + NumberofNeighbors(checkPos, takenPositions));
                }
            }

            //Finalize Position
            rooms[(int) checkPos.x + gridSizeX, (int) checkPos.y + gridSizeY] = new Room(checkPos, 0);
            takenPositions.Insert(0, checkPos);
        }
    }

    Vector2 NewPosition() 
    {
        int x = 0;
        int y = 0;

        Vector2 checkingPos = Vector2.zero;

        do
        {
            int index = Mathf.RoundToInt(Random.value * (takenPositions.Count -  1));
            x = (int) takenPositions[index].x;
            y = (int) takenPositions[index].y;
            bool TopBottom = (Random.value < 0.5f);
            bool positive = (Random.value < 0.5f);

            if (TopBottom)
            {
                if (positive)
                    y += 1;
                else
                    y -= 1;
            }
            else
            {
                if (positive)
                    x += 1;
                else
                    x -= 1;
            }
            checkingPos = new Vector2(x, y);
        } while (takenPositions.Contains(checkingPos) || x >= gridSizeX || x < -gridSizeX || y >= gridSizeY || y < -gridSizeY);
        return checkingPos;
    }

    Vector2 SelectiveNewPosition()
    {
        int index = 0;
        int inc = 0;
        int x = 0;
        int y = 0;

        Vector2 checkingPos = Vector2.zero;

        do
        {
            inc = 0;
            do
            {
                index = Mathf.RoundToInt(Random.value * (takenPositions.Count - 1));
                inc++;
            } while (NumberofNeighbors(takenPositions[index], takenPositions) > 1 && inc < 100);

            x = (int) takenPositions[index].x;
            y = (int) takenPositions[index].y;
            bool TopBottom = (Random.value < 0.5f);
            bool positive = (Random.value < 0.5f);

            if (TopBottom)
            {
                if (positive)
                    y += 1;
                else
                    y -= 1;
            }
            else
            {
                if (positive)
                    x += 1;
                else
                    x -= 1;
            }
            checkingPos = new Vector2(x, y);
        } while (takenPositions.Contains(checkingPos) || x >= gridSizeX || x < -gridSizeX || y >= gridSizeY || y < -gridSizeY);
        
        if (inc >= 100)
        {
            print("Error: could not find position with only one neighbor");
        }
        return checkingPos;
    }

    int NumberofNeighbors(Vector2 checkingPos, List<Vector2> usedPosition)
    {
        int ret = 0;
        if (usedPosition.Contains(checkingPos + Vector2.right))
            { ret++; }
        if (usedPosition.Contains(checkingPos + Vector2.left))
            { ret++; }
        if (usedPosition.Contains(checkingPos + Vector2.up))
            { ret++; }
        if (usedPosition.Contains(checkingPos + Vector2.down))
            { ret++; }
        return ret;
    }

    void SetRoomDoors() 
    {
        for (int x = 0; x < ((gridSizeX * 2)); x++)
        {
            for (int y = 0; y < ((gridSizeY * 2)); y++)
            {
                if (rooms[x, y] == null)
                {
                    continue;
                }
                Vector2 gridPosition = new Vector2(x,y);
                if (y - 1 < 0)
                    rooms[x, y].doorBot = false;
                else
                    rooms[x, y].doorBot = (rooms[x,y-1] != null);
                if (y + 1 >= gridSizeY * 2)
                    rooms[x, y].doorTop = false;
                else
                    rooms[x, y].doorTop = (rooms[x,y+1] != null);
                if (x - 1 < 0)
                    rooms[x, y].doorLeft = false;
                else
                    rooms[x, y].doorLeft = (rooms[x-1,y] != null);
                if (x + 1 >= gridSizeX * 2)
                    rooms[x, y].doorRight = false;
                else
                    rooms[x, y].doorRight = (rooms[x+1,y] != null);

            }
        }
    }
    void DrawMap() 
    {
        foreach (Room room in rooms)
        {
            if (room == null){
                continue;
            }
            
            Vector2 drawPos = room.gridPos;
            drawPos.x *= 1;
            drawPos.y *= 1;

            Vector3 drawPos2 = new Vector3(room.gridPos.x, 0, room.gridPos.y);
            drawPos2.x *= 30;
            drawPos2.z *= 30;
            
            // MapSpriteSelector mapper = Object.Instantiate(roomWhiteObj, drawPos, Quaternion.identity).GetComponent<MapSpriteSelector>();
            // mapper.top = room.doorTop;
            // mapper.bottom = room.doorBot;
            // mapper.right = room.doorRight;
            // mapper.left = room.doorLeft;
            
            PlatformSelector platter = Object.Instantiate(platformObj, drawPos2, Quaternion.identity).GetComponent<PlatformSelector>();
            platter.top = room.doorTop;
            platter.bottom = room.doorBot;
            platter.right = room.doorRight;
            platter.left = room.doorLeft;

            // mapper.transform.parent = targetCanvas.transform;
            platter.transform.parent = gameObject.transform;
        }
    }
}
