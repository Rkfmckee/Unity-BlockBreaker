using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private bool gameStarted = false;
    private int minSpeed = 8, maxSpeed = 10;

    // Use this for initialization
    void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
	}

    // Update is called once per frame
    void Update() {
        if (!gameStarted) {
            this.transform.position = paddle.transform.position + paddleToBallVector;

            if (Input.GetMouseButtonDown(0)) {
                float randomLeft = Random.value*5;
                float randomRight = Random.value * 5;
                this.GetComponent<Rigidbody2D>().velocity = (Vector2.up * 10) + ((Vector2.left * randomLeft) + (Vector2.right * randomRight));
                gameStarted = true;
            }
        } else {
            if (GetComponent<Rigidbody2D>().velocity.magnitude >= maxSpeed) {
                GetComponent<Rigidbody2D>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody2D>().velocity, maxSpeed);
            }
        }
        print(GetComponent<Rigidbody2D>().velocity.magnitude);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak;
        if (GetComponent<Rigidbody2D>().velocity.y > 0) {
            velocityTweak = new Vector2(Random.Range(-.4f, .4f), Random.Range(0f, .4f));
        } else {
            velocityTweak = new Vector2(Random.Range(-.4f, .4f), Random.Range(-.4f, 0f));
        }

        if (gameStarted) {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += velocityTweak;
        }
    }
}
