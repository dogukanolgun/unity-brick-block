using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator instance;
    public int width = 5;
    public int height = 10;
    public GridElement GridElement;
    public GridElement[] GridElements;

    // Start is called before the first frame update
    void Start()
    {

        instance = this;

        GridElements = new GridElement[width * width * height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < width; z++)
                {
                    GridElement gridElementInsance
                            = Instantiate(GridElement, new Vector3(x, y, z), Quaternion.identity, this.transform);
                    gridElementInsance.Initialize(x, y, z);
                    GridElements[x + width * (z + width * y)] = gridElementInsance;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
