using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*****
 * component of the player
 * 
 * 
 * 
 * Alex Collier-Lake
 **********/


public class Boundary : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        if (x >= 186)
        {
            transform.position = new Vector3(186, y, z);
        }

        if (x <= 35)
        {
            transform.position = new Vector3(35, y, z);
        }
    }


}
