using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    int width = 5;
    int height = 10;
    public GridElement GridElement;
    public GridElement[] GridElements;

    // Start is called before the first frame update
    void Start()
    {
        GridElements = new GridElement[width * width * height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < width; z++)
                {
                    GridElement GridElementInsance
                            = Instantiate(GridElement, new Vector3(x, y, z), Quaternion.identity, this.transform);
                    GridElementInsance.name = "GridElement" + x + "_" + y + "_" + z;
                    GridElements[x + width * (z + width * y)] = GridElementInsance;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
