using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletScript : MonoBehaviour
{
    public float lifeTime;
    private float timer = 0f;
    void Start()
    {
         
    }

    void Update()
    {
        if(timer < lifeTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
