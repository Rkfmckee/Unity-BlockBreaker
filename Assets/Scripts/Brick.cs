﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    public Sprite[] hitSprites;
    public GameObject[] powerups;
    public static int breakableBrickCount = 0;
    public enum Type { GREY, YELLOW, GREEN };
    public Type type;

    private LevelManager levelManager;
    private int timesHit;
    private bool isBreakable;

    // Use this for initialization
    void Start () {
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        isBreakable = this.tag.StartsWith("Breakable");

        if (isBreakable) {
            breakableBrickCount++;
        }
    }
	
	public int GetTimesHit() {
        return timesHit;
	}

    public void SetTimesHit(int num) {
        timesHit = num;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (isBreakable) {
            HandleHits(collision);
        }
    }

    void HandleHits(Collision2D collision) {
        int maxHits = hitSprites.Length + 1;
        if (collision.collider.tag == "Ball")
        {
            timesHit++;
        }

        if (timesHit >= maxHits)
        {
            breakableBrickCount--;
            levelManager.BrickDestroyed();
            dropPowerup();
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

    void dropPowerup() {
        int randomPowerup = Random.Range(0, powerups.Length);
        GameObject powerupChosen = powerups[randomPowerup];

        float randomChance = Random.Range(0.0f, 1.0f);
        if (randomChance <= powerupChosen.GetComponent<Powerup>().chanceOfSpawn) {
            Instantiate(powerupChosen, new Vector2(transform.position.x, transform.position.y), transform.rotation);
            print(powerupChosen.name + " spawned.");
        }
    }
}
