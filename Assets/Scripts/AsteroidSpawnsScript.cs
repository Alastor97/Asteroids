using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnsScript : MonoBehaviour
{
    private Transform shipPosition;

    void Start()
    {
        shipPosition = GameObject.FindGameObjectWithTag("Ship").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = shipPosition.position;
    }
}
