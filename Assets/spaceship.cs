using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceship : MonoBehaviour
{
    public GameObject missle;
    public float speed;
    public GameObject gameOver;

    private int lives = 5;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            missle.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z);
            missle.GetComponent<missle>().isEnemy = false;
            Instantiate(missle);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.GetComponent<meteor>() != null) {
            Destroy(other.gameObject);
            lives--;
            StartCoroutine("changeColor");
        }


        if (other.GetComponent<missle>().isEnemy)
        {
            Destroy(other.gameObject);
            lives--;
            StartCoroutine("changeColor");
        }

        if (lives < 1)
        {
            Instantiate(gameOver);
            Destroy(this.gameObject);
            
        }
    }

    private void OnGUI()
    {
        GUILayout.Label("Lives: " + lives.ToString());

    }

    IEnumerator changeColor(){
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(1.0f);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
