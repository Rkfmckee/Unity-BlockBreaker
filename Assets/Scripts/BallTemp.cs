using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTemp : MonoBehaviour {
    private Paddle paddle;
    private Ball ball;

	void Start() {
        paddle = GameObject.FindObjectOfType<Paddle>();
        ball = GameObject.FindObjectOfType<Ball>();
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), paddle.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), ball.GetComponent<Collider2D>());

        float randomLeft = Random.value * 15;
        float randomRight = Random.value * 15;
        this.GetComponent<Rigidbody2D>().velocity = (Vector2.up * 10) + ((Vector2.left * randomLeft) + (Vector2.right * randomRight));
    }
}
