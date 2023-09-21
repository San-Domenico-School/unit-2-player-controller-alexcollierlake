using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * attached to the camera to keep it above and behind the vehicle.
 * 
 * Alexandra Collier-Lake
 * September 12, 2023
 */

public class CameraController : MonoBehaviour
{
    [Tooltip("Drag Vehicle onto Vehicle Transform")]
    [SerializeField] private Transform vehicleTransform; //keep track of vehicle position
    private Vector3 offset; //distance camera is from vehicle

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 5, -7);

    }

    // Update is called once per frame just after update
    void LateUpdate()
    {
        if(vehicleTransform.gameObject != null)
            transform.position = vehicleTransform.position + offset;

    }
}
