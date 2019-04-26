using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceship : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb2d;


    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
      
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(0, moveVertical);

        rb2d.velocity = (movement * speed);
    }

}
