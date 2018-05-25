using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public Text startText;
    public Image[] ballLives;
    private Ball ball;

    void Start() {
        ball = GameObject.FindObjectOfType<Ball>();   
    }

    void Update() {
        for (int i = 0; i < ballLives.Length; i++) {
            if (i < ball.GetLives()) {
                ballLives[i].enabled = true;
            } else {
                ballLives[i].enabled = false;
            }
        }
    }

    public void StartGame() {
        Destroy(startText);
    }
}
