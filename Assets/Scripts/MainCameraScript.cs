using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    private Transform shipPosition;
    void Start()
    {
        shipPosition = GameObject.FindGameObjectWithTag("Ship").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(shipPosition.position.x, shipPosition.position.y, transform.position.z);
    }
}
