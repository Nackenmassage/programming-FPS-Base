using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridOfCubes : MonoBehaviour
{
    public int xLength = 1920;
    public int yLength = 1080;
    public Texture2D heightmap;
    public Vector3 size = new Vector3(100, 10, 100);

    GameObject[,] gameObjectGrid;

    private void Start()
    {
        gameObjectGrid = new GameObject[xLength, yLength];

        for (int x = 0; x < xLength; x++)
        {
            for (int z = 0; z < yLength; z++)
            {
                gameObjectGrid[x, z] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameObjectGrid[x, z].transform.position = new Vector3(x, 0f, z);
                int newX = Mathf.FloorToInt(x / size.x * heightmap.width);
                int newZ = Mathf.FloorToInt(z / size.z * heightmap.height);
                Vector3 pos = gameObjectGrid[x, z].transform.position;
                pos.y = heightmap.GetPixel(newX, newZ).grayscale * size.y;
                gameObjectGrid[x, z].transform.position = pos;
            }
        }

    }

    void Update()
    {
        //int x = Mathf.FloorToInt(transform.position.x / size.x * heightmap.width);
        //int z = Mathf.FloorToInt(transform.position.z / size.z * heightmap.height);
        //Vector3 pos = transform.position;
        //pos.y = heightmap.GetPixel(x, z).grayscale * size.y;
        //transform.position = pos;
    }
}
