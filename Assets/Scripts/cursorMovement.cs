using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorMovement : MonoBehaviour
{
    RaycastHit hit;
    Ray ray;
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
        }
    }
}
