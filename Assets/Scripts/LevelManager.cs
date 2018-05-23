using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    
    public void LoadLevel(string name) {
        print("Level load requested for " + name);
        Brick.breakableBrickCount = 0;
        SceneManager.LoadScene(name);
    }

    public void QuitRequest() {
        print("The game has requested to quit.");
        Application.Quit();
    }

    public void LoadNextLevel() {
        Brick.breakableBrickCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BrickDestroyed() {
        if (Brick.breakableBrickCount <= 0) {
            LoadNextLevel();
        }
    }
}
