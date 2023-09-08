using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform vehicleTransform;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 5, -7);

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = vehicleTransform.position + offset;

    }
}
