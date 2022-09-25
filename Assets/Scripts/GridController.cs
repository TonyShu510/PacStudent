using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridController : MonoBehaviour
{
    int[,] nextLevelData;
    int arrayWidth , arrayHeight;
    [SerializeField] GameObject[] prefab_list;
    [SerializeField] Canvas windowIn;

    // Start is called before the first frame update
    void Start()
    {
        //if add more level need change the code here
        nextLevelData = LevelGenerator.levelMap01;
        //GenerateGrid();

    }


    public void GenerateGrid()
    {
        arrayHeight = nextLevelData.GetLength(0);  //generate whole map
        arrayWidth = nextLevelData.GetLength(1);   

        for (int x = 0; x< arrayWidth; x++)//Row
        {
            for(int y = 0; y< arrayHeight; y++)//Coloum
            {
                for (int z = 0; z < 4; z++)//four area top left is A then clockwise BCD
                {
                    int targetTileNum = nextLevelData[y, x];
                    //skip duplicate
                    if (x == arrayWidth - 1 && (z == 1 || z == 2)) { } else if (y == arrayHeight && z > 2) { }else
                    {
                        if (targetTileNum > 0)
                        {
                            //set location based on area
                            int targetX = 0, targetY = 0;

                            if (z == 0)
                            {
                                targetX = x - arrayWidth + 1;
                                targetY = -(y - arrayHeight +1);
                            }
                            else if (z == 1)
                            {
                                targetX = -(x - arrayWidth + 1);
                                targetY = -(y - arrayHeight + 1);
                            }
                            else if (z == 2)
                            {
                                targetX = -(x - arrayWidth + 1);
                                targetY = (y - arrayHeight + 1);
                            }
                            else if (z == 3)
                            {
                                targetX = (x - arrayWidth + 1);
                                targetY = (y - arrayHeight + 1);
                            }

                            //add the prefab
                            var spawnedTile = Instantiate(prefab_list[targetTileNum], new Vector3(targetX * 0.32f, targetY * 0.32f), Quaternion.identity);
                            
                            //set a name for the variable
                            spawnedTile.name = $"Tile-Area{z} X:{x} Y:{y}";

                            //rotate if wall in left or right side
                            if (targetTileNum == 2 && y<arrayHeight-1 && y>0)
                            {
                                if(nextLevelData[y+1, x]==2 || nextLevelData[y-1, x] == 2)
                                {
                                    spawnedTile.transform.rotation = Quaternion.AngleAxis(90f, Vector3.forward);
                                }
                            }

                            spawnedTile.transform.SetParent(windowIn.transform, false);
                            spawnedTile.transform.localPosition = spawnedTile.transform.localPosition - new Vector3(0, 0.32f);

                            //spawnedTile.transform.localPosition = new Vector3(x * 0.32f, y * 0.32f);
                        }
                    }
                }
            }
        }
    }
}
