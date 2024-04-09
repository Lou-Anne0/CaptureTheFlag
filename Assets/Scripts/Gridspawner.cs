using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Random = System.Random;

// 1.534
public class Gridspawner : MonoBehaviour
{
    public GameObject[] simpleCases;
    public GameObject[] specialCases;
    public int size;
    public float gridSpacingOffset = 4f;
    public Vector3 gridOrigin = Vector3.zero;
    public GameObject flag;
    
    
    void Start()
    {
        SpawnGrid();
    }

    public void SpawnGrid()
    {
        //Placement cases spéciales
        int totcases = size*size;
        float calccasesspe = totcases * 0.15f;
        int nbspecialcases = (int)calccasesspe;
        int nbsimplecases = totcases - nbspecialcases;
        
        int[] placementlist = new int[nbspecialcases];
        int[] blockedlist = new int[totcases+1];
        print("nbspecialcases");
        print(nbspecialcases);
        

        for (int i = 0; i < nbspecialcases; i++)
        {
            Random rnd = new Random();
            int rIndex  = rnd.Next(size*2+1, totcases-2*size);
            
            while ((blockedlist[rIndex-1]>1)
                   || (blockedlist[rIndex+1]>1) 
                || (blockedlist[rIndex+size]>1)
                || (blockedlist[rIndex-size]>1))
            {
                rIndex  = rnd.Next(size*2+1, totcases-2*size);
            }
            

            placementlist[i] = rIndex;
            blockedlist[rIndex - 1] = blockedlist[rIndex - 1] + 1;
            blockedlist[rIndex + 1] = blockedlist[rIndex + 1] + 1;
            blockedlist[rIndex - size] = blockedlist[rIndex - size] + 1;
            blockedlist[rIndex + size] = blockedlist[rIndex + size] + 1;
        }
        

        

        //int startblock = 0;

        int counter = 1;
        int bib = 0;

        for (int x=1; x<size+1; x++)
        {
            for (int z = 1; z< size+1; z++)
            {
                if (placementlist.Contains(counter))
                {
                    Random rnd = new Random();
                    int rIndexcase  = rnd.Next(0, 2);
                    Vector3 spawnPosition = new Vector3((x-1) * gridSpacingOffset, 0, (z-1) * gridSpacingOffset) + gridOrigin;
                    GameObject clone = Instantiate(specialCases[rIndexcase], spawnPosition, Quaternion.identity);
                    counter = counter + 1;
                }
                
                else
                {
                    Vector3 spawnPosition = new Vector3((x-1) * gridSpacingOffset, 0, (z-1) * gridSpacingOffset) + gridOrigin;
                    
                    if ((counter<=2*size) || (counter>size*(size-2)))
                    {
                        if (counter <= 2 * size)
                        {
                            GameObject clone = Instantiate(simpleCases[2], spawnPosition, Quaternion.identity);
                        }
                        else
                        {
                            GameObject clone = Instantiate(simpleCases[3], spawnPosition, Quaternion.identity);
                        }
                    }
                    else
                    {
                        if ((IsDivisible(x,2)) && (IsDivisible(z,2)))
                        {
                            GameObject clone = Instantiate(simpleCases[0], spawnPosition, Quaternion.identity);
                            
                        }
                        if (!(IsDivisible(x,2)) && !(IsDivisible(z,2)))
                        {
                            GameObject clone = Instantiate(simpleCases[0], spawnPosition, Quaternion.identity);
                        }
                        if (!(IsDivisible(x,2)) && (IsDivisible(z,2)))
                        {
                            GameObject clone = Instantiate(simpleCases[1], spawnPosition, Quaternion.identity);
                            
                        }
                        if ((IsDivisible(x,2)) && !(IsDivisible(z,2)))
                        {
                            GameObject clone = Instantiate(simpleCases[1], spawnPosition, Quaternion.identity);
                        }
                    }
                        

                    counter = counter + 1;


                }
                
            }
        }

        for (int i = 0; i < size + 2; i++)
        {
            Vector3 spawnPosition = new Vector3(-gridSpacingOffset, 0,  (i-1)*gridSpacingOffset) + gridOrigin;
            GameObject clone = Instantiate(specialCases[0], spawnPosition, Quaternion.identity);
        }
        
        for (int i = 0; i < size + 2; i++)
        {
            Vector3 spawnPosition = new Vector3(size*gridSpacingOffset, 0,  (i-1)*gridSpacingOffset) + gridOrigin;
            GameObject clone = Instantiate(specialCases[0], spawnPosition, Quaternion.identity);
        }
        
        for (int i = 0; i < size ; i++)
        {
            Vector3 spawnPosition = new Vector3(i*gridSpacingOffset, 0,  -gridSpacingOffset) + gridOrigin;
            GameObject clone = Instantiate(specialCases[0], spawnPosition, Quaternion.identity);
        }
        
        for (int i = 0; i < size ; i++)
        {
            Vector3 spawnPosition = new Vector3(i*gridSpacingOffset, 0,  size*gridSpacingOffset) + gridOrigin;
            GameObject clone = Instantiate(specialCases[0], spawnPosition, Quaternion.identity);
        }
        
        Vector3 spawnPositionh = new Vector3(gridSpacingOffset*3, 1.534f,  (size/2)*gridSpacingOffset) + gridOrigin;
        GameObject clonef = Instantiate(flag, spawnPositionh, Quaternion.identity);
    }

    public bool IsDivisible(int a, int b)
    {
        return (a % b) == 0;
    }
    
}
