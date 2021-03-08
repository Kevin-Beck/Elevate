using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTiles : MonoBehaviour
{
    [SerializeField] GameObject tile;
    float xMax;
    float xMin;
    float zMax;
    float zMin;
    float tileSizeX;
    float tileSizeZ;


    // Start is called before the first frame update
    void Start()
    {
        Transform planeTransform = GetComponent<Transform>();
        xMax = Mathf.Round(planeTransform.localScale.x)*5;
        zMax = Mathf.Round(planeTransform.localScale.z)*5;
        xMin = -xMax;
        zMin = -zMax;

        Transform tileTransform = tile.GetComponent<Transform>();
        tileSizeX = Mathf.Round(tileTransform.localScale.x);
        tileSizeZ = Mathf.Round(tileTransform.localScale.z);


        if(xMax*2 % tileSizeX != 0 || zMax*2 % tileSizeZ != 0)
        {
            Debug.Log("Cannot tile neatly on the board with tile in this space");
        }
        int rows = (int)(xMax*2 / tileSizeX);
        int columns = (int)(zMax*2 / tileSizeZ);

        Vector3 position = new Vector3(xMin + (tileSizeX / 2), 0, zMin + (tileSizeZ / 2));
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < columns; j++)
            {
                var currentTile = Instantiate(tile, position + new Vector3(i * tileSizeX, planeTransform.position.y-1.8f, j * tileSizeZ), Quaternion.identity);
                currentTile.GetComponent<Transform>().parent = planeTransform;
            }
        }        
    }    
}
