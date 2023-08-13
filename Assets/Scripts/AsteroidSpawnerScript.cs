using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class AsteroidSpawnerScript : MonoBehaviour
{
    public int moveSpeedMin;
    public int moveSpeedMax;
    public int spawnRateMin;
    public int spawnRateMax;
    public int spawnRate;
    private float timer = 0;
    public GameObject asteroidPrefab;
    public float topPosition;
    public float bottomPosition;
    private Transform shipPosition;
    private float[] size = {0.75f, 0.5f, 0.25f, 1f};    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;

        }
        else
        {
            spawnAsteroidMoving();
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            timer = 0;

        }
    }

    void spawnAsteroidMoving()
    {
        shipPosition = GameObject.FindGameObjectWithTag("Ship").GetComponent<Transform>();
        
        GameObject asteroid = Instantiate(asteroidPrefab, new Vector3(transform.position.x, transform.position.y + Random.Range(bottomPosition, topPosition), 2.0f), transform.rotation);

        var sizeMultipler = Random.Range(0, 3);
        asteroid.transform.localScale = new Vector3(asteroid.transform.localScale.x * size[sizeMultipler], asteroid.transform.localScale.y * size[sizeMultipler], 1);

        Rigidbody2D myRigibody = asteroid.GetComponent<Rigidbody2D>();
        Vector3 dir = (shipPosition.position - myRigibody.transform.position).normalized;
        myRigibody.AddForce(dir * Random.Range(moveSpeedMin, moveSpeedMax), ForceMode2D.Impulse);

    }

    

}
