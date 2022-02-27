using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator instance;
    public int width = 5;
    public int height = 10;
    public GridElement GridElement;
    public CornerElement cornerElement;
    public GridElement[] GridElements;
    public CornerElement[] cornerElements;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        GridElements = new GridElement[width * width * height];
        cornerElements = new CornerElement[(width + 1) * (width + 1) * (height + 1)];

        for (int y = 0; y < height + 1; y++)
        {
            for (int x = 0; x < width + 1; x++)
            {
                for (int z = 0; z < width + 1; z++)
                {
                    CornerElement cornerElementInsance
                            = Instantiate(cornerElement, Vector3.zero, Quaternion.identity, this.transform);
                    cornerElementInsance.Initialize(x, y, z);
                    cornerElements[x + (width + 1) * (z + (width + 1) * y)] = cornerElementInsance;
                }
            }
        }

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

        foreach (CornerElement corner in cornerElements)
        {
            corner.SetNearGridElements();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
