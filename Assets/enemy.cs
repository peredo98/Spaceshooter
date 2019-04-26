using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    public float speed = 3;
    private int lives = 3;

    public float verticalVelociy = 0;
    private Rigidbody2D rb2d;
    public GameObject missle;

    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine("shoot");
        StartCoroutine("changeVelocity");
    }


    // Update is called once per frame
    void Update()
    {

        Vector2 movement = new Vector2(-1, verticalVelociy);

        rb2d.velocity = (movement * speed);

    }

    IEnumerator changeVelocity() {
        yield return new WaitForSeconds(0.5f);
        float randomVal = Random.Range(-1.0f, 1.0f);
        verticalVelociy = randomVal;
        StartCoroutine("changeVelocity");
    }

    IEnumerator shoot() {
        yield return new WaitForSeconds(1.5f);
        missle.transform.position = this.transform.position;
        missle.GetComponent<missle>().isEnemy = true;
        Instantiate(missle);
        StartCoroutine("shoot");
    }

    void OnTriggerEnter2D(Collider2D other)
    {


        if (!other.GetComponent<missle>().isEnemy)
        {
            Destroy(other.gameObject);
            lives--;
        }

        if (lives < 1)
        {
            Destroy(this.gameObject);
        }
    }


}
