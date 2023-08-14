using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletSpawnerScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRate;
    public float spawnTime;
    private float timer = 0;
    public float bulletForce;
    public LogicScript logic;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(logic.healthAmount > 0f)
        {
            if (Input.GetMouseButton(0))
            {
                if (timer < spawnRate)
                {
                    timer = timer + Time.deltaTime;
                }
                else
                {
                    GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 2.0f), transform.rotation);
                    Rigidbody2D myRigibody = bullet.GetComponent<Rigidbody2D>();
                    myRigibody.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
                    timer = 0;
                }
            }
        }
        
    }
}
