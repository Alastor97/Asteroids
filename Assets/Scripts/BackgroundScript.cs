using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public GameObject star;
    public GameObject asteroid;
    public AsteroidSpawnsScript asteroidSpawner;
    public int xLimit;
    public int yLimit;

    private void Start()
    {
        spawnAsteroid();
    }

    private void spawnAsteroid()
    {
        asteroidSpawner = GameObject.FindGameObjectWithTag("Asteroid Spawner").GetComponent<AsteroidSpawnsScript>();
        asteroidSpawner.spawnAsteroids(xLimit, yLimit);
        for (int i = 0; i < 100; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-xLimit, xLimit), Random.Range(-yLimit, yLimit), 3);
            var newStar = Instantiate(star, pos, Quaternion.identity, GameObject.Find("Background").transform);


            var anim = newStar.GetComponent<Animator>();
            anim.speed = Random.Range(0.5f, 1.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
