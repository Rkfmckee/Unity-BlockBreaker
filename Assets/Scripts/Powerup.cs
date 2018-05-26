using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {
    public float chanceOfSpawn;
    public enum Type {ONE_BALL, FIVE_BALL, BIG_PADDLE, GREEN_YELLOW, INSANE };
    public Type type;

    private Paddle paddle;

    private void Start()
    {
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), FindObjectOfType<Ball>().GetComponent<Collider2D>());
        paddle = GameObject.FindObjectOfType<Paddle>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Paddle") {
            switch(type) {
                case (Type.ONE_BALL):
                    ActivateOneBall();
                    break;
                case (Type.FIVE_BALL):
                    ActivateFiveBall();
                    break;
                case (Type.BIG_PADDLE):
                    ActivateBigPaddle();
                    break;
                case (Type.GREEN_YELLOW):
                    ActivateGreenYellow();
                    break;
                case (Type.INSANE):
                    ActivateInsane();
                    break;
            }
        }
    }

    private void ActivateOneBall() {
        Instantiate(Resources.Load("Prefabs/BallTemp"), new Vector2(paddle.transform.position.x, paddle.transform.position.y), transform.rotation);
    }

    private void ActivateFiveBall() {
        for (int i = 0; i < 5; i++) {
            Instantiate(Resources.Load("Prefabs/BallTemp"), new Vector2(paddle.transform.position.x, paddle.transform.position.y), transform.rotation);
        }
    }

    private void ActivateBigPaddle() {

    }

    private void ActivateGreenYellow() {
        GameObject[] greenBricks = GameObject.FindGameObjectsWithTag("BreakableGreen");
        foreach (GameObject brick in greenBricks) {
            int timesHit = brick.GetComponent<Brick>().GetTimesHit();
            Destroy(brick.gameObject);
            GameObject newBrick = (GameObject)Instantiate(Resources.Load("Prefabs/Blocks/Block - Yellow"), new Vector2(brick.transform.position.x, brick.transform.position.y), transform.rotation);
        }
    }

    private void ActivateInsane() {

    }
}
