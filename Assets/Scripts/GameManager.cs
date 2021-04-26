using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int points = 0;
    public bool gameOver = false;
    public GameObject gameOverUI;
    public GameObject scoreUI;
    public GameObject audioManager;
    public GameObject[] obstacles; 
    public int hScore; 
    public Text highScore;

    private void Start() {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        points = 0;
        Time.timeScale = 1;
    }

    public void GameOver(){
        obstacles = GameObject.FindGameObjectsWithTag("Obstacles");
        foreach (GameObject obstacle in obstacles){
            Destroy(obstacle);
        }

        audioManager.SetActive(false);

        if(points > PlayerPrefs.GetInt("HighScore", 0)){
            PlayerPrefs.SetInt("HighScore", points);
        } 
        gameOver = true;
        scoreUI.SetActive(false);
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void Replay(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit(){
        Application.Quit();
    }
}
