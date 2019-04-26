using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor : MonoBehaviour {

    public float speed = 1;

    private Rigidbody2D rb2d;


    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(-1, 0);

        rb2d.velocity = (movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {   

        /*if (!other.GetComponent<missle>().isEnemy){
            Destroy(other);
        }*/
    }
}
