using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorMovement : MonoBehaviour
{
    RaycastHit hit;
    Ray ray;
    GridElement lastHit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) && hit.collider.tag == "GridElement")
        {
            Debug.Log(hit.collider.name);
            this.transform.position = hit.collider.transform.position;
            lastHit = hit.collider.gameObject.GetComponent<GridElement>();

            if (Input.GetMouseButtonDown(1))
            {
                SetCursorButton(0);
            }
        }
    }
    public void SetCursorButton(int input)
    {
        Coord coord = lastHit.GetCoord();
        int width = LevelGenerator.instance.width;
        int height = LevelGenerator.instance.height;

        switch (input)
        {
            case 0:
                // remove gridElement
                lastHit.SetDisable();
                break;
            case 1:
                // add X+
                if (coord.x < width - 1)
                {
                    Debug.Log("X+");
                    LevelGenerator
                        .instance
                        .GridElements[coord.x + 1 + width * (coord.z + width * coord.y)]
                        .SetEnable();
                }
                break;
            case 2:
                // add X-
                if (coord.x > 0)
                    LevelGenerator
                        .instance
                        .GridElements[coord.x - 1 + width * (coord.z + width * coord.y)]
                        .SetEnable();
                break;
            case 3:
                // add Z+
                if (coord.z < width - 1)
                    LevelGenerator
                        .instance
                        .GridElements[coord.x + width * (coord.z + 1 + width * coord.y)]
                        .SetEnable();
                break;
            case 4:
                // add Z-
                if (coord.z > 0)
                    LevelGenerator
                        .instance
                        .GridElements[coord.x + width * (coord.z - 1 + width * coord.y)]
                        .SetEnable();
                break;
            case 5:
                // add Y+
                if (coord.y < height - 1)
                    LevelGenerator
                        .instance
                        .GridElements[coord.x + width * (coord.z + width * (coord.y + 1))]
                        .SetEnable();
                break;

        }
    }
}
