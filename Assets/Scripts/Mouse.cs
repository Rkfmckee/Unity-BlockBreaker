using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour {
    private Paddle paddle;

	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();	
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 paddlePos = new Vector3(paddle.transform.position.x, paddle.transform.position.y, 0f);
        Vector3 myPos = this.transform.position;
        myPos.x = paddlePos.x;

        this.transform.position = myPos;
    }
}
