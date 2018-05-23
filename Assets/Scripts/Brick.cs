using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    public Sprite[] hitSprites;
    public static int breakableBrickCount = 0;

    private LevelManager levelManager;
    private int timesHit;
    private bool isBreakable;

    // Use this for initialization
    void Start () {
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        isBreakable = this.tag == "Breakable";

        if (isBreakable) {
            breakableBrickCount++;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (isBreakable) {
            HandleHits(collision);
        }
    }

    void HandleHits(Collision2D collision) {
        int maxHits = hitSprites.Length + 1;
        if (collision.collider.name == "Ball")
        {
            timesHit++;
        }

        if (timesHit >= maxHits)
        {
            breakableBrickCount--;
            levelManager.BrickDestroyed();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void SimulateWin() {
        levelManager.LoadNextLevel();
    }

    void LoadSprites() {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex]) {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }
}
