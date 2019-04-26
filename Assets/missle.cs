using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missle : MonoBehaviour {

    public float speed = 5;
    public bool isEnemy = false;

    private Rigidbody2D rb2d;


    void Start()
    {
        if (isEnemy) {
            transform.localRotation = Quaternion.Euler(0, 180, -90);
        }
        rb2d = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update () {
        Vector2 movement;
        if (!isEnemy){
            movement = new Vector2(1, 0);
        }
        else {
            movement = new Vector2(-1, 0);
        }

        rb2d.velocity = (movement * speed);
    }
}
