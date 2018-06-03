using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public float time = 10.0f;
    public Text timerUI;

    private Canvas canvas;
    private string timerText = null;

    private void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        int totalTimers = GameObject.FindObjectsOfType<Timer>().Length;

    }

    private void Update()
    {
        /*if (Mathf.Round(time) > 0) {
            time -= Time.deltaTime;
            if (timerText == null){
                timerText = "Timer";
            }
            timerUI.text = timerText + ": " + Mathf.Round(time);
        } else {
            timerUI.enabled = false;
            Destroy(gameObject);
        }*/
    }
}
