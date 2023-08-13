using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnsScript : MonoBehaviour
{
    private Transform shipPosition;
    public GameObject asteroidPrefab;
    private float[] size = { 0.75f, 0.5f, 0.25f, 1f };
    void Start()
    {
        shipPosition = GameObject.FindGameObjectWithTag("Ship").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = shipPosition.position;
    }

    // Spawnea 
    public void spawnAsteroids(int xLimit, int yLimit)
    {
        for (int i = 0; i < 50; i++)
        {

            Vector3 pos = new Vector3(Random.Range(-xLimit, xLimit), Random.Range(-yLimit, yLimit), 2);
            var newAsteroid = Instantiate(asteroidPrefab, pos, Quaternion.identity, GameObject.Find("Background").transform);
            var sizeMultipler = Random.Range(0, 3);
            newAsteroid.transform.localScale = new Vector3(newAsteroid.transform.localScale.x * size[sizeMultipler], newAsteroid.transform.localScale.y * size[sizeMultipler], 1);
            var anim = newAsteroid.GetComponent<Animator>();
            anim.speed = Random.Range(0.5f, 1.5f);
        }
    }
}
