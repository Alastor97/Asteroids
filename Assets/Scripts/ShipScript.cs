using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    public LogicScript logic;
    public Rigidbody2D rb;
    public float moveSpeed;
    public float maxSpeed;
    public float brakeSpeed;
    public int life;
    public bool shipDestroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(rb.velocity.magnitude);
        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }

        if (logic.healthAmount <= 0f)
        {
            logic.gameOver();
        }
        else
        {
            rotateShipWithMouse();
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(transform.up * moveSpeed, ForceMode2D.Force);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(-transform.up * (moveSpeed * 0.5f), ForceMode2D.Force);
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                rb.velocity = rb.velocity * brakeSpeed;
                if(rb.velocity.magnitude < 0.0005f)
                {
                    rb.velocity = rb.velocity * 0;
                }
            }
        }
        
    }

    void rotateShipWithMouse()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.takeDamage(20f);
    }
}
