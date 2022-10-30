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
    [SerializeField] GameObject[] skull_prefab_list;
    [SerializeField] GameObject red_Wizard_Prefab;

    // Start is called before the first frame update
    void Start()
    {
        //if add more level need change the code here
        nextLevelData = LevelGenerator.levelMap01;
        GenerateGrid();

    }


    public void GenerateGrid()
    {

        // map size
        arrayHeight = nextLevelData.GetLength(0);  
        arrayWidth = nextLevelData.GetLength(1);   
        //level generate
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


        //element generate
        //red Wizard in top left
        var redWizard = Instantiate(red_Wizard_Prefab, new Vector3((arrayHeight-3)*-0.32f, (arrayWidth-2)*0.32f, 0), Quaternion.identity);
        redWizard.transform.SetParent(windowIn.transform, false);
        redWizard.transform.localPosition = redWizard.transform.localPosition;

        
        var skull01 = Instantiate(skull_prefab_list[0], new Vector3((0)*-0.32f, (1)*0.32f, 0), Quaternion.identity);
        skull01.transform.SetParent(windowIn.transform, false);
        skull01.transform.localPosition = skull01.transform.localPosition - new Vector3(0, 0.32f);

        var skull02 = Instantiate(skull_prefab_list[1], new Vector3((0)*-0.32f, (-1)*0.32f, 0), Quaternion.identity);
        skull02.transform.SetParent(windowIn.transform, false);
        skull02.transform.localPosition = skull02.transform.localPosition - new Vector3(0, 0.32f);
        
        var skull03 = Instantiate(skull_prefab_list[2], new Vector3((1)*-0.32f, (0)*0.32f, 0), Quaternion.identity);
        skull03.transform.SetParent(windowIn.transform, false);
        skull03.transform.localPosition = skull03.transform.localPosition - new Vector3(0, 0.32f);
        
        var skull04 = Instantiate(skull_prefab_list[3], new Vector3((-1)*-0.32f, (0)*0.32f, 0), Quaternion.identity);
        skull04.transform.SetParent(windowIn.transform, false);
        skull04.transform.localPosition = skull04.transform.localPosition - new Vector3(0, 0.32f);

    }



}
