using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    public bool autoPlay = false;

    private Ball ball;

    void Start() {
        ball = GameObject.FindObjectOfType<Ball>();

        if (LevelManager.getCurrentScene().name == "HowToPlay") {
            autoPlay = true;
        }
    }

    // Update is called once per frame
    void Update () {
        if (!autoPlay) {
            MoveWithMouse();
        } else {
            AutoPlay();
        }
	}

    void MoveWithMouse() {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        float mousePosInBlocks = (Input.mousePosition.x / Screen.width) * 16;
        paddlePos.x = mousePosInBlocks;

        paddlePos.x = Mathf.Clamp(paddlePos.x, 0.5f, 15.5f);
        this.transform.position = paddlePos;
    }

    void AutoPlay() {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = ballPos.x;

        paddlePos.x = Mathf.Clamp(paddlePos.x, 0.5f, 15.5f);
        this.transform.position = paddlePos;
    }
}
